using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public abstract class Controller : MonoBehaviour
{
	/*field*/

	protected Database DB;
	protected UI_Element UI;
	protected G_U_I GUI;
	protected GA_Controller GA;

	//Coroutine........................

	//使用Coroutine物件,在使用Coroutine物件中有while情況下也可以直接StopCoroutine
	Coroutine RecordTime;
	Coroutine CountDown;

	//bool.............................

	//避免IfTheEnd()與Feedback()同時執行
	protected bool Suppress_Feedback;

	//int.............................

	//閒置次數
	protected int TimeOutCount;
	//回饋對錯紀錄
	protected int feedbackCount;

	//float.............................

	//存放各關的起始值
	protected float tmp_lightTime;
	protected float tmp_darkTime;

	//總遊戲時間
	protected float time;
	//每增加難度亮燈減少的時間
	protected float interval;

	//IEnumerator.........................

	//紀錄時間
	public abstract IEnumerator _RecordTime ();

	//開始倒數計時
	public abstract IEnumerator _CountDown ();

	//abstract function.....................

	//初始
	public abstract void Init ();
	//參數初始
	public abstract void resetParameter ();

	public abstract void AllColliderEnabled (bool enabled);

	public abstract bool Feedback ();

	//Mono.............................

	void Awake ()
	{
		OnAwake ();
	}

	public virtual void OnAwake ()
	{
		#if UNITY_EDITOR
		Debug.logger.logEnabled = true;
		#else
		Debug.logger.logEnabled = false;
		#endif
	}

	//public..................................................................

	//遊戲結束,完成遊戲後顯示資訊
	public virtual void Finish ()
	{	
		GUIAnimSystemFREE.Instance.EnableAllButtons (false);
		StopAllCoroutines ();
		Suppress_Feedback = true;//壓制Feedback()執行
		DisplayPercent ();//答對率
		DisplayTime (time);//時間
		DisplayScore ();//統計
		GUI.UI_Finish ();//顯示所有資訊
		GA.HideAllGUIs ();
	}

	//錯誤9次
	public virtual void GameOver ()
	{
		GUIAnimSystemFREE.Instance.EnableAllButtons (false);
		StopAllCoroutines ();
		GUI.UI_GameOver ();
		GA.HideAllGUIs ();
	}

	//遊戲閒置
	public virtual void TimeOut ()
	{
		GUIAnimSystemFREE.Instance.EnableAllButtons (false);
		StopAllCoroutines ();
		GUI.UI_TimeOut ();
		GA.HideAllGUIs ();
	}

	//SliderBar.....................................

	//設定SliderBar
	public void DisplaySliderBar ()
	{
		float increase = (DB.Select_Level_number) * 1f / DB.TOTAL_LEVEL;
		UI.slider_level.value = increase;
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
			Results (UI.Object, UI.GameObject_Bingo);
		else
			Results (UI.Object, UI.GameObject_Error);
	}

	public bool Compare<T> (List<T> list1, List<T> list2)
	{
		//型態不一致
		if (list1.GetType () != list2.GetType ())
			return false;

		//數量不一致
		if (list1.Count != list2.Count)
			return false;

		bool result = true;

		for (int i = 0; i <= list1.Count - 1; i++) {
			if (!list1 [i].Equals (list2 [i])) {
				result = false;
				break;
			}
		}

		return result;
	}

	//遊戲按鈕...............................

	public virtual void GameStart ()
	{
		GUIAnimSystemFREE.Instance.EnableAllButtons (true);
		RecordTime = StartCoroutine (_RecordTime ());//開始計時
		setLightTime ();//選完難度後設定關卡參數
		GUI.UI_GameStart ();
		GA.start ();//MoveIn GA套件
	}

	public virtual void LevelMenu (string str)
	{
		StopAllCoroutines ();
		AllColliderEnabled (false);
		resetParameter ();

		if (str == "GA") {
			GUI.UI_GA_LevelMenu ();
			GA.HideAllGUIs ();
		} else
			GUI.UI_LevelMenu ();
	}

	public virtual void BackHome (int SceneNumber)
	{
		resetParameter ();
		SceneManager.LoadScene (SceneNumber);
	}

	public virtual void Again (string str)
	{
		GUIAnimSystemFREE.Instance.EnableAllButtons (true);
		StopAllCoroutines ();
		AllColliderEnabled (false);
		resetParameter ();
		if (str == "GA")
			GA.ToggleButton_1 ();
		else
			GUI.UI_Again ();
	}

	public virtual void Next ()
	{
		resetParameter ();
		GUI.UI_NextLevel ();
	}

	public virtual void Back ()
	{
		resetParameter ();
		GUI.UI_BackLevel ();
	}

	//private..................................................................

	//顯示答對錯Icon
	private void Results (GameObject parent, GameObject child)
	{
		GameObject go = GameObject.Instantiate (child) as GameObject;

		if (go != null && parent != null) {
			Transform t = go.transform;
			t.parent = parent.transform;
			//go.GetComponent<UISprite> ().depth = 1;
			go.transform.localScale = DB.ResultScale;
			go.transform.localPosition = DB.ResultPosition;
			iTween.ScaleFrom (go, iTween.Hash ("scale", Vector3.zero));
			Destroy (go, 1f);
		}
	}

	//顯示答對率
	private void DisplayPercent ()
	{
		float sum = DB.BingoCount + DB.ErrorCount;
		float percent = DB.BingoCount / sum;
		UI.slider_percent.value = (!float.IsNaN (percent)) ? percent : 0;//if not NaN
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
}
