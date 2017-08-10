using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class UFO
{
	//UFO建置的parent位置
	static public  Transform UFO_group;

	//讓UFO連續從四個頂點新增
	static public  int s_iPos = 0;

	//物件
	public GameObject GetUFO { get; private set; }

	//點擊移動開關 default = false
	public bool m_bToggle{ get; set; }

	//是否在移動 default = false
	public bool m_isMoving{ get; set; }

	///UFO生成座標
	public static Vector3[] GeneratePoint = new Vector3[] {
		new Vector3 (800, 500),
		new Vector3 (800, -500),
		new Vector3 (-800, -500),
		new Vector3 (-800, 500)
	};

	//建構子
	public UFO (GameObject go)
	{
		//實例化物件並設定父節點
		if (go != null) {
			this.GetUFO = MonoBehaviour.Instantiate (go) as GameObject;
			this.GetUFO.transform.parent = UFO_group;
		}
	}

	//從UFOList中新增UFO
	static public List<UFO> InstantiateUFOs (int lack)
	{
		//新加入UFO,保留原本UFO並加入新UFO
		List<UFO> TempUFOList = new List<UFO> ();

		//設定座標 & 實例化UFO
		for (int i = 0; i < lack; i++) {

			UFO ufo = new UFO (Level1_DB.LoadUFO [Level1_DB.g_iRandom]);

			ufo.GetUFO.transform.localPosition = GeneratePoint [s_iPos++ % 4];

			Level1_DB.UFOList.Add (ufo);

			TempUFOList.Add (ufo);

			ufo.AddListener ();
		}
		return TempUFOList;
	}

	//從UFOList、UFO中移除UFO
	static public void DestroyUFO (int extra, float duration = 0.5f)
	{
		//Destroy幾台
		for (int i = 0; i < extra; i++) {

			var go = Level1_DB.UFOList [Level1_DB.UFOList.Count - 1];

			go.moveTo (duration, GeneratePoint [i % 4]);

			Level1_DB.UFOList.Remove (go);

			MonoBehaviour.Destroy (go.GetUFO, 1.5f);

			Level1_DB.UFO.Remove (go);
		}
	}

	static public void AllColliderEnabled (bool enabled)
	{
		Level1_DB.UFOList.ForEach (go => go.GetUFO.GetComponent<SphereCollider> ().enabled = enabled);
	}

	//Initmove -> (duration,Pos,true,delay)
	//Initmove -> (duration,Pos,true)
	//moveTo ->(duration,Pos)
	public void moveTo (float duration, Vector3 pos, bool bToggle = false, float delay = 0)
	{
		this.m_isMoving = true;

		if (bToggle)
			this.m_bToggle = true;

		TweenPosition TP = TweenPosition.Begin (this.GetUFO, duration, pos);

		TP.onFinished.Add (new EventDelegate (() => m_isMoving = false));
		//true=>從按下play後就開始計算時間,false=>直到正式開始遊戲時才計算時間
		TP.ignoreTimeScale = false;

		TP.delay = delay;
	}
		
	//直接設定UFO位置(目前用於第4關
	public void setPos (Vector3 pos)
	{
		this.GetUFO.transform.localPosition = pos;
		this.m_bToggle = true;
	}

	//點擊事件
	void OnClick (GameObject ufo)
	{
		if (this.m_bToggle) {

			this.Gray ();

			//加入UFO陣列
			Level1_DB.UFO.Add (this);

		} else {

			this.Original ();

			//從UFO陣列移除
			Level1_DB.UFO.Remove (this);
		}
	}

	//UFO原始顏色
	public void Original (bool Collider = true)
	{
		//找到當前UFO的發光模型
		if (Level1_DB.Original_color == null) {
			Level1_DB.Original_color = Resources.Load<GameObject> ("JT/UFO_3D/" + this.GetUFO.gameObject.name.Replace ("R(Clone)", ""));
			//當來源不存在
			if (Level1_DB.Original_color == null) {
				Debug.LogError ("Missing Original 3D Model");
				return;
			}
		}

		this.ReplaceTheUFO (Level1_DB.Original_color);
		this.m_bToggle = true;
		AddListener ();
		ColliderEnabled (Collider);
	}

	//UFO紅色
	public void Red ()
	{
		//找到當前UFO的發光模型
		if (Level1_DB.Red_color == null) {
			Level1_DB.Red_color = Resources.Load<GameObject> ("JT/UFO_3D(R)/" + this.GetUFO.gameObject.name.Replace ("(Clone)", "") + "R");
			//當來源不存在
			if (Level1_DB.Red_color == null) {
				Debug.LogError ("Missing Red 3D Model");
				return;
			}
		}

		this.ReplaceTheUFO (Level1_DB.Red_color);
	}

	//UFO灰色
	public void Gray ()
	{
		//找到當前UFO的發光模型
		if (Level1_DB.Gray_color == null) {
			Level1_DB.Gray_color = Resources.Load<GameObject> ("JT/UFO_3D(G)/" + this.GetUFO.gameObject.name.Replace ("(Clone)", "") + "G");
			//當來源不存在
			if (Level1_DB.Gray_color == null) {
				Debug.LogError ("Missing Gray 3D Model");
				return;
			}
		}

		this.ReplaceTheUFO (Level1_DB.Gray_color);
		this.m_bToggle = false;
		AddListener ();
		ColliderEnabled (true);
	}

	//Add Listener
	private void AddListener ()
	{
		//Listen
		UIEventListener.Get (this.GetUFO).onClick = OnClick;
	}

	private void ColliderEnabled (bool Collider)
	{
		if (Collider)
			this.GetUFO.GetComponent<SphereCollider> ().enabled = true;
	}

	//替換UFO
	private void ReplaceTheUFO (GameObject colorufo)
	{
		//實例化後發現子物件的transform值預設為(0,0,0)，因此必須再移除原模型前先將子物件值保留
		var tmp = this.GetUFO.transform.GetChild (0).localEulerAngles;

		//移除原模型
		if (this.GetUFO != null)
			MonoBehaviour.Destroy (this.GetUFO.transform.gameObject);

		GameObject go = MonoBehaviour.Instantiate (colorufo, this.GetUFO.transform.parent);

		go.transform.position = this.GetUFO.transform.position;

		go.transform.localRotation = this.GetUFO.transform.localRotation;

		go.transform.localScale = this.GetUFO.transform.localScale;

		this.GetUFO = go;

		this.GetUFO.transform.GetChild (0).localEulerAngles = tmp;//實例化後將子物件設定為原來值
	}
}
