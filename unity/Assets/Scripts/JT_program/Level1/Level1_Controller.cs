using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Linq;

public class Level1_Controller:MonoBehaviour
{
	//執行GameStart的方法
	public UIEventListener.VoidDelegate StartGameLoop;

	Level1_UI UI;
	Level1_DB DB;

	TweenPosition Billboard;
	TweenPosition Wrong;
	TweenPosition uiTimeOut;
	TweenPosition UI_Select_Level;
	TweenPosition UI_Slider_Level;

	//Coroutine........................

	//使用Coroutine物件,在使用Coroutine物件中有while情況下也可以直接StopCoroutine
	Coroutine RecordTime;
	Coroutine CountDown;

	//bool.............................

	//	private bool End;
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

	void Awake ()
	{
		UI = GetComponent<Level1_UI> ();
		DB = GetComponent<Level1_DB> (); 
		Init ();
	}

	void Start ()
	{
		ButtonEvent ();//註冊按鈕事件
	}

	void Update ()
	{
		
	}

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

	//public..................................................................

	//遊戲結束,完成遊戲後顯示資訊
	public void Finish ()
	{	
		Suppress_Feedback = true;//壓制Feedback()執行
		StopCoroutine (RecordTime);//計時停止
		UI_Finish ();//顯示所有資訊
		DisplayPercent ();//答對率
		DisplayTime (time);//時間
		DisplayScore ();//統計
		UFO.DestroyUFO (Level1_DB.UFOList.Count, 1f);//清空場上所有UFO
	}

	//錯誤9次
	public void GameOver ()
	{
		StopCoroutine (RecordTime);//計時停止
		UI_GameOver ();
		UFO.DestroyUFO (Level1_DB.UFOList.Count, 1f);//清空場上所有UFO
	}

	//遊戲閒置
	public void TimeOut ()
	{
		StopCoroutine (RecordTime);//計時停止
		UI_TimeOut ();
		UFO.DestroyUFO (Level1_DB.UFOList.Count, 1f);//清空場上所有UFO
	}

	//閒置倒數
	public void CountDownStart ()
	{
		CountDown = StartCoroutine (_CountDown ());	
	}

	//設定SliderBar
	public void DisplaySliderBar ()
	{
		float increase = (DB.Select_Level_number) * 1f / DB.TOTAL_LEVEL;
		UI.slider_level.value = increase;
	}

	//設定SliderBar
	public void DisplaySliderBar (Func<float> increase)
	{
		UI.slider_level.value = increase ();
	}

	//是否TimeOut
	public bool IfTimeOut ()
	{
		return DB.TimeOut;
	}

	//	//難度提升
	//	public void LevelUp ()
	//	{
	//		ReduceLightTime ();//亮燈時間減少
	//	}

	//回饋,連錯3題增加亮燈時間,再錯3題減少random數,再錯3題返回上一關
	public bool Feedback (bool result)
	{
		bool bo = false;
		//避免IfTheEnd()與Feedback()同時執行
		if (!Suppress_Feedback) {

			if (result) {
				feedbackCount = 0;
				return false;
			} 

			feedbackCount++;

			if (feedbackCount == 3) {
				DB.lighttime = Mathf.Clamp (DB.lighttime + 0.5f, 0.1f, 2f);
				DB.darktime = Mathf.Clamp (DB.darktime + 0.5f, 0.1f, 2f);
			} 

			if (feedbackCount == 6) {
				DB.random = Mathf.Clamp (DB.random--, 2, 10);
			}

			if (feedbackCount == 9) {
				bo = true;
			}
		}
		return bo;
	}

	//創造旋轉群組
	public GameObject CreateGroup (Transform parent)//parent->RotationGroup物件的parent
	{
		GameObject go = new GameObject ("G" + DB.RotationGroup_Index++);
	
		go.transform.parent = parent;
	
		go.transform.localScale = Vector3.one;
	
		Level1_RotationFix rf = go.AddComponent<Level1_RotationFix> ();
	
		rf.Group = go;
	
		rf.direction = dir *= -1;
	
		DB.RotationGroup.Add (rf);
	
		return go;
	}

	//移除整個RotationGroup物件，並移除所有子物件(UFO)
	public void DestoryGroup (Level1_RotationFix rf)
	{
		UFO.DestroyUFO (rf.transform.childCount);
		MonoBehaviour.Destroy (rf.gameObject, 0.5f);
		DB.RotationGroup_Index--;
	}

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

	// 紀錄對錯次數
	public void Record (bool result)
	{
		if (result)
			DB.BingoCount++;
		else
			DB.ErrorCount++;
	}

	//TimeOutCount歸零
	public void ResetTimeOutCount ()
	{
		TimeOutCount = 0;
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

	//取得指定範圍地圖陣列(mapRange1,mapRange2)
	public List<List<Vector3>> GetMapRange (int mapRange1, int mapRange2)
	{
		List<List<Vector3>> map = new List<List<Vector3>> ();

		for (int i = 0; i <= (mapRange2 - mapRange1); i++) {
			map.Add (DB.arrangement [i + mapRange1]);
		}

		return map;
	}

	//預測下一次是否結束遊戲
	public bool IfTheEnd (int LevelCount, int Loop)
	{
		if (LevelCount++ != Loop)
			return false;

		if ((DB.Select_Level_number) != DB.TOTAL_LEVEL)
			return false;

		Finish ();
		//壓制Feedback()執行
		Suppress_Feedback = true;

		return true;
	}

	//預測下一次是否結束遊戲
	public bool IfTheEnd (Func<bool> TheEnd)
	{
		if (!TheEnd ())
			return false;

		Finish ();
		//壓制Feedback()執行
		Suppress_Feedback = true;

		return true;
	}



	//private..................................................................

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

		time = 0;
		dir = 1;
		interval = 0.05f;
		TimeOutCount = 0;
		feedbackCount = 0;
		Suppress_Feedback = false;

		tmp_lightTime = DB.lighttime;
		tmp_darkTime = DB.darktime;
	}

	//Controller開始設置
	private void ControllerStart ()
	{
		RecordTime = StartCoroutine (_RecordTime ());//開始計時
		setLightTime ();//選完難度後設定關卡參數
	}

	//Button......................................

	//遊戲開始
	private void GameStart (GameObject go)
	{
		StartGameLoop (go);
		ControllerStart ();
		UI_GameStart ();
	}

	//下一關
	private void NextLevel (GameObject go)
	{
		Next ();
		resetParameter ();//參數初始
		StartGameLoop (go);
		ControllerStart ();
		UI_NextLevel ();
	}

	private void Next ()
	{
//		if (DB.Select_Level_number >= 9)
//			DB.Select_Level_number += 2;
//		else
		DB.Select_Level_number++;
		UI.Label_Level.text = (int.Parse (UI.Label_Level.text) + 1).ToString ();
	}

	//上一關
	private void BackLevel (GameObject go)
	{
		Back ();
		resetParameter ();//參數初始
		StartGameLoop (go);
		ControllerStart ();
		UI_BackLevel ();
	}

	private void Back ()
	{ 
		DB.Select_Level_number = Mathf.Max (1, DB.Select_Level_number--);
		UI.Label_Level.text = (Mathf.Max (1, (int.Parse (UI.Label_Level.text) - 1))).ToString ();
	}

	//再玩一次
	private void Again (GameObject go)
	{
		resetParameter ();//參數初始
		StartGameLoop (go);
		ControllerStart ();
		UI_Again ();
	}
		
	//回到選擇難度
	private void LevelMenu (GameObject go)
	{
		resetParameter ();//參數初始
		UI_LevelMenu ();
	}

	//回到主畫面
	private void BackHome (GameObject go)
	{
		AsyncOperation LoadScene = SceneManager.LoadSceneAsync (0);
	}

	//When the game is over...........................

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


	public void UI_Billboard_dir (bool Forward)
	{
		UI.Billboard.SetActive (true);
		if (Forward) {
			Billboard = TweenPosition.Begin (UI.Billboard, 0.6f, new Vector3 (0, -34, 0));
			Billboard.delay = 0;
		} else {
			Billboard.PlayReverse ();
			EventDelegate.Add (Billboard.onFinished, () => UI.Billboard.SetActive (false), true);
		}
	}

	private void UI_Select_Level_dir (bool Forward)
	{
		if (Forward) {
			UI_Select_Level = TweenPosition.Begin (UI.UI_Select_Level, 0.6f, new Vector3 (0, -780, 0));
			UI_Select_Level.delay = 0;
		} else
			UI_Select_Level.PlayReverse ();
	}

	private void UI_Slider_Level_dir (bool Forward)
	{
		if (Forward) {
			UI_Slider_Level = TweenPosition.Begin (UI.UI_Slider_Level, 1f, new Vector3 (-535, -146, 0));
			UI_Slider_Level.delay = 0;
		} else
			UI_Slider_Level.PlayReverse ();
	}

	public void UI_Wrong_dir (bool Forward)
	{
		UI.Wrong.SetActive (true);//顯示錯誤連篇資訊

		if (Forward) {
			Wrong = TweenPosition.Begin (UI.Wrong, 0.6f, new Vector3 (0, -34, 0));
			Wrong.delay = 0;
		} else {
			Wrong.PlayReverse ();
			EventDelegate.Add (Wrong.onFinished, () => UI.Wrong.SetActive (false), true);
		}
	}

	private void UI_TimeOut_dir (bool Forward)
	{
		UI.TimeOut.SetActive (true);

		if (Forward) {
			uiTimeOut = TweenPosition.Begin (UI.TimeOut, 0.6f, new Vector3 (0, -34, 0));
			uiTimeOut.delay = 0;
		} else {
			uiTimeOut.PlayReverse ();
			EventDelegate.Add (uiTimeOut.onFinished, () => UI.TimeOut.SetActive (false), true);
		}
	}

	//事件監聽
	private void ButtonEvent ()
	{
		UIEventListener.Get (UI.Button_CONFIRM.gameObject).onClick = GameStart;
		UIEventListener.Get (UI.Button_Again.gameObject).onClick = Again;
		UIEventListener.Get (UI.Button_NextLevel.gameObject).onClick = NextLevel;
		UIEventListener.Get (UI.Button_BackLevel.gameObject).onClick = BackLevel;
		UIEventListener.Get (UI.Button_BackHome.gameObject).onClick = BackHome;
		UIEventListener.Get (UI.Button_TimeOutBackHome.gameObject).onClick = BackHome;
		UIEventListener.Get (UI.Button_Menu.gameObject).onClick = LevelMenu;
		UIEventListener.Get (UI.Button_UP.gameObject).onClick = Select_Level;
		UIEventListener.Get (UI.Button_DOWN.gameObject).onClick = Select_Level;
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
//		if (btn == UI.Button_UP.gameObject) {
//			if (DB.Select_Level_number < DB.TOTAL_LEVEL + 1) {
//				if (DB.Select_Level_number < 9)
//					UI.Label_Level.text = (++DB.Select_Level_number).ToString ();
//				else {
//					int txt = int.Parse (UI.Label_Level.text);
//					UI.Label_Level.text = (++txt).ToString ();
//					DB.Select_Level_number += 2;
//				}
//			}
//		}
//
//		if (btn == UI.Button_DOWN.gameObject) {
//			if (DB.Select_Level_number > 1) {
//				if (DB.Select_Level_number > 9)
//					UI.Label_Level.text = (DB.Select_Level_number -= 2).ToString ();
//				else
//					UI.Label_Level.text = (--DB.Select_Level_number).ToString ();
//			}
//		}
		if (btn == UI.Button_UP.gameObject) {
			if (DB.Select_Level_number < DB.TOTAL_LEVEL)
				UI.Label_Level.text = (++DB.Select_Level_number).ToString ();
		}
	
		if (btn == UI.Button_DOWN.gameObject) {
			if (DB.Select_Level_number > 1)
				UI.Label_Level.text = (--DB.Select_Level_number).ToString ();
		}
	}


	//顯示答對率
	private void DisplayPercent ()
	{
		float sum = DB.BingoCount + DB.ErrorCount;
		float percent = DB.BingoCount / sum;
		UI.slider_percent.value = percent;
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
		//		DB.random = 0;
		DB.g_iBalance = 0;
		DB.g_iTempValue = 0;
		DB.BingoCount = 0;
		DB.ErrorCount = 0;
		DB.start = false;
		DB.LevelUP = false;
		DB.TimeOut = false;
		DB.RotationGroup.Clear ();
	}
}
