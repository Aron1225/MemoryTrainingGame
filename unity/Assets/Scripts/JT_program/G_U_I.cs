using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G_U_I : MonoBehaviour
{
	protected UI_Element UI;
	protected Database DB;

	//TweenPosition......................

	TweenPosition TP_Billboard;
	TweenPosition TP_Wrong;
	TweenPosition TP_TimeOut;
	TweenPosition TP_Select_Level;
	TweenPosition TP_Slider_Level;

	//update number...........................

	///更新遊戲畫面上的數字
	public void Updated ()
	{
		UI.Label_Level.text = DB.Select_Level_number.ToString ();
	}

	//選擇難易度
	public void _Select_Level (GameObject btn)
	{
		if (btn == UI.Button_UP.gameObject) {
			if (DB.Select_Level_number < DB.TOTAL_LEVEL) {
				DB.Select_Level_number++;
				Updated ();
			} else {
				DB.Select_Level_number = 1;
				Updated ();
			}
		}

		if (btn == UI.Button_DOWN.gameObject) {
			if (DB.Select_Level_number > 1) {
				DB.Select_Level_number--;
				Updated ();
			} else {
				DB.Select_Level_number = 10;
				Updated ();
			}
		}
	}

	//遊戲結束後UI的觸發動作............................

	//顯示所有資訊
	public void UI_Finish ()
	{
		UI_Slider_Level_dir (false);
		UI_Billboard_dir (true);

		//大於10 nextButton就隱藏
		if (DB.Select_Level_number >= DB.TOTAL_LEVEL)
			UI.Button_NextLevel.gameObject.SetActive (false);
		else
			UI.Button_NextLevel.gameObject.SetActive (true);
	}

	public void UI_GameOver ()
	{
		UI_Wrong_dir (true);
		UI_Slider_Level_dir (false);
	}

	public void UI_TimeOut ()
	{
		UI_TimeOut_dir (true);
		UI_Slider_Level_dir (false);
	}

	//GA套件的UI的觸發動作.........................

	public void UI_GA_LevelMenu ()
	{
		UI_Select_Level_dir (false);
		UI_Slider_Level_dir (false);
	}

	//When Button CLick.............................

	public void UI_GameStart ()
	{
		UI_Slider_Level_dir (true);
		UI_Select_Level_dir (true);
	}

	public void UI_NextLevel ()
	{
		UI_Slider_Level_dir (true);
		UI_Billboard_dir (false);
	}

	public void UI_BackLevel ()
	{
		UI_Wrong_dir (false);
		UI_Slider_Level_dir (true);
	}

	public void UI_Again ()
	{
		UI_Slider_Level_dir (true);
		UI_Billboard_dir (false);
	}

	public void UI_LevelMenu ()
	{
		UI_Select_Level_dir (false);
		UI_Billboard_dir (false);
	}

	//UI direction................................

	private void UI_Select_Level_dir (bool Forward)
	{
		UI_dir (Forward, false, UI.Select_Level, ref TP_Select_Level, 0.6f, new Vector3 (0, -780, 0));
	}

	private void UI_Billboard_dir (bool Forward)
	{
		UI_dir (Forward, true, UI.Billboard, ref TP_Billboard, 0.6f, new Vector3 (0, -34, 0));
	}

	private void UI_Slider_Level_dir (bool Forward)
	{
		UI_dir (Forward, true, UI.Slider_Level, ref TP_Slider_Level, 0.6f, new Vector3 (-535, -146, 0));
	}

	private void UI_Wrong_dir (bool Forward)
	{
		UI_dir (Forward, true, UI.Wrong, ref TP_Wrong, 0.6f, new Vector3 (0, -34, 0));
	}

	private void UI_TimeOut_dir (bool Forward)
	{
		UI_dir (Forward, false, UI.TimeOut, ref TP_TimeOut, 0.6f, new Vector3 (0, -34, 0));
	}

	protected void UI_dir (bool Forward, bool hidden, GameObject go, ref TweenPosition TP, float duration, Vector3 TargetPos)
	{
		go.SetActive (true);

		if (Forward) {
			if (TP == null)
				TP = TweenPosition.Begin (go, duration, TargetPos);
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
}
