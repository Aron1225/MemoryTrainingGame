using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class Level1_3_old : MonoBehaviour
{
////	Level1_DB DB;
//	Level1_Controller_ooo Controller;
//
//	//關卡參數
//	int[][,,] LevelParameter;
//
//
//	//	private int Loop = 5;
//	//	private int LevelCount = 0, LoopFlag = 0;
//	//	//使每關可以完Loop次
//	//	int checkCount = 0;
//	//	//{{a,b},{c,d}}=>x到y重複Loop次
//	//	int[,] Level = { { 0, 4 }, { 5, 9 }, { 10, 14 }, { 15, 19 }, { 20, 24 } };
//	//	int Level_length;
//
//	void Awake ()
//	{
////		DB = GetComponent<Level1_DB> ();
//		Controller = GetComponent<Level1_Controller_ooo(oldd> ();
//	}
//
//	void Start ()
//	{
//		Parameter ();
//
//		//讀取地圖
//		MAP ();
//
//		ButtonEvent ();
//	}
//
//	void ButtonEvent ()
//	{
//		//將執行權給Controller
//		Controller.StartGameLoop += (GameObject go) => StartCoroutine (GameLoop ());
//	}
//
//	void Parameter ()
//	{
//		//{Loop,Random},{range1,range2}
//		LevelParameter = new int[][,,] {
//
//			new int[,,]{ { { 20, 2 }, { 0, 4 } } },//1
//			new int[,,]{ { { 20, 3 }, { 5, 9 } } }, //2
//			new int[,,]{ { { 25, 3 }, { 10, 14 } } },//3
//			new int[,,]{ { { 25, 4 }, { 15, 19 } } },//4
//			new int[,,]{ { { 30, 4 }, { 20, 24 } } },//5
//			new int[,,]{ { { 30, 5 }, { 25, 29 } } },//6
//			new int[,,]{ { { 35, 5 }, { 30, 34 } } }, //7
//			new int[,,]{ { { 35, 6 }, { 35, 39 } } },//8
//			new int[,,]{ { { 20, 6 }, { 40, 44 } }, { { 20, 7 }, { 40, 44 } } },//9
//			new int[,,]{ { { 20, 7 }, { 45, 49 } }, { { 20, 8 }, { 45, 49 } } },//10
//
//
////			new int[,,]{ { { 20, 2 }, { 0, 3 } } },//1
////			new int[,,]{ { { 20, 3 }, { 0, 3 } } },//2
////
////			new int[,,]{ { { 25, 3 }, { 4, 7 } } },//3
////			new int[,,]{ { { 25, 4 }, { 4, 7 } } },//4
////
////			new int[,,]{ { { 30, 4 }, { 8, 11 } } },//5
////			new int[,,]{ { { 30, 5 }, { 8, 11 } } },//6
////
////			new int[,,]{ { { 35, 5 }, { 12, 13 } } },//7
////			new int[,,]{ { { 35, 6 }, { 12, 13 } } },//8
////
////			new int[,,]{ { { 20, 6 }, { 14, 17 } }, { { 20, 7 }, { 14, 17 } } },//9
////			new int[,,]{ { { 20, 7 }, { 18, 21 } }, { { 20, 8 }, { 18, 21 } } },//10
//		};
//	}
//
//	private void MAP ()
//	{
////		DB.map = Resources.LoadAll<TextAsset> ("JT/maps");
//
//		//讀入txt
//		Controller.LoadMap (Resources.LoadAll<TextAsset> ("JT/maps") [2].text);
//	}
//
//	IEnumerator GameLoop ()
//	{
//		IEnumerator e = Loop1 (Controller.Select_Level_number);
//
//		yield return StartCoroutine (e);
//
//		//回傳遊戲是如何結束
//		//回傳0代表正常結束遊戲
//		//回傳1代表錯誤9次
//		//回傳2代表遊戲閒置
//
//		int code = (int)e.Current;
//
//		if (code == 0) {
//			Controller.Finish ();//結束遊戲
//			Debug.Log ("finish");
//		}
//		if (code == 1) {
//			Controller.GameOver ();//錯誤9次
//			Debug.Log ("GameOver");
//		}
//		if (code == 2) {
//			Controller.TimeOut ();//遊戲閒置
//			Debug.Log ("TimeOut");
//		}
//		yield break;
//	}
//
//	IEnumerator Loop1 (int Select_Level_number)
//	{
//		int number = Select_Level_number - 1;
//
//		IEnumerator e = null;
//
//		for (int i = 0; i < LevelParameter [number].GetLength (0); i++) {
//
//			var Loop = LevelParameter [number] [i, 0, 0];
//
////			DB.random = LevelParameter [number] [i, 0, 1];
//			Controller.random = LevelParameter [number] [i, 0, 1];
//
//			var mapRange1 = LevelParameter [number] [i, 1, 0];//0
//
//			var mapRange2 = LevelParameter [number] [i, 1, 1];//3
//
//			List<List<Vector3>> maps = Controller.Get_MapRange (mapRange1, mapRange2);//0~3,取得指定範圍地圖陣列
//
//			e = Loop2 (Loop, maps);
//
//			yield return StartCoroutine (e);
//
//			if ((int)e.Current != 0)
//				break;
//		}
//
//		yield return e.Current;//回傳至GameLoop
//	}
//
//	IEnumerator Loop2 (int Loop, List<List<Vector3>> maps)
//	{
//		int CheckCode = 0, Count = 0, index = 0;
//
//		while (Count++ != Loop) {
//
//			if (index == maps.Count)
//				index = 0;
//
//			yield return StartCoroutine (LevelManagement (maps [index++]));
//
//			//隨機亂數
//			yield return StartCoroutine (MakeRandom ());
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
//			if (Controller.Feedback ()) {
//				CheckCode = 1;
//				break;
//			}
//
//			if (Controller.IfTimeOut) {
//				CheckCode = 2;
//				break;
//			}
//			yield return null;
//		}
//		yield return CheckCode;//回傳至Loop1
//	}
//
//	///關卡設定
//	IEnumerator LevelManagement (List<Vector3> map)
//	{
////		Controller.DisplaySliderBar ();//更新難度條
////
////		var mapCount = map.Count;   
////
////		DB.g_iBalance = Level1_DB.UFOList.Count - mapCount;//多(少)幾台
////
////		//extra
////		if (DB.g_iBalance > 0) {
////			UFO.DestroyUFO (DB.g_iBalance);//Destroy幾台
////		}
////
////		//lack
////		if (DB.g_iBalance < 0) {
////			DB.g_iBalance *= -1;
////			UFO.InstantiateUFOs (DB.g_iBalance);//實例化UFO
////		} 
////
////		//重設場上所有UFO座標
////		for (int i = 0; i < mapCount; i++)
////			Level1_DB.UFOList [i].moveTo (0.8f, map [i], true, 0.1f);
////
////		yield break;
////
////		bool needAdd = true;
////
////		if (DB.arrangement_index == Level [LoopFlag, 1]) {
////			DB.arrangement_index = Level [LoopFlag, 0];
////			needAdd = false;
////		}
////
////		//下一關圖形
////		if (LevelCount++ == Loop) {
////			LevelCount = 1;
////			LoopFlag++;
////			DB.arrangement_index = Level [LoopFlag, 0];
////			needAdd = false;
////		}
////
////		Controller.DisplaySliderBar (() => {
////			float increase = (LoopFlag + 1) * 1f / Level_length;
////			return increase;
////		});
////
////		if (!DB.start)
////			DB.g_iBalance = -DB.arrangement [DB.arrangement_index].Count;
////		else {
////			DB.arrangement_index = (needAdd) ? DB.arrangement_index + 1 : DB.arrangement_index;
////			DB.g_iBalance = Level1_DB.UFOList.Count - DB.arrangement [DB.arrangement_index].Count;//缺(多)幾台UFO
////		}
////
////		//extra
////		if (DB.g_iBalance > 0) {
////			UFO.DestroyUFO (DB.g_iBalance);//Destroy幾台
////		}
////
////		//lack
////		if (DB.g_iBalance < 0) {
////			DB.g_iBalance *= -1;
////			UFO.InstantiateUFOs (DB.g_iBalance);//實例化UFO
////		} 
////
////		//重設場上所有UFO座標
////		for (int i = 0; i < DB.arrangement [DB.arrangement_index].Count; i++)
////			Level1_DB.UFOList [i].moveTo (0.7f, DB.arrangement [DB.arrangement_index] [i], true, 0.1f);
////
////		yield break;
//		yield return Controller._LevelManagement (map, false);
//	}
//
//	//隨機亂數
//	IEnumerator MakeRandom ()
//	{
////		//清空
////		Level1_DB.UFO_Random.Clear ();
////
////		List<UFO> TempList = Level1_DB.UFOList.ToList ();
////
////		for (int i = 0; i < key; i++) {
////			int num = UnityEngine.Random.Range (0, TempList.Count);
////			Level1_DB.UFO_Random.Add (TempList [num]);
////			TempList [num] = TempList [TempList.Count - 1];
////			TempList.RemoveAt (TempList.Count - 1);
////		}
////		yield break;
//		yield return Controller._MakeRandom ();
//	}
//
//	IEnumerator ShowLight ()
//	{
////		//當陣列全部等於false時執行
////		yield return DB.WaitUntilUFOReady;
////
////		yield return DB.WaitOneSecond;
////
////		var last = Level1_DB.UFO_Random.Last ();
////
////		foreach (var ufo in Level1_DB.UFO_Random) {
////
////			ufo.Red ();
////
////			yield return new WaitForSeconds (DB.lighttime);
////
////			ufo.Original (false);
////
////			//當走訪至最後時跳出迴圈
////			if (ufo == last)
////				break;
////
////			yield return new WaitForSeconds (DB.darktime);
////		}
//		yield return Controller._ShowLight ();
//	}
//
//	IEnumerator AnswerCompare ()
//	{
////		//清空
////		Level1_DB.UFO.Clear ();
////
////		//開啟點擊
////		UFO.AllColliderEnabled (true);
////
////		int RandomCount = Level1_DB.UFO_Random.Count;
////
////		Controller.CountDownStart ();//30秒到數
////
////		while (DB.Compare) {
////			//UFO數量到達時判斷
////			if (RandomCount == Level1_DB.UFO.Count) {
////
////				//關閉點擊
////				UFO.AllColliderEnabled (false);
////
////				DB.LevelUP = Controller.Compare (Level1_DB.UFO, Level1_DB.UFO_Random);
////
////				Controller.showResults (DB.LevelUP);
////
////				Controller.Record (DB.LevelUP);
////
////				Controller.ResetTimeOutCount ();//只要有作答TimeOutCount就歸零
////
////				break;//跳出while迴圈
////			}
////			yield return null;//等待下一幀
////		}
////		yield return DB.WaitOneSecond;
//		yield return Controller._AnswerCompare ();
//	}
//
//	//重置
//	IEnumerator Reset ()
//	{
////		Level1_DB.UFOList.ForEach (go => go.Original (false));
////		DB.Compare = true;
////		DB.start = true;
////		yield break;
//		yield return Controller._Reset ();
//	}
}
