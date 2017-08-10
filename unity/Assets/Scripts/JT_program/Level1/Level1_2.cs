using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class Level1_2 : MonoBehaviour
{
	Level1_UI UI;
	Level1_DB DB;
	Level1_Controller Controller;

	int[][,,] LevelParameter;


	//	//同一關玩幾次
	//	private int Loop = 5;
	//	private int LevelCount = 0, LoopFlag = 0;

	//	//使每關可以完Loop次
	//	int checkCount = 0;
	//	//	//{{a,b},{c,d}}=>x到y重複Loop次
	//	int Level_length;
	//	int LevelInterval;


	//	private int[,] Level = {
	//		{ 0, 3 },
	//		{ 4, 7 },
	//		{ 8, 11 },
	//		{ 12, 15 },
	//		{ 16, 19 }
	//	};

	void Awake ()
	{
		UI = GetComponent<Level1_UI> ();
		DB = GetComponent<Level1_DB> ();
		Controller = GetComponent<Level1_Controller> ();
//		UIEventListener.Get (UI.Button_CONFIRM.gameObject).onClick = GameStart;
//		Level_length = Level.GetLength (0);
//		LevelInterval = 4;
	}

	void Start ()
	{

		Parameter ();

		//讀取地圖
		MAP ();
	
		//因應不同關卡,判斷方式也不同
//		Override_AddListener ();

		ButtonEvent ();
	}

	void ButtonEvent ()
	{
		Controller.StartGameLoop += (GameObject go) => StartCoroutine (GameLoop ());
	}


	void Parameter ()
	{
		//{Loop,Random},{range1,range2}
		LevelParameter = new int[][,,] {
			//test
//			new int[,,]{ { { 20, 2 }, { 0, 3 } } },//1
//			new int[,,]{ { { 20, 3 }, { 4, 7 } } }, //2
//			new int[,,]{ { { 25, 3 }, { 8, 11 } } },//3
//			new int[,,]{ { { 25, 4 }, { 12, 15 } } },//4
//			new int[,,]{ { { 30, 4 }, { 16, 19 } } },//5

			new int[,,]{ { { 4, 2 }, { 0, 3 } } },//1


			new int[,,]{ { { 4, 3 }, { 0, 3 } } },//2

			new int[,,]{ { { 4, 3 }, { 4, 7 } } },//3
			new int[,,]{ { { 4, 4 }, { 4, 7 } } },//4

			new int[,,]{ { { 4, 4 }, { 8, 11 } } },//5
			new int[,,]{ { { 4, 5 }, { 8, 11 } } },//6

			new int[,,]{ { { 4, 5 }, { 12, 13 } } },//7
			new int[,,]{ { { 4, 6 }, { 12, 13 } } },//8

			new int[,,]{ { { 4, 6 }, { 14, 17 } }, { { 4, 7 }, { 14, 17 } } },//9
			new int[,,]{ { { 4, 7 }, { 18, 21 } }, { { 4, 8 }, { 18, 21 } } },//10

//			new int[,,]{ { { 20, 6 }, { 0, 0 } }, { { 20, 7 }, { 0, 0 } } },//9
//			new int[,,]{ { { 20, 7 }, { 0, 0 } }, { { 20, 8 }, { 0, 0 } } },//10
		};
	}

	//	void GameStart (GameObject go)
	//	{
	//		//遊戲開始
	//		StartCoroutine (GameLoop ());
	//
	//		Controller.start ();
	//	}

	private void MAP ()
	{
		//讀入txt
		DB.map = Resources.LoadAll<TextAsset> ("JT/maps");

		Controller.LoadMap (DB.map [1].text);
	}


	//	//將Controller的Onclick覆蓋過去
	//	private void Override_AddListener ()
	//	{
	//		UIEventListener.Get (UI.Button_UP.gameObject).onClick = Override_select_Level;
	//		UIEventListener.Get (UI.Button_DOWN.gameObject).onClick = Override_select_Level;
	//	}

	//	int twice = 0;
	//
	//	private void Override_select_Level (GameObject btn)
	//	{
	//		if (btn == UI.Button_UP.gameObject) {
	//			if (DB.Select_Level_number < DB.TOTAL_LEVEL)
	//				UI.Label_Level.text = (++DB.Select_Level_number).ToString ();
	//			if (DB.arrangement_index < Level [Level_length - 1, 0]) {
	//				if (++twice % 2 == 0) {
	//					twice = 0;
	//					DB.arrangement_index += LevelInterval;
	//					LoopFlag += 1;
	//				}
	//			}
	//
	////			if (DB.arrangement_index < Level [Level_length - 1, 0] && LoopFlag++ % 2 == 0) {
	////				
	////				DB.arrangement_index += LevelInterval;
	//////				LoopFlag += 1;
	////			}
	//
	////			if (DB.arrangement_index < DB.arrangement.Count - 1)
	////				DB.arrangement_index++;
	//		}
	//
	//		if (btn == UI.Button_DOWN.gameObject) {
	//			if (DB.Select_Level_number > 1)
	//				UI.Label_Level.text = (--DB.Select_Level_number).ToString ();
	//			if (DB.arrangement_index > 0) {
	//				if (--twice % 2 == 0) {
	//					twice = 0;
	//					DB.arrangement_index -= LevelInterval;
	//					LoopFlag -= 1;
	//				}
	//			}
	////			if (DB.arrangement_index > 0)
	////				DB.arrangement_index--;
	//		}
	//
	////		int getText = int.Parse (UI.Label_Level.text);
	////
	////		if (btn == UI.Button_UP.gameObject && DB.arrangement_index < Level [Level_length - 1, 0]) {
	////			DB.arrangement_index += Level_length;
	////			LoopFlag += 1;
	////			UI.Label_Level.text = (getText + 1).ToString ();
	////		}
	////		if (btn == UI.Button_DOWN.gameObject && DB.arrangement_index > 0) {
	////			DB.arrangement_index -= Level_length;
	////			LoopFlag -= 1;
	////			UI.Label_Level.text = (getText - 1).ToString ();
	////		}
	//	}

	//	private bool IfTheEnd ()
	//	{
	//		bool check = true;//確保最後一關也能執行Loop次
	//		
	//		if (++checkCount != Loop)
	//			return false;
	//		else {
	//			checkCount = 0;
	//			check = false;
	//		}
	//
	//		if (LevelCount + 1 != Loop && check)
	//			return false;
	//
	//		if (LoopFlag + 1 < Level_length)
	//			return false;
	//
	//		return true;
	//	}

	IEnumerator GameLoop ()
	{
		IEnumerator e = Loop1 (DB.Select_Level_number);

		yield return StartCoroutine (e);

		//回傳遊戲是如何結束
		//回傳0代表正常結束遊戲
		//回傳1代表錯誤9次
		//回傳2代表遊戲閒置

		int code = (int)e.Current;

		if (code == 0) {
			Controller.Finish ();//結束遊戲
			Debug.Log ("finish");
		}
		if (code == 1) {
			Controller.GameOver ();//錯誤9次
			Debug.Log ("GameOver");
		}
		if (code == 2) {
			Controller.TimeOut ();//遊戲閒置
			Debug.Log ("TimeOut");
		}
		yield break;
	}

	IEnumerator Loop1 (int Select_Level_number)
	{
		int number = Select_Level_number - 1;

		for (int i = 0; i < LevelParameter [number].GetLength (0); i++) {

			var Loop = LevelParameter [number] [i, 0, 0];

			DB.random = LevelParameter [number] [i, 0, 1];

			var mapRange1 = LevelParameter [number] [i, 1, 0];//0

			var mapRange2 = LevelParameter [number] [i, 1, 1];//3

			List<List<Vector3>> maps = Controller.GetMapRange (mapRange1, mapRange2);//0~3,取得指定範圍地圖陣列

			IEnumerator e = Loop2 (Loop, maps);

			yield return StartCoroutine (e);

			yield return e.Current;//回傳至GameLoop

		}
		yield break;
	}

	IEnumerator Loop2 (int Loop, List<List<Vector3>> maps)
	{
		int CheckCode = 0, Count = 0, index = 0;

		while (Count++ != Loop) {

			if (index == maps.Count)
				index = 0;

			yield return StartCoroutine (LevelManagement (maps [index++]));

			//隨機亂數
			yield return StartCoroutine (MakeRandom (DB.random));

			//亮燈
			yield return StartCoroutine (ShowLight ());

			//答案比對
			yield return StartCoroutine (AnswerCompare ());

			//重置
			yield return StartCoroutine (Reset ());

//			if (Controller.Feedback (DB.LevelUP)) {
//				CheckCode = 1;
//				break;
//			}

			if (Controller.IfTimeOut ()) {
				CheckCode = 2;
				break;
			}
			yield return null;
		}
		yield return CheckCode;//回傳至Loop1
	}

	///關卡設定
	IEnumerator LevelManagement (List<Vector3> map)
	{
//		bool needAdd = true;
//		
//		if (DB.arrangement_index == Level [LoopFlag, 1]) {
//			DB.arrangement_index = Level [LoopFlag, 0];
//			needAdd = false;
//		}
//
//		//下一關圖形
//		if (LevelCount++ == Loop) {
//			if (++twice % 2 == 0) {
//				twice = 0;
//				LoopFlag++;
//				DB.arrangement_index = Level [LoopFlag, 0];
//				needAdd = false;
//			}
//			LevelCount = 1;
//		}
//
//		Controller.DisplaySliderBar (() => {
//			float increase = (LoopFlag + 1) * 1f / Level_length;
//			return increase;
//		});
//		
//		if (!DB.start)
//			DB.g_iBalance = -DB.arrangement [DB.arrangement_index].Count;
//		else {
//			DB.arrangement_index = (needAdd) ? DB.arrangement_index + 1 : DB.arrangement_index;
//			DB.g_iBalance = Level1_DB.UFOList.Count - DB.arrangement [DB.arrangement_index].Count;//缺(多)幾台UFO
//		}
//
//		//extra
//		if (DB.g_iBalance > 0) {
//			UFO.DestroyUFO (DB.g_iBalance);//Destroy幾台
//		}
//
//		//lack
//		if (DB.g_iBalance < 0) {
//			DB.g_iBalance *= -1;
//			UFO.InstantiateUFOs (DB.g_iBalance);//實例化UFO
//		} 
//
//		//重設場上所有UFO座標
//		for (int i = 0; i < DB.arrangement [DB.arrangement_index].Count; i++)
//			Level1_DB.UFOList [i].moveTo (0.7f, DB.arrangement [DB.arrangement_index] [i], true, 0.1f);
//
//		yield break;

		Controller.DisplaySliderBar ();//更新難度條

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
//		if (DB.g_iBalance != 0)
		for (int i = 0; i < mapCount; i++)
			Level1_DB.UFOList [i].moveTo (0.8f, map [i], true, 0.1f);
		
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

		Controller.CountDownStart ();//30秒到數

		while (DB.Compare) {
			//UFO數量到達時判斷
			if (RandomCount == Level1_DB.UFO.Count) {

				//關閉點擊
				UFO.AllColliderEnabled (false);

				DB.LevelUP = Controller.Compare (Level1_DB.UFO, Level1_DB.UFO_Random);

				Controller.showResults (DB.LevelUP);

				Controller.Record (DB.LevelUP);

				Controller.ResetTimeOutCount ();//只要有作答TimeOutCount就歸零

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
		DB.Compare = true;
		DB.start = true;
		yield break;
	}
}
