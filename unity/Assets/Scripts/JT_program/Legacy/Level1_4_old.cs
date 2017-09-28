using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using UnityEngine.SceneManagement;

public class Level1_4_old : MonoBehaviour
{
//	//	Level1_DB DB;
//	Level1_Controller_ooo Controller;
//	public CameraControl2 Camera;
//
//	//關卡參數
//	int[][,] LevelParameter;
//
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
//		//{ Loop, arrangement_index, random,CameraStep}
//		LevelParameter = new int[][,] {
////			new int[,] { { 2, 0, 2, 0 } },//1
////			new int[,] { { 2, 0, 3, 0 } },//2
////			new int[,] { { 2, 1, 3, 1 } },//3
////			new int[,] { { 2, 1, 4, 1 } },//4
////			new int[,] { { 2, 2, 4, 2 } },//5
////			new int[,] { { 2, 2, 5, 2 } },//6
////			new int[,] { { 2, 3, 5, 3 } },//7
////			new int[,] { { 2, 3, 6, 3 } },//8
////			new int[,] { { 1, 4, 6, 4 }, { 1, 4, 7, 4 } },//9
////			new int[,] { { 1, 4, 7, 4 }, { 1, 4, 8, 4 } },//10
//
//			new int[,] { { 20, 0, 2, 0 } },//1
//			new int[,] { { 20, 0, 3, 0 } },//2
//			new int[,] { { 25, 1, 3, 1 } },//3
//			new int[,] { { 25, 1, 4, 1 } },//4
//			new int[,] { { 30, 2, 4, 2 } },//5
//			new int[,] { { 30, 2, 5, 2 } },//6
//			new int[,] { { 35, 3, 5, 3 } },//7
//			new int[,] { { 35, 3, 6, 3 } },//8
//			new int[,] { { 20, 4, 6, 4 }, { 20, 4, 7, 4 } },//9
//			new int[,] { { 20, 4, 7, 4 }, { 20, 5, 8, 4 } },//10
//		};
//	}
//
//	private void MAP ()
//	{
////		DB.map = Resources.LoadAll<TextAsset> ("JT/maps");
//		//讀入txt
//		Controller.LoadMap (Resources.LoadAll<TextAsset> ("JT/maps") [3].text);
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
//		int code = (int)e.Current;//UnBox
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
//			var Loop = LevelParameter [number] [i, 0];
//
//			var mapIndex = LevelParameter [number] [i, 1];
//
//			//DB.random = LevelParameter [number] [i, 2];
//			Controller.random = LevelParameter [number] [i, 2];
//
//			var CameraStep = LevelParameter [number] [i, 3];
//
//			e = Loop2 (Loop, CameraStep, mapIndex);
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
//	IEnumerator Loop2 (int Loop, int CameraStep, int mapIndex)
//	{
//		Camera.Step (CameraStep);
//
//		int CheckCode = 0;
//
//		if (!Controller.start)
//			for (int j = 0; j <= mapIndex; j++)
//				yield return StartCoroutine (LevelManagement (Controller.Get_arrangement (j)));
////				yield return StartCoroutine (LevelManagement (DB.arrangement [j]));
//
//		for (int i = 0; i < Loop; i++) {
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
//		Controller.DisplaySliderBar ();//更新難度條
//
//		var Balance = map.Count; //多(少)幾台
//
//		List<UFO> Group = UFO.InstantiateUFOs (Balance);//實例化UFO
//
//		//重設場上所有UFO座標
//		for (int i = 0; i < Group.Count; i++)
//			Group [i].moveTo (0.7f, map [i], true, 0.1f);
//
//		yield break;
//		//		for (int i = 0; i <= mapIndex; i++) {
//		//			var Group = UFO.InstantiateUFOs (DB.arrangement [i].Count);//實例化UFO
//		//			for (int j = 0; j < Group.Count; j++) {
//		//				Group [j].moveTo (0.7f, DB.arrangement [i] [j], true, 0.1f);
//		//			}
//		//		}
//		//		var mapCount = map.Count;
//		//		DB.g_iBalance = Level1_DB.UFOList.Count - mapCount;
//		//重設場上所有UFO座標
//		//		if (DB.g_iBalance != 0)
//		//			for (int i = 0; i < mapCount; i++)
//		//				Level1_DB.UFOList [i].moveTo (1f, map [i], true, 0.1f);
//		//		yield break;
//		//		if (!DB.start)
//		//			for (int i = 0; i <= DB.arrangement_index; i++) {
//		//				var Group = UFO.InstantiateUFOs (DB.arrangement [i].Count);//實例化UFO
//		//				for (int j = 0; j < Group.Count; j++) {
//		//					Group [j].moveTo (0.7f, DB.arrangement [i] [j], true, 0.1f);
//		//				}
//		//			}
//		//
//		//		//下一關圖形
//		//		if (LevelCount++ == Loop) {
//		//			Camera.Back ();
//		//			LevelCount = 1;
//		//			DB.arrangement_index++;
//		//			DB.g_iBalance = DB.arrangement [DB.arrangement_index].Count;//缺(多)幾台UFO
//		//			var Group = UFO.InstantiateUFOs (DB.g_iBalance);//實例化UFO
//		//			for (int j = 0; j < Group.Count; j++) {
//		//				Group [j].moveTo (0.7f, DB.arrangement [DB.arrangement_index] [j], true, 0.1f);
//		//			}
//		//		}
//		//
//		//		Controller.DisplaySliderBar ();
//		//
//		//
//		//		yield break;
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
