using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CameraControl2 : MonoBehaviour
{
//	public Level1_DB DB;

	//	//邊緣緩衝(向後
	//	public float m_ScreenEdgeBuffer = 0;
	//	//邊緣緩衝(向前
	//	public float m_ScreenEdgeBuffer2 = 0;
	//	//焦段縮放係數,越大縮放越多
	//	public float m_movingSpeed = 3f;
	//	//最大焦段
	//	public float m_MaxSize;
	//	//最小焦段
	//	public float m_MinSize;
	//綠屏定值
	public float offset = 5;

	//Camera
//	private Camera m_Camera;
	//螢幕高
	private int ScreenHeight;
	//螢幕寬
	private int ScreenWidth;

	private Vector2 ScreenCenter;
	//Camera要移動到的位置
	private Vector3 m_DesiredPosition;
	//中心點
	private Vector3 center;

	float[] step;
	//	int flag = 0;

	private void Awake ()
	{
//		m_Camera = GetComponent<Camera> ();
		ScreenHeight = Screen.height;//螢幕高
		ScreenWidth = Screen.width;//螢幕寬
		ScreenCenter = new Vector2 (ScreenWidth / 2, ScreenHeight / 2);
		m_DesiredPosition = Vector3.zero;//Camera要移動到的位置
		center = Vector3.zero;//中心點
	}

	void Start ()
	{
		step = new float[] {
			-417,
			-862,
			-1350,
			-1746,
			-2184,
		};
	}


	public void Step (int flag)
	{
		if (flag >= 0 && flag < step.Length)
			TweenPosition.Begin (gameObject, 0.7f, new Vector3 (transform.localPosition.x, transform.localPosition.y, step [flag]));
	}

	//	public void Back ()
	//	{
	//		if (flag < step.Length - 1)
	//			TweenPosition.Begin (gameObject, 0.5f, new Vector3 (transform.localPosition.x, transform.localPosition.y, step [++flag]));
	//	}
	//
	//	public void Forward ()
	//	{
	//		if (flag > 0)
	//			TweenPosition.Begin (gameObject, 0.5f, new Vector3 (transform.localPosition.x, transform.localPosition.y, step [--flag]));
	//	}

//	private void FixedUpdate ()
//	{
//		if (Level1_DB.UFOList.All (list => !(list.m_isMoving)))
//			Move ();
//
//		Move2 ();
//	}

	//	private void Move2 ()
	//	{
	//		//只看最外層的UFO
	//		for (int i = 0; i < DB.arrangement [DB.arrangement_index].Count; i++) {
	//
	//			var pos = DB.arrangement [DB.arrangement_index] [i];
	//
	//			//local to World
	//			var Local_To_World = transform.TransformVector (pos);
	//
	//			var World_To_Screen = m_Camera.WorldToScreenPoint (Local_To_World);
	//
	//
	//			//指到arrangement的點
	//			Debug.DrawLine (transform.position, Local_To_World, Color.green);
	//
	//
	//			//寬
	//			bool b1 = targetToScreenPoint.x < m_ScreenEdgeBuffer || targetToScreenPoint.x > ScreenWidth - m_ScreenEdgeBuffer;
	//
	//			//高
	//			bool b2 = World_To_Screen.y < m_ScreenEdgeBuffer || World_To_Screen.y > ScreenHeight - m_ScreenEdgeBuffer;
	//
	//			bool b3 = Mathf.Abs (Mathf.Abs (World_To_Screen.x) - 960) < test;
	//
	//			bool b4 = Mathf.Abs (World_To_Screen.y) - 540 < test;
	//
	//			bool b1 = World_To_Screen.x < m_ScreenEdgeBuffer;
	//
	//			bool b5 = Vector2.Distance (new Vector2 (World_To_Screen.x, World_To_Screen.y), ScreenCenter) < m_ScreenEdgeBuffer2;
	//
	//			if (b1) {
	//				if (transform.localPosition.z >= m_MaxSize)
	//					transform.Translate (transform.forward * -Time.deltaTime * m_movingSpeed);
	//
	//				m_CameraIsmoving = true;
	//
	//				return;
	//			}
	//
	//			if (b5) {
	//				transform.Translate (transform.forward * Time.deltaTime * m_movingSpeed * 1.5f);
	//
	//				m_CameraIsmoving = true;
	//
	//				return;
	//			}
	//
	//			m_CameraIsmoving = false;
	//		}
	//	}
		
	//	//符合螢幕範圍
	//	private void Move ()
	//	{
	//		m_CameraIsmoving = false;
	//
	//		for (int i = 0; i < DB.UFO_group.childCount; i++) {
	//
	//			if (!DB.UFO_group.GetChild (i))
	//				continue;
	//
	//			//將UFO轉換為遊戲畫面上的座標點
	//			Vector3 targetToScreenPoint = m_Camera.WorldToScreenPoint (DB.UFO_group.GetChild (i).position);
	//
	//			//寬
	//			bool b1 = targetToScreenPoint.x < m_ScreenEdgeBuffer || targetToScreenPoint.x > ScreenWidth - m_ScreenEdgeBuffer;
	//			//高
	//			bool b2 = targetToScreenPoint.y < m_ScreenEdgeBuffer || targetToScreenPoint.y > ScreenHeight - m_ScreenEdgeBuffer;
	//
	//
	//			if (b1 || b2) {
	//				if (transform.localPosition.z >= m_MaxSize)
	//					transform.Translate (transform.forward * -Time.deltaTime * m_movingSpeed);
	//
	//				m_CameraIsmoving = true;
	//
	//				Debug.DrawLine (transform.position, DB.UFO_group.GetChild (i).position, Color.red);//繪製螢幕到UFO的射線
	//				return;
	//			}
	//
	//			Debug.DrawLine (transform.position, DB.UFO_group.GetChild (i).position, Color.green);
	//
	//			Debug.DrawLine (transform.position, center, Color.cyan);
	//		}
	//	}

	void OnDrawGizmos ()
	{
		//綠屏中心點
		Vector3 center = new Vector3 (m_DesiredPosition.x, m_DesiredPosition.y, 0);
		//綠屏右上方頂點
		var rect_tr = GetComponent<Camera> ().ScreenToWorldPoint (new Vector3 (ScreenWidth, ScreenHeight, offset));
		//綠屏左下方頂點
		var rect_bl = GetComponent<Camera> ().ScreenToWorldPoint (Vector3.zero);
		//綠屏寬
		float width = (rect_tr - rect_bl).x;
		//綠屏高
		float Height = (rect_tr - rect_bl).y;
		//綠色
		Gizmos.color = new Color (0.0f, 1.0f, 0.0f, 0.5f);
		//繪製綠屏
		Gizmos.DrawCube (center, new Vector3 (width, Height, 0));

	}
}
