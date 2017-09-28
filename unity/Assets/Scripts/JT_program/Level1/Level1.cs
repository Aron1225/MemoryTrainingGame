using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;


public abstract class Level1 : Level
{
	//protected field.........................

	protected Level1_Controller CT1;

	//abstract method.........................

	//參數
	public abstract void Parameter ();
	//地圖
	public abstract void MAP ();

	public abstract IEnumerator Loop1 (int Select_Level_number);

	public abstract IEnumerator Loop2 (params object[] args);

	//Mono....................................

	public override void OnAwake ()
	{
		base.OnAwake ();
	}

	public override void OnStart ()
	{
		base.OnStart ();
	}

	//遊戲功能流程觸發.........................

	public override void _GameStart ()
	{
		level_instance.StartCoroutine (level_instance.GameLoop ());
		CT1.GameStart ();
	}

	public override void _LevelMenu (string str = "")
	{
		level_instance.StopAllCoroutines ();
		CT1.LevelMenu (str);
	}

	public override void _BackHome ()
	{
		level_instance.StopAllCoroutines ();
		CT1.BackHome (1);
	}

	public override void _Again (string str)
	{
		level_instance.StopAllCoroutines ();
		CT1.Again (str);
		GameStart ();
	}

	public override void _Next ()
	{
		CT1.Next ();
		GameStart ();
	}

	public override void _Back ()
	{
		CT1.Back ();
		GameStart ();
	}

	//遊戲流程.................................

	public override IEnumerator GameLoop ()
	{
		IEnumerator e = Loop1 (CT1.useL1DB.Select_Level_number);

		yield return StartCoroutine (e);

		//回傳遊戲是如何結束
		//回傳0代表正常結束遊戲
		//回傳1代表錯誤9次
		//回傳2代表遊戲閒置

		int code = (int)e.Current;

		if (code == 0) {
			CT1.Finish ();//結束遊戲
			Debug.Log ("finish");
		}
		if (code == 1) {
			CT1.GameOver ();//錯誤9次
			Debug.Log ("GameOver");
		}
		if (code == 2) {
			CT1.TimeOut ();//遊戲閒置
			Debug.Log ("TimeOut");
		}

		yield break;
	}
		
	//UFO的建置與設定位置
	public override IEnumerator LevelManagement (params object[] args)
	{
		CT1.DisplaySliderBar ();//更新難度條

		CT1.Balance ((List<Vector3>)args [0], (bool)args [1]);//依關卡數量生出UFO、設定UFO位置

		yield break;
	}

	//需要幾個亂數
	public override IEnumerator MakeRandom (int key)
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

	//顯示亂數
	public override IEnumerator ShowLight ()
	{
		//當陣列全部等於false時執行
		yield return CT1.useL1DB.WaitUntilUFOReady;

		yield return CT1.useL1DB.WaitOneSecond;

		var last = Level1_DB.UFO_Random.Last ();

		foreach (var ufo in Level1_DB.UFO_Random) {

			ufo.Red ();

			yield return new WaitForSeconds (CT1.useL1DB.lighttime);

			ufo.Original (false);

			//當走訪至最後時跳出迴圈
			if (ufo == last)
				break;

			yield return new WaitForSeconds (CT1.useL1DB.darktime);
		}
	}

	public override IEnumerator AnswerCompare ()
	{
		//清空
		Level1_DB.UFO.Clear ();

		//開啟點擊
		CT1.AllColliderEnabled (true);

		int RandomCount = Level1_DB.UFO_Random.Count;

		CT1.CountDownStart ();//30秒到數

		while (CT1.useL1DB.Compare) {
			//UFO數量到達時判斷
			if (RandomCount == Level1_DB.UFO.Count) {

				//關閉點擊
				CT1.AllColliderEnabled (false);

				CT1.useL1DB.LevelUP = CT1.Compare (Level1_DB.UFO, Level1_DB.UFO_Random);

				CT1.showResults (CT1.useL1DB.LevelUP);

				CT1.Record (CT1.useL1DB.LevelUP);

				CT1.ResetTimeOutCount ();//只要有作答TimeOutCount就歸零

				break;//跳出while迴圈
			}
			yield return null;//等待下一幀
		}
		yield return CT1.useL1DB.WaitOneSecond;
	}

	public override IEnumerator Reset ()
	{
		Level1_DB.UFOList.ForEach (go => go.Original (false));
		CT1.useL1DB.Compare = true;
		CT1.useL1DB.start = true;
		yield break;
	}
}
