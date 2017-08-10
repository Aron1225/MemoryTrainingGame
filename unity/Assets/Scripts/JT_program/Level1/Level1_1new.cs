using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;


public class Level1_1new : MonoBehaviour
{
	Level1_UI UI;
	Level1_DB DB;
	Level1_Controller Controller;

	//同一關玩幾次
	private int Loop = 5;
	private int LevelCount = 0;


	//	class LevelParameter
	//	{
	//		public int Loop{ get; set; }
	//
	//		public int arrangement_index{ get; set; }
	//
	//		public int random{ get; set; }
	//	}

	//{ Loop, arrangement_index, random }
	int[,] LevelParameter;



	void Awake ()
	{
		UI = GetComponent<Level1_UI> ();
		DB = GetComponent<Level1_DB> ();
		Controller = GetComponent<Level1_Controller> ();
		UIEventListener.Get (UI.Button_CONFIRM.gameObject).onClick = GameStart;
	}

	void Start ()
	{
		Parameter ();
		//讀取地圖
		MAP ();

//		RandomRunle ();//亂數增加規則
	}

	//	void FixedUpdate ()
	//	{
	//
	//	}
	//
	//	void OnDestroy ()
	//	{
	//
	//	}

	void GameStart (GameObject go)
	{
		//遊戲開始
		StartCoroutine (GameLoop ());

//		Controller.start ();
	}

	void Parameter ()
	{
//		LevelFlag = 0;

		//{ Loop, arrangement_index, random }
		LevelParameter = new int[,] {
			{ 20, 0, 2 },//1
			{ 20, 0, 3 },//2
			{ 25, 1, 3 },//3
			{ 25, 1, 4 },//4
			{ 30, 2, 4 },//5
			{ 30, 2, 5 },//6
			{ 35, 3, 5 },//7 
			{ 35, 3, 6 },//8
			{ 20, 4, 6 },//9
			{ 20, 4, 7 },//9
			{ 20, 5, 7 },//10
			{ 20, 5, 8 },//10
		};
	}

	private void MAP ()
	{
		//讀入txt
		DB.map = Resources.LoadAll<TextAsset> ("JT/maps");

		Controller.LoadMap (DB.map [0].text);
	}

	IEnumerator GameLoop ()
	{
		for (int i = 0; i < LevelParameter.Length; i++) {

			var Loop = LevelParameter [i, 0];
			var map = DB.arrangement [LevelParameter [i, 1]];
			var random = LevelParameter [i, 2];
			DB.random = random;

			for (int j = 0; j < Loop; j++) {

				yield return StartCoroutine (LevelManagement (map));

				//隨機亂數
				yield return StartCoroutine (MakeRandom (random));
				
				//亮燈
				yield return StartCoroutine (ShowLight ());
				
				//答案比對
				yield return StartCoroutine (AnswerCompare ());
				
				//重置
				yield return StartCoroutine (Reset ());
			}
		}



//		while (true) {
//
//			//關卡設定
//		yield return StartCoroutine (LevelManagement ());
//
//			//隨機亂數
//			yield return StartCoroutine (MakeRandom (DB.random));
//
//			//亮燈
//			yield return StartCoroutine (ShowLight ());
//
//			//答案比對
//			yield return StartCoroutine (AnswerCompare ());
//
//			//重置
//			yield return StartCoroutine (Reset ());
//
//			if (Controller.IfTheEnd (LevelCount, Loop) || Controller.Feedback (DB.LevelUP))
//				yield break;
//
//			//等待下一幀
//		yield return null;
//		}
	}


	//	int LevelFlag;


	///關卡設定
	IEnumerator LevelManagement (List<Vector3> map)
	{
		var mapCount = map.Count;
		DB.g_iBalance = Level1_DB.UFOList.Count - mapCount;

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
		if (DB.g_iBalance != 0)
			for (int i = 0; i < mapCount; i++)
				Level1_DB.UFOList [i].moveTo (1f, map [i], true, 0.1f);


		//		//下一關圖形
		//		if (LevelCount++ == Loop) {
		//			Controller.LevelUp ();//亮燈時間減少、亂數增加
		//			DB.arrangement_index++;
		//			LevelCount = 1;
		//		}
		//
		//		Controller.DisplaySliderBar ();//更新難度條
		//
		//		//第一次選完難度後執行UFO數量、位置設定
		//		if (DB.start && DB.Select_Level_number > DB.arrangement.Count - 1)
		//			yield break;
		//
		//		if (!DB.start)
		//			DB.g_iBalance = -DB.arrangement [DB.arrangement_index].Count;
		//		else
		//			DB.g_iBalance = Level1_DB.UFOList.Count - DB.arrangement [DB.arrangement_index].Count;//缺(多)幾台UFO
		//

		//
		//		

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

