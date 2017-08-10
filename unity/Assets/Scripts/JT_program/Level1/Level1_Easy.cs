using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

//清除監控的Error,可刪除
using System;
using UnityEngine.SceneManagement;

public class Level1_Easy : MonoBehaviour
{
//	#region Parameter...
//
//	[HideInInspector]
//	public int arrangement_index;
//
//	//圖案
//	[Header ("Object")]
//	[Tooltip ("UIRoot-Panel")]
//	public GameObject Panel;
//	[Tooltip ("BingoIcon")]
//	public GameObject Bingo;
//	[Tooltip ("ErrorIcon")]
//	public GameObject Error;
//
//	//List
//	public List<Level1_UFO> UFOList = new List<Level1_UFO> ();
//	public static List<Level1_UFO> UFO = new List<Level1_UFO> ();
//	public static List<Level1_UFO> UFO_Random = new List<Level1_UFO> ();
//	public static List<List<Vector3>> arrangement = new List<List<Vector3>> ();
//
//	///UFO物件父節點
//	public static Transform UFO_group;
//	///UFO移動至下方X軸之位置
//	public static int s_iReferencePoint = -500;
//	///UFO間隔
//	public static int s_iInterval = 250;
//	//點擊旗標
//	public static  int s_iClick = 0;
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
//
//	///載入UFO
//	GameObject[] LoadUFO;
//	GameObject SliderBar;
//	GameObject BackGround;
//	//排列圖
//	TextAsset[] map;
//
//	Vector3 CheckedScale;
//
//	WaitUntil WaitUntilUFOReady;
//	WaitForSeconds WaitOneSecond;
//	WaitForSeconds LightTime;
//	WaitForSeconds DarkTime;
//
//	#endregion
//
//
//	public static void UFO_OnClick (Level1_UFO ufo)
//	{
//		if (ufo.m_bToggle) {
//
//			//ufo.m_bToggle = !ufo.m_bToggle;
//
//			Debug.Log ("a");
//
//			//移動到下方
////			ufo.moveTo (0.5f, new Vector3 (s_iReferencePoint, -316, 0));
//
//			//指向下一個位置
//			s_iReferencePoint += s_iInterval;
//			//加入UFO陣列
//			UFO.Add (ufo);
//
//			try {
//				UFO [s_iClick - 1].GetUFO.GetComponent<SphereCollider> ().enabled = false;//設計當點下最後一個UFO時全關閉BoxCollider之後再統一開啟
//			} catch (Exception e) {
//			}	
//
//			s_iClick++;
//
//		} else {
//
//			Debug.Log (ufo.m_bToggle);
//
//			Debug.Log ("b");
//
//			//ufo.m_bToggle = !ufo.m_bToggle;
//
////			ufo.moveBack ();
//
//			//指向上一個位置
//			s_iReferencePoint -= s_iInterval;
//
//			s_iClick--;
//
//			try {
//				UFO [s_iClick - 1].GetUFO.GetComponent<SphereCollider> ().enabled = true;
//			} catch (Exception e) {
//			}	
//			//
//			//從UFO陣列移除
//			UFO.Remove (ufo);
//		}
//	}
//
//	void Start ()
//	{
//		//初始化
//		Initialization ();
//
//		//遊戲開始
//		StartCoroutine (GameStart ());
//
////		ClearLog ();//清除監控的Error,可刪除
//	}
//
//	void Update ()
//	{
//		
//	}
//
//
//
//	///初始化
//	void Initialization ()
//	{
//		//讀入txt
//		map = Resources.LoadAll<TextAsset> ("JT/maps/easy");
//
//		//UFO排列圖座標陣列
//		LoadMap (map [0].text);
//
//		//Level1_UFO.easy = this;
//
//		//假如從Menu選單進入遊戲，使用Menu的數值;假如使用scene進入遊戲，使用scene的數值
//		arrangement_index = (Level1_Menu.level < 0) ? arrangement_index : Level1_Menu.level;
//
//		//取得Panel物件
//		Panel = GameObject.Find ("Panel");
//
//		//取得UFO_group物件
//		UFO_group = GameObject.Find ("UFO_group").transform;
//
//		//取得Control - Colored Slider物件
//		SliderBar = GameObject.Find ("Control - Colored Slider");
//
//		//BackGround = GameObject.Find ("BackGround");
//
//		//取得Bingo物件
//		Bingo = Resources.Load<GameObject> ("JT/" + "checked-Bingo");
//
//		//取得Error物件
//		Error = Resources.Load<GameObject> ("JT/" + "checked-Error");
//
//		//載入UFO
//		LoadUFO = Resources.LoadAll<GameObject> ("JT/UFO_3D");
//
////		WaitUntilUFOReady = new WaitUntil (() => UFOList.All (list => !(list.isMoving)));
//
//		LightTime = new WaitForSeconds (0.1f);
//
//		DarkTime = new WaitForSeconds (0.1f);
//
//		WaitOneSecond = new WaitForSeconds (1f);
//
//		CheckedScale = new Vector3 (140, 140, 0);
//	}
//		
//
//	public IEnumerator GameStart ()
//	{
//		while (true) {
//
//			//關卡設定
//			yield return StartCoroutine (LevelManagement ());
//
//			//隨機亂數
//			yield return StartCoroutine (MakeRandom (3));
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
//		//		DisplaySliderBar ();
//
//		if (!LevelUP) {
//			//進入遊戲後初始，只執行一次
//			if (UFOList.Count == 0) {
//
//				//設定亂數種子
//				UnityEngine.Random.InitState (System.Guid.NewGuid ().GetHashCode ());
//
//				//隨機值
//				g_iRandom = UnityEngine.Random.Range (0, 8);
//
//				//建置UFO位置
//				Level1_UFO.UFO_group = UFO_group;
//
//				//設定座標 & 實例化UFO
//				Level1_UFO.InstantiateUFOs (arrangement [arrangement_index].Count);
//
//			} else {
//				//當答錯時執行
////				UFOList.ForEach (go => go.moveBack ());
//			}
//		} else {
//
//			//暫存值
//			g_iTempValue = arrangement_index;
//
//			//下一關圖形
//			arrangement_index++;
//
//			//缺(多)幾台UFO
//			g_iBalance = arrangement [g_iTempValue].Count - arrangement [arrangement_index].Count;
//
//			//extra
//			if (g_iBalance > 0) {
//
//				//Destroy幾台
//				Level1_UFO.DestroyUFO (g_iBalance);
//			}
//
//			//走訪旗標
//			int iFlag = 0;
//
//			//lack
//			if (g_iBalance < 0) {
//
//				g_iBalance *= -1;
//
//				//設定座標 & 實例化UFO
//				Level1_UFO.InstantiateUFOs (g_iBalance);
//			} 
//
//
//			//設定座標 & 實例化UFO
//			for (iFlag = 0; iFlag < arrangement [arrangement_index].Count; iFlag++)
//				UFOList [iFlag].moveTo (0.5f, arrangement [arrangement_index] [iFlag]);
//
//
////				UFOList [iFlag].Initmove (0.5f, arrangement [arrangement_index] [iFlag]);
//
//		}
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
//		//UnityEngine.Random.InitState (System.Guid.NewGuid ().GetHashCode ());
//
//		List<Level1_UFO> TempList = UFOList.ToList ();
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
//	IEnumerator ShowLight ()
//	{
//		//當陣列全部等於false時執行
//		yield return WaitUntilUFOReady;
//
//		foreach (Level1_UFO ufo in UFO_Random) {
//
//			ufo.Red ();
//
//			yield return LightTime;
//
//			ufo.Original ();
//
//			//當走訪至最後時跳出迴圈
//			//			if (ufo == UFO_Random.Last ())
//			//				break;
//
//			yield return DarkTime;
//		}
//	}
//
//	IEnumerator AnswerCompare ()
//	{
//		//清空
//		UFO.Clear ();
//
//		//開啟點擊
//		UFOList.ForEach (go => {
//			go.GetUFO.GetComponent<SphereCollider> ().enabled = true;
////			go.AddListener();
//		});
//
//
//		while (true) {
//			//UFO數量到達時判斷
//			if (UFO.Count == UFO_Random.Count) {
//
//				//關閉點擊
//				UFOList.ForEach (go => go.GetUFO.GetComponent<SphereCollider> ().enabled = false);
//
//				LevelUP = Compare (UFO, UFO_Random);
//
//				GameObject clone = (LevelUP) ? NGUITools.AddChild (Panel, Bingo) : NGUITools.AddChild (Panel, Error);
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
//
//	//重置
//	IEnumerator Reset ()
//	{
//		//重置點擊移動開關
//		//UFOList.ForEach (go => go.m_bToggle = false);
//
//		s_iClick = 0;
//
//		s_iReferencePoint = -500;
//
//		yield break;
//	}
//
//	bool Compare (List<Level1_UFO> UFO, List<Level1_UFO> UFO_Random)
//	{
//		bool result = true;
//
//		for (int i = 0; i < UFO.Count - 1; i++) {
//			if (UFO [i].GetUFO != UFO_Random [i].GetUFO) {
//				result = false;
//				break;
//			}
//		}
//		return result;
//	}
//		
//
//	void DisplaySliderBar ()
//	{
//		if (arrangement_index >= 0) {
//			if (arrangement_index >= 0 && arrangement_index <= 10)
//				SliderBar.GetComponent<UISlider> ().value = 0.25f;
//			if (arrangement_index >= 11 && arrangement_index <= 21)
//				SliderBar.GetComponent<UISlider> ().value = 0.5f;
//			if (arrangement_index >= 22 && arrangement_index <= 31)
//				SliderBar.GetComponent<UISlider> ().value = 0.75f;
//			if (arrangement_index >= 32)
//				SliderBar.GetComponent<UISlider> ().value = 1f;
//		}
//	}
//
//	void LoadMap (string map)
//	{
//		//分隔符
//		string[] split_char = { "\n", "\r" };
//		//所有字串
//		string[] lines = map.Trim ().Split (split_char, StringSplitOptions.RemoveEmptyEntries);
//
//		int p1 = 1;
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
//	public void BackHome(){
//		AsyncOperation LoadScene = SceneManager.LoadSceneAsync (0);
//	}
}
