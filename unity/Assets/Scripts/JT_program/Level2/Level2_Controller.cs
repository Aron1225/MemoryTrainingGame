using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;
using System;

public class Level2_Controller : MonoBehaviour
{
	Level2_UI UI;
	Level2_DB DB;

	//對錯紀錄
	private int feedbackCount;
	//總遊戲時間
	private float time;
	//避免IfTheEnd()與Feedback()同時執行
	private bool Suppress_Feedback;

	private CustomRotation Main;
	private CustomRotation[] Cups;

	void Awake ()
	{
		UI = GetComponent<Level2_UI> ();
		DB = GetComponent<Level2_DB> (); 
		AddListener ();
		Init ();
	}

	void Start ()
	{
		
	}

	void FixedUpdate ()
	{
		time += Time.deltaTime;
	}

	//public..................................................................

	//預測下一次是否結束遊戲
	public bool IfTheEnd (int LevelCount, int Loop)
	{
		if (LevelCount++ % Loop != 0)
			return false;

		if ((DB.index) != DB.MaxLevel)
			return false;

		Finish ();
		//壓制Feedback()執行
		Suppress_Feedback = true;

		return true;
	}

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
				DB.lighttime = (DB.lighttime <= 2f) ? DB.lighttime + 0.3f : DB.lighttime;
				DB.darktime = (DB.darktime <= 2f) ? DB.darktime + 0.3f : DB.darktime;
			} 

			if (feedbackCount == 6) {
				DB.random--;
			} 

			if (feedbackCount == 9) {
				GameOver ();
				bo = true;
			}
		}
		return bo;
	}

	//設定SliderBar
	public void DisplaySliderBar ()
	{
//		float increase = (DB.arrangement_index + 1) * 1f / DB.arrangement.Count;
//		UI.slider_level.value = increase;
	}

	//歸位UI
	public void  Select_Slider_init ()
	{
		TweenPosition.Begin (UI.UI_Select_Level, 0.6f, new Vector3 (0, -780, 0)).delay = 0;
		TweenPosition.Begin (UI.UI_Slider_level, 1f, new Vector3 (-535, -146, 0));
	}

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
	public bool Compare (List<BALL> BALL, List<BALL> BALL_Random)
	{
		if (BALL.Count != BALL_Random.Count)
			return false;

		bool result = true;

		for (int i = 0; i <= BALL.Count - 1; i++) {
			if (BALL [i] != BALL_Random [i]) {
				result = false;
				break;
			}
		}
		return result;
	}

	public void AllColliderEnabled (bool enabled)
	{
		Level2_DB.BALLList.ForEach (go => go.GetComponent<SphereCollider> ().enabled = enabled);
	}

	//	Func<int> 表示無參，傳回值為int的委託
	//	Func<object,string,int> 表示傳入參數為object, string 傳回值為int的委託
	//	Func<int,string> test = i => i.ToString ();

	public Action Main_Cylinder_Rotation (float speed, bool Clockwise)
	{
		if (Main == null)
			Main = DB.Main_Cylinder.AddComponent<CustomRotation> ();

		return set_Rotation (new CustomRotation[]{ Main }, speed, Clockwise);//回傳容器
//		return set_Rotation (new GameObject[]{ DB.Main_Cylinder }, speed, Clockwise);
	}

	public Action Cups_Rotation (float speed, bool Clockwise)
	{
		if (Cups == null) {
			Cups = new CustomRotation[DB.Cups.Length];
			for (int i = 0; i < Cups.Length; i++) {
				Cups [i] = DB.Cups [i].AddComponent<CustomRotation> ();
			}
		}

		return set_Rotation (Cups, speed, Clockwise);//回傳容器
//		return set_Rotation (DB.Cups, speed, Clockwise);//回傳容器
	}

	public void StartRotation (Action total)
	{
		Stop_Rotation ();//enabled=false 所有旋轉腳本
		if (total != null)
			total.Invoke ();
	}

	//private..................................................................

	//回到主畫面
	private void BackHome (GameObject go)
	{
		AsyncOperation LoadScene = SceneManager.LoadSceneAsync (6);
	}

	//上一關
	private void BackLevel (GameObject go)
	{
		int scene = SceneManager.GetActiveScene ().buildIndex;
		AsyncOperation LoadScene = SceneManager.LoadSceneAsync (scene - 1);
	}

	//下一關
	private void nextLevel (GameObject go)
	{
		int scene = SceneManager.GetActiveScene ().buildIndex;
		AsyncOperation LoadScene = SceneManager.LoadSceneAsync (scene + 1);
	}

	//再玩一次
	private void Again (GameObject go)
	{
		int scene = SceneManager.GetActiveScene ().buildIndex;
		SceneManager.LoadScene (scene);
	}

	//事件監聽
	private void AddListener ()
	{
		UIEventListener.Get (UI.Button_BackHome1.gameObject).onClick = BackHome;
		UIEventListener.Get (UI.Button_BackHome2.gameObject).onClick = BackHome;
		UIEventListener.Get (UI.Button_Again.gameObject).onClick = Again;
		UIEventListener.Get (UI.Button_NextLevel.gameObject).onClick = nextLevel;
		UIEventListener.Get (UI.Button_BackLevel.gameObject).onClick = BackLevel;
		UIEventListener.Get (UI.Button_UP.gameObject).onClick = select_Level;
		UIEventListener.Get (UI.Button_DOWN.gameObject).onClick = select_Level;
	}
	//初始
	private void Init ()
	{
		//設定亂數種子
		UnityEngine.Random.InitState (System.Guid.NewGuid ().GetHashCode ());
		DB.WaitOneSecond = new WaitForSeconds (1f);
		DB.CheckedScale = new Vector3 (140, 140, 0);
		feedbackCount = 0;
		time = 0;
		Suppress_Feedback = false;
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
	private void select_Level (GameObject btn)
	{
		if (btn == UI.Button_UP.gameObject && DB.index < 4)
			DB.index++;
		if (btn == UI.Button_DOWN.gameObject && DB.index > 0)
			DB.index--;

		UI.Label_Level.text = (DB.index + 1).ToString ();
	}
	//完成遊戲後顯示資訊
	private void Finish ()
	{
		UI.Billboard.SetActive (true);
		DisplayPercent ();//答對率
		DisplayTime (time);//時間
		DisplayScore ();//統計
		SmoothStop ();//旋轉平滑停止
	}

	//錯誤9次
	private void GameOver ()
	{
		UI.Wrong.SetActive (true);
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

	//設定旋轉參數
	private Action set_Rotation (CustomRotation[] CustomRotation, float speed, bool Clockwise)
	{
		Action method = null;//方法容器

		for (int i = 0; i < CustomRotation.Length; i++) {

			var CR = CustomRotation [i];

			//將方法累加到容器
			method += () => {
				CR.enabled = true;
				CR.speed = speed;//設定旋轉速度
				CR.setDirection (Clockwise);//設定旋轉方向
			};
		}
		return  method;//回傳容器
	}

	//設定旋轉參數
	//	private Action set_Rotation (GameObject[] Rotation_go, float speed, bool Clockwise)
	//	{
	//		Action method = null;//方法容器
	//
	//		for (int i = 0; i < Rotation_go.Length; i++) {
	//
	//			var go = Rotation_go [i];
	//
	//			CustomRotation CR = go.GetComponent<CustomRotation> ();
	//
	//			if (CR == null) {
	//				//將方法指定到容器
	//				method += () => CR = go.AddComponent<CustomRotation> ();//掛上旋轉腳本
	//			} else {
	//				//將方法指定到容器
	//				method += () => CR.enabled = true;
	//			}
	//
	//			//將方法累加到容器
	//			method += () => {
	//				CR.speed = speed;//設定旋轉速度
	//				CR.setDirection (Clockwise);//設定旋轉方向
	//			};
	//		}
	//		return  method;//回傳容器
	//	}

	//關閉所有的旋轉
	private void Stop_Rotation ()
	{
		if (Main != null)
			Main.enabled = false;
		if (Cups != null) {
			for (int i = 0; i < DB.Cups.Length; i++) {
				if (Cups [i] != null)
					Cups [i].enabled = false;
			}
		}
	}

	private void SmoothStop ()
	{
		Main.SmoothStop ();
	}
}
