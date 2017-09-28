using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;


public class Level2_Controller : Controller
{
	/*field*/

	//Level2自帶的資料
	Level2_DB L2DB;

	//Getter...........................

	//是否TimeOut
	public bool IfTimeOut{ get { return L2DB.TimeOut; } }

	public Level2_DB useL2DB{ get { return L2DB; } }

	/*methods*/

	//Mono.............................

	public override void OnAwake ()
	{
		base.OnAwake ();
		L2DB = GetComponent<Level2_DB> ();  
		base.UI = GetComponent<UI_Element> ();
		base.GUI = GetComponent<Level2_GUI> ();
		base.GA = GetComponent<GA_Controller> ();
		base.DB = L2DB;
		Init ();
	}

	//遊戲狀態.........

	public override void Finish ()
	{
		base.Finish ();
	}

	public override void GameOver ()
	{
		base.GameOver ();
	}

	public override void TimeOut ()
	{
		base.TimeOut ();
	}

	//重置..........................

	//初始
	public override void Init ()
	{
		//設定亂數種子
		UnityEngine.Random.InitState (System.Guid.NewGuid ().GetHashCode ());

		base.DB.WaitOneSecond = new WaitForSeconds (1f);

		base.DB.ResultScale = new Vector3 (140, 140, 0);

		base.DB.ResultPosition = Vector3.zero;

		base.DB.Compare = true;

		interval = 0.05f;

		base.tmp_lightTime = base.DB.lighttime;
		base.tmp_darkTime = base.DB.darktime;
	}

	//參數初始
	public override void resetParameter ()
	{
		time = 0;
		feedbackCount = 0;
		TimeOutCount = 0;
		Suppress_Feedback = false;

		Level2_DB.BALL.Clear ();
		Level2_DB.BALL_Random.Clear ();

		base.DB.lighttime = base.tmp_lightTime;
		base.DB.darktime = base.tmp_darkTime;

		base.DB.BingoCount = 0;
		base.DB.ErrorCount = 0;
		base.DB.start = false;
		base.DB.LevelUP = false;
		base.DB.TimeOut = false;

		Level2_DB.BALLList.ForEach (go => go.Original (false));
	}

	//Feedback..........................................

	//回饋,連錯3題增加亮燈時間,再錯3題減少random數,再錯3題返回上一關
	public override bool Feedback ()
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

	//點擊觸發......................................

	//碰撞器開關
	public override void AllColliderEnabled (bool enabled)
	{
		Level2_DB.BALLList.ForEach (go => go.GetComponent<SphereCollider> ().enabled = enabled);
	}

	//IEnumerator.........................

	//紀錄時間
	public override IEnumerator _RecordTime ()
	{
		while (true) {
			time += Time.deltaTime;
			yield return null;
		}
	}

	//開始倒數計時
	public override IEnumerator _CountDown ()
	{
		float tmpTime = 0;

		int tmpCount = Level2_DB.BALL.Count;

		//當未作答至指定數量
		while (Level2_DB.BALL.Count != Level2_DB.BALL_Random.Count) {

			//當按下時重新倒數
			if (tmpCount != Level2_DB.BALL.Count) {
				tmpCount = Level2_DB.BALL.Count;
				tmpTime = 0;
			}

			tmpTime += Time.deltaTime;//增加時間

			//到達閒置時間
			if (Mathf.FloorToInt (tmpTime) == base.DB.TimeOut_Time) {

				base.DB.Compare = false;//使AnswerCompare中的while跳過
				AllColliderEnabled (false);
				showResults (false);
				Record (false);

				if (++TimeOutCount == 3) {
					base.DB.TimeOut = true;
				}
				yield break;
			}
			yield return null;
		}	
	}
}
