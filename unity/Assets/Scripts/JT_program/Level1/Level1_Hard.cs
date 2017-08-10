using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class Level1_Hard : MonoBehaviour
{
//	#region Parameter...
//
//	[HideInInspector]
//	public int popup;
//	[HideInInspector]
//	public int arrangement_index;
//
//
////	Level1_AI ai;
//	[Header ("status")]
//
//	[Range (0.5f, 1f)]
//	public float AISpeed = 0.5f;
//
//	[Header ("Object")]
//	[Tooltip ("UIRoot-Panel")]
//	public GameObject Panel;
//	[Tooltip ("BingoIcon")]
//	public GameObject Bingo;
//	[Tooltip ("ErrorIcon")]
//	public GameObject Error;
//
//	Level1_RotationFix rotationfix;
//
//
//
//	int Index;
//	int IndexCount;
//
//	public List<Level1_UFO> UFOList = new List<Level1_UFO> ();
//
//	public static List<Level1_UFO> UFO = new List<Level1_UFO> ();
//
//	public static List<Level1_UFO> UFO_Random = new List<Level1_UFO> ();
//
//	public static List<List<Vector3>> arrangement = new List<List<Vector3>> ();
//
//
//	List<Vector3> Point = new List<Vector3> ();
//
//
//	public  string UFO_RedLight;
//
//	public static string UFO_DefaultLight;
//
//	public static string UFO_GrayLight;
//
//	///UFO物件父節點   Level1_ufo要用static才抓的到
//	public static Transform UFO_group;
//	public static Transform UFO_group_Click;
//
//	///UFO移動至下方X軸之位置
//	public static int s_iReferencePoint = -500;
//
//	///UFO間隔
//	public static int s_iInterval = 90;
//
//	//點擊旗標
//	public static  int s_iClick = 0;
//
//	///下一關圖型
//	//	public static bool s_bNextLevel = false;
//
//	///關卡難度提升
//	bool LevelUP = false;
//
//	//UFO隨機樣式
//	private int g_iRandom;
//	//UFO數量平衡
//	private int g_iBalance;
//	///暫存值
//	private int g_iTempValue;
//	///載入UFO
//	GameObject[] LoadUFO;
//
//	TextAsset[] map;
//
//	GameObject SliderBar;
//
//	GameObject BackGround;
//
//	Vector3 CheckedScale;
//
//	//	WaitUntil WaitValueChange;
//
//	WaitUntil WaitUntilUFOReady;
//
//	WaitForSeconds WaitOneSecond;
//
//	WaitForSeconds LightTime;
//
//	WaitForSeconds DarkTime;
//
//	#endregion
//
//	// Use this for initialization
//	void Start ()
//	{
//		//初始化
//		Initialization ();
//
////		遊戲開始
//		StartCoroutine (GameStart (popup));
//
//	}
//	
//	// Update is called once per frame
//	void Update ()
//	{
//
//	}
//
//
//	public static void UFO_OnClick (Level1_UFO ufo)
//	{
//		Debug.Log (ufo.GetUFO.name + "\t" + ufo.m_bToggle);
//
////		ufo.isMoving = true;
//
//		if (ufo.m_bToggle) {
//
//			ufo.GetUFO.transform.parent = UFO_group_Click.transform;
//
////			Level1_RotationFix.children.Remove (ufo.GetUFO.transform);
//
////			Level1_AI.children.Remove (ufo.GetUFO.transform);
//
//			ufo.GetUFO.transform.rotation = Quaternion.identity;
//
//			//移動到下方
//			TweenPosition.Begin (ufo.GetUFO, 0.5f, new Vector3 (s_iReferencePoint, -316, 0));
//
//
//			//指向下一個位置
//			s_iReferencePoint += s_iInterval;
//			//加入UFO陣列
//			UFO.Add (ufo);
//
//			try {
//				UFO [s_iClick - 1].GetUFO.GetComponent<SphereCollider> ().enabled = false;//設計當點下最後一個UFO時全關閉BoxCollider之後再統一開啟
//				UFO [s_iClick - 1].GetUFO.GetComponent<UISprite> ().spriteName = UFO_GrayLight;
//			} catch (Exception e) {
//			}	
//
//			s_iClick++;
//
//			ufo.m_bToggle = !ufo.m_bToggle;
//
//		} else {
//
//			ufo.GetUFO.transform.parent = UFO_group.transform;
//
////			Level1_RotationFix.children.Add (ufo.GetUFO.transform);
//
////			Level1_AI.children.Add (ufo.GetUFO.transform);
//
//			//指向上一個位置
//			s_iReferencePoint -= s_iInterval;
//
//			ufo.m_bToggle = !ufo.m_bToggle;
//
//			s_iClick--;
//
//			try {
//				UFO [s_iClick - 1].GetUFO.GetComponent<SphereCollider> ().enabled = true;
//				UFO [s_iClick - 1].GetUFO.GetComponent<UISprite> ().spriteName = UFO_DefaultLight;
//			} catch (Exception e) {
//			}	
//			//
//			//從UFO陣列移除
//			UFO.Remove (ufo);
//		}
//	}
//
//	void Initialization ()
//	{
//		//讀入txt
//		map = Resources.LoadAll<TextAsset> ("JT/maps/hard");
//
//		//Level1_UFO.hard = this;
//
//		arrangement_index = Level1_Menu.level;
//
//		//取得Panel物件
//		Panel = GameObject.Find ("Panel");
//
//		//取得UFO_group物件
//		UFO_group = GameObject.Find ("UFO_group").transform;
//
//		UFO_group_Click = GameObject.Find ("UFO_group_Click").transform;
//
//		//取得Control - Colored Slider物件
//		SliderBar = GameObject.Find ("Control - Colored Slider");
//
//		//取得Bingo物件
//		Bingo = Resources.Load<GameObject> ("JT/" + "checked-Bingo");
//
//		//取得Error物件
//		Error = Resources.Load<GameObject> ("JT/" + "checked-Error");
//
//		//載入UFO
//		LoadUFO = Resources.LoadAll<GameObject> ("JT/UFO_groupAll");
//
////		ModeSelect = GetComponent<Level1_Select> ();
//
//		BackGround = GameObject.Find ("background");
//
////		WaitValueChange = new WaitUntil (() => g_iTempValue != Level1_Select._arrangement_index);
//
////		WaitUntilUFOReady = new WaitUntil (() => UFOList.All (list => !(list.isMoving)));
//
//		WaitOneSecond = new WaitForSeconds (1f);
//
//		CheckedScale = new Vector3 (140, 140, 0);
//
//		//設定亂數種子
//		UnityEngine.Random.InitState (System.Guid.NewGuid ().GetHashCode ());
//
//		LightTime = new WaitForSeconds (0.1f);
//
//		DarkTime = new WaitForSeconds (0.1f);
//
//
//	}
//
//	public IEnumerator GameStart (int Mode)
//	{
//		switch (Mode) {
//		case 0:
//			LoadMap (map [0].text);
//			while (true) {
//
//
//				Index = arrangement_index;
//
//				IndexCount = arrangement [Index].Count / 2;
//
//
//				//關卡設定
//				yield return StartCoroutine (LevelManager0 ());
//
//				//隨機亂數
//				yield return StartCoroutine (MakeRandom0 ());
//
//				//			//亮燈
//				yield return StartCoroutine (ShowLight0 ());
//
//
//				yield return StartCoroutine (ChangePattern0 ());
//
//				//			//答案比對
//				yield return StartCoroutine (AnswerCompare0 ());
//				//
//				//			//重置
//				yield return StartCoroutine (Reset0 ());
//
//
//				yield return null;
//			}
//		//break;
//		case 1:
//			LoadMap (map [1].text);
//			while (true) {
//
//
//				Index = arrangement_index;
//
//				IndexCount = arrangement [Index].Count;
//
//
//				//關卡設定
//				yield return StartCoroutine (LevelManager1 ());
//
//				//隨機亂數
//				yield return StartCoroutine (MakeRandom1 ());
//
//
//				yield return StartCoroutine (StartRotate1 ());
//
//				//			//亮燈
//				yield return StartCoroutine (ShowLight1 ());
//
//
//				//			//答案比對
//				yield return StartCoroutine (AnswerCompare1 ());
//				//
//				//			//重置
//				yield return StartCoroutine (Reset1 ());
//
//
//				yield return null;
//			}
//		//break;
//		case 2:
//			LoadMap (map [2].text);
//			while (true) {
//
//				Index = arrangement_index;
//
//				IndexCount = arrangement [Index].Count;
//
//
//				//關卡設定
//				yield return StartCoroutine (LevelManager2 ());
//
//				//隨機亂數
//				yield return StartCoroutine (MakeRandom2 ());
//
//
//				yield return StartCoroutine (StartRandomlyMove2 ());
//
//				//亮燈
//				yield return StartCoroutine (ShowLight2 ());
//
//				//答案比對
//				yield return StartCoroutine (AnswerCompare2 ());
//				
//				//重置
//				yield return StartCoroutine (Reset2 ());
//
//
//				yield return null;
//			}
////			break;
//		}
//
//
//
//	}
//
//	#region 固定移動...
//
//	///關卡設定
//	IEnumerator LevelManager0 ()
//	{
//		
//
////		DisplaySliderBar ();
//
//		if (!LevelUP) {
//
//			//進入遊戲後初始，只執行一次
//			if (!UFOList.Any ()) {
//				
//				//隨機值
//				g_iRandom = UnityEngine.Random.Range (0, 5);
//
//
//				for (int i = 0; i < IndexCount; i++) {
//					UFOList.Add (new Level1_UFO (LoadUFO [g_iRandom]));
//					TweenPosition.Begin (UFOList [i].GetUFO, 1f, arrangement [arrangement_index] [i]);
//				}
//
//
//				//取得當前UFO原始圖名稱
//				UFO_DefaultLight = UFOList [0].GetUFO.GetComponent<UISprite> ().spriteName;
////
////				//取得當前UFO的亮燈圖名稱
//				UFO_RedLight = UFO_DefaultLight + "_red";
////
//				UFO_GrayLight = UFO_DefaultLight + "_gray";
//
//
//			} else {//當答錯時執行
//				
//				var iFlag = 0;
//
//
//				UFOList.ForEach (go => {
//
//					TweenPosition.Begin (go.GetUFO, 0.5f, arrangement [Index] [iFlag++]);
//
//					TweenScale.Begin (go.GetUFO, 0.5f, Vector3.one);
//
//
//					go.GetUFO.GetComponent<UISprite> ().spriteName = UFO_DefaultLight;
//
//					//isMoving = true
////					go.isMoving = true;
////					(UFOList.Find (go2 => go2.GetUFO.Equals (go.GetUFO))).isMoving = true;
//
//					go.GetUFO.transform.parent = UFO_group.transform;
//
//				});
//
////				if (ReRandom.Any (list => list.Equals (Level1_Select._arrangement_index))) {
////
////					//reReRandom
////
////					//test...
////
////				}
//
//			}
//		} else {
//
//			//暫存值
//			g_iTempValue = Index;
//
//			//下一關圖形
////			s_bNextLevel = true;
//			arrangement_index++;
//
//			//值改變時執行
////			yield return WaitValueChange;
//
//
//			g_iBalance = (arrangement [g_iTempValue].Count - arrangement [arrangement_index].Count) / 2;
//		
//
//			Index = arrangement_index;
//
//
//			//extra
//			if (g_iBalance > 0) {
//
//				//Destroy幾台
//				for (int i = 0; i < g_iBalance; i++) {
//
////					UFOList.Remove (UFOList.Find (go2 => go2.GetUFO.Equals (UFO_sequence.Last ())));
////					UFO_sequence.Remove (UFO_sequence.Last ());
//
//					var go = UFO.Last ();
//
//					TweenPosition.Begin (go.GetUFO, 0.5f, Level1_UFO.GeneratePoint [i % 4]);
//
//					TweenAlpha.Begin (go.GetUFO, 0.5f, 0);
//
//					UFOList.Remove (go);
//
//					Destroy (go.GetUFO, 1.5f);
//
//					UFO.Remove (go);
//
//
//				}
//			}
//
//
//
//			//走訪旗標
//			int iFlag = 0;
//
//
//			UFOList.ForEach (go => { 
//				//設定下個座標
//				TweenPosition.Begin (go.GetUFO, 0.5f, arrangement [Index] [iFlag++]);
//
//				//				UFO_OriginalOrder.Add (go1);
//
//				go.GetUFO.GetComponent<UISprite> ().spriteName = UFO_DefaultLight;
//
//				//開始移動
//				go.GetUFO.GetComponent<UIPlayTween> ().Play (true);
//
//				//isMoving = true
////				go.isMoving = true;
////				(UFOList.Find (go2 => go2.GetUFO.Equals (go1.GetUFO))).isMoving = true;
//
//				go.GetUFO.transform.parent = UFO_group.transform;
//
//			});
//
//
//			//lack
//			if (g_iBalance < 0) {
//
//				g_iBalance *= -1;
//
//				//少幾台UFO
//				for (int i = 0; i < g_iBalance; i++) {
//					UFOList.Add (new Level1_UFO (LoadUFO [g_iRandom]));
//					TweenPosition.Begin (UFOList.Last ().GetUFO, 0.5f, arrangement [Index] [iFlag++]);
//				}
//
//
//			}  
//
//
//
//
//
//
//			//重新給暫存值
////			g_iTempValue = Level1_Select._arrangement_index;
//
////			DisplaySliderBar ();
//		}
//
//
//
//		yield return null;
//
//
////		yield return WaitUntilUFOReady;
//
//
////		if (!NeedChangePattern) {
////
////
////			if (class_RotationFix == null) {
////				//				yield return new WaitForSeconds(3);
////				class_RotationFix = UFO_group.gameObject.AddComponent<Level1_RotationFix> ();
////			} else {
////				UFO.ForEach (go => {
////					go.transform.parent = UFO_group.transform;
////
////					if (Level1_RotationFix.children.All (list => list != go))
////						Level1_RotationFix.children.Add (go.transform);
////				});
////			}
////
////
////		}
//	}
//	//隨機亂數
//	IEnumerator MakeRandom0 ()
//	{
//		//清空
//		UFO_Random.Clear ();
//	
//		//設定亂數種子
//		//UnityEngine.Random.InitState (System.Guid.NewGuid ().GetHashCode ());
//		List<Level1_UFO> TempList = UFOList.ToList ();
//
//		var key = UFOList.Count;
//
//		for (int i = 0; i < key; i++) {
//			int num = UnityEngine.Random.Range (0, TempList.Count);
//			UFO_Random.Add (TempList [num]);
//			TempList [num] = TempList [TempList.Count - 1];
//			TempList.RemoveAt (TempList.Count - 1);
//		}
//	
//		//將UFO_Random加回UFO_sequence
////			UFO_sequence.AddRange (UFO_Random);
//	
//		yield break;
//	}
//
//	IEnumerator ShowLight0 ()
//	{
//		//當陣列全部等於false時執行
//		yield return WaitUntilUFOReady;
//	
//		foreach (Level1_UFO arr in UFO_Random) {
//	
//			arr.GetUFO.GetComponent<UISprite> ().spriteName = UFO_RedLight;
//	
//			yield return LightTime;
//	
//			arr.GetUFO.GetComponent<UISprite> ().spriteName = UFO_DefaultLight;
//	
//			//當走訪至最後時跳出迴圈
//			if (arr == UFO_Random.Last ())
//				break;
//	
//			yield return DarkTime;
//		}
//	}
//
//	IEnumerator ChangePattern0 ()
//	{
//		//yield return WaitOneSecond;
//	
//	
//			
//		for (int i = 0; i < UFOList.Count; i++) {
//			TweenPosition.Begin (UFOList [i].GetUFO, 0.5f, arrangement [Index] [i + (arrangement [Index].Count / 2)]);
//	
//			//				if (i == UFO_Random.Count - 1)
//			//					break;
//	
//			//yield return WaitOneSecond;
//		}
//
//	
//		//開啟點擊
//		UFO_Random.ForEach (go => go.GetUFO.GetComponent<SphereCollider> ().enabled = true);
//	
//		//開啟點擊
//		//UFO_sequence.ForEach (go => go.GetComponent<SphereCollider> ().enabled = true);
//	
//		yield break;
//	}
//
//	IEnumerator AnswerCompare0 ()
//	{
//		//清空
//		UFO.Clear ();
//	
//		while (true) {
//			//UFO數量到達時判斷
//			if (UFO.Count == UFO_Random.Count) {
//	
//				//關閉點擊
//				UFO_Random.ForEach (go => go.GetUFO.GetComponent<SphereCollider> ().enabled = false);
//	
//				//答對答錯
//				if (UFO.SequenceEqual (UFO_Random))
//					LevelUP = true;
//				else
//					LevelUP = false;
//	
//				//比對陣列是否一致  答對=>clone = Bingo,反之,答對=>clone = Error
//				GameObject clone = (UFO.SequenceEqual (UFO_Random)) ? NGUITools.AddChild (Panel, Bingo) : NGUITools.AddChild (Panel, Error);
//	
//				//設定大小
//				clone.transform.localScale = CheckedScale;
//	
//				//設定大小tween
//				iTween.ScaleFrom (clone, iTween.Hash ("scale", Vector3.zero, "delay", 0.2));
//	
//				Destroy (clone, 1f);
//	
//				break;//跳出while迴圈
//			}
//			yield return null;//等待下一幀
//		}
//		yield return WaitOneSecond;
//	}
//	//重置
//	IEnumerator Reset0 ()
//	{
//		//重置點擊移動開關
//		UFOList.ForEach (go => go.m_bToggle = true);
//	
//		s_iClick = 0;
//	
//		s_iReferencePoint = -500;
//	
//		yield break;
//	}
//
//	#endregion
//
//	#region 旋轉移動...
//
//	///關卡設定
//	IEnumerator LevelManager1 ()
//	{
////		DisplaySliderBar ();
//
//		if (!LevelUP) {
//
//			//進入遊戲後初始，只執行一次
//			if (!UFOList.Any ()) {
//
//				//隨機值
//				g_iRandom = UnityEngine.Random.Range (0, 5);
//
//
//				for (int i = 0; i < IndexCount; i++) {
//					UFOList.Add (new Level1_UFO (LoadUFO [g_iRandom]));
//					TweenPosition.Begin (UFOList [i].GetUFO, 1f, arrangement [arrangement_index] [i]);
//				}
//
//
//				//取得當前UFO原始圖名稱
//				UFO_DefaultLight = UFOList [0].GetUFO.GetComponent<UISprite> ().spriteName;
//				
////				取得當前UFO的亮燈圖名稱
//				UFO_RedLight = UFO_DefaultLight + "_red";
//				//
//				UFO_GrayLight = UFO_DefaultLight + "_gray";
//
//
//			} else {//當答錯時執行
//
//				var iFlag = 0;
//
//				//				UFO_OriginalOrder.Clear ();
//
//				UFOList.ForEach (go => {
//
//					//					go1.GetUFO.GetComponent<UIPlayTween>().Play(true);
//
//					TweenPosition.Begin (go.GetUFO, 0.5f, arrangement [Index] [iFlag++]);
//
//					TweenScale.Begin (go.GetUFO, 0.5f, Vector3.one);
//
//					//					UFO_OriginalOrder.Add (go1); 
//
//					go.GetUFO.GetComponent<UISprite> ().spriteName = UFO_DefaultLight;
//
//					//isMoving = true
////					go.isMoving = true;
////					(UFOList.Find (go2 => go2.GetUFO.Equals (go1.GetUFO))).isMoving = true;
//
//					go.GetUFO.transform.parent = UFO_group.transform;
//
//				});
//
//				//				if (ReRandom.Any (list => list.Equals (Level1_Select._arrangement_index))) {
//				//
//				//					//reReRandom
//				//
//				//					//test...
//				//
//				//				}
//
//			}
//		} else {
//
//			//暫存值
//			g_iTempValue = Index;
//
//			//下一關圖形
////			s_bNextLevel = true;
//			arrangement_index++;
//			//值改變時執行
////			yield return WaitValueChange;
//
//
//			g_iBalance = arrangement [g_iTempValue].Count - arrangement [arrangement_index].Count;
//
//
//			Index = arrangement_index;
//
//
//			//extra
//			if (g_iBalance > 0) {
//
//				//Destroy幾台
//				for (int i = 0; i < g_iBalance; i++) {
//
//					var go = UFO.Last ();
//
//					TweenPosition.Begin (go.GetUFO, 0.5f, Level1_UFO.GeneratePoint [i % 4]);
//
//					TweenAlpha.Begin (go.GetUFO, 0.5f, 0);
//
//					UFOList.Remove (go);
//
//					Destroy (go.GetUFO, 1.5f);
//
//					UFO.Remove (go);
//				}
//			}
//
//
//
//			//走訪旗標
//			int iFlag = 0;
//
//
//			UFOList.ForEach (go => { 
//				//設定下個座標
//				TweenPosition.Begin (go.GetUFO, 0.5f, arrangement [Index] [iFlag++]);
//
//				go.GetUFO.GetComponent<UISprite> ().spriteName = UFO_DefaultLight;
//
//				//開始移動
//				go.GetUFO.GetComponent<UIPlayTween> ().Play (true);
//
//				//isMoving = true
////				go.isMoving = true;
////				(UFOList.Find (go2 => go2.GetUFO.Equals (go.GetUFO))).isMoving = true;
//
//				go.GetUFO.transform.parent = UFO_group.transform;
//
//			});
//
//
//			//lack
//			if (g_iBalance < 0) {
//
//				g_iBalance *= -1;
//
//				//少幾台UFO
//				for (int i = 0; i < g_iBalance; i++) {
//					UFOList.Add (new Level1_UFO (LoadUFO [g_iRandom]));
//					TweenPosition.Begin (UFOList.Last ().GetUFO, 0.5f, arrangement [Index] [iFlag++]);
//				}
//
//
//			}  
//
//			//重新給暫存值
//			//			g_iTempValue = Level1_Select._arrangement_index;
//
//			//			DisplaySliderBar ();
//		}
//
//		yield break;
//
//	}
//	//隨機亂數
//	IEnumerator MakeRandom1 ()
//	{
//		//清空
//		UFO_Random.Clear ();
//
//		//設定亂數種子
//		//UnityEngine.Random.InitState (System.Guid.NewGuid ().GetHashCode ());
//		List<Level1_UFO> TempList = UFOList.ToList ();
//
//		var key = UFOList.Count;
//
//		for (int i = 0; i < key; i++) {
//			int num = UnityEngine.Random.Range (0, TempList.Count);
//			UFO_Random.Add (TempList [num]);
//			TempList [num] = TempList [TempList.Count - 1];
//			TempList.RemoveAt (TempList.Count - 1);
//		}
//
//		//將UFO_Random加回UFO_sequence
//		//			UFO_sequence.AddRange (UFO_Random);
//
//		yield break;
//	}
//
//
//	IEnumerator StartRotate1 ()
//	{
//		//當陣列全部等於false時執行
//		yield return WaitUntilUFOReady;
//
//		if (rotationfix == null)
////			rotationfix = UFO_group.gameObject.AddComponent<Level1_RotationFix> ();
//
//		yield break;
//	}
//
//
//	IEnumerator ShowLight1 ()
//	{
//
//		yield return WaitOneSecond;
//
//		foreach (Level1_UFO arr in UFO_Random) {
//
//			arr.GetUFO.GetComponent<UISprite> ().spriteName = UFO_RedLight;
//
//			yield return LightTime;
//
//			arr.GetUFO.GetComponent<UISprite> ().spriteName = UFO_DefaultLight;
//
//			//當走訪至最後時跳出迴圈
//			if (arr == UFO_Random.Last ())
//				break;
//
//			yield return DarkTime;
//		}
//	}
//
//
//	IEnumerator AnswerCompare1 ()
//	{
//		//清空
//		UFO.Clear ();
//
//		//開啟點擊
//		UFO_Random.ForEach (go => go.GetUFO.GetComponent<SphereCollider> ().enabled = true);
//
//		while (true) {
//			//UFO數量到達時判斷
//			if (UFO.Count == UFO_Random.Count) {
//
//				//關閉點擊
//				UFO_Random.ForEach (go => go.GetUFO.GetComponent<SphereCollider> ().enabled = false);
//
//				//答對答錯
//				if (UFO.SequenceEqual (UFO_Random))
//					LevelUP = true;
//				else
//					LevelUP = false;
//
//				//比對陣列是否一致  答對=>clone = Bingo,反之,答對=>clone = Error
//				GameObject clone = (UFO.SequenceEqual (UFO_Random)) ? NGUITools.AddChild (Panel, Bingo) : NGUITools.AddChild (Panel, Error);
//
//				//設定大小
//				clone.transform.localScale = CheckedScale;
//
//				//設定大小tween
//				iTween.ScaleFrom (clone, iTween.Hash ("scale", Vector3.zero, "delay", 0.2));
//
//				Destroy (clone, 1f);
//
//				break;//跳出while迴圈
//			}
//			yield return null;//等待下一幀
//		}
//		yield return WaitOneSecond;
//	}
//	//重置
//	IEnumerator Reset1 ()
//	{
//		//重置點擊移動開關
//		UFOList.ForEach (go => go.m_bToggle = true);
//
//		s_iClick = 0;
//
//		s_iReferencePoint = -500;
//
//		yield break;
//	}
//
//	#endregion
//
//	///關卡設定
//	IEnumerator LevelManager2 ()
//	{
//		//		DisplaySliderBar ();
//
//		if (!LevelUP) {
//
//			//進入遊戲後初始，只執行一次
//			if (!UFOList.Any ()) {
//
//				//隨機值
//				g_iRandom = UnityEngine.Random.Range (0, 5);
//
//
//				for (int i = 0; i < IndexCount; i++) {
//					UFOList.Add (new Level1_UFO (LoadUFO [g_iRandom]));
//					TweenPosition.Begin (UFOList [i].GetUFO, 1f, arrangement [arrangement_index] [i]);
//				}
//
//
//				//取得當前UFO原始圖名稱
//				UFO_DefaultLight = UFOList [0].GetUFO.GetComponent<UISprite> ().spriteName;
//
//				//				取得當前UFO的亮燈圖名稱
//				UFO_RedLight = UFO_DefaultLight + "_red";
//				//
//				UFO_GrayLight = UFO_DefaultLight + "_gray";
//
//
//			} else {//當答錯時執行
//
//				var iFlag = 0;
//
//				UFOList.ForEach (go => {
//
//
//					TweenPosition.Begin (go.GetUFO, 0.5f, arrangement [Index] [iFlag++]);
//
//					TweenScale.Begin (go.GetUFO, 0.5f, Vector3.one);
//
//
//					go.GetUFO.GetComponent<UISprite> ().spriteName = UFO_DefaultLight;
//
//					//isMoving = true
////					go.isMoving = true;
////					(UFOList.Find (go2 => go2.GetUFO.Equals (go.GetUFO))).isMoving = true;
//
//					go.GetUFO.transform.parent = UFO_group.transform;
//
//				});
//			}
//		} else {
//
//			//暫存值
//			g_iTempValue = Index;
//
//			//下一關圖形
//			arrangement_index++;
//
//			g_iBalance = arrangement [g_iTempValue].Count - arrangement [arrangement_index].Count;
//
//
//			Index = arrangement_index;
//
//
//			//extra
//			if (g_iBalance > 0) {
//
//				//Destroy幾台
//				for (int i = 0; i < g_iBalance; i++) {
//
//					var go = UFO.Last ();
//
//					TweenPosition.Begin (go.GetUFO, 0.5f, Level1_UFO.GeneratePoint [i % 4]);
//
//					TweenAlpha.Begin (go.GetUFO, 0.5f, 0);
//
//					UFOList.Remove (go);
//
//					Destroy (go.GetUFO, 1.5f);
//
//					UFO.Remove (go);
//				}
//			}
//
//
//
//			//走訪旗標
//			int iFlag = 0;
//
//
//			UFOList.ForEach (go => { 
//				//設定下個座標
//				TweenPosition.Begin (go.GetUFO, 0.5f, arrangement [Index] [iFlag++]);
//
//				go.GetUFO.GetComponent<UISprite> ().spriteName = UFO_DefaultLight;
//
//				//開始移動
//				go.GetUFO.GetComponent<UIPlayTween> ().Play (true);
//
//				//isMoving = true
////				go.isMoving = true;
////				(UFOList.Find (go2 => go2.GetUFO.Equals (go.GetUFO))).isMoving = true;
//
//				go.GetUFO.transform.parent = UFO_group.transform;
//
//			});
//
//
//			//lack
//			if (g_iBalance < 0) {
//
//				g_iBalance *= -1;
//
//				//少幾台UFO
//				for (int i = 0; i < g_iBalance; i++) {
//					UFOList.Add (new Level1_UFO (LoadUFO [g_iRandom]));
//					TweenPosition.Begin (UFOList.Last ().GetUFO, 0.5f, arrangement [Index] [iFlag++]);
//				}
//
//
//			}  
//		}
//
//		yield break;
//
//	}
//	//隨機亂數
//	IEnumerator MakeRandom2 ()
//	{
//		//清空
//		UFO_Random.Clear ();
//
//		//設定亂數種子
//		//UnityEngine.Random.InitState (System.Guid.NewGuid ().GetHashCode ());
//		List<Level1_UFO> TempList = UFOList.ToList ();
//
//		var key = UFOList.Count;
//
//		for (int i = 0; i < key; i++) {
//			int num = UnityEngine.Random.Range (0, TempList.Count);
//			UFO_Random.Add (TempList [num]);
//			TempList [num] = TempList [TempList.Count - 1];
//			TempList.RemoveAt (TempList.Count - 1);
//		}
//		yield break;
//	}
//
//
//	IEnumerator StartRandomlyMove2 ()
//	{
//		//當陣列全部等於false時執行
//		yield return WaitUntilUFOReady;
//
////		if (ai == null)
////			ai = UFO_group.gameObject.AddComponent<Level1_AI> ();
//
//		yield break;
//	}
//
//
//	IEnumerator ShowLight2 ()
//	{
//
//		yield return new WaitForSeconds (3);
//
//		foreach (Level1_UFO arr in UFO_Random) {
//
//			arr.GetUFO.GetComponent<UISprite> ().spriteName = UFO_RedLight;
//
//			yield return LightTime;
//
//			arr.GetUFO.GetComponent<UISprite> ().spriteName = UFO_DefaultLight;
//
//			//當走訪至最後時跳出迴圈
//			if (arr == UFO_Random.Last ())
//				break;
//
//			yield return DarkTime;
//		}
//	}
//
//
//	IEnumerator AnswerCompare2 ()
//	{
//		//清空
//		UFO.Clear ();
//
//		//開啟點擊
//		UFO_Random.ForEach (go => go.GetUFO.GetComponent<SphereCollider> ().enabled = true);
//
//		while (true) {
//			//UFO數量到達時判斷
//			if (UFO.Count == UFO_Random.Count) {
//
//				//關閉點擊
//				UFO_Random.ForEach (go => go.GetUFO.GetComponent<SphereCollider> ().enabled = false);
//
//				//答對答錯
//				if (UFO.SequenceEqual (UFO_Random))
//					LevelUP = true;
//				else
//					LevelUP = false;
//
//				//比對陣列是否一致  答對=>clone = Bingo,反之,答對=>clone = Error
//				GameObject clone = (UFO.SequenceEqual (UFO_Random)) ? NGUITools.AddChild (Panel, Bingo) : NGUITools.AddChild (Panel, Error);
//
//				//設定大小
//				clone.transform.localScale = CheckedScale;
//
//				//設定大小tween
//				iTween.ScaleFrom (clone, iTween.Hash ("scale", Vector3.zero, "delay", 0.2));
//
//				Destroy (clone, 1f);
//
//				break;//跳出while迴圈
//			}
//			yield return null;//等待下一幀
//		}
//		yield return WaitOneSecond;
//	}
//	//重置
//	IEnumerator Reset2 ()
//	{
//		//重置點擊移動開關
//		UFOList.ForEach (go => go.m_bToggle = true);
//
//		s_iClick = 0;
//
//		s_iReferencePoint = -500;
//
//		yield break;
//	}
//
//
//	void LoadMap (string map)
//	{
//		for (int x = -3; x <= 3; x++) {
//			for (int y = -1; y <= 2; y++) {
//				Point.Add (new Vector3 ((200f * x), (150f * y), 100));
//			}
//		}
//
//		for (int x = -1; x <= 3; x++) {
//			for (int y = -2; y <= -2; y++) {
//				Point.Add (new Vector3 ((200f * x), (150f * y), 100));
//			}
//		}
//			
//
//		//分隔符
//		string[] split_char = { "\n", "\r" };
//		//所有字串
//		string[] lines = map.Trim ().Split (split_char, StringSplitOptions.RemoveEmptyEntries);
//
//		int p1 = 1;
//
//		var temp = Point.ToList ();
//
//		for (int i = 0; i < lines.Length; i++) {
//			//以,#分隔
//			string[] parts = lines [i].Split ("," [0], "#" [0]);
//
//			if (p1 != int.Parse (parts [0])) {
//
//				arrangement.Add (new List<Vector3> ());
//
//				p1 = int.Parse (parts [0]);
//			}
//				
//			//加入座標
//			arrangement [int.Parse (parts [0])].Add (new Vector3 (float.Parse (parts [1]), float.Parse (parts [2]), float.Parse (parts [3])));
//		
//		}
//	}
}