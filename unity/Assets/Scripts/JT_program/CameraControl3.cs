using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CameraControl3 : Level1_DataBase
{
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

//	public bool m_CameraIsmoving;

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
			-1634,
			-1730,
			-2205,
			-2877,
			-921,
			-1592,
//			-1780,
			-2502,
			-2569
		};
	}

	public void Step (int flag)
	{
		if (flag >= 0 && flag < step.Length)
			TweenPosition.Begin (gameObject, 0.7f, new Vector3 (transform.localPosition.x, transform.localPosition.y, step [flag]));
	}

//	public void Back ()
//	{
//		if (flag < 8)
//			TweenPosition.Begin (gameObject, 0.5f, new Vector3 (transform.localPosition.x, transform.localPosition.y, step [++flag]));
//	}
//
//	public void Forward ()
//	{
//		if (flag > 0)
//			TweenPosition.Begin (gameObject, 0.5f, new Vector3 (transform.localPosition.x, transform.localPosition.y, step [--flag]));
//	}


	//	private void Move2 ()
	//	{
	//		float maxValue = 0;
	//		Vector3 maxPos = new Vector3 ();
	//
	//		//只看最外層的UFO
	//		for (int i = 0; i < Level1_DB.UFOList.Count; i++) {
	//
	//			var pos = Level1_DB.UFOList [i].GetUFO.transform.localPosition;
	//
	//			//local to World
	//			var Local_To_World = transform.TransformVector (pos);
	//			//World to Screen
	//			var World_To_Screen = m_Camera.WorldToScreenPoint (Local_To_World);
	//
	//			float distance = Vector3.Distance (World_To_Screen, ScreenCenter);
	//
	//			if (distance > maxValue) {
	//				maxPos = World_To_Screen;
	//				maxValue = distance;
	//			}
	//	
	//			//指到arrangement的點
	//			Debug.DrawLine (transform.position, Local_To_World, Color.green);
	//	
	//			//			//寬
	//			//			bool b1 = targetToScreenPoint.x < m_ScreenEdgeBuffer || targetToScreenPoint.x > ScreenWidth - m_ScreenEdgeBuffer;
	//			//
	//			//						//高
	//			//			bool b2 = World_To_Screen.y < m_ScreenEdgeBuffer || World_To_Screen.y > ScreenHeight - m_ScreenEdgeBuffer;
	//			//
	//			//			bool b3 = Mathf.Abs (Mathf.Abs (World_To_Screen.x) - 960) < test;
	//			//			
	//			//			bool b4 = Mathf.Abs (World_To_Screen.y) - 540 < test;
	//	
	//			bool b1 = World_To_Screen.x < m_ScreenEdgeBuffer;
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
	//	
	//	
	//			m_CameraIsmoving = false;
	//		}
	//	
	//		bool b5 = Vector2.Distance (maxPos, ScreenCenter) < m_ScreenEdgeBuffer2;
	//	
	//		Debug.Log (Vector2.Distance (maxPos, ScreenCenter));
	//
	//
	////		Debug.DrawLine (transform.position, m_Camera.ScreenToWorldPoint (maxPos), Color.black);
	//	
	//	
	//	
	////		if (b5) {
	////		
	////			transform.Translate (transform.forward * Time.deltaTime * m_movingSpeed * 1.5f);
	////		
	////			m_CameraIsmoving = true;
	////		
	////			return;
	////		}
	//	
	//	
	//	
	//	}
		

	//	IEnumerator stop (float time)
	//	{
	//		yield return new WaitForSeconds (time);
	//		Backward = false;//time秒內可以前進
	//		yield return new WaitForSeconds (1f);
	//		MasterSwitch = false;//time+1秒後完全不動
	//		m_CameraIsmoving = false;
	//	}

	//	void Move ()
	//	{
	//		//當所有UFO停下來執行
	//		if (UFOList.All (list => !(list.m_isMoving))) {
	//			//場上UFO數量有變化時
	//			if (count != UFOList.Count) {
	//				MasterSwitch = true;//開啟總開關
	//				StartCoroutine (Move ());//開始移動
	//				StartCoroutine (stop (ScanTime));//掃描幾秒
	//				count = UFOList.Count;
	//			}
	//		} else {
	//			MasterSwitch = false;//當UFO沒停下來時總開關不開
	//		}
	//	}
	
	//	//符合螢幕範圍
	//	IEnumerator Move ()
	//	{
	//		Backward = true;
	//
	//		while (MasterSwitch) {
	//
	//			m_CameraIsmoving = false;
	//
	//			//4種向前的條件
	//			float case1 = ScreenHeight;
	//			float case2 = ScreenHeight;
	//			float case3 = ScreenWidth;
	//			float case4 = ScreenWidth;
	//
	//			Vector3 pos = Vector3.zero;
	//
	//			for (int i = 0; i < UFO_group.childCount; i++) {
	//
	//				//G0 G1 G2 G3....
	//				if (!UFO_group.GetChild (i))
	//					continue;
	//
	//				for (int j = 0; j < UFO_group.GetChild (i).childCount; j++) {
	//
	//					//UFO1 UFO2 UFO3...
	//					if (!UFO_group.GetChild (i).GetChild (j))
	//						continue;
	//
	//					//UFO_group->G0->UFO1
	//					pos = UFO_group.GetChild (i).GetChild (j).GetChild (0).position;
	//
	//					//將UFO轉換為遊戲畫面上的座標點
	//					Vector3 targetToScreenPoint = m_Camera.WorldToScreenPoint (pos);
	//
	//					//寬
	//					bool b1 = targetToScreenPoint.x < m_ScreenEdgeBuffer || targetToScreenPoint.x > ScreenWidth - m_ScreenEdgeBuffer;
	//					//高
	//					bool b2 = targetToScreenPoint.y < m_ScreenEdgeBuffer || targetToScreenPoint.y > ScreenHeight - m_ScreenEdgeBuffer;
	//
	//					//4種向前的條件
	//					case1 = Mathf.Min (case1, ScreenHeight - targetToScreenPoint.y);
	//					case2 = Mathf.Min (case2, targetToScreenPoint.y);
	//					case3 = Mathf.Min (case3, targetToScreenPoint.x);
	//					case4 = Mathf.Min (case4, ScreenWidth - targetToScreenPoint.x);
	//
	//					//向後
	//					if (b1 || b2) {
	//						if (transform.localPosition.z >= m_MaxSize)
	//							transform.Translate (transform.forward * -Time.deltaTime * m_movingSpeed);
	//						m_CameraIsmoving = true;
	//						Debug.DrawLine (transform.position, pos, Color.red);//繪製螢幕到UFO的射線
	//					}
	//					Debug.DrawLine (transform.position, pos, Color.green);
	//					Debug.DrawLine (transform.position, center, Color.cyan);
	//				}
	//			}
	//
	//			//向前移動
	//			if (Backward) {
	//				//4種條件都符合才前進
	//				bool b1 = case1 > front;
	//				bool b2 = case2 > front;
	//				bool b3 = case3 > front;
	//				bool b4 = case4 > front;
	//
	//				if (b1 && b2 && b3 && b4) {
	//					transform.Translate (transform.forward * Time.deltaTime * m_movingSpeed * 2);
	//					m_CameraIsmoving = true;
	//					Debug.DrawLine (transform.position, pos, Color.yellow);
	//				}
	//			}
	//			yield return null;
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
