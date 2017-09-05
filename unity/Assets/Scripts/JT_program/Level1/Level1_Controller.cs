using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Linq;

public class Level1_Controller : MonoBehaviour
{
	//執行GameStart的方法
	public UIEventListener.VoidDelegate StartGameLoop;

	Level1_UI UI;
	Level1_DB DB;
	GA_Controller GA;

	//TweenPosition......................

	TweenPosition TP_Billboard;
	TweenPosition TP_Wrong;
	TweenPosition TP_TimeOut;
	TweenPosition TP_Select_Level;
	TweenPosition TP_Slider_Level;

	//Coroutine........................

	//使用Coroutine物件,在使用Coroutine物件中有while情況下也可以直接StopCoroutine
	Coroutine RecordTime;
	Coroutine CountDown;

	//bool.............................

	//避免IfTheEnd()與Feedback()同時執行
	private bool Suppress_Feedback;

	//int.............................

	//閒置次數
	private int TimeOutCount;
	//回饋對錯紀錄
	private int feedbackCount;
	//RotationGroup方向
	private int dir;

	//float.............................

	//存放各關的起始值
	private float tmp_lightTime;
	private float tmp_darkTime;

	//總遊戲時間
	private float time;
	//每增加難度亮燈減少的時間
	private float interval;

	//Getter...........................

	//是否TimeOut
	public bool IfTimeOut{ get { return DB.TimeOut; } }

	//是否開始
	public bool start{ get { return DB.start; } }

	//選單數字
	public int Select_Level_number{ get { return DB.Select_Level_number; } }

	//Setter..........................

	//亂數
	public int random{ set { DB.random = value; } }

	//Mono.............................

	void Awake ()
	{
		#if UNITY_EDITOR
		Debug.logger.logEnabled = true;
		#else
		Debug.logger.logEnabled = false;
		#endif
		UI = GetComponent<Level1_UI> ();
		DB = GetComponent<Level1_DB> ();
		GA = GetComponent<GA_Controller> ();
		Init ();
	}

	void Start ()
	{
		ButtonEvent ();//註冊按鈕事件
	}

	void Update ()
	{
		
	}

	//IEnumerator.........................

	//紀錄時間
	IEnumerator _RecordTime ()
	{
		while (true) {
			time += Time.deltaTime;
			yield return null;
		}
	}

	//開始倒數計時
	IEnumerator _CountDown ()
	{
		float tmpTime = 0;

		int tmpCount = Level1_DB.UFO.Count;
	
		//當未作答至指定數量
		while (Level1_DB.UFO.Count != Level1_DB.UFO_Random.Count) {

			//當按下時重新倒數
			if (tmpCount != Level1_DB.UFO.Count) {
				tmpCount = Level1_DB.UFO.Count;
				tmpTime = 0;
			}

			tmpTime += Time.deltaTime;//增加時間

			//到達閒置時間
			if (Mathf.FloorToInt (tmpTime) == DB.TimeOut_Time) {

				DB.Compare = false;//使AnswerCompare中的while跳過
				showResults (false);
				Record (false);

				if (++TimeOutCount == 3) {
					DB.TimeOut = true;
				}
				yield break;
			}
			yield return null;
		}	
	}

	//UFO的建置與設定位置
	public IEnumerator _LevelManagement (List<Vector3> map, bool IgnoreBalanceIsZero = false)
	{
		///關卡設定
		DisplaySliderBar ();//更新難度條

		Balance (map, IgnoreBalanceIsZero);//依關卡數量生出UFO、設定UFO位置

		yield break;
	}

	//亂數
	public IEnumerator _MakeRandom ()
	{
		int key = DB.random;//key->需要幾個亂數

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
	public IEnumerator _ShowLight ()
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

	//比對答案
	public IEnumerator _AnswerCompare ()
	{
		//清空
		Level1_DB.UFO.Clear ();

		//開啟點擊
		UFO.AllColliderEnabled (true);

		int RandomCount = Level1_DB.UFO_Random.Count;

		CountDownStart ();//30秒到數

		while (DB.Compare) {
			//UFO數量到達時判斷
			if (RandomCount == Level1_DB.UFO.Count) {

				//關閉點擊
				UFO.AllColliderEnabled (false);

				DB.LevelUP = Compare (Level1_DB.UFO, Level1_DB.UFO_Random);

				showResults (DB.LevelUP);

				Record (DB.LevelUP);

				ResetTimeOutCount ();//只要有作答TimeOutCount就歸零

				break;//跳出while迴圈
			}
			yield return null;//等待下一幀
		}
		yield return DB.WaitOneSecond;
	}

	//重置
	public IEnumerator _Reset ()
	{
		Level1_DB.UFOList.ForEach (go => go.Original (false));
		DB.Compare = true;
		DB.start = true;
		yield break;
	}

	//public..................................................................

	//遊戲結束,完成遊戲後顯示資訊
	public void Finish ()
	{	
		Suppress_Feedback = true;//壓制Feedback()執行
		StopAllCoroutines ();
//		StopCoroutine (RecordTime);//計時停止
		UI_Finish ();//顯示所有資訊
		DisplayPercent ();//答對率
		DisplayTime (time);//時間
		DisplayScore ();//統計
		UFO.DestroyUFO (Level1_DB.UFOList.Count, 1f);//清空場上所有UFO
		GA.HideAllGUIs ();
		Invoke ("unload", 1.5f);
	}
		
	//錯誤9次
	public void GameOver ()
	{
		StopAllCoroutines ();
//		StopCoroutine (RecordTime);//計時停止
		UI_GameOver ();
		UFO.DestroyUFO (Level1_DB.UFOList.Count, 1f);//清空場上所有UFO
		GA.HideAllGUIs ();
		Invoke ("unload", 1.5f);
	}

	//遊戲閒置
	public void TimeOut ()
	{
		StopAllCoroutines ();
//		StopCoroutine (RecordTime);//計時停止
		UI_TimeOut ();
		UFO.DestroyUFO (Level1_DB.UFOList.Count, 1f);//清空場上所有UFO
		GA.HideAllGUIs ();
		Invoke ("unload", 1.5f);
	}

	//卸載掉不使用的資源
	void unload ()
	{
		Resources.UnloadUnusedAssets ();//讓Unity 自行去卸載掉不使用的資源
		GC.Collect ();
	}

	//SliderBar.....................................

	//設定SliderBar
	public void DisplaySliderBar ()
	{
		float increase = (DB.Select_Level_number) * 1f / DB.TOTAL_LEVEL;
		UI.slider_level.value = increase;
	}

	//	//設定SliderBar
	//	public void DisplaySliderBar (Func<float> increase)
	//	{
	//		UI.slider_level.value = increase ();
	//	}

	//Feedback..........................................

	//回饋,連錯3題增加亮燈時間,再錯3題減少random數,再錯3題返回上一關
	public bool Feedback ()
	{
		bool bo = false;
		//避免IfTheEnd()與Feedback()同時執行
		if (!Suppress_Feedback) {

			if (DB.LevelUP) {
				feedbackCount = 0;
				return false;
			} 

			feedbackCount++;

			if (feedbackCount == 3) {
				DB.lighttime = Mathf.Clamp (DB.lighttime + 0.5f, 0.1f, 2f);
				DB.darktime = Mathf.Clamp (DB.darktime + 0.5f, 0.1f, 2f);
			} 

			if (feedbackCount == 6) {
				DB.random = Mathf.Clamp (DB.random - 1, 2, 10);
			}

			if (feedbackCount == 9) {
				bo = true;
			}
		}
		return bo;
	}
		
	//有關閒置部分...................................

	//閒置倒數
	public void CountDownStart ()
	{
		CountDown = StartCoroutine (_CountDown ());	
	}

	//TimeOutCount歸零
	public void ResetTimeOutCount ()
	{
		TimeOutCount = 0;
	}

	//作答部分.......................................

	// 紀錄對錯次數
	public void Record (bool result)
	{
		if (result)
			DB.BingoCount++;
		else
			DB.ErrorCount++;
	}

	//顯示答對錯Icon
	public void showResults (bool result)
	{
		if (result)
			Results (UI.UI_Object, UI.GameObject_Bingo);
		else
			Results (UI.UI_Object, UI.GameObject_Error);
	}

	//UFO與UFO_Random的答案比對
	public bool Compare (List<UFO> UFO, List<UFO> UFO_Random)
	{
		if (UFO.Count != UFO_Random.Count)
			return false;

		bool result = true;

		for (int i = 0; i <= UFO.Count - 1; i++) {
			if (UFO [i].GetUFO != UFO_Random [i].GetUFO) {
				result = false;
				break;
			}
		}
		return result;
	}
		
	//Get..........................................

	public List<Vector3> Get_arrangement (int index)
	{
		return DB.arrangement [index];
	}

	//取得指定範圍地圖陣列(mapRange1,mapRange2)
	public List<List<Vector3>> Get_MapRange (int mapRange1, int mapRange2)
	{
		List<List<Vector3>> map = new List<List<Vector3>> ();

		for (int i = 0; i <= (mapRange2 - mapRange1); i++) {
			map.Add (DB.arrangement [i + mapRange1]);
		}

		return map;
	}

	//旋轉群組.........................................

	//創造旋轉群組
	public Level1_RotationFix CreateGroup ()
	{
		GameObject go = new GameObject ("G" + DB.RotationGroup_Index++);

		go.transform.parent = DB.UFO_group;

		go.transform.localScale = Vector3.one;

		Level1_RotationFix rf = go.AddComponent<Level1_RotationFix> ();

		rf.Group = go;

		rf.direction = dir *= -1;

//		DB.RotationGroup.Add (rf);

		return rf;
	}
		
	//移除整個RotationGroup物件，並移除所有子物件(UFO)
	public void DestoryGroup (Level1_RotationFix rf)
	{
		UFO.DestroyUFO (rf.transform.childCount);
		MonoBehaviour.Destroy (rf.gameObject, 0.5f);
		DB.RotationGroup_Index--;
	}

	//GA(GUI Animator)外掛套件.................................

	public void GA_LevelMenu ()
	{
		StopAllCoroutines ();
		UFO.DestroyUFO (Level1_DB.UFOList.Count, 1f);//清空場上所有UFO
		Invoke ("unload", 1.5f);
//		Resources.UnloadUnusedAssets ();//讓Unity 自行去卸載掉不使用的資源
//		resetParameter ();//參數初始
		UI_GA_LevelMenu ();
		GA.HideAllGUIs ();
	}

	//回到主畫面
	public void GA_BackHome ()
	{
		Btn_BackHome (this.gameObject);
	}

	public void GA_Again ()
	{
		StopAllCoroutines ();
		UFO.DestroyUFO (Level1_DB.UFOList.Count, 1f);//清空場上所有UFO
		Invoke ("unload", 1.5f);
//		Resources.UnloadUnusedAssets ();//讓Unity 自行去卸載掉不使用的資源
		GameStart (this.gameObject);
//		resetParameter ();//參數初始
//		StartGameLoop (this.gameObject);
//		ControllerStart ();
	}

	//map..............................................

	//UFO排列圖座標陣列
	public void LoadMap (string map)
	{
		//分隔符
		string[] split_char = { "\n", "\r" };
		//所有字串
		string[] lines = map.Trim ().Split (split_char, System.StringSplitOptions.RemoveEmptyEntries);

		int p1 = 1;

		for (int i = 0; i < lines.Length; i++) {
			//以,#分隔
			string[] parts = lines [i].Split ("," [0], "#" [0]);

			if (p1 != int.Parse (parts [0])) {

				DB.arrangement.Add (new List<Vector3> ());

				p1 = int.Parse (parts [0]);
			}
			//加入座標
			DB.arrangement [int.Parse (parts [0])].Add (new Vector3 (float.Parse (parts [1]), float.Parse (parts [2]), float.Parse (parts [3])));
		}
	}

	//Legacy............................................

	//	//預測下一次是否結束遊戲
	//	public bool IfTheEnd (int LevelCount, int Loop)
	//	{
	//		if (LevelCount++ != Loop)
	//			return false;
	//
	//		if ((DB.Select_Level_number) != DB.TOTAL_LEVEL)
	//			return false;
	//
	//		Finish ();
	//		//壓制Feedback()執行
	//		Suppress_Feedback = true;
	//
	//		return true;
	//	}
	//
	//	//預測下一次是否結束遊戲
	//	public bool IfTheEnd (Func<bool> TheEnd)
	//	{
	//		if (!TheEnd ())
	//			return false;
	//
	//		Finish ();
	//		//壓制Feedback()執行
	//		Suppress_Feedback = true;
	//
	//		return true;
	//	}
	//	//創造旋轉群組
	//	public GameObject CreateGroup (Transform parent)//parent->RotationGroup物件的parent
	//	{
	//		GameObject go = new GameObject ("G" + DB.RotationGroup_Index++);
	//
	//		go.transform.parent = parent;
	//
	//		go.transform.localScale = Vector3.one;
	//
	//		Level1_RotationFix rf = go.AddComponent<Level1_RotationFix> ();
	//
	//		rf.Group = go;
	//
	//		rf.direction = dir *= -1;
	//
	//		DB.RotationGroup.Add (rf);
	//
	//		return go;
	//	}
	//	public bool Feedback (bool result)
	//	{
	//		bool bo = false;
	//		//避免IfTheEnd()與Feedback()同時執行
	//		if (!Suppress_Feedback) {
	//
	//			if (result) {
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

	//private..................................................................

	//Init.....................................

	//初始
	private void Init ()
	{
		//設定亂數種子
		UnityEngine.Random.InitState (System.Guid.NewGuid ().GetHashCode ());

		DB.WaitUntilUFOReady = new WaitUntil (() => Level1_DB.UFOList.All (list => !(list.m_isMoving)));

		DB.WaitOneSecond = new WaitForSeconds (1f);

		DB.CheckedScale = new Vector3 (140, 140, 0);

		DB.Compare = true;

		//載入UFO
		Level1_DB.LoadUFO = Resources.LoadAll<GameObject> ("JT/UFO_3D");

		//隨機值
		Level1_DB.g_iRandom = UnityEngine.Random.Range (0, 7);

		//建置UFO位置
		UFO.UFO_group = DB.UFO_group;


		/*
		time = 0;
		feedbackCount = 0;
		TimeOutCount = 0;
		Suppress_Feedback = false;
		
		*/

//		time = 0;
		dir = 1;
		interval = 0.05f;
//		TimeOutCount = 0;
//		feedbackCount = 0;
//		Suppress_Feedback = false;

		tmp_lightTime = DB.lighttime;
		tmp_darkTime = DB.darktime;
	}

	private void Balance (List<Vector3> map, bool IgnoreBalanceIsZero = false)
	{
		var Balance = Level1_DB.UFOList.Count - map.Count;//多(少)幾台

		//extra
		if (Balance > 0) {
			UFO.DestroyUFO (Balance);//Destroy幾台
		}

		//lack
		if (Balance < 0) {
			UFO.InstantiateUFOs (Mathf.Abs (Balance));//實例化UFO
		} 

		//重設場上所有UFO座標
		if (!DB.start || !IgnoreBalanceIsZero)
			for (int i = 0; i < map.Count; i++)
				Level1_DB.UFOList [i].moveTo (1f, map [i], true, 0.1f);
	}
		
	//start............................

	//Controller開始設置
	private void ControllerStart ()
	{
		RecordTime = StartCoroutine (_RecordTime ());//開始計時
		setLightTime ();//選完難度後設定關卡參數
	}

	//update number...........................

	///更新遊戲畫面上的數字
	private void Updated ()
	{
		UI.Label_Level.text = DB.Select_Level_number.ToString ();
	}

	//Button......................................

	//遊戲開始
	private void Btn_GameStart (GameObject go)
	{
//		StartGameLoop (go);
//		ControllerStart ();
		GameStart (go);
		UI_GameStart ();
		GA.start ();//MoveIn GA套件
	}

	//下一關
	private void Btn_NextLevel (GameObject go)
	{
		Next ();
//		resetParameter ();//參數初始
//		StartGameLoop (go);
//		ControllerStart ();
		GameStart (go);
		UI_NextLevel ();
		GA.start ();//MoveIn GA套件
	}

	//上一關
	private void Btn_BackLevel (GameObject go)
	{
		Back ();
//		resetParameter ();//參數初始
//		StartGameLoop (go);
//		ControllerStart ();
		GameStart (go);
		UI_BackLevel ();
		GA.start ();//MoveIn GA套件
	}
		
	//再玩一次
	private void Btn_Again (GameObject go)
	{
//		resetParameter ();//參數初始
//		StartGameLoop (go);
//		ControllerStart ();
		GameStart (go);
		UI_Again ();
		GA.start ();//MoveIn GA套件
	}

	//回到選擇難度
	private void Btn_LevelMenu (GameObject go)
	{
//		resetParameter ();//參數初始
		UI_LevelMenu ();
	}

	//回到主畫面
	private void Btn_BackHome (GameObject go)
	{
		SceneManager.LoadScene (1);
//		AsyncOperation LoadScene = SceneManager.LoadSceneAsync (1);
	}

	//Button附帶方法...............................

	private void GameStart (GameObject go)
	{
		resetParameter ();//參數初始
		StartGameLoop (go);//執行遊戲主要協程
		ControllerStart ();//執行次要計時協程與亮燈時間設定
	}

	private void Next ()
	{
//		UI.Label_Level.text = (int.Parse (UI.Label_Level.text) + 1).ToString ();
		DB.Select_Level_number++;
		Updated ();
	}

	private void Back ()
	{ 
//		DB.Select_Level_number = Mathf.Max (1, DB.Select_Level_number--);
//		UI.Label_Level.text = (Mathf.Max (1, (int.Parse (UI.Label_Level.text) - 1))).ToString ();
		DB.Select_Level_number = Mathf.Clamp (DB.Select_Level_number - 1, 1, 10);
		Updated ();
	}

	//遊戲結束後UI的觸發動作............................

	//顯示所有資訊
	private void UI_Finish ()
	{
		UI_Slider_Level_dir (false);
		UI_Billboard_dir (true);

		//大於10 nextButton就隱藏
		if (DB.Select_Level_number >= DB.TOTAL_LEVEL)
			UI.Button_NextLevel.gameObject.SetActive (false);
		else
			UI.Button_NextLevel.gameObject.SetActive (true);
	}

	private void UI_GameOver ()
	{
		UI_Wrong_dir (true);
		UI_Slider_Level_dir (false);
	}

	private void UI_TimeOut ()
	{
		UI_TimeOut_dir (true);
		UI_Slider_Level_dir (false);
	}


	//GA套件的UI的觸發動作.........................

	void UI_GA_LevelMenu ()
	{
		UI_Select_Level_dir (false);
		UI_Slider_Level_dir (false);
	}

	//When Button CLick.............................

	private void UI_GameStart ()
	{
		UI_Slider_Level_dir (true);
		UI_Select_Level_dir (true);
	}

	private void UI_NextLevel ()
	{
		UI_Slider_Level_dir (true);
		UI_Billboard_dir (false);
	}

	private void UI_BackLevel ()
	{
		UI_Wrong_dir (false);
		UI_Slider_Level_dir (true);
	}

	private void UI_Again ()
	{
		UI_Slider_Level_dir (true);
		UI_Billboard_dir (false);
	}

	private void UI_LevelMenu ()
	{
		UI_Select_Level_dir (false);
		UI_Billboard_dir (false);
	}

	//UI direction................................

	private void UI_Select_Level_dir (bool Forward)
	{
//		if (Forward) {
//			TP_Select_Level = TweenPosition.Begin (UI.UI_Select_Level, 0.6f, new Vector3 (0, -780, 0));
//			TP_Select_Level.delay = 0;
//		} else
//			TP_Select_Level.PlayReverse ();
		UI_dir (Forward, false, UI.UI_Select_Level, ref TP_Select_Level, 0.6f, new Vector3 (0, -780, 0));
	}

	private void UI_Billboard_dir (bool Forward)
	{
//		UI.Billboard.SetActive (true);
//		if (Forward) {
//			TP_Billboard = TweenPosition.Begin (UI.Billboard, 0.6f, new Vector3 (0, -34, 0));
//			TP_Billboard.delay = 0;
//		} else {
//			TP_Billboard.PlayReverse ();
//			EventDelegate.Add (TP_Billboard.onFinished, () => UI.Billboard.SetActive (false), true);
//		}
		UI_dir (Forward, true, UI.Billboard, ref TP_Billboard, 0.6f, new Vector3 (0, -34, 0));
	}

	private void UI_Slider_Level_dir (bool Forward)
	{
//		if (Forward) {
//			TP_Slider_Level = TweenPosition.Begin (UI.UI_Slider_Level, 1f, new Vector3 (-535, -146, 0));
//			TP_Slider_Level.delay = 0;
//		} else
//			TP_Slider_Level.PlayReverse ();
		UI_dir (Forward, true, UI.UI_Slider_Level, ref TP_Slider_Level, 0.6f, new Vector3 (-535, -146, 0));
	}

	private void UI_Wrong_dir (bool Forward)
	{
//		UI.Wrong.SetActive (true);//顯示錯誤連篇資訊
//
//		if (Forward) {
//			TP_Wrong = TweenPosition.Begin (UI.Wrong, 0.6f, new Vector3 (0, -34, 0));
//			TP_Wrong.delay = 0;
//		} else {
//			TP_Wrong.PlayReverse ();
//			EventDelegate.Add (TP_Wrong.onFinished, () => UI.Wrong.SetActive (false), true);
//		}
		UI_dir (Forward, false, UI.Wrong, ref TP_Wrong, 0.6f, new Vector3 (0, -34, 0));
	}

	private void UI_TimeOut_dir (bool Forward)
	{
//		UI.TimeOut.SetActive (true);
//
//		if (Forward) {
//			TP_TimeOut = TweenPosition.Begin (UI.TimeOut, 0.6f, new Vector3 (0, -34, 0));
//			TP_TimeOut.delay = 0;
//		} else {
//			TP_TimeOut.PlayReverse ();
//			EventDelegate.Add (TP_TimeOut.onFinished, () => UI.TimeOut.SetActive (false), true);
//		}
		UI_dir (Forward, false, UI.TimeOut, ref TP_TimeOut, 0.6f, new Vector3 (0, -34, 0));
	}

	private void UI_dir (bool Forward, bool hidden, GameObject go, ref TweenPosition TP, float duration, Vector3 pos)
	{
		go.SetActive (true);

		if (Forward) {
			if (TP == null)
				TP = TweenPosition.Begin (go, duration, pos);
			else
				TP.PlayForward ();
			TP.delay = 0;
		} else {
			TP.PlayReverse ();
			//結束後隱藏
			if (hidden) {

				EventDelegate eventDelegate = new EventDelegate (this, "hidden");  

				eventDelegate.parameters [0] = new EventDelegate.Parameter (TP);

				EventDelegate.Add (TP.onFinished, eventDelegate, true);//oneshot=true
			}
		}
	}

	//隱藏
	private void hidden (TweenPosition TP)
	{
		TP.gameObject.SetActive (false);
	}

	//UIEventListener...................................

	//事件監聽
	private void ButtonEvent ()
	{
		//select_level.........................

		UIEventListener.Get (UI.Button_CONFIRM.gameObject).onClick = Btn_GameStart;
		UIEventListener.Get (UI.Button_UP.gameObject).onClick = Select_Level;
		UIEventListener.Get (UI.Button_DOWN.gameObject).onClick = Select_Level;

		//Billboard............................

		UIEventListener.Get (UI.Button_Menu.gameObject).onClick = Btn_LevelMenu;
		UIEventListener.Get (UI.Button_NextLevel.gameObject).onClick = Btn_NextLevel;
		UIEventListener.Get (UI.Button_Again.gameObject).onClick = Btn_Again;
		UIEventListener.Get (UI.Button_BackHome.gameObject).onClick = Btn_BackHome;

		//FeedBack.............................

		UIEventListener.Get (UI.Button_BackLevel.gameObject).onClick = Btn_BackLevel;

		//TimeOut..............................

		UIEventListener.Get (UI.Button_TimeOutBackHome.gameObject).onClick = Btn_BackHome;
	}

	//顯示答對錯Icon
	private void Results (GameObject parent, GameObject child)
	{
		GameObject go = GameObject.Instantiate (child) as GameObject;

		if (go != null && parent != null) {
			Transform t = go.transform;
			t.parent = parent.transform;
			go.GetComponent<UISprite> ().depth = 1;
			go.transform.localScale = DB.CheckedScale;
			go.transform.localPosition = new Vector3 (0, 0, 220);
			iTween.ScaleFrom (go, iTween.Hash ("scale", Vector3.zero));
			Destroy (go, 1f);
		}
	}

	//選擇關卡
	private void Select_Level (GameObject btn)
	{
		if (btn == UI.Button_UP.gameObject) {
			if (DB.Select_Level_number < DB.TOTAL_LEVEL) {
//				UI.Label_Level.text = (++DB.Select_Level_number).ToString ();
				DB.Select_Level_number++;
				Updated ();
			} else {
				DB.Select_Level_number = 1;
				Updated ();
			}

		}
	
		if (btn == UI.Button_DOWN.gameObject) {
			if (DB.Select_Level_number > 1) {
//				UI.Label_Level.text = (--DB.Select_Level_number).ToString ();
				DB.Select_Level_number--;
				Updated ();
			} else {
				DB.Select_Level_number = 10;
				Updated ();
			}
		}
	}

	//顯示答對率
	private void DisplayPercent ()
	{
		float sum = DB.BingoCount + DB.ErrorCount;
		float percent = DB.BingoCount / sum;
		UI.slider_percent.value = (!float.IsNaN (percent)) ? percent : 0;//if not NaN
//		UI.slider_percent.value = percent;
	}

	//顯示總共玩遊戲時間
	private void DisplayTime (float time)
	{
		TimeSpan timeSpan = TimeSpan.FromSeconds (time);
		UI.label_Time.text = timeSpan.Hours + "h " + timeSpan.Minutes + "m " + timeSpan.Seconds + "s ";
	}

	//顯示分數
	private void DisplayScore ()
	{
		UI.label_Bingo.text = DB.BingoCount.ToString ();
		UI.label_Error.text = DB.ErrorCount.ToString ();
	}

	//選完難度後設定關卡參數
	private void setLightTime ()
	{
		//設定亮燈時間
		DB.lighttime = tmp_lightTime - interval * (DB.Select_Level_number - 1);
		DB.darktime = tmp_darkTime - interval * (DB.Select_Level_number - 1);
	}

	//	//亮燈時間每次減少
	//	private void ReduceLightTime ()
	//	{
	//		DB.lighttime -= interval;
	//		DB.darktime -= interval;
	//	}

	//參數初始
	private void resetParameter ()
	{
		time = 0;
		feedbackCount = 0;
		TimeOutCount = 0;
		Suppress_Feedback = false;

		//static
		Level1_DB.Original_color = null;
		Level1_DB.Red_color = null;
		Level1_DB.Gray_color = null;
		Level1_DB.g_iRandom = UnityEngine.Random.Range (0, 7);
		//		Level1_DB.UFOList.Clear ();
		Level1_DB.UFO.Clear ();
		Level1_DB.UFO_Random.Clear ();

		//難度選單數字
		//DB.Select_Level_number = 1;
		DB.lighttime = tmp_lightTime;
		DB.darktime = tmp_darkTime;
		DB.RotationGroup_Index = 0;
		//DB.random = 0;
		//DB.g_iBalance = 0;
//		DB.g_iTempValue = 0;
		DB.BingoCount = 0;
		DB.ErrorCount = 0;
		DB.start = false;
		DB.LevelUP = false;
		DB.TimeOut = false;
	}
}
