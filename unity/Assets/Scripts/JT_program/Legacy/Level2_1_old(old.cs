using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class Level2_1_old: MonoBehaviour
{
//	Level2_Controller_old Controller;
//	ICoffeeCup coffeeCup;
//
//	//關卡參數
//	Level[][,] LevelParameter;
//
//	class Level
//	{
//		public int Loop;
//		public int random;
//		public ICoffeeCup ICC;
//
//		public Level (int Loop, int random, ICoffeeCup ICC)
//		{
//			this.Loop = Loop;
//			this.random = random;
//			this.ICC = ICC;
//		}
//	}
//
//	void Awake ()
//	{
//		Controller = GetComponent<Level2_Controller_old> ();
//	}
//
//	void Start ()
//	{
//		Parameter ();
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
//		//{ Loop, random,iCoffeeCup}
//		LevelParameter = new Level[][,] {
//			new Level[,] { { new Level (20, 2, CoffeeCup.build (Model.OneCups_ThreeBall)) } }, 
//			new Level[,] { { new Level (25, 3, CoffeeCup.build (Model.OneCups_ThreeBall)) } },
//			new Level[,] { { new Level (25, 3, CoffeeCup.build (Model.OneCups_FourBall)) } },
//			new Level[,] { { new Level (30, 4, CoffeeCup.build (Model.OneCups_FourBall)) } },
//			new Level[,] { { new Level (30, 4, CoffeeCup.build (Model.OneCups_FiveBall)) } },
//			new Level[,] { { new Level (35, 5, CoffeeCup.build (Model.OneCups_FiveBall)) } },
//			new Level[,] { { new Level (35, 5, CoffeeCup.build (Model.OneCups_SixBall)) } },
//			new Level[,] { { new Level (40, 6, CoffeeCup.build (Model.OneCups_SixBall)) } },
//			new Level[,] { { new Level (40, 6, CoffeeCup.build (Model.OneCups_SevenBall)) } },
//			new Level[,] { { new Level (40, 7, CoffeeCup.build (Model.OneCups_SevenBall)) } },
//		};
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
////			Controller.GameOver ();//錯誤9次
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
////		{ Loop, random,ICC}
//		for (int i = 0; i < LevelParameter [number].GetLength (0); i++) {
//
//			var Loop = LevelParameter [number] [i, 0].Loop;
//
//			Controller.random = LevelParameter [number] [i, 0].random; 
//
//			var ICC = LevelParameter [number] [i, 0].ICC;
//
//			e = Loop2 (Loop, ICC);
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
//	IEnumerator Loop2 (int Loop, ICoffeeCup ICC)
//	{
//		int CheckCode = 0;
//
//		yield return StartCoroutine (LevelManagement (ICC));
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
////			if (Controller.Feedback ()) {
////				CheckCode = 1;
////				break;
////			}
////
//			if (Controller.IfTimeOut) {
//				CheckCode = 2;
//				break;
//			}
//		}
//
//		coffeeCup.stop ();
//
//		yield return CheckCode;//回傳至Loop1
//	}
//
//	///關卡設定
//	IEnumerator LevelManagement (ICoffeeCup ICC)
//	{
//		Controller.DisplaySliderBar ();//更新難度條
//
//		coffeeCup = ICC;
//
//		coffeeCup.start ();
//
//		yield break;
//
////		IEnumerator e = Controller._LevelManagement (ICC);
////
////		yield return StartCoroutine (e);
////
////		coffeeCup = (ICoffeeCup)e.Current;
////
////		yield break;
//	}
//
//	//隨機亂數
//	IEnumerator MakeRandom ()
//	{
//		yield return Controller._MakeRandom ();
//	}
//
//	IEnumerator ShowLight ()
//	{
//		yield return Controller._ShowLight ();
//	}
//
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
