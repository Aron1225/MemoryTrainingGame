using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;


public class Level1_1_old : MonoBehaviour
{
//	//	Level1_DB DB;
//	Level1_Controller_ooo Controller;
//
//	int[][,] LevelParameter;
//
//	//	//同一關玩幾次
//	//	private int Loop = 5;
//	//	private int LevelCount = 0;
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
//		LevelParameter = new int[][,] {
////			{ Loop, arrangement_index, random }
////			new int[,] { { 1, 0, 2 } },//1
////			new int[,] { { 3, 0, 3 } },//2
////			new int[,] { { 3, 1, 3 } },//3
////			new int[,] { { 3, 1, 4 } },//4
////			new int[,] { { 3, 2, 4 } },//5
////			new int[,] { { 3, 2, 5 } },//6
////			new int[,] { { 3, 3, 5 } },//7
////			new int[,] { { 3, 3, 6 } },//8
////			new int[,] { { 1, 4, 6 }, { 1, 4, 7 } },//9
////			new int[,] { { 1, 5, 7 }, { 1, 5, 8 } },//10
//
//			new int[,] { { 20, 0, 2 } },//1
//			new int[,] { { 20, 0, 3 } },//2
//			new int[,] { { 25, 1, 3 } },//3
//			new int[,] { { 25, 1, 4 } },//4
//			new int[,] { { 30, 2, 4 } },//5
//			new int[,] { { 30, 2, 5 } },//6
//			new int[,] { { 35, 3, 5 } },//7
//			new int[,] { { 35, 3, 6 } },//8
//			new int[,] { { 20, 4, 6 }, { 20, 4, 7 } },//9
//			new int[,] { { 20, 5, 7 }, { 20, 5, 8 } },//10
//		};
//	}
//
//	private void MAP ()
//	{
////		DB.map =  Resources.LoadAll<TextAsset> ("JT/maps");
//		//讀入txt
//		Controller.LoadMap (Resources.LoadAll<TextAsset> ("JT/maps") [0].text);
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
//
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
//			var Loop = LevelParameter [number] [i, 0];
//
////			var map = DB.arrangement [LevelParameter [number] [i, 1]];
////			DB.random = LevelParameter [number] [i, 2];
//
//			var map = Controller.Get_arrangement (LevelParameter [number] [i, 1]);
//
//			Controller.random = LevelParameter [number] [i, 2];
//
//			e = Loop2 (Loop, map);
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
//	IEnumerator Loop2 (int Loop, List<Vector3> map)
//	{
//		int CheckCode = 0;
//
//		for (int i = 0; i < Loop; i++) {
//			
//			yield return StartCoroutine (LevelManagement (map));
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
//		}
//		yield return CheckCode;//回傳至Loop1
//	}
//
//	///關卡設定
//	IEnumerator LevelManagement (List<Vector3> map)
//	{
////		Controller.DisplaySliderBar ();//更新難度條
////
////		Controller.Balance (map, true);
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
////		if (DB.g_iBalance != 0)
////			for (int i = 0; i < mapCount; i++)
////				Level1_DB.UFOList [i].moveTo (1f, map [i], true, 0.1f);
////		//下一關圖形
////		if (LevelCount++ == Loop) {
////			Controller.LevelUp ();//亮燈時間減少、亂數增加
////			DB.arrangement_index++;
////			LevelCount = 1;
////		}
////
////
////		//第一次選完難度後執行UFO數量、位置設定
////		if (DB.start && DB.Select_Level_number > DB.arrangement.Count - 1)
////			yield break;
////
////		if (!DB.start)
////			DB.g_iBalance = -DB.arrangement [DB.arrangement_index].Count;
////		else
////			DB.g_iBalance = Level1_DB.UFOList.Count - DB.arrangement [DB.arrangement_index].Count;//缺(多)幾台UFO
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
////		if (DB.g_iBalance != 0)
////			for (int i = 0; i < DB.arrangement [DB.arrangement_index].Count; i++)
////				Level1_DB.UFOList [i].moveTo (1f, DB.arrangement [DB.arrangement_index] [i], true, 0.1f);
//		yield return Controller._LevelManagement (map, true);
//	}
//		
//	//隨機亂數
//	IEnumerator MakeRandom ()
//	{
//		yield return Controller._MakeRandom ();
//	}
//
//	//亮燈
//	IEnumerator ShowLight ()
//	{
//		yield return Controller._ShowLight ();
//	}
//
//	//答案比對
//	IEnumerator AnswerCompare ()
//	{
//		yield return Controller._AnswerCompare ();
//	}
//
//	//重置
//	IEnumerator Reset ()
//	{
//		yield return Controller._Reset ();
//	}
}
