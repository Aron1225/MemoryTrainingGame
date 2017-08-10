using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using UnityEngine.SceneManagement;

public class Level1_4 : MonoBehaviour
{
	Level1_UI UI;
	Level1_DB DB;
	Level1_Controller Controller;

	public CameraControl2 Camera;

	private int Loop = 5;
	private int LevelCount = 0;

	void Awake ()
	{
		UI = GetComponent<Level1_UI> ();
		DB = GetComponent<Level1_DB> ();
		Controller = GetComponent<Level1_Controller> ();
		UIEventListener.Get (UI.Button_CONFIRM.gameObject).onClick = GameStart;
	}

	void Start ()
	{
		//讀取地圖
		MAP ();
	}

	void GameStart (GameObject go)
	{
		//遊戲開始
		StartCoroutine (GameLoop ());
	}

	void FixedUpdate ()
	{

	}

	void OnDestroy ()
	{

	}

	private void MAP ()
	{
		//讀入txt
		DB.map = Resources.LoadAll<TextAsset> ("JT/maps");

		Controller.LoadMap (DB.map [3].text);
	}

	IEnumerator GameLoop ()
	{
//		Controller.Select_Slider_forward ();//歸位UI

		while (true) {

			//關卡設定
			yield return StartCoroutine (LevelManagement ());

			//隨機亂數
			yield return StartCoroutine (MakeRandom (DB.random));

			//亮燈
			yield return StartCoroutine (ShowLight ());

			//答案比對
			yield return StartCoroutine (AnswerCompare ());

			//重置
			yield return StartCoroutine (Reset ());

			if (Controller.IfTheEnd (LevelCount, Loop) || Controller.Feedback (DB.LevelUP))
				yield break;

			//等待下一幀
			yield return null;
		}
	}

	///關卡設定
	IEnumerator LevelManagement ()
	{
		if (!DB.start)
			for (int i = 0; i <= DB.arrangement_index; i++) {
				var Group = UFO.InstantiateUFOs (DB.arrangement [i].Count);//實例化UFO
				for (int j = 0; j < Group.Count; j++) {
					Group [j].moveTo (0.7f, DB.arrangement [i] [j], true, 0.1f);
				}
			}

		//下一關圖形
		if (LevelCount++ == Loop) {
			Camera.Back ();
			LevelCount = 1;
			DB.arrangement_index++;
			DB.g_iBalance = DB.arrangement [DB.arrangement_index].Count;//缺(多)幾台UFO
			var Group = UFO.InstantiateUFOs (DB.g_iBalance);//實例化UFO
			for (int j = 0; j < Group.Count; j++) {
				Group [j].moveTo (0.7f, DB.arrangement [DB.arrangement_index] [j], true, 0.1f);
			}
		}

		Controller.DisplaySliderBar ();


		yield break;
	}

	//隨機亂數
	IEnumerator MakeRandom (int key)//key->需要幾個亂數
	{
		//清空
		Level1_DB.UFO_Random.Clear ();

		List<UFO> TempList = Level1_DB.UFOList.ToList ();

		for (int i = 0; i < key; i++) {
			int num = UnityEngine.Random.Range (0, TempList.Count);
			Level1_DB.UFO_Random.Add (TempList [num]);
			TempList [num] = TempList [TempList.Count - 1];
			TempList.RemoveAt (TempList.Count - 1);
		}
		yield break;
	}

	IEnumerator ShowLight ()
	{
		//當陣列全部等於false時執行
		yield return DB.WaitUntilUFOReady;

		yield return DB.WaitOneSecond;

		var last = Level1_DB.UFO_Random.Last ();

		foreach (var ufo in Level1_DB.UFO_Random) {

			ufo.Red ();

			yield return new WaitForSeconds (DB.lighttime);

			ufo.Original (false);

			//當走訪至最後時跳出迴圈
			if (ufo == last)
				break;

			yield return new WaitForSeconds (DB.darktime);
		}
	}

	IEnumerator AnswerCompare ()
	{
		//清空
		Level1_DB.UFO.Clear ();

		//開啟點擊
		UFO.AllColliderEnabled (true);

		int RandomCount = Level1_DB.UFO_Random.Count;

		while (true) {
			//UFO數量到達時判斷
			if (RandomCount == Level1_DB.UFO.Count) {

				//關閉點擊
				UFO.AllColliderEnabled (false);

				DB.LevelUP = Controller.Compare (Level1_DB.UFO, Level1_DB.UFO_Random);

				Controller.showResults (DB.LevelUP);

				Controller.Record (DB.LevelUP);

				break;//跳出while迴圈
			}
			yield return null;//等待下一幀
		}
		yield return DB.WaitOneSecond;
	}

	//重置
	IEnumerator Reset ()
	{
		Level1_DB.UFOList.ForEach (go => go.Original (false));
		DB.start = true;
		yield break;
	}
}
