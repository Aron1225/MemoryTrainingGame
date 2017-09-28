using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;


public class Level1_Controller : Controller
{
	/*field*/

	//Level1自帶的資料
	Level1_DB L1DB;

	//RotationGroup方向
	private int dir = 1;

	//Getter...........................

	//是否TimeOut
	public bool IfTimeOut{ get { return L1DB.TimeOut; } }

	public Level1_DB useL1DB{ get { return L1DB; } }

	/*methods*/

	//Mono.............................

	public override void OnAwake ()
	{
		base.OnAwake ();
		this.L1DB = GetComponent<Level1_DB> (); 
		base.UI = GetComponent<UI_Element> ();
		base.GUI = GetComponent<Level1_GUI> ();
		base.GA = GetComponent<GA_Controller> ();
		base.DB = L1DB;
		Init ();
	}

	//遊戲狀態.........

	public override void Finish ()
	{
		base.Finish ();
		UFO.DestroyUFO (Level1_DB.UFOList.Count, 1f);//清空場上所有UFO
	}

	public override void GameOver ()
	{
		base.GameOver ();
		UFO.DestroyUFO (Level1_DB.UFOList.Count, 1f);//清空場上所有UFO
	}

	public override void TimeOut ()
	{
		base.TimeOut ();
		UFO.DestroyUFO (Level1_DB.UFOList.Count, 1f);//清空場上所有UFO
	}

	//遊戲功能流程觸發.........................

	public override void GameStart ()
	{
		base.GameStart ();
	}

	public override void LevelMenu (string str)
	{
		base.LevelMenu (str);
		UFO.DestroyUFO (Level1_DB.UFOList.Count, 1f);//清空場上所有UFO
	}

	public override void BackHome (int SceneNumber)
	{
		base.BackHome (SceneNumber);
	}

	public override void Again (string str)
	{
		base.Again (str);
		UFO.DestroyUFO (Level1_DB.UFOList.Count, 1f);//清空場上所有UFO
	}

	public override void Next ()
	{
		base.Next ();
	}

	public override void Back ()
	{
		base.Back ();
	}

	//重置..........................

	public override void Init ()
	{
		//base......................................

		//設定亂數種子
		UnityEngine.Random.InitState (System.Guid.NewGuid ().GetHashCode ());

		L1DB.WaitOneSecond = new WaitForSeconds (1f);
		L1DB.ResultScale = new Vector3 (140, 140, 0);
		L1DB.ResultPosition = Vector3.zero;
		L1DB.Compare = true;
		base.tmp_lightTime = L1DB.lighttime;
		base.tmp_darkTime = L1DB.darktime;
		base.interval = 0.05f;

		//self.......................................

		//載入UFO
		Level1_DB.LoadUFO = Resources.LoadAll<GameObject> ("JT/UFO_3D");

		//隨機值
		Level1_DB.g_iRandom = UnityEngine.Random.Range (0, Level1_DB.LoadUFO.Length);

		L1DB.WaitUntilUFOReady = new WaitUntil (() => Level1_DB.UFOList.All (list => !(list.m_isMoving)));

		//建置UFO位置
		UFO.UFO_group = L1DB.UFO_group;

		dir = 1;
	}

	//參數初始
	public override void resetParameter ()
	{
		time = 0;
		feedbackCount = 0;
		TimeOutCount = 0;
		Suppress_Feedback = false;

		//static
		Level1_DB.Original_color = null;
		Level1_DB.Red_color = null;
		Level1_DB.Gray_color = null;
		Level1_DB.g_iRandom = UnityEngine.Random.Range (0, Level1_DB.LoadUFO.Length);
		Level1_DB.UFO.Clear ();
		Level1_DB.UFO_Random.Clear ();

		L1DB.lighttime = base.tmp_lightTime;
		L1DB.darktime = base.tmp_darkTime;
		L1DB.BingoCount = 0;
		L1DB.ErrorCount = 0;
		L1DB.start = false;
		L1DB.LevelUP = false;
		L1DB.TimeOut = false;
		L1DB.RotationGroup_Index = 0;
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
		//關閉點擊
		UFO.AllColliderEnabled (enabled);
	}

	//tool..........................................

	public List<Vector3> Get_arrangement (int index)
	{
		return L1DB.arrangement [index];
	}

	//取得指定範圍地圖陣列(mapRange1,mapRange2)
	public List<List<Vector3>> Get_MapRange (int mapRange1, int mapRange2)
	{
		List<List<Vector3>> map = new List<List<Vector3>> ();

		for (int i = 0; i <= (mapRange2 - mapRange1); i++) {
			map.Add (L1DB.arrangement [i + mapRange1]);
		}

		return map;
	}

	public void Balance (List<Vector3> map, bool IgnoreBalanceIsZero = false)
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
				Level1_DB.UFOList [i].moveTo (1f, (Vector3)map [i], true, 0.1f);
	}

	//旋轉群組.........................................
	
	//創造旋轉群組
	public Level1_RotationFix CreateGroup ()
	{
		GameObject go = new GameObject ("G" + L1DB.RotationGroup_Index++);
	
		go.transform.parent = L1DB.UFO_group;
	
		go.transform.localScale = Vector3.one;
	
		Level1_RotationFix rf = go.AddComponent<Level1_RotationFix> ();
	
		rf.Group = go;
	
		rf.direction = dir *= -1;
	
		return rf;
	}
			
	//移除整個RotationGroup物件，並移除所有子物件(UFO)
	public void DestoryGroup (Level1_RotationFix rf)
	{
		UFO.DestroyUFO (rf.transform.childCount);
		MonoBehaviour.Destroy (rf.gameObject, 0.5f);
		L1DB.RotationGroup_Index--;
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
	
				L1DB.arrangement.Add (new List<Vector3> ());
	
				p1 = int.Parse (parts [0]);
			}
			//加入座標
			L1DB.arrangement [int.Parse (parts [0])].Add (new Vector3 (float.Parse (parts [1]), float.Parse (parts [2]), float.Parse (parts [3])));
		}
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
			if (Mathf.FloorToInt (tmpTime) == L1DB.TimeOut_Time) {

				L1DB.Compare = false;//使AnswerCompare中的while跳過
				showResults (false);
				Record (false);

				if (++TimeOutCount == 3) {
					L1DB.TimeOut = true;
				}
				yield break;
			}
			yield return null;
		}	
	}
}
