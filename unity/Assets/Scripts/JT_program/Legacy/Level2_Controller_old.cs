using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;
using System;

public class Level2_Controller_old : MonoBehaviour
{
//	//執行GameStart的方法
//	public UIEventListener.VoidDelegate StartGameLoop;
//
//	UI_Element UI;
//	Level2_DB DB;
//	GA_Controller GA;
//
//	//TweenPosition......................
//
//	TweenPosition TP_Billboard;
//	TweenPosition TP_Wrong;
//	TweenPosition TP_TimeOut;
//	TweenPosition TP_Select_Level;
//	TweenPosition TP_Slider_Level;
//
//	//Coroutine........................
//
//	//使用Coroutine物件,在使用Coroutine物件中有while情況下也可以直接StopCoroutine
//	Coroutine RecordTime;
//	Coroutine CountDown;
//
//	//bool.............................
//
//	//避免IfTheEnd()與Feedback()同時執行
//	private bool Suppress_Feedback;
//
//	//int.............................
//
//	//閒置次數
//	private int TimeOutCount;
//	//回饋對錯紀錄
//	private int feedbackCount;
//
//	//float.............................
//
//	//存放各關的起始值
//	private float tmp_lightTime;
//	private float tmp_darkTime;
//
//	//總遊戲時間
//	private float time;
//	//每增加難度亮燈減少的時間
//	private float interval;
//
//	//Getter...........................
//
//	//是否TimeOut
//	public bool IfTimeOut{ get { return DB.TimeOut; } }
//
//	//是否開始
//	public bool start{ get { return DB.start; } }
//
//	//選單數字
//	public int Select_Level_number{ get { return DB.Select_Level_number; } }
//
//	//Setter..........................
//
//	//亂數
//	public int random{ set { DB.random = value; } }
//
//	//legacy.........................
//
//	//	private CustomRotation Main;
//	//	private CustomRotation[] Cups;
//
//	//Mono.............................
//
//	void Awake ()
//	{
//		#if UNITY_EDITOR
//		Debug.logger.logEnabled = true;
//		#else
//		Debug.logger.logEnabled = false;
//		#endif
//		UI = GetComponent<UI_Element> ();
//		DB = GetComponent<Level2_DB> (); 
//		GA = GetComponent<GA_Controller> ();
//		Init ();
//	}
//
//	void Start ()
//	{
//		ButtonEvent ();//註冊按鈕事件
//	}
//
//	void Update ()
//	{
//
//	}
//
//	//IEnumerator.........................
//
//	//紀錄時間
//	IEnumerator _RecordTime ()
//	{
//		while (true) {
//			time += Time.deltaTime;
//			yield return null;
//		}
//	}
//
//	//開始倒數計時
//	IEnumerator _CountDown ()
//	{
//		float tmpTime = 0;
//
//		int tmpCount = Level2_DB.BALL.Count;
//
//		//當未作答至指定數量
//		while (Level2_DB.BALL.Count != Level2_DB.BALL_Random.Count) {
//
//			//當按下時重新倒數
//			if (tmpCount != Level2_DB.BALL.Count) {
//				tmpCount = Level2_DB.BALL.Count;
//				tmpTime = 0;
//			}
//
//			tmpTime += Time.deltaTime;//增加時間
//
//			//到達閒置時間
//			if (Mathf.FloorToInt (tmpTime) == DB.TimeOut_Time) {
//
//				DB.Compare = false;//使AnswerCompare中的while跳過
//				AllColliderEnabled (false);
//				showResults (false);
//				Record (false);
//
//				if (++TimeOutCount == 3) {
//					DB.TimeOut = true;
//				}
//				yield break;
//			}
//			yield return null;
//		}	
//	}
//
//	//	///關卡設定
//	//	public IEnumerator _LevelManagement (ICoffeeCup ICC)
//	//	{
//	//		DisplaySliderBar ();//更新難度條
//	//
//	//		ICC.start ();
//	//
//	//		yield break;
//	//
//	////		yield return ICC;
//	//	}
//
//	//亂數
//	public IEnumerator _MakeRandom ()
//	{
//		//需要幾個亂數
//		int key = DB.random;
//
//		//清空
//		Level2_DB.BALL_Random.Clear ();
//
//		List<BALL> TempList = Level2_DB.BALLList.ToList ();
//
//		for (int i = 0; i < key; i++) {
//			int num = UnityEngine.Random.Range (0, TempList.Count);
//			Level2_DB.BALL_Random.Add (TempList [num]);
//			TempList [num] = TempList [TempList.Count - 1];
//			TempList.RemoveAt (TempList.Count - 1);
//		}
//
//		yield break;
//	}
//
//	//顯示亂數
//	public IEnumerator _ShowLight ()
//	{
//		yield return DB.WaitOneSecond;
//
//		var last = Level2_DB.BALL_Random.Last ();
//
//		foreach (var ball in Level2_DB.BALL_Random) {
//
//			ball.Red ();
//
//			yield return new WaitForSeconds (DB.lighttime);
//
//			ball.Original (false);
//
//			//當走訪至最後時跳出迴圈
//			if (ball == last)
//				break;
//
//			yield return new WaitForSeconds (DB.darktime);
//		}
//	}
//
//	//比對答案
//	public IEnumerator _AnswerCompare ()
//	{
//		//清空
//		Level2_DB.BALL.Clear ();
//
//		//開啟點擊
//		AllColliderEnabled (true);
//
//		int RandomCount = Level2_DB.BALL_Random.Count;
//
//		CountDownStart ();//30秒到數
//
//		while (DB.Compare) {
//			//UFO數量到達時判斷
//			if (RandomCount == Level2_DB.BALL.Count) {
//
//				//關閉點擊
//				AllColliderEnabled (false);
//
//				DB.LevelUP = Compare (Level2_DB.BALL, Level2_DB.BALL_Random);
//
//				showResults (DB.LevelUP);
//
//				Record (DB.LevelUP);
//
//				ResetTimeOutCount ();//只要有作答TimeOutCount就歸零
//
//				break;//跳出while迴圈
//			}
//			yield return null;//等待下一幀
//		}
//		yield return DB.WaitOneSecond;
//	}
//
//	//重置
//	public IEnumerator _Reset ()
//	{
//		Level2_DB.BALLList.ForEach (go => go.Original (false));
//		DB.Compare = true;
//		DB.start = true;
//		yield break;
//	}
//
//
//	//public..................................................................
//
//	//遊戲結束,完成遊戲後顯示資訊
//	public void Finish ()
//	{	
//		Suppress_Feedback = true;//壓制Feedback()執行
//		StopAllCoroutines ();
//		UI_Finish ();//顯示所有資訊
//		DisplayPercent ();//答對率
//		DisplayTime (time);//時間
//		DisplayScore ();//統計
//		GA.HideAllGUIs ();
//	}
//
//	//錯誤9次
//	public void GameOver ()
//	{
//		StopAllCoroutines ();
//		UI_GameOver ();
//		GA.HideAllGUIs ();
//	}
//
//	//遊戲閒置
//	public void TimeOut ()
//	{
//		StopAllCoroutines ();
//		UI_TimeOut ();
//		GA.HideAllGUIs ();
//	}
//
//	//SliderBar.....................................
//
//	//設定SliderBar
//	public void DisplaySliderBar ()
//	{
//		float increase = (DB.Select_Level_number) * 1f / DB.TOTAL_LEVEL;
//		UI.slider_level.value = increase;
//	}
//
//	//Feedback..........................................
//
//	//回饋,連錯3題增加亮燈時間,再錯3題減少random數,再錯3題返回上一關
//	public bool Feedback ()
//	{
//		bool bo = false;
//		//避免IfTheEnd()與Feedback()同時執行
//		if (!Suppress_Feedback) {
//
//			if (DB.LevelUP) {
//				feedbackCount = 0;
//				return false;
//			} 
//
//			feedbackCount++;
//
//			if (feedbackCount == 3) {
//				DB.lighttime = Mathf.Clamp (DB.lighttime + 0.5f, 0.1f, 2f);
//				DB.darktime = Mathf.Clamp (DB.darktime + 0.5f, 0.1f, 2f);
//			} 
//
//			if (feedbackCount == 6) {
//				DB.random = Mathf.Clamp (DB.random - 1, 2, 10);
//			}
//
//			if (feedbackCount == 9) {
//				bo = true;
//			}
//		}
//		return bo;
//	}
//
//	//有關閒置部分...................................
//
//	//閒置倒數
//	public void CountDownStart ()
//	{
//		CountDown = StartCoroutine (_CountDown ());	
//	}
//
//	//TimeOutCount歸零
//	public void ResetTimeOutCount ()
//	{
//		TimeOutCount = 0;
//	}
//
//	//作答部分.......................................
//
//	// 紀錄對錯次數
//	public void Record (bool result)
//	{
//		if (result)
//			DB.BingoCount++;
//		else
//			DB.ErrorCount++;
//	}
//
//	//顯示答對錯Icon
//	public void showResults (bool result)
//	{
//		if (result)
//			Results (UI.Object, UI.GameObject_Bingo);
//		else
//			Results (UI.Object, UI.GameObject_Error);
//	}
//
//	public bool Compare<T> (List<T> list1, List<T> list2)
//	{
//		//型態不一致
//		if (list1.GetType () != list2.GetType ())
//			return false;
//
//		//數量不一致
//		if (list1.Count != list2.Count)
//			return false;
//
//		bool result = true;
//
//		for (int i = 0; i <= list1.Count - 1; i++) {
//			if (!list1 [i].Equals (list2 [i])) {
//				result = false;
//				break;
//			}
//		}
//
//		return result;
//	}
//
//	//GA(GUI Animator)外掛套件.................................
//
//	public void GA_LevelMenu ()
//	{
////		CoffeeCup.CoffeeCupStop ();
//		AllColliderEnabled (false);
//		StopAllCoroutines ();
//		UI_GA_LevelMenu ();
//		GA.HideAllGUIs ();
//	}
//
//	//回到主畫面
//	public void GA_BackHome ()
//	{
//		Btn_BackHome (this.gameObject);
//	}
//
//	public void GA_Again ()
//	{
////		CoffeeCup.CoffeeCupStop ();
//		AllColliderEnabled (false);
//		StopAllCoroutines ();
//		GameStart (this.gameObject);
//	}
//
//	//private..................................................................
//
//	//Init.....................................
//
//	//初始
//	private void Init ()
//	{
//		//設定亂數種子
//		UnityEngine.Random.InitState (System.Guid.NewGuid ().GetHashCode ());
//
//		DB.WaitOneSecond = new WaitForSeconds (1f);
//
//		DB.CheckedScale = new Vector3 (140, 140, 0);
//
//		DB.Compare = true;
//
////		time = 0;
//		interval = 0.05f;
////		TimeOutCount = 0;
////		feedbackCount = 0;
////		Suppress_Feedback = false;
//
//		tmp_lightTime = DB.lighttime;
//		tmp_darkTime = DB.darktime;
//	}
//
//	//start............................
//
//	//Controller開始設置
//	private void ControllerStart ()
//	{
//		RecordTime = StartCoroutine (_RecordTime ());//開始計時
//		setLightTime ();//選完難度後設定關卡參數
//	}
//
//	//update number...........................
//
//	///更新遊戲畫面上的數字
//	private void Updated ()
//	{
//		UI_Element.Label_Level.text = DB.Select_Level_number.ToString ();
//	}
//
//	//Button......................................
//
//	//遊戲開始
//	private void Btn_GameStart (GameObject go)
//	{
//		GameStart (go);
//		UI_GameStart ();
//		GA.start ();//MoveIn GA套件
//	}
//
//	//下一關
//	private void Btn_NextLevel (GameObject go)
//	{
//		Next ();
//		GameStart (go);
//		UI_NextLevel ();
//		GA.start ();//MoveIn GA套件
//	}
//
//	//上一關
//	private void Btn_BackLevel (GameObject go)
//	{
//		Back ();
//		GameStart (go);
//		UI_BackLevel ();
//		GA.start ();//MoveIn GA套件
//	}
//
//	//再玩一次
//	private void Btn_Again (GameObject go)
//	{
//		GameStart (go);
//		UI_Again ();
//		GA.start ();//MoveIn GA套件
//	}
//
//	//回到選擇難度
//	private void Btn_LevelMenu (GameObject go)
//	{
//		UI_LevelMenu ();
//	}
//
//	//回到主畫面
//	private void Btn_BackHome (GameObject go)
//	{
//		SceneManager.LoadScene (7);
//	}
//
//	//Button附帶方法...............................
//
//	private void GameStart (GameObject go)
//	{
//		resetParameter ();//參數初始
//		StartGameLoop (go);//執行遊戲主要協程
//		ControllerStart ();//執行次要計時協程與亮燈時間設定
//	}
//
//	private void Next ()
//	{
//		DB.Select_Level_number++;
//		Updated ();
//	}
//
//	private void Back ()
//	{ 
//		DB.Select_Level_number = Mathf.Clamp (DB.Select_Level_number - 1, 1, 10);
//		Updated ();
//	}
//
//	//遊戲結束後UI的觸發動作............................
//
//	//顯示所有資訊
//	private void UI_Finish ()
//	{
//		UI_Slider_Level_dir (false);
//		UI_Billboard_dir (true);
//
//		//大於10 nextButton就隱藏
//		if (DB.Select_Level_number >= DB.TOTAL_LEVEL)
//			UI_Element.Button_NextLevel.gameObject.SetActive (false);
//		else
//			UI_Element.Button_NextLevel.gameObject.SetActive (true);
//	}
//
//	private void UI_GameOver ()
//	{
//		UI_Wrong_dir (true);
//		UI_Slider_Level_dir (false);
//	}
//
//	private void UI_TimeOut ()
//	{
//		UI_TimeOut_dir (true);
//		UI_Slider_Level_dir (false);
//	}
//
//	//GA套件的UI的觸發動作.........................
//
//	void UI_GA_LevelMenu ()
//	{
//		UI_Select_Level_dir (false);
//		UI_Slider_Level_dir (false);
//	}
//
//	//When Button CLick.............................
//
//	private void UI_GameStart ()
//	{
//		UI_Slider_Level_dir (true);
//		UI_Select_Level_dir (true);
//	}
//
//	private void UI_NextLevel ()
//	{
//		UI_Slider_Level_dir (true);
//		UI_Billboard_dir (false);
//	}
//
//	private void UI_BackLevel ()
//	{
//		UI_Wrong_dir (false);
//		UI_Slider_Level_dir (true);
//	}
//
//	private void UI_Again ()
//	{
//		UI_Slider_Level_dir (true);
//		UI_Billboard_dir (false);
//	}
//
//	private void UI_LevelMenu ()
//	{
//		UI_Select_Level_dir (false);
//		UI_Billboard_dir (false);
//	}
//
//	//UI direction................................
//
//	private void UI_Select_Level_dir (bool Forward)
//	{
//		UI_dir (Forward, false, UI_Element.Select_Level, ref TP_Select_Level, 0.6f, new Vector3 (0, -780, 0));
//	}
//
//	private void UI_Billboard_dir (bool Forward)
//	{
//		UI_dir (Forward, true, UI_Element.Billboard, ref TP_Billboard, 0.6f, new Vector3 (0, -34, 0));
//	}
//
//	private void UI_Slider_Level_dir (bool Forward)
//	{
//		UI_dir (Forward, true, UI_Element.Slider_Level, ref TP_Slider_Level, 0.6f, new Vector3 (-535, -146, 0));
//	}
//
//	private void UI_Wrong_dir (bool Forward)
//	{
//		UI_dir (Forward, false, UI_Element.Wrong, ref TP_Wrong, 0.6f, new Vector3 (0, -34, 0));
//	}
//
//	private void UI_TimeOut_dir (bool Forward)
//	{
//		UI_dir (Forward, false, UI_Element.TimeOut, ref TP_TimeOut, 0.6f, new Vector3 (0, -34, 0));
//	}
//
//	private void UI_dir (bool Forward, bool hidden, GameObject go, ref TweenPosition TP, float duration, Vector3 pos)
//	{
//		go.SetActive (true);
//
//		if (Forward) {
//			if (TP == null)
//				TP = TweenPosition.Begin (go, duration, pos);
//			else
//				TP.PlayForward ();
//			TP.delay = 0;
//		} else {
//			TP.PlayReverse ();
//			//結束後隱藏
//			if (hidden) {
//
//				EventDelegate eventDelegate = new EventDelegate (this, "hidden");  
//
//				eventDelegate.parameters [0] = new EventDelegate.Parameter (TP);
//
//				EventDelegate.Add (TP.onFinished, eventDelegate, true);//oneshot=true
//			}
//		}
//	}
//
//	//隱藏
//	private void hidden (TweenPosition TP)
//	{
//		TP.gameObject.SetActive (false);
//	}
//
//	//UIEventListener...................................
//
//	//事件監聽
//	private void ButtonEvent ()
//	{
//		//select_level.........................
//
//		UIEventListener.Get (UI_Element.Button_CONFIRM.gameObject).onClick = Btn_GameStart;
//		UIEventListener.Get (UI_Element.Button_UP.gameObject).onClick = Select_Level;
//		UIEventListener.Get (UI_Element.Button_DOWN.gameObject).onClick = Select_Level;
//
//		//Billboard............................
//
//		UIEventListener.Get (UI_Element.Button_Menu.gameObject).onClick = Btn_LevelMenu;
//		UIEventListener.Get (UI_Element.Button_NextLevel.gameObject).onClick = Btn_NextLevel;
//		UIEventListener.Get (UI_Element.Button_Again.gameObject).onClick = Btn_Again;
//		UIEventListener.Get (UI_Element.Button_BackHome.gameObject).onClick = Btn_BackHome;
//
//		//FeedBack.............................
//
//		UIEventListener.Get (UI_Element.Button_BackLevel.gameObject).onClick = Btn_BackLevel;
//
//		//TimeOut..............................
//
//		UIEventListener.Get (UI_Element.Button_TimeOutBackHome.gameObject).onClick = Btn_BackHome;
//	}
//
//	//顯示答對錯Icon
//	private void Results (GameObject parent, GameObject child)
//	{
//		GameObject go = GameObject.Instantiate (child) as GameObject;
//
//		if (go != null && parent != null) {
//			Transform t = go.transform;
//			t.parent = parent.transform;
//			go.GetComponent<UISprite> ().depth = 1;
//			go.transform.localScale = DB.CheckedScale;
//			go.transform.localPosition = new Vector3 (0, 0, 220);
//			iTween.ScaleFrom (go, iTween.Hash ("scale", Vector3.zero));
//			Destroy (go, 1f);
//		}
//	}
//
//	//選擇關卡
//	private void Select_Level (GameObject btn)
//	{
//		if (btn == UI_Element.Button_UP.gameObject) {
//			if (DB.Select_Level_number < DB.TOTAL_LEVEL) {
//				//				UI.Label_Level.text = (++DB.Select_Level_number).ToString ();
//				DB.Select_Level_number++;
//				Updated ();
//			} else {
//				DB.Select_Level_number = 1;
//				Updated ();
//			}
//		}
//
//		if (btn == UI_Element.Button_DOWN.gameObject) {
//			if (DB.Select_Level_number > 1) {
//				//				UI.Label_Level.text = (--DB.Select_Level_number).ToString ();
//				DB.Select_Level_number--;
//				Updated ();
//			} else {
//				DB.Select_Level_number = 10;
//				Updated ();
//			}
//		}
//	}
//
//	//顯示答對率
//	private void DisplayPercent ()
//	{
//		float sum = DB.BingoCount + DB.ErrorCount;
//		float percent = DB.BingoCount / sum;
//		UI_Element.slider_percent.value = (!float.IsNaN (percent)) ? percent : 0;//if not NaN
//	}
//
//	//顯示總共玩遊戲時間
//	private void DisplayTime (float time)
//	{
//		TimeSpan timeSpan = TimeSpan.FromSeconds (time);
//		UI_Element.label_Time.text = timeSpan.Hours + "h " + timeSpan.Minutes + "m " + timeSpan.Seconds + "s ";
//	}
//
//	//顯示分數
//	private void DisplayScore ()
//	{
//		UI_Element.label_Bingo.text = DB.BingoCount.ToString ();
//		UI_Element.label_Error.text = DB.ErrorCount.ToString ();
//	}
//
//	//選完難度後設定關卡參數
//	private void setLightTime ()
//	{
//		//設定亮燈時間
//		DB.lighttime = tmp_lightTime - interval * (DB.Select_Level_number - 1);
//		DB.darktime = tmp_darkTime - interval * (DB.Select_Level_number - 1);
//	}
//
//	//碰撞器開關
//	private void AllColliderEnabled (bool enabled)
//	{
//		Level2_DB.BALLList.ForEach (go => go.GetComponent<SphereCollider> ().enabled = enabled);
//	}
//
//	//參數初始
//	private void resetParameter ()
//	{
//		time = 0;
//		feedbackCount = 0;
//		TimeOutCount = 0;
//		Suppress_Feedback = false;
//
//		Level2_DB.BALL.Clear ();
//		Level2_DB.BALL_Random.Clear ();
//
//		DB.lighttime = tmp_lightTime;
//		DB.darktime = tmp_darkTime;
//
//		DB.BingoCount = 0;
//		DB.ErrorCount = 0;
//		DB.start = false;
//		DB.LevelUP = false;
//		DB.TimeOut = false;
//
//		Level2_DB.BALLList.ForEach (go => go.Original (false));
//	}
//
//	//	Func<int> 表示無參，傳回值為int的委託
//	//	Func<object,string,int> 表示傳入參數為object, string 傳回值為int的委託
//	//	Func<int,string> test = i => i.ToString ();
//	//	public Action Main_Cylinder_Rotation (float speed, bool Clockwise)
//	//	{
//	//		if (Main == null)
//	//			Main = DB.Main_Cylinder.AddComponent<CustomRotation> ();
//	//
//	//		return set_Rotation (new CustomRotation[]{ Main }, speed, Clockwise);//回傳容器
//	//		return set_Rotation (new GameObject[]{ DB.Main_Cylinder }, speed, Clockwise);
//	//	}
//	//	public Action Cups_Rotation (float speed, bool Clockwise)
//	//	{
//	//		if (Cups == null) {
//	//			Cups = new CustomRotation[DB.Cups.Length];
//	//			for (int i = 0; i < Cups.Length; i++) {
//	//				Cups [i] = DB.Cups [i].AddComponent<CustomRotation> ();
//	//			}
//	//		}
//	//
//	//		return set_Rotation (Cups, speed, Clockwise);//回傳容器
//	//		return set_Rotation (DB.Cups, speed, Clockwise);//回傳容器
//	//	}
//	//
//	//	public void StartRotation (Action total)
//	//	{
//	//		Stop_Rotation ();//enabled=false 所有旋轉腳本
//	//		if (total != null)
//	//			total.Invoke ();
//	//	}
//	//	//設定旋轉參數
//	//	private Action set_Rotation (CustomRotation[] CustomRotation, float speed, bool Clockwise)
//	//	{
//	//		Action method = null;//方法容器
//	//
//	//		for (int i = 0; i < CustomRotation.Length; i++) {
//	//
//	//			var CR = CustomRotation [i];
//	//
//	//			//將方法累加到容器
//	//			method += () => {
//	//				CR.enabled = true;
//	//				CR.speed = speed;//設定旋轉速度
//	//				CR.setDirection (Clockwise);//設定旋轉方向
//	//			};
//	//		}
//	//		return  method;//回傳容器
//	//	}
//	//設定旋轉參數
//	//	private Action set_Rotation (GameObject[] Rotation_go, float speed, bool Clockwise)
//	//	{
//	//		Action method = null;//方法容器
//	//
//	//		for (int i = 0; i < Rotation_go.Length; i++) {
//	//
//	//			var go = Rotation_go [i];
//	//
//	//			CustomRotation CR = go.GetComponent<CustomRotation> ();
//	//
//	//			if (CR == null) {
//	//				//將方法指定到容器
//	//				method += () => CR = go.AddComponent<CustomRotation> ();//掛上旋轉腳本
//	//			} else {
//	//				//將方法指定到容器
//	//				method += () => CR.enabled = true;
//	//			}
//	//
//	//			//將方法累加到容器
//	//			method += () => {
//	//				CR.speed = speed;//設定旋轉速度
//	//				CR.setDirection (Clockwise);//設定旋轉方向
//	//			};
//	//		}
//	//		return  method;//回傳容器
//	//	}
//	//	//關閉所有的旋轉
//	//	private void Stop_Rotation ()
//	//	{
//	//		if (Main != null)
//	//			Main.enabled = false;
//	//		if (Cups != null) {
//	//			for (int i = 0; i < DB.Cups.Length; i++) {
//	//				if (Cups [i] != null)
//	//					Cups [i].enabled = false;
//	//			}
//	//		}
//	//	}
//	//
//	//	private void SmoothStop ()
//	//	{
//	//		Main.SmoothStop ();
//	//	}
}
