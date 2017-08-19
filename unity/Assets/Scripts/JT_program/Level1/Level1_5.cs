using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using UnityEngine.SceneManagement;

public class Level1_5 : MonoBehaviour
{
	//	Level1_DB DB;
	Level1_Controller Controller;

	public CameraControl3 Camera;

	//關卡參數
	int[][,,] LevelParameter;

	//	private int Loop = 3;
	//	private int LevelCount = 1;
	//	private  int twice = 0;

	void Awake ()
	{
//		DB = GetComponent<Level1_DB> ();
		Controller = GetComponent<Level1_Controller> ();
	}

	void Start ()
	{
		Parameter ();

		//讀取地圖
		MAP ();

		ButtonEvent ();
	}

	void ButtonEvent ()
	{
		//將執行權給Controller
		Controller.StartGameLoop += (GameObject go) => StartCoroutine (GameLoop ());
	}

	void Parameter ()
	{
		//{ mode, Loop, arrangement_index, random,CameraStep}
		//只抓取陣列第一筆資料
		LevelParameter = new int[][,,] {

			//1.........................
			new int[,,]{ { { 1, 20, 0, 2, 0 } } },//1
			new int[,,]{ { { 1, 20, 1, 3, 1 } } },//2
			new int[,,]{ { { 1, 25, 2, 3, 2 } } },//3
			new int[,,]{ { { 1, 25, 3, 4, 3 } } },//4
			new int[,,]{ { { 1, 30, 3, 5, 3 } } },//5

			//0.........................
			new int[,,] { { 
					{ 0, 30, 4, 3, 4 } 
				} 
			},//6

			new int[,,] { {
					{ 0, 35, 4, 4, 5 }, 
					{ 0, 35, 5, 4, 5 }
				},
			},//7

			new int[,,] { {
					{ 0, 35, 4, 5, 5 },
					{ 0, 35, 5, 5, 5 }, 
					{ 0, 35, 6, 5, 5 } 
				},
			},//8

			new int[,,] { {
					{ 0, 40, 4, 6, 6 }, 
					{ 0, 40, 5, 6, 6 }, 
					{ 0, 40, 6, 6, 6 }, 
					{ 0, 40, 7, 6, 6 }
				},
			},//9

			new int[,,] { {
					{ 0, 40, 4, 7, 7 }, 
					{ 0, 40, 5, 7, 7 }, 
					{ 0, 40, 6, 7, 7 }, 
					{ 0, 40, 7, 7, 7 }, 
					{ 0, 40, 8, 7, 7 },
				},
			},//10
		};
	}

	private void MAP ()
	{
//		DB.map = Resources.LoadAll<TextAsset> ("JT/maps");
		//讀入txt
		Controller.LoadMap (Resources.LoadAll<TextAsset> ("JT/maps") [4].text);
	}

	//使多層旋轉群組可以(順逆順逆)旋轉
	private int Forward_OR_Reverse (ref int dir, ref int dirCount)
	{
		if (dirCount++ == 0) {
			dir *= -1;
			return dir;
		}

		if (dirCount % 2 == 0) {
			dir *= -1;
		}
		return dir;
	}

	IEnumerator GameLoop ()
	{
		IEnumerator e = Loop1 (Controller.Select_Level_number);

		yield return StartCoroutine (e);

		//回傳遊戲是如何結束
		//回傳0代表正常結束遊戲
		//回傳1代表錯誤9次
		//回傳2代表遊戲閒置

		int code = (int)e.Current;//UnBox

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

		IEnumerator e = Loop2 (number);

		yield return StartCoroutine (e);

		yield return e.Current;//回傳至GameLoop
	}

	IEnumerator Loop2 (int number)
	{
		//只抓取陣列第一筆資料
		var Loop = LevelParameter [number] [0, 0, 1];

		var CameraStep = LevelParameter [number] [0, 0, 4];

		Camera.Step (CameraStep);//設定camera距離

		//用來使群組能順逆轉
		int dirCount = 0;
		int dir = 1;

		for (int i = 0; i < LevelParameter [number].GetLength (0); i++) {
			for (int j = 0; j < LevelParameter [number].GetLength (1); j++) {

				var mode = LevelParameter [number] [i, j, 0];

				var map = Controller.Get_arrangement (LevelParameter [number] [i, j, 2]);

				Controller.random = LevelParameter [number] [i, j, 3];

				yield return StartCoroutine (LevelManagement (mode, Forward_OR_Reverse (ref dir, ref dirCount), map));
			}
		}

		IEnumerator e = Loop3 (Loop);

		yield return StartCoroutine (e);
						
		yield return e.Current;//回傳至Loop1
	}

	IEnumerator Loop3 (int Loop)
	{
		int CheckCode = 0;

		for (int i = 0; i < Loop; i++) {

			//隨機亂數
			yield return StartCoroutine (MakeRandom ());

			//亮燈
			yield return StartCoroutine (ShowLight ());

			//答案比對
			yield return StartCoroutine (AnswerCompare ());

			//重置
			yield return StartCoroutine (Reset ());

			if (Controller.Feedback ()) {
				CheckCode = 1;
				break;
			}

			if (Controller.IfTimeOut) {
				CheckCode = 2;
				break;
			}
		}
		yield return CheckCode;//回傳至Loop2
	}

	///關卡設定
	IEnumerator LevelManagement (int mode, int dir, List<Vector3> map)
	{
		Controller.DisplaySliderBar ();//更新難度條

		//創造旋轉群組
		Level1_RotationFix RotateGroup = Controller.CreateGroup ();

		if (mode == 0) {
			RotateGroup.direction = dir;
		}

		//建置UFO位置
		UFO.UFO_group = RotateGroup.transform;

		var Balance = map.Count; //多(少)幾台

		var Group = UFO.InstantiateUFOs (Balance);//實例化UFO

		//重設場上所有UFO座標
		for (int i = 0; i < Group.Count; i++)
			Group [i].moveTo (0.7f, map [i], true, 0.1f);

		yield break;
		//		Controller.DisplaySliderBar ();//更新難度條
		//
		//		if (mode == 1) {
		//			//創造旋轉群組
		//			Level1_RotationFix RotateGroup = Controller.CreateGroup (map);
		//			//建置UFO位置
		//			UFO.UFO_group = RotateGroup.transform;
		//
		//			var Balance = map.Count; //多(少)幾台
		//
		//			var Group = UFO.InstantiateUFOs (Balance);//實例化UFO
		//
		//			//重設場上所有UFO座標
		//			for (int i = 0; i < Group.Count; i++)
		//				Group [i].moveTo (0.7f, map [i], true, 0.1f);
		//		}
		//
		//		if (mode == 0) {
		//
		//			//創造旋轉群組
		//			Level1_RotationFix RotateGroup = Controller.CreateGroup (map);
		//
		//			RotateGroup.direction = dir;
		//			//建置UFO位置
		//			UFO.UFO_group = RotateGroup.transform;
		//
		//			var Balance = map.Count; //多(少)幾台
		//
		//			var Group = UFO.InstantiateUFOs (Balance);//實例化UFO
		//
		//			//重設場上所有UFO座標
		//			for (int i = 0; i < Group.Count; i++)
		//				Group [i].moveTo (0.7f, map [i], true, 0.1f);
		//		}
//		if (!DB.start) {
//
//			Controller.DisplaySliderBar ();
//
//			if (DB.arrangement_index <= 4) {
//
//				//創造旋轉群組
//		GameObject go = Controller.CreateGroup ();
//
//				//建置UFO位置
//		UFO.UFO_group = go.transform;
//
//		var Group = UFO.InstantiateUFOs (DB.arrangement [DB.arrangement_index].Count);//實例化UFO
//
//				//重設場上所有UFO座標
//		for (int i = 0; i < Group.Count; i++)
//			Group [i].moveTo (0.8f, DB.arrangement [DB.arrangement_index] [i], true, 0.1f);
//
//		yield break;
//
//			} else {
//				for (int i = 4; i <= DB.arrangement_index; i++) {
//
//					if (twice++ != 2) {
//
//						//創造旋轉群組
//						GameObject go = Controller.CreateGroup (DB.UFO_group);
//
//						//建置UFO位置
//						UFO.UFO_group = go.transform;
//					} else {
//						twice = 1;
//					}
//
//					var Group = UFO.InstantiateUFOs (DB.arrangement [i].Count);//實例化UFO
//					for (int j = 0; j < Group.Count; j++) {
//						Group [j].moveTo (0.7f, DB.arrangement [i] [j], true, 0.1f);
//					}
//				}
//			}
//	
//		} else {
//	
//			if (LevelCount++ == Loop) {
//
//				Camera.Back ();
//	
//				DB.arrangement_index++;
//	
//				if (DB.arrangement_index < 4) {
//	
//					if (DB.UFO_group.childCount != 0)
//						Controller.DestoryGroup (DB.RotationGroup.Last ());
//	
//					GameObject go = Controller.CreateGroup (DB.UFO_group);
//	
//					//建置UFO位置
//					UFO.UFO_group = go.transform;
//	
//					var Group = UFO.InstantiateUFOs (DB.arrangement [DB.arrangement_index].Count);//實例化UFO
//	
//					//重設場上所有UFO座標
//					for (int i = 0; i < Group.Count; i++)
//						Group [i].moveTo (0.8f, DB.arrangement [DB.arrangement_index] [i], true, 0.1f);
//	
//				} else {
//	
//					if (DB.arrangement_index == 4 && DB.UFO_group.childCount != 0)
//						Controller.DestoryGroup (DB.RotationGroup.Last ());
//	
//					if (twice++ != 2) {
//	
//						GameObject go = Controller.CreateGroup (DB.UFO_group);
//	
//						//建置UFO位置
//						UFO.UFO_group = go.transform;
//					} else {
//						twice = 1;
//						bool RotationComplete = false;
//						TweenRotation.Begin (DB.RotationGroup.Last ().Group, 1f, Quaternion.identity).AddOnFinished (() => RotationComplete = true);
//						yield return new WaitUntil (() => RotationComplete);
//					}
//	
//					var Group = UFO.InstantiateUFOs (DB.arrangement [DB.arrangement_index].Count);
//	
//					//設定座標
//					for (int i = 0; i < Group.Count; i++)
//						Group [i].moveTo (0.8f, DB.arrangement [DB.arrangement_index] [i], true, 0.1f);
//	
//				}
//				LevelCount = 1;
//			}
//			Controller.DisplaySliderBar ();
//		}
//		//		if (!start) {
//					GameObject go = Level1_Tools.CreateGroup (UFO_group);
//		//
//		//			//建置UFO位置
//		//			Level1_UFO.UFO_group = go.transform;
//		//
//		//			var Group = Level1_UFO.InstantiateUFOs (arrangement [arrangement_index].Count);
//		//
//		//			//設定座標
//		//			for (int i = 0; i < arrangement [arrangement_index].Count; i++)
//		//				Group [i].moveTo (0.8f, arrangement [arrangement_index] [i], true, 0.1f);
//		//
//		//			arrangement_index++;
//		//
//		//		} else {
//		//
//		//			if (twice++ != 2) {
//		//
//		//				GameObject go = Level1_Tools.CreateGroup (UFO_group);
//		//
//		//				//建置UFO位置
//		//				Level1_UFO.UFO_group = go.transform;
//		//			} else {
//		//				twice = 1;
//		//				bool RotationComplete = false;
//		//				TweenRotation.Begin (RotationGroup.Last ().Group, 1f, Quaternion.identity).AddOnFinished (() => RotationComplete = true);
//		//				yield return new WaitUntil (() => RotationComplete);
//		//			}
//		//
//		//
//		//
//		//			var Group = Level1_UFO.InstantiateUFOs (arrangement [arrangement_index].Count);
//		//
//		//			//設定座標
//		//			for (int i = 0; i < arrangement [arrangement_index].Count; i++)
//		//				Group [i].moveTo (0.8f, arrangement [arrangement_index] [i], true, 0.1f);
//		//
//		//			arrangement_index++;
//		//
//		//		}
//		yield break;
	}
	
	//隨機亂數
	IEnumerator MakeRandom ()
	{
		yield return Controller._MakeRandom ();
	}

	IEnumerator ShowLight ()
	{
		yield return Controller._ShowLight ();
	}

	IEnumerator AnswerCompare ()
	{
		yield return Controller._AnswerCompare ();
	}
	
	//重置
	IEnumerator Reset ()
	{
		yield return Controller._Reset ();
	}
}
