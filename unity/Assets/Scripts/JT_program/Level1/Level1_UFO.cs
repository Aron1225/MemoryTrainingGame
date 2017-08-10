using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using AnimationOrTween;

[System.Serializable]
public class Level1_UFO
{
//	//UFO建置的parent位置
//	static public  Transform UFO_group;
//	//Color
//	static public  GameObject Original_color;
//	static public  GameObject Red_color;
//	static public  GameObject Gray_color;
//	//各關物件
//	static public  Level1_1 one;
//	static public  Level1_2 two;
//	static public  Level1_3 three;
//	static public  Level1_4 four;
//	static public  Level1_5 five;
//	static public  Level1_6 six;
//
//	//讓UFO連續從四個頂點新增
//	public static int s_iPos = 0;
//
//	//物件
//	public GameObject GetUFO { get; private set; }
//
//	//點擊移動開關 default = false
//	public bool m_bToggle{ get; set; }
//
//	//是否在移動 default = false
//	public bool m_isMoving{ get; set; }
//
//
//	///UFO生成座標
//	public static Vector3[] GeneratePoint = new Vector3[] {
//		new Vector3 (800, 500),
//		new Vector3 (800, -500),
//		new Vector3 (-800, -500),
//		new Vector3 (-800, 500)
//	};
//
//	//建構子
//	public Level1_UFO (GameObject go)
//	{
////		實例化物件並設定父節點
//		if (go != null) {
//			this.GetUFO = MonoBehaviour.Instantiate (go) as GameObject;
//			this.GetUFO.transform.parent = UFO_group;
//		}
//	}
//
//	//從UFOList中新增UFO
//	static public List<Level1_UFO> InstantiateUFOs (int lack)
//	{
//		//新加入UFO,保留原本UFO並加入新UFO
//		List<Level1_UFO> TempUFOList = new List<Level1_UFO> ();
//
//		//設定座標 & 實例化UFO
//		for (int i = 0; i < lack; i++) {
//
//			Level1_UFO ufo = new Level1_UFO (Level1_DataBase.LoadUFO [Level1_DataBase.g_iRandom]);
//
//			ufo.GetUFO.transform.localPosition = GeneratePoint [s_iPos++ % 4];
//
//			Level1_DataBase.UFOList.Add (ufo);
//
//			TempUFOList.Add (ufo);
//
//			ufo.AddListener ();
//		}
//		return TempUFOList;
//	}
//
//	//從UFOList、UFO中移除UFO
//	static public void DestroyUFO (int extra, float duration = 0.5f)
//	{
//		//Destroy幾台
//		for (int i = 0; i < extra; i++) {
//
//			var go = Level1_DataBase.UFOList.Last ();
//
//			go.moveTo (duration, GeneratePoint [i % 4]);
//
//			Level1_DataBase.UFOList.Remove (go);
//
//			MonoBehaviour.Destroy (go.GetUFO, 1.5f);
//
//			Level1_DataBase.UFO.Remove (go);
//		}
//	}
//
//
//	//Initmove -> (duration,Pos,true,delay)
//	//Initmove -> (duration,Pos,true)
//	//moveTo ->(duration,Pos)
//	public void moveTo (float duration, Vector3 pos, bool bToggle = false, float delay = 0)
//	{
//		this.m_isMoving = true;
//
//		if (bToggle)
//			this.m_bToggle = true;
//
//		TweenPosition TP = TweenPosition.Begin (this.GetUFO, duration, pos);
//
//		TP.onFinished.Add (new EventDelegate (() => m_isMoving = false));
//		//true=>從按下play後就開始計算時間,false=>直到正式開始遊戲時才計算時間
//		TP.ignoreTimeScale = false;
//
//		TP.delay = delay;
//	}
//
//
//	//直接設定UFO位置(目前用於第4關
//	public void setPos (Vector3 pos)
//	{
//		this.GetUFO.transform.localPosition = pos;
//		this.m_bToggle = true;
//	}
//
//
//	//點擊事件
//	void OnClick (GameObject obj)
//	{
//		if (one)
//			Level1_1.UFO_OnClick (this);
//		if (two)
//			Level1_2.UFO_OnClick (this);
//		if (three)
//			Level1_3.UFO_OnClick (this);
//		if (four)
//			Level1_4.UFO_OnClick (this);
//		if (five)
//			Level1_5.UFO_OnClick (this);
//		if (six)
//			Level1_6.UFO_OnClick (this);
//	}
//
//	//UFO原始顏色
//	public void Original (bool Collider = true)
//	{
//		//找到當前UFO的發光模型
//		if (Original_color == null) {
//			Original_color = Resources.Load<GameObject> ("JT/UFO_3D/" + this.GetUFO.gameObject.name.Replace ("R(Clone)", ""));
//			//當來源不存在
//			if (Original_color == null) {
//				Debug.LogError ("Missing Original 3D Model");
//				return;
//			}
//		}
//
//		this.ReplaceTheUFO (Original_color);
//		this.m_bToggle = true;
//		AddListener ();
//		ColliderEnabled (Collider);
//	}
//
//	//UFO紅色
//	public void Red ()
//	{
//		//找到當前UFO的發光模型
//		if (Red_color == null) {
//			Red_color = Resources.Load<GameObject> ("JT/UFO_3D(R)/" + this.GetUFO.gameObject.name.Replace ("(Clone)", "") + "R");
//			//當來源不存在
//			if (Red_color == null) {
//				Debug.LogError ("Missing Red 3D Model");
//				return;
//			}
//		}
//
//		this.ReplaceTheUFO (Red_color);
//	}
//
//	//UFO灰色
//	public void Gray ()
//	{
//		//找到當前UFO的發光模型
//		if (Gray_color == null) {
//			Gray_color = Resources.Load<GameObject> ("JT/UFO_3D(G)/" + this.GetUFO.gameObject.name.Replace ("(Clone)", "") + "G");
//			//當來源不存在
//			if (Gray_color == null) {
//				Debug.LogError ("Missing Gray 3D Model");
//				return;
//			}
//		}
//
//		this.ReplaceTheUFO (Gray_color);
//		this.m_bToggle = false;
//		AddListener ();
//		ColliderEnabled (true);
//	}
//
//
//	//Add Listener
//	private void AddListener ()
//	{
//		//Listen
//		UIEventListener.Get (this.GetUFO).onClick = OnClick;
//	}
//
//	private void ColliderEnabled (bool Collider)
//	{
//		if (Collider)
//			this.GetUFO.GetComponent<SphereCollider> ().enabled = true;
//	}
//
//	//替換UFO
//	private void ReplaceTheUFO (GameObject colorufo)
//	{
//		//實例化後發現子物件的transform值預設為(0,0,0)，因此必須再移除原模型前先將子物件值保留
//		var tmp = this.GetUFO.transform.GetChild (0).localEulerAngles;
//
//		//移除原模型
//		if (this.GetUFO != null)
//			MonoBehaviour.Destroy (this.GetUFO.transform.gameObject);
//
//		GameObject go = MonoBehaviour.Instantiate (colorufo, this.GetUFO.transform.parent);
//
//		go.transform.position = this.GetUFO.transform.position;
//
//		go.transform.localRotation = this.GetUFO.transform.localRotation;
//
//		go.transform.localScale = this.GetUFO.transform.localScale;
//
//		this.GetUFO = go;
//
//		this.GetUFO.transform.GetChild (0).localEulerAngles = tmp;//實例化後將子物件設定為原來值
//	}
//
//
//	//	//替換UFO
//	//	public GameObject ReplaceTheUFO_old (GameObject colorufo, Transform UFO_Transform)
//	//	{
//	//		GameObject go = MonoBehaviour.Instantiate (colorufo, UFO_Transform.position, UFO_Transform.localRotation, UFO_group) as GameObject;
//	//
//	//		GameObject go = MonoBehaviour.Instantiate (colorufo, UFO_group);
//	//
//	//		go.transform.position = UFO_Transform.position;
//	//
//	//		go.transform.localRotation = UFO_Transform.localRotation;
//	//
//	//		go.transform.localScale = UFO_Transform.localScale;
//	//
//	//		go.transform.GetChild(0).rotation = UFO_Transform.localRotation;
//	//
//	//		Debug.Log(UFO_Transform.localRotation);
//	//
//	//		go.transform.GetChild(0).rotation.eulerAngles.Set(0,UFO_Transform.localRotation.y,0);
//	//
//	//	Debug.Log (go.transform.rotation);
//	//	Debug.Log (go.transform.GetChild (0).rotation);
//	//
//	//	go.GetComponentInChildren<Transform> ().rotation = Quaternion.Euler (new Vector3 (-90, 0, 0));
//	//
//	//		return go;
//	//	}
}
