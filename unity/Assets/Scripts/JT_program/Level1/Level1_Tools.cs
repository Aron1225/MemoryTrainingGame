using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;
using System;

public class Level1_Tools:Level1_DataBase
{
//	//初始化RotationGroup起始編號
//	//	static int GroupIndex = 0;
//
//	//新增RotationGroup物件
//	static int dir = 1;
//
//	static public GameObject CreateGroup (Transform parent)//parent->RotationGroup物件的parent
//	{
//		GameObject go = new GameObject ("G" + Level1_DataBase.RotationGroup_Index++);
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
//		RotationGroup.Add (rf);
//
//		return go;
////		GameObject go = new GameObject ("G" + Level1_DataBase.RotationGroup_Index++);
////
////		Level1_RotationFix rf = go.AddComponent<Level1_RotationFix> ();
////
////		rf.enabled = false;
////
////		rf.group = go;
////
////		rf.group.transform.parent = parent.transform;
////
////		rf.group.transform.localScale = Vector3.one;
////
////		return rf;
//	}
//
//	//移除整個RotationGroup物件，並移除所有子物件(UFO)
//	static public void DestoryGroup (Level1_RotationFix rf)
//	{
//		Level1_UFO.DestroyUFO (rf.transform.childCount);
//		MonoBehaviour.Destroy (rf.gameObject, 0.5f);
//		Level1_DataBase.RotationGroup_Index--;
//	}
//
//	//加入子物件
//	static public GameObject showResults (GameObject parent, GameObject child)
//	{
//		GameObject go = GameObject.Instantiate (child) as GameObject;
//
//		if (go != null && parent != null) {
//			Transform t = go.transform;
//			t.parent = parent.transform;
//			go.GetComponent<UISprite> ().depth = 1;
//			go.transform.localScale = Level1_DataBase.CheckedScale;
//			go.transform.localPosition = new Vector3 (0, 0, 220);
//			iTween.ScaleFrom (go, iTween.Hash ("scale", Vector3.zero));
//			Destroy (go, 1f);
//		}
//		return go;
//	}
//
//	//UFO與UFO_Random的答案比對
//	static public bool Compare (List<Level1_UFO> UFO, List<Level1_UFO> UFO_Random)
//	{
//		if (UFO.Count != UFO_Random.Count)
//			return false;
//
//		bool result = true;
//
//		for (int i = 0; i <= UFO.Count - 1; i++) {
//			if (UFO [i].GetUFO != UFO_Random [i].GetUFO) {
//				result = false;
//				break;
//			}
//		}
//		
//		return result;
//	}
//
//	/// <summary>
//	/// 紀錄對錯次數
//	/// </summary>
//	static public void Record (bool result)
//	{
//		if (result)
//			BingoCount++;
//		else
//			ErrorCount++;
//	}
//
//	//UFO排列圖座標陣列
//	static public void LoadMap (string map)
//	{
//		//分隔符
//		string[] split_char = { "\n", "\r" };
//		//所有字串
//		string[] lines = map.Trim ().Split (split_char, System.StringSplitOptions.RemoveEmptyEntries);
//
//		int p1 = 1;
//
//		for (int i = 0; i < lines.Length; i++) {
//			//以,#分隔
//			string[] parts = lines [i].Split ("," [0], "#" [0]);
//
//			if (p1 != int.Parse (parts [0])) {
//
//				Level1_DataBase.arrangement.Add (new List<Vector3> ());
//
//				p1 = int.Parse (parts [0]);
//			}
//
//			//加入座標
//			Level1_DataBase.arrangement [int.Parse (parts [0])].Add (new Vector3 (float.Parse (parts [1]), float.Parse (parts [2]), float.Parse (parts [3])));
//		}
//	}
//
//	static public void BackHome ()
//	{
//		AsyncOperation LoadScene = SceneManager.LoadSceneAsync (0);
//	}
//
//	static public void playAgain ()
//	{
//		int scene = SceneManager.GetActiveScene ().buildIndex;
//		SceneManager.LoadScene (scene);
//	}
//
//	static public void DisplayPercent ()
//	{
//		float sum = BingoCount + ErrorCount;
//		float percent = BingoCount / sum;
//		slider_percent.value = percent;
//	}
//
//	static public void DisplayTime (float time)
//	{
//		TimeSpan timeSpan = TimeSpan.FromSeconds (time);
//		label_Time.text = timeSpan.Hours + "h " + timeSpan.Minutes + "m " + timeSpan.Seconds + "s ";
//	}
//
//	static public void DisplayScore ()
//	{
//		label_Bingo.text = BingoCount.ToString ();
//		label_Error.text = ErrorCount.ToString ();
//	}
//
//	static public  void DisplaySliderBar ()
//	{
//		float step = slider_level.GetComponent<UISlider> ().numberOfSteps - 1;
//		float increase = 1 / step;
//		slider_level.GetComponent<UISlider> ().value += increase;
//	}
//
//	static public void FindGameObject ()
//	{
//		//取得Bingo物件
//		Bingo = Resources.Load<GameObject> ("JT/checked-Bingo");
//
//		//取得Error物件
//		Error = Resources.Load<GameObject> ("JT/checked-Error");
//
//		//載入UFO
//		LoadUFO = Resources.LoadAll<GameObject> ("JT/UFO_3D");
//
//		//MainCamera
//		MainCamera = GameObject.Find ("MainCamera");
//
//		//取得UFO_group物件
//		UFO_group = GameObject.Find ("UFO_group").transform;
//
//		UI_Object = GameObject.Find ("UI_Object");
//
//		Billboard = UI_Object.transform.Find ("Billboard").gameObject;
//
//		Wrong = UI_Object.transform.Find ("Wrong").gameObject;
//
//		label_Bingo = Billboard.transform.Find ("Panel/answer/bingo/label_Bingo").gameObject.GetComponent<UILabel> ();
//
//		label_Error = Billboard.transform.Find ("Panel/answer/error/label_Error").gameObject.GetComponent<UILabel> ();
//
//		label_Time = Billboard.transform.Find ("Panel/time/label_Time").gameObject.GetComponent<UILabel> ();
//
//		slider_percent = Billboard.transform.Find ("Panel/finish/percent").gameObject.GetComponent<UISlider> ();
//
//		slider_level = UI_Object.transform.Find ("slider_level").gameObject.gameObject.GetComponent<UISlider> ();
//	}
//
//	//靜態參數初始
//	static public void onDestroy ()
//	{
//		start = false;
//		LevelUP = false;
//
//		UFO.Clear ();
//		UFOList.Clear ();
//		UFO_Random.Clear ();
//		arrangement.Clear ();
//		RotationGroup.Clear ();
//
//		g_iRandom = 0;
//		g_iBalance = 0;
//		g_iTempValue = 0;
//		RotationGroup_Index = 0;
//		BingoCount = 0;
//		ErrorCount = 0;
//
//		Level1_UFO.Original_color = null;
//		Level1_UFO.Red_color = null;
//		Level1_UFO.Gray_color = null;
//
//		Level1_UFO.one = null;
//		Level1_UFO.two = null;
//		Level1_UFO.three = null;
//		Level1_UFO.four = null;
//		Level1_UFO.five = null;
//		Level1_UFO.six = null;
//	}
}
