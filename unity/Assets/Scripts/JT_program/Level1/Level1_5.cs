using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using UnityEngine.SceneManagement;

public class Level1_5 : Level1_DataBase
{
	Level1_UI UI;
	Level1_DB DB;
	Level1_Controller Controller;

	public CameraControl3 Camera;

	private int Loop = 3;
	private int LevelCount = 1;

	private  int twice = 0;

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

		Controller.LoadMap (DB.map [4].text);
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
		if (!DB.start) {

			Controller.DisplaySliderBar ();

			if (DB.arrangement_index <= 4) {

				//創造旋轉群組
				GameObject go = Controller.CreateGroup (DB.UFO_group);

				//建置UFO位置
				UFO.UFO_group = go.transform;

				var Group = UFO.InstantiateUFOs (DB.arrangement [DB.arrangement_index].Count);//實例化UFO

				//重設場上所有UFO座標
				for (int i = 0; i < Group.Count; i++)
					Group [i].moveTo (0.8f, DB.arrangement [DB.arrangement_index] [i], true, 0.1f);

			} else {
				for (int i = 4; i <= DB.arrangement_index; i++) {

					if (twice++ != 2) {

						//創造旋轉群組
						GameObject go = Controller.CreateGroup (DB.UFO_group);

						//建置UFO位置
						UFO.UFO_group = go.transform;
					} else {
						twice = 1;
					}

					var Group = UFO.InstantiateUFOs (DB.arrangement [i].Count);//實例化UFO
					for (int j = 0; j < Group.Count; j++) {
						Group [j].moveTo (0.7f, DB.arrangement [i] [j], true, 0.1f);
					}
				}
			}
	
		} else {
	
			if (LevelCount++ == Loop) {

				Camera.Back ();
	
				DB.arrangement_index++;
	
				if (DB.arrangement_index < 4) {
	
					if (DB.UFO_group.childCount != 0)
						Controller.DestoryGroup (DB.RotationGroup.Last ());
	
					GameObject go = Controller.CreateGroup (DB.UFO_group);
	
					//建置UFO位置
					UFO.UFO_group = go.transform;
	
					var Group = UFO.InstantiateUFOs (DB.arrangement [DB.arrangement_index].Count);//實例化UFO
	
					//重設場上所有UFO座標
					for (int i = 0; i < Group.Count; i++)
						Group [i].moveTo (0.8f, DB.arrangement [DB.arrangement_index] [i], true, 0.1f);
	
				} else {
	
					if (DB.arrangement_index == 4 && DB.UFO_group.childCount != 0)
						Controller.DestoryGroup (DB.RotationGroup.Last ());
	
					if (twice++ != 2) {
	
						GameObject go = Controller.CreateGroup (DB.UFO_group);
	
						//建置UFO位置
						UFO.UFO_group = go.transform;
					} else {
						twice = 1;
						bool RotationComplete = false;
						TweenRotation.Begin (DB.RotationGroup.Last ().Group, 1f, Quaternion.identity).AddOnFinished (() => RotationComplete = true);
						yield return new WaitUntil (() => RotationComplete);
					}
	
					var Group = UFO.InstantiateUFOs (DB.arrangement [DB.arrangement_index].Count);
	
					//設定座標
					for (int i = 0; i < Group.Count; i++)
						Group [i].moveTo (0.8f, DB.arrangement [DB.arrangement_index] [i], true, 0.1f);
	
				}
				LevelCount = 1;
			}
			Controller.DisplaySliderBar ();
		}
		//		if (!start) {
		//			GameObject go = Level1_Tools.CreateGroup (UFO_group);
		//
		//			//建置UFO位置
		//			Level1_UFO.UFO_group = go.transform;
		//
		//			var Group = Level1_UFO.InstantiateUFOs (arrangement [arrangement_index].Count);
		//
		//			//設定座標
		//			for (int i = 0; i < arrangement [arrangement_index].Count; i++)
		//				Group [i].moveTo (0.8f, arrangement [arrangement_index] [i], true, 0.1f);
		//
		//			arrangement_index++;
		//
		//		} else {
		//
		//			if (twice++ != 2) {
		//
		//				GameObject go = Level1_Tools.CreateGroup (UFO_group);
		//
		//				//建置UFO位置
		//				Level1_UFO.UFO_group = go.transform;
		//			} else {
		//				twice = 1;
		//				bool RotationComplete = false;
		//				TweenRotation.Begin (RotationGroup.Last ().Group, 1f, Quaternion.identity).AddOnFinished (() => RotationComplete = true);
		//				yield return new WaitUntil (() => RotationComplete);
		//			}
		//
		//
		//
		//			var Group = Level1_UFO.InstantiateUFOs (arrangement [arrangement_index].Count);
		//
		//			//設定座標
		//			for (int i = 0; i < arrangement [arrangement_index].Count; i++)
		//				Group [i].moveTo (0.8f, arrangement [arrangement_index] [i], true, 0.1f);
		//
		//			arrangement_index++;
		//
		//		}
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
