using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using System.Runtime.InteropServices;

public class Level2_1 : MonoBehaviour
{
	Level2_UI UI;
	Level2_DB DB;
	Level2_Controller Controller;

	//同一關玩幾次
	private int Loop;
	private int LevelCount;

	void Awake ()
	{
		UI = GetComponent<Level2_UI> ();
		DB = GetComponent<Level2_DB> ();
		Controller = GetComponent<Level2_Controller> ();
		UIEventListener.Get (UI.Button_CONFIRM.gameObject).onClick = GameStart;
		Loop = 5;
		LevelCount = 0;
	}

	void Start ()
	{
		
	}

	void GameStart (GameObject go)
	{
		//遊戲開始
		StartCoroutine (GameLoop ());
	}

	void Update ()
	{
		
	}

	IEnumerator GameLoop ()
	{
		Controller.Select_Slider_init ();//歸位UI

//		LevelCount = (DB.index + 1) * Loop;

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

//			if (Controller.IfTheEnd (LevelCount, Loop) || Controller.Feedback (DB.LevelUP))
//				yield break;

			if (Controller.IfTheEnd (LevelCount, Loop))
				yield break;

			//等待下一幀
			yield return null;
		}
	}

	///關卡設定
	IEnumerator LevelManagement ()
	{
//		Controller.DisplaySliderBar ();

		//5,10,15,20次個別關卡
		if (LevelCount++ != Loop && DB.start)
			yield break;

		Action action = null;//方法容器

		if (DB.index == 0) {
			Debug.Log ("1");	
		}
		if (DB.index == 1) {
			action += Controller.Main_Cylinder_Rotation (10, true);
			action += Controller.Cups_Rotation (40, false);
			Debug.Log ("2");	
		}
		if (DB.index == 2) {
			action += Controller.Main_Cylinder_Rotation (20, false);
			action += Controller.Cups_Rotation (30, true);
			Debug.Log ("3");	
		}
		if (DB.index == 3) {
			action += Controller.Main_Cylinder_Rotation (30, true);
			action += Controller.Cups_Rotation (20, false);
			Debug.Log ("4");	
		}
		if (DB.index == 4) {
			action += Controller.Main_Cylinder_Rotation (40, false);
//			action += Controller.Cups_Rotation (10, true);
			Debug.Log ("5");	
		}

		DB.index++;
		LevelCount = 1;
		Controller.StartRotation (action);//執行容器

		yield break;
	}

	//隨機亂數
	IEnumerator MakeRandom (int key)//key->需要幾個亂數
	{
		//清空
		Level2_DB.BALL_Random.Clear ();

		List<BALL> TempList = Level2_DB.BALLList.ToList ();

		for (int i = 0; i < key; i++) {
			int num = UnityEngine.Random.Range (0, TempList.Count);
			Level2_DB.BALL_Random.Add (TempList [num]);
			TempList [num] = TempList [TempList.Count - 1];
			TempList.RemoveAt (TempList.Count - 1);
		}
		yield break;
	}

	IEnumerator ShowLight ()
	{
//		yield return DB.WaitOneSecond;

		var last = Level2_DB.BALL_Random.Last ();

		foreach (var ball in Level2_DB.BALL_Random) {

			ball.Red ();

			yield return new WaitForSeconds (DB.lighttime);

			ball.Original (false);

			//當走訪至最後時跳出迴圈
			if (ball == last)
				break;

			yield return new WaitForSeconds (DB.darktime);
		}
	}

	IEnumerator AnswerCompare ()
	{
		//清空
		Level2_DB.BALL.Clear ();

		//開啟點擊
		Controller.AllColliderEnabled (true);

		int RandomCount = Level2_DB.BALL_Random.Count;
//
		while (true) {
			//UFO數量到達時判斷
			if (RandomCount == Level2_DB.BALL.Count) {

				//關閉點擊
				Controller.AllColliderEnabled (false);

				DB.LevelUP = Controller.Compare (Level2_DB.BALL, Level2_DB.BALL_Random);

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
		Level2_DB.BALLList.ForEach (go => go.Original (false));
		DB.start = true;
		yield break;
	}
}
