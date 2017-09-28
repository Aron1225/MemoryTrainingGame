using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;


public abstract class Level2 : Level
{
	//public field............................

	public GameObject BrainWaveData;

	//protected field.........................
	
	protected Level2_Controller CT2;

	//關卡參數
	protected Level[][,] LevelParameter;

	//protected field.........................

	private ICoffeeCup coffeeCup;

	//innerclass..............................

	protected class Level
	{
		private int Loop;
		private int random;
		private ICoffeeCup ICC;

		public Level (int Loop, int random, ICoffeeCup ICC)
		{
			this.Loop = Loop;
			this.random = random;
			this.ICC = ICC;
		}

		public int GetLoop ()
		{
			return Loop;
		}

		public int Getrandom ()
		{
			return random;
		}

		public ICoffeeCup GetICC ()
		{
			return ICC;
		}
	}

	//abstract method.........................

	//抽象方法
	public abstract void Parameter ();

	//Mono....................................

	public override void OnAwake ()
	{
		base.OnAwake ();
	}

	public override void OnStart ()
	{
		base.OnStart ();
		if (Level2_Menu.UseBrainWave) {
			BrainWaveData.SetActive (true);
			#if !UNITY_EDITOR
			Connect.jo.Call ("StartBrainWave");
			#endif
		}
	}

	public override void On_OnDestroy ()
	{
		base.On_OnDestroy ();
		if (Level2_Menu.UseBrainWave) {
			#if !UNITY_EDITOR
			Connect.jo.Call ("StopBrainWave");
			#endif
		}
	}

	//遊戲功能流程觸發.........................

	public override void _GameStart ()
	{
		level_instance.StartCoroutine (level_instance.GameLoop ());
		CT2.GameStart ();
	}

	public override void _LevelMenu (string str = "")
	{
		level_instance.StopAllCoroutines ();
		CT2.LevelMenu (str);
		coffeeCup.stop ();
	}

	public override void _BackHome ()
	{
		level_instance.StopAllCoroutines ();
		CT2.BackHome (7);
		coffeeCup.stop ();
	}

	public override void _Again (string str = "")
	{
		level_instance.StopAllCoroutines ();
		CT2.Again (str);
		coffeeCup.stop ();
		GameStart ();
	}

	public override void _Next ()
	{
		CT2.Next ();
		GameStart ();
	}

	public override void _Back ()
	{
		CT2.Back ();
		GameStart ();
	}

	//遊戲流程.................................

	public override IEnumerator GameLoop ()
	{
		IEnumerator e = Loop1 (CT2.useL2DB.Select_Level_number);
	
		yield return StartCoroutine (e);
	
		//回傳遊戲是如何結束
		//回傳0代表正常結束遊戲
		//回傳1代表錯誤9次
		//回傳2代表遊戲閒置
	
		int code = (int)e.Current;
	
		if (code == 0) {
			CT2.Finish ();//結束遊戲
			Debug.Log ("finish");
		}
		if (code == 1) {
			CT2.GameOver ();//錯誤9次
			Debug.Log ("GameOver");
		}
		if (code == 2) {
			CT2.TimeOut ();//遊戲閒置
			Debug.Log ("TimeOut");
		}
	
		yield break;
	}

	IEnumerator Loop1 (int Select_Level_number)
	{
		int number = Select_Level_number - 1;
	
		IEnumerator e = null;
	
		//{ Loop, random,ICC}
		for (int i = 0; i < LevelParameter [number].GetLength (0); i++) {
	
			var Loop = LevelParameter [number] [i, 0].GetLoop ();

			var random = LevelParameter [number] [i, 0].Getrandom ();
	
			var ICC = LevelParameter [number] [i, 0].GetICC ();
	
			CT2.useL2DB.random = random;

			e = Loop2 (Loop, ICC);
	
			yield return StartCoroutine (e);
	
			if ((int)e.Current != 0)
				break;
		}
	
		yield return e.Current;//回傳至GameLoop
	}

	IEnumerator Loop2 (int Loop, ICoffeeCup ICC)
	{
		int CheckCode = 0;
	
		yield return StartCoroutine (LevelManagement (ICC));
	
		for (int i = 0; i < Loop; i++) {
	
			//隨機亂數
			yield return StartCoroutine (MakeRandom (CT2.useL2DB.random));
	
			//亮燈
			yield return StartCoroutine (ShowLight ());
	
			//答案比對
			yield return StartCoroutine (AnswerCompare ());
	
			//重置
			yield return StartCoroutine (Reset ());
	
			if (CT2.Feedback ()) {
				CheckCode = 1;
				break;
			}
	
			if (CT2.useL2DB.TimeOut) {
				CheckCode = 2;
				break;
			}
		}
	
		coffeeCup.stop ();
	
		yield return CheckCode;//回傳至Loop1
	}

	//管理
	public override IEnumerator LevelManagement (params object[] args)
	{
		CT2.DisplaySliderBar ();//更新難度條

		coffeeCup = (ICoffeeCup)args [0];

		coffeeCup.start ();

		yield break;
	}

	//需要幾個亂數
	public override IEnumerator MakeRandom (int key)
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

	//顯示亂數
	public override IEnumerator ShowLight ()
	{
		yield return CT2.useL2DB.WaitOneSecond;

		var last = Level2_DB.BALL_Random.Last ();

		foreach (var ball in Level2_DB.BALL_Random) {

			ball.Red ();

			yield return new WaitForSeconds (CT2.useL2DB.lighttime);

			ball.Original (false);

			//當走訪至最後時跳出迴圈
			if (ball == last)
				break;

			yield return new WaitForSeconds (CT2.useL2DB.darktime);
		}
	}

	//比對答案
	public override IEnumerator AnswerCompare ()
	{
		//清空
		Level2_DB.BALL.Clear ();

		//開啟點擊
		CT2.AllColliderEnabled (true);

		int RandomCount = Level2_DB.BALL_Random.Count;

		CT2.CountDownStart ();//30秒到數

		while (CT2.useL2DB.Compare) {
			//UFO數量到達時判斷
			if (RandomCount == Level2_DB.BALL.Count) {

				//關閉點擊
				CT2.AllColliderEnabled (false);

				CT2.useL2DB.LevelUP = CT2.Compare (Level2_DB.BALL, Level2_DB.BALL_Random);

				CT2.showResults (CT2.useL2DB.LevelUP);

				CT2.Record (CT2.useL2DB.LevelUP);

				CT2.ResetTimeOutCount ();//只要有作答TimeOutCount就歸零

				break;//跳出while迴圈
			}
			yield return null;//等待下一幀
		}
		yield return CT2.useL2DB.WaitOneSecond;
	}

	//重置
	public override IEnumerator Reset ()
	{
		Level2_DB.BALLList.ForEach (go => go.Original (false));
		CT2.useL2DB.Compare = true;
		CT2.useL2DB.start = true;
		yield break;
	}
}
