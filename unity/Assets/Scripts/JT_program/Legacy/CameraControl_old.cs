using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl_old : MonoBehaviour
{
	public bool CameraFollow = false;
	public float m_DampTime = 0.2f;//平滑移動時間
	public float m_ScreenEdgeBuffer = 200f;//邊緣緩衝
	//最小焦段
	public float m_MinSize = 30f;
	//焦段縮放係數,越大縮放越多
	public float m_Zoon = 2f;
	//綠屏定值
	public float offset = 5;
	private Camera m_Camera;
	//螢幕高
	private int ScreenHeight = Screen.height;

	//螢幕寬
	private int ScreenWidth = Screen.width;
	//(高-寬)/2
	private int W_H_Diff = (Screen.width - Screen.height) / 2;

	private float m_ZoomSpeed;

	private Vector3 m_MoveVelocity;

	//Camera要移動到的位置
	private Vector3 m_DesiredPosition;

	//中心點
	private Vector3 AveragePos;

	public Transform[] Targets;

	private void Awake ()
	{
		m_Camera = GetComponent<Camera> ();
	}

	private void FixedUpdate ()
	{
		//Camera移動
		if (CameraFollow)
			Move ();

		//焦段縮放
		Zoom ();
	}


	private void Move ()
	{
		//找到平均點
		FindAveragePosition ();

		//移動到平均點
		transform.position = Vector3.SmoothDamp (transform.position, m_DesiredPosition, ref m_MoveVelocity, m_DampTime);
	}


	private void FindAveragePosition ()
	{
		//平均點
		Vector3 averagePos = new Vector3 ();
		//目標群
		int numTargets = 0;

		//走訪所有目標物件
		for (int i = 0; i < Targets.Length; i++) {
			//當不存在時跳過,找尋下一個
			if (!Targets [i])
				continue;
			
			//將目標位置加總
			averagePos += Targets [i].position;
			//將存在場上的數量加總
			numTargets++;
		}

		//當目標群大於0時,相除找平均點
		if (numTargets > 0)
			averagePos /= numTargets;

		//位置相加除總數的中心點
		AveragePos = averagePos;

		//保持Z軸值一致(Camera那端的中心點)
		averagePos.z = transform.position.z;

		//Camera要移動到的位置
		m_DesiredPosition = averagePos;
	}

	public bool ReSetZoon = false;

	private void Zoom ()
	{
		//找到適合的fieldOfView值
		float requiredSize = FindRequiredSize ();

		if (ReSetZoon) {

			if (m_Camera.fieldOfView > 30)
//				m_Camera.fieldOfView = Mathf.SmoothDamp (m_Camera.fieldOfView, m_Camera.fieldOfView - 1, ref m_ZoomSpeed, m_DampTime);
				m_Camera.fieldOfView--;

//			requiredSize = Mathf.Max (requiredSize, m_MinSize);

//			m_Camera.fieldOfView = Mathf.SmoothDamp (m_Camera.fieldOfView, 0, ref m_ZoomSpeed, m_DampTime);

//			requiredSize += m_Camera.fieldOfView;

			if (requiredSize != 0)
				ReSetZoon = false;
		}

//		requiredSize = m_Camera.fieldOfView - requiredSize;

		requiredSize += m_Camera.fieldOfView;
		//限制最小Zoom
		requiredSize = Mathf.Max (requiredSize, m_MinSize);

		m_Camera.fieldOfView = Mathf.SmoothDamp (m_Camera.fieldOfView, requiredSize, ref m_ZoomSpeed, m_DampTime);
	}



	private float FindRequiredSize ()
	{
		float size = 0;

		for (int i = 0; i < Targets.Length; i++) {
			
			if (!Targets [i])
				continue;

			//將UFO轉換為遊戲畫面上的座標點
			Vector3 targetToScreenPoint = m_Camera.WorldToScreenPoint (Targets [i].position);

			//從螢幕到UFO的射線
//			Ray targetRay = m_Camera.ScreenPointToRay (targetToScreenPoint);

			//UFO
//			RaycastHit hit;

			//當射線可以到達UFO
//			bool b1 = Physics.Raycast (targetRay, out hit);
			//右上角
//			bool b2 = targetToScreenPoint.x < (Screen.width - m_ScreenEdgeBuffer) && targetToScreenPoint.y < (Screen.height - m_ScreenEdgeBuffer);
			//左下角
//			bool b3 = targetToScreenPoint.x > m_ScreenEdgeBuffer && targetToScreenPoint.y > m_ScreenEdgeBuffer;

//			bool b4 = Targets.Length != 0;

//			if (!(b2 && b3))
//				return m_Zoon;


			bool b1 = (targetToScreenPoint.x - (ScreenWidth - W_H_Diff)) > -m_ScreenEdgeBuffer || (targetToScreenPoint.y - ScreenHeight) > -m_ScreenEdgeBuffer;
			bool b2 = (targetToScreenPoint.x - W_H_Diff) < -m_ScreenEdgeBuffer || targetToScreenPoint.y < m_ScreenEdgeBuffer;


//			bool b1 = (targetToScreenPoint.x - Screen.width) > -m_ScreenEdgeBuffer;
//				|| (targetToScreenPoint.y - Screen.height) > -m_ScreenEdgeBuffer;

//			bool b2 = targetToScreenPoint.x < m_ScreenEdgeBuffer || targetToScreenPoint.y < m_ScreenEdgeBuffer;


//			bool b3 = (targetToScreenPoint.x - Screen.width) < -m_ScreenEdgeBuffer;
//
//			bool b4 = (targetToScreenPoint.x - 0) < -m_ScreenEdgeBuffer || (targetToScreenPoint.y - 0) < -m_ScreenEdgeBuffer;



			if (b1 || b2) {
				size = m_Zoon;
			}



			//繪製螢幕到UFO的射線
			Debug.DrawLine (m_Camera.transform.position, Targets [i].position, Color.red);

			Debug.DrawLine (m_Camera.transform.position, AveragePos, Color.cyan);



		}






		return size;
	}

	//	public void ReSetZoon ()
	//	{
	//
	//		for (int i = 0; i < Targets.Length; i++) {
	//
	//			if (!Targets [i])
	//				continue;
	//
	//			//將UFO轉換為遊戲畫面上的座標點
	//			Vector3 targetToScreenPoint = m_Camera.WorldToScreenPoint (Targets [i].position);
	//
	//			if (targetToScreenPoint.x  - (Screen.width - m_ScreenEdgeBuffer) > 100)
	//				m_Camera.fieldOfView--;
	//
	//		}
	//
	////		m_Camera.fieldOfView = Mathf.SmoothDamp (m_Camera.fieldOfView, 30, ref m_ZoomSpeed, m_DampTime);
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
