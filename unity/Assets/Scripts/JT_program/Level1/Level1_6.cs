using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;
using System.Threading;
using System;


public class Level1_6 : Level1_DataBase
{
//	public int random = 3;
//	public float lighttime;
//	public float darktime;
//
//	private int index;
//	private bool play;
//	private float time;
//	private int feedbackCount;
//	private int Loop;
//	private int LevelCount;
//	private float angle;
//
//	List<Vector3> RandPos = new List<Vector3> ();
//	//	public List<Level1_AI> AI = new List<Level1_AI> ();
//
//	public float x = -90;
//	public float y = -90;
//	public float z;
//
//
//	public static void UFO_OnClick (Level1_UFO ufo)
//	{
//		if (ufo.m_bToggle) {
//
//			ufo.Gray ();
//
////			ufo.Original ();
//
//			//加入UFO陣列
//			UFO.Add (ufo);
//		}
//	}
//
//	void Awake ()
//	{
//		play = true;
//		time = 0;
//		Loop = 3;
//		index = 0;
//		angle = 0;
//		LevelCount = 0;
//		feedbackCount = 0;
//	}
//
//	void Start ()
//	{
//		//遊戲開始
//		StartCoroutine (GameStart ());
//	}
//
//	void FixedUpdate ()
//	{
//		RecordTime ();
//		AI ();
//	}
//
//	void AI ()
//	{
//		for (int i = 0; i < UFO_group.childCount; i++) {
//			GameObject ufo = UFO_group.GetChild (i).gameObject;
//			Rotate (ufo);
//			move (ufo);
//			collision (ufo);
//		}
//	}
//
//	//旋轉
//	void Rotate (GameObject ufo)
//	{
//		if (Time.frameCount % 100 == 0)
//			angle = UnityEngine.Random.Range (-0.5f, 0.5f);
//
//		ufo.transform.rotation *= Quaternion.AngleAxis (angle, transform.up);
//	}
//
//	//向上移動
//	void move (GameObject ufo)
//	{
//		ufo.transform.Translate (transform.forward * Time.deltaTime * 0.1f, Space.Self);//向上
//	}
//		
//	//偵測碰撞牆壁
//	void collision (GameObject ufo)
//	{
//		Vector3 rotation = ufo.transform.eulerAngles;
//		float pos_X = ufo.transform.localPosition.x;
//		float pos_Y = ufo.transform.localPosition.y;
//		SphereCollider sc = ufo.GetComponent<SphereCollider> ();
//
//		//上
//		if (pos_Y >= 320)
//			ufo.transform.rotation = Quaternion.Euler (-rotation.x, (rotation.y == 90) ? 90 : -90, -90);
//
//		//下
//		if (pos_Y <= -320)
//			ufo.transform.rotation = Quaternion.Euler (-rotation.x, (rotation.y == 90) ? 90 : -90, -90);
//
//		//左
//		if (pos_X <= -560)
//			ufo.transform.rotation = Quaternion.Euler (ufo.transform.eulerAngles.x, 90, -90);
//
//		//右
//		if (pos_X >= 560)
//			ufo.transform.rotation = Quaternion.Euler (ufo.transform.eulerAngles.x, -90, -90);
//
//		
////		Vector3 rotation = ai.gameObject.transform.eulerAngles;
////		float pos_X = ai.gameObject.transform.localPosition.x;
////		float pos_Y = ai.gameObject.transform.localPosition.y;
////
////		//上
////		if (pos_Y >= 320)
////			ai.gameObject.transform.rotation = Quaternion.Euler (-rotation.x, (rotation.y == 90) ? 90 : -90, -90);
////		
////		//下
////		if (pos_Y <= -320)
////			ai.gameObject.transform.rotation = Quaternion.Euler (-rotation.x, (rotation.y == 90) ? 90 : -90, -90);
////
////		//左
////		if (pos_X <= -560)
////			ai.gameObject.transform.rotation = Quaternion.Euler (ai.gameObject.transform.eulerAngles.x, 90, -90);
////
////		//右
////		if (pos_X >= 560)
////			ai.gameObject.transform.rotation = Quaternion.Euler (ai.gameObject.transform.eulerAngles.x, -90, -90);
//	}
//
//	void OnDestroy ()
//	{
//		Debug.Log ("OnDestroy");
//		Level1_Tools.onDestroy ();
//	}
//
//	public void RecordTime ()
//	{
//		time += Time.deltaTime;
//	}
//
//	public void BackHome ()
//	{
//		Level1_Tools.BackHome ();
//	}
//
//	public void Again ()
//	{
//		Level1_Tools.playAgain ();
//	}
//
//	public void BackLevel ()
//	{
//		AsyncOperation LoadScene = SceneManager.LoadSceneAsync (4);
//	}
//
//	public bool IfTheEnd ()
//	{
//		return false;
//	}
//
//	public void Finish ()
//	{
//		play = false;
//		Billboard.SetActive (true);
//		Destroy (MainCamera.GetComponent<CameraControl3> ());
//		Level1_Tools.DisplayPercent ();//答對率
//		Level1_Tools.DisplayTime (time);//時間
//		Level1_Tools.DisplayScore ();//統計
//		Level1_UFO.DestroyUFO (UFOList.Count, 1f);
//	}
//
//	//錯誤9次結束遊戲
//	public void GameOver ()
//	{
//		play = false;
//		Wrong.SetActive (true);
//		Destroy (MainCamera.GetComponent<CameraControl3> ());
//		Level1_UFO.DestroyUFO (UFOList.Count, 1f);
//	}
//
//	public void Feedback (bool result)
//	{
////		throw new System.NotImplementedException ();
//	}
//
//	//進入遊戲後初始
//	public void Initialization ()
//	{
//		Level1_UFO.six = this;
//
//		//設定亂數種子
//		UnityEngine.Random.InitState (System.Guid.NewGuid ().GetHashCode ());
//
//		//隨機值
//		g_iRandom = UnityEngine.Random.Range (0, 7);
//
//		Level1_Tools.FindGameObject ();
//
//		//建置UFO位置
//		Level1_UFO.UFO_group = UFO_group;
//
//		WaitUntilUFOReady = new WaitUntil (() => UFOList.All (list => !(list.m_isMoving)));
//
//		WaitOneSecond = new WaitForSeconds (1f);
//
//		CheckedScale = new Vector3 (140, 140, 0);
//
//		makeRandomPos ();
//	}
//
//	IEnumerator GameStart ()
//	{
//		//UFO初始化
//		Initialization ();
//
//		while (true) {
//
//			//關卡設定
//			yield return StartCoroutine (LevelManagement ());
//
//			if (!play)
//				yield break;
//			
//			//隨機亂數
//			yield return StartCoroutine (MakeRandom (random));
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
//			//等待下一幀
//			yield return null;
//		}
//	}
//
//	///關卡設定
//	IEnumerator LevelManagement ()
//	{
//		if (IfTheEnd ())
//			yield break;
//
////		ai = UFO_group.gameObject.AddComponent<Level1_AI> ();
//
//		//實例化UFO
//		var Group = Level1_UFO.InstantiateUFOs (3);
//
//		//重設場上所有UFO座標
//		for (int i = 0; i < Group.Count; i++) {
//			var ufo = Group [i];
//			ufo.moveTo (0.8f, RandPos [index += i], true, 0.1f);
//		}
//
//		index++;
//
////		if (start) {
////
////			//實例化UFO
////			Level1_UFO.InstantiateUFOs (1);
////
//////			var pos = selectRandomPos ();
////
////			UFOList [UFOList.Count - 1].GetUFO.transform.rotation = Quaternion.identity;
////			UFOList [UFOList.Count - 1].moveTo (1f, pos, true, 0.5f);
////		} 
//		yield break;
//	}
//
//	//隨機亂數
//	IEnumerator MakeRandom (int key)//key->需要幾個亂數
//	{
//		//清空
//		UFO_Random.Clear ();
//
//		//設定亂數種子
//		UnityEngine.Random.InitState (System.Guid.NewGuid ().GetHashCode ());
//
//
//		List<Level1_UFO> TempList = UFOList.ToList ();
//
//		for (int i = 0; i < key; i++) {
//			int num = UnityEngine.Random.Range (0, TempList.Count);
//			UFO_Random.Add (TempList [num]);
//			TempList [num] = TempList [TempList.Count - 1];
//			TempList.RemoveAt (TempList.Count - 1);
//		}
//		
//		yield break;
//	}
//
//	IEnumerator ShowLight ()
//	{
//		//當陣列全部等於false時執行
//		yield return WaitUntilUFOReady;
//
//		foreach (Level1_UFO ufo in UFO_Random) {
//
//			ufo.Red ();
//
//			yield return new WaitForSeconds (lighttime);
//
//			ufo.Original (false);
//	
//			//當走訪至最後時跳出迴圈
//			if (ufo == UFO_Random.Last ())
//				break;
//
//			yield return new WaitForSeconds (darktime);
//		}
//	}
//
//	IEnumerator AnswerCompare ()
//	{
//		//清空
//		UFO.Clear ();
//
//		//開啟點擊
//		UFOList.ForEach (go => go.GetUFO.GetComponent<SphereCollider> ().enabled = true);
//
//
//		while (true) {
//			//UFO數量到達時判斷
//			if (UFO.Count == UFO_Random.Count) {
//
//				//關閉點擊
//				UFOList.ForEach (go => go.GetUFO.GetComponent<SphereCollider> ().enabled = false);
//
//				LevelUP = Level1_Tools.Compare (UFO, UFO_Random);
//
//				GameObject clone = (LevelUP) ? Level1_Tools.showResults (UI_Object, Bingo) : Level1_Tools.showResults (UI_Object, Error);
//
//				Level1_Tools.Record (LevelUP);
//
//				break;//跳出while迴圈
//			}
//			yield return null;//等待下一幀
//		}
//		yield return WaitOneSecond;
//		Feedback (LevelUP);
//	}
//
//	//重置
//	IEnumerator Reset ()
//	{
//		UFOList.ForEach (go => go.Original (false));
//		start = true;
//		yield break;
//	}
//
//	void makeRandomPos ()
//	{
//		UnityEngine.Random.InitState (System.Guid.NewGuid ().GetHashCode ());
//
//		//設定寬高
//		arrangement.Add (new List<Vector3> ());
//		for (int x = -2; x < 2; x++)
//			for (int y = -2; y < 2; y++)
//				arrangement [0].Add (new Vector3 ((200f * x + 100), (200 * y + 100), -400));//製作所有UFO可到的點
//
//		for (int i = 0; i < arrangement [0].Count; i++) {
//			//全部-選過 = 剩下
//			var TempList = arrangement [0].Except (RandPos).ToList ();
//			int num = UnityEngine.Random.Range (0, TempList.Count);
//			RandPos.Add (TempList [num]);
//		}
//	}
}
