using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class Level1 : MonoBehaviour
{
	[Tooltip ("UFO Default Light")]
	protected static string UFO_DefaultLight;
	[Tooltip ("UFO Gray Light")]
	protected static string UFO_GrayLight;
	///亂數序列
	protected static List<GameObject> UFO_sequence = new List<GameObject> ();
	///亂數陣列
	protected static List<GameObject> UFO_Random = new List<GameObject> ();
	///點擊陣列
	protected static List<GameObject> UFO = new List<GameObject> ();

	protected static List<GameObject> UFO_OriginalOrder = new List<GameObject> ();


	///二維座標陣列
	protected static  List<List<Vector3>> arrangement = new List<List<Vector3>> ();
	///UFO資訊陣列
	protected static List<CreatUFO> UFOList = new List<CreatUFO> ();
	///UFO物件父節點
	public  static Transform UFO_group;

	protected static Transform UFO_group_Click;


	///UFO移動至下方X軸之位置
	protected static int s_iReferencePoint = -500;
	///UFO間隔
	static int s_iInterval = 90;



	[Header ("Object")]
	[Tooltip ("UIRoot-Panel")]
	[SerializeField]protected GameObject Panel;
	[Tooltip ("BingoIcon")]
	[SerializeField]protected GameObject Bingo;
	[Tooltip ("ErrorIcon")]
	[SerializeField]protected GameObject Error;

	[Space (10)]

	[Tooltip ("UFO Red Light")]
	[SerializeField]protected string UFO_RedLight;



	///關卡難度提升
	protected bool LevelUP = false;



	///下一關圖型
	public static bool s_bNextLevel = false;

	//UFO隨機樣式
	protected int g_iRandom;
	//UFO數量平衡
	protected int g_iBalance;
	///暫存值
	protected int g_iTempValue;
	///載入UFO
	protected GameObject[] LoadUFO;

	protected GameObject SliderBar;

	protected GameObject BackGround;


	protected Vector3 CheckedScale;

	protected WaitUntil WaitValueChange;

	protected WaitUntil WaitUFOReady;

	protected WaitForSeconds WaitOneSecond;


	///UFO生成座標
	protected static Vector3[] GeneratePoint = new Vector3[] {
		new Vector3 (800, 500),
		new Vector3 (800, -500),
		new Vector3 (-800, -500),
		new Vector3 (-800, 500)
	};


	protected class CreatUFO
	{
		//走訪旗標
		public static int m_s_iPos = 0;

		//點擊旗標
		public static int m_s_iClick = 0;

		//物件
		public GameObject getUFO { get; private set; }

		//點擊移動開關 default = false
		public bool m_bToggle{ get; set; }

		//是否在移動 default = false
		public bool isMoving{ get; set; }

		private TweenPosition TP;

		//點擊事件
		public void OnClick (GameObject obj)
		{
			Debug.Log (obj.name + m_bToggle);

			isMoving = true;

			if (m_bToggle) {

				obj.transform.parent = UFO_group_Click.transform;

//				Level1_RotationFix.children.Remove (obj.transform);

				//移動到下方
				TP = TweenPosition.Begin (obj, 0.5f, new Vector3 (s_iReferencePoint, -316, 0));
				//指向下一個位置
				s_iReferencePoint += s_iInterval;
				//加入UFO陣列
				UFO.Add (obj);


				try {
					UFO [m_s_iClick - 1].GetComponent<SphereCollider> ().enabled = false;//設計當點下最後一個UFO時全關閉BoxCollider之後再統一開啟
					UFO [m_s_iClick - 1].GetComponent<UISprite> ().spriteName = UFO_GrayLight;

				} catch (Exception e) {
				}	

				m_s_iClick++;

				m_bToggle = !m_bToggle;

			} else {

				obj.transform.parent = UFO_group.transform;

//				Level1_RotationFix.children.Add (obj.transform);

				//指向上一個位置
				s_iReferencePoint -= s_iInterval;

				m_bToggle = !m_bToggle;

				m_s_iClick--;

				try {
					UFO [m_s_iClick - 1].GetComponent<SphereCollider> ().enabled = true;
					UFO [m_s_iClick - 1].GetComponent<UISprite> ().spriteName = UFO_DefaultLight;
				} catch (Exception e) {
				}	

				//從UFO陣列移除
				UFO.Remove (obj);
			}
		}


		//建構子
		public CreatUFO (GameObject go, bool Ready)//Ready-> true:duration = 0.5f   false:duration = 1f;
		{
			m_bToggle = true;

			isMoving = true;

			//實例化物件並設定父節點
			go = Instantiate (go, parent: UFO_group.transform) as GameObject;

			//設定實例化位置
			go.transform.localPosition = GeneratePoint [m_s_iPos % 4];

			//設定大小為Vector3(1,1,1)
			go.transform.localScale = Vector3.one;

			//移動到當前關卡座標//
			//TP = TweenPosition.Begin (go, Ready ? 0.5f : 1f, arrangement [Level1_Select._arrangement_index] [m_s_iPos++]);

			//加入UFO_sequence陣列
			UFO_sequence.Add (go);

			this.getUFO = go;

			if (!Ready)
				UFO_OriginalOrder.Add (go);
			else
//				Level1_RotationFix.children.Add (go.transform);

			//Listen
			UIEventListener.Get (go).onClick = OnClick;

			//設定onFinished Event   "onshot = false"
			EventDelegate.Add (TP.onFinished, () => {

				if (Ready) {
					Ready = false;
					UFO_OriginalOrder.Add (go);
				}

				isMoving = false;
				TP.duration = 0.5f;
				TP.delay = 0f;


			});
		}

	}


	protected void Initialization ()
	{
		//取得Panel物件
		Panel = GameObject.Find ("Panel");

		//取得UFO_group物件
		UFO_group = GameObject.Find ("UFO_group").transform;

		UFO_group_Click = GameObject.Find ("UFO_group_Click").transform;

		//取得Control - Colored Slider物件
		SliderBar = GameObject.Find ("Control - Colored Slider");

		//取得Bingo物件
		Bingo = Resources.Load<GameObject> ("JT/" + "checked-Bingo");

		//取得Error物件
		Error = Resources.Load<GameObject> ("JT/" + "checked-Error");

		//載入UFO
		LoadUFO = Resources.LoadAll<GameObject> ("JT/UFO_groupAll");

		BackGround = GameObject.Find ("background");

		//WaitValueChange = new WaitUntil (() => g_iTempValue != Level1_Select._arrangement_index);

		WaitUFOReady = new WaitUntil (() => UFOList.All (list => !(list.isMoving)));

		WaitOneSecond = new WaitForSeconds (1f);

		CheckedScale = new Vector3 (140, 140, 0);

		//設定亂數種子
		UnityEngine.Random.InitState (System.Guid.NewGuid ().GetHashCode ());

		InitializationParameter ();
	}

	public virtual void InitializationParameter ()
	{
		Debug.LogError ("繼承自Level1之InitializationParameter未覆寫");
	}

}


