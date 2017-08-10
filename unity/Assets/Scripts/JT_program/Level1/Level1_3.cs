using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class Level1_3 : MonoBehaviour
{
	Level1_UI UI;
	Level1_DB DB;
	Level1_Controller Controller;

	private int Loop = 5;
	private int LevelCount = 0, LoopFlag = 0;
	//使每關可以完Loop次
	int checkCount = 0;
	//{{a,b},{c,d}}=>x到y重複Loop次
	int[,] Level = { { 0, 4 }, { 5, 9 }, { 10, 14 }, { 15, 19 }, { 20, 24 } };
	int Level_length;

	void Awake ()
	{
		UI = GetComponent<Level1_UI> ();
		DB = GetComponent<Level1_DB> ();
		Controller = GetComponent<Level1_Controller> ();
		UIEventListener.Get (UI.Button_CONFIRM.gameObject).onClick = GameStart;
		Level_length = Level.GetLength (0);
	}

	void Start ()
	{
		//讀取地圖
		MAP ();

		//因應不同關卡,判斷方式也不同
		Override_AddListener ();
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

		Controller.LoadMap (DB.map [2].text);
	}

	//將Controller的Onclick覆蓋過去
	private void Override_AddListener ()
	{
		UIEventListener.Get (UI.Button_UP.gameObject).onClick = Override_select_Level;
		UIEventListener.Get (UI.Button_DOWN.gameObject).onClick = Override_select_Level;
	}

	private void Override_select_Level (GameObject btn)
	{
		int getText = int.Parse (UI.Label_Level.text);

		if (btn == UI.Button_UP.gameObject && DB.arrangement_index < Level [Level_length - 1, 0]) {
			DB.arrangement_index += Level_length;
			LoopFlag += 1;
			UI.Label_Level.text = (getText + 1).ToString ();
		}
		if (btn == UI.Button_DOWN.gameObject && DB.arrangement_index > 0) {
			DB.arrangement_index -= Level_length;
			LoopFlag -= 1;
			UI.Label_Level.text = (getText - 1).ToString ();
		}
	}

	private bool IfTheEnd ()
	{
		bool check = true;//確保最後一關也能執行Loop次

		if (++checkCount != Loop)
			return false;
		else {
			checkCount = 0;
			check = false;
		}

		if (LevelCount + 1 != Loop && check)
			return false;

		if (LoopFlag + 1 < Level_length)
			return false;

		return true;
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

			if (Controller.IfTheEnd (IfTheEnd) || Controller.Feedback (DB.LevelUP))
				yield break;

			//等待下一幀
			yield return null;
		}
	}

	///關卡設定
	IEnumerator LevelManagement ()
	{
		bool needAdd = true;

		if (DB.arrangement_index == Level [LoopFlag, 1]) {
			DB.arrangement_index = Level [LoopFlag, 0];
			needAdd = false;
		}

		//下一關圖形
		if (LevelCount++ == Loop) {
			LevelCount = 1;
			LoopFlag++;
			DB.arrangement_index = Level [LoopFlag, 0];
			needAdd = false;
		}

		Controller.DisplaySliderBar (() => {
			float increase = (LoopFlag + 1) * 1f / Level_length;
			return increase;
		});

		if (!DB.start)
			DB.g_iBalance = -DB.arrangement [DB.arrangement_index].Count;
		else {
			DB.arrangement_index = (needAdd) ? DB.arrangement_index + 1 : DB.arrangement_index;
			DB.g_iBalance = Level1_DB.UFOList.Count - DB.arrangement [DB.arrangement_index].Count;//缺(多)幾台UFO
		}

		//extra
		if (DB.g_iBalance > 0) {
			UFO.DestroyUFO (DB.g_iBalance);//Destroy幾台
		}

		//lack
		if (DB.g_iBalance < 0) {
			DB.g_iBalance *= -1;
			UFO.InstantiateUFOs (DB.g_iBalance);//實例化UFO
		} 

		//重設場上所有UFO座標
		for (int i = 0; i < DB.arrangement [DB.arrangement_index].Count; i++)
			Level1_DB.UFOList [i].moveTo (0.7f, DB.arrangement [DB.arrangement_index] [i], true, 0.1f);

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
