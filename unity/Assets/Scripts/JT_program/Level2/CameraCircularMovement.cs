using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCircularMovement : MonoBehaviour
{
	//移動的半徑
	[Range (0.01f, 2f)]
	public  float radius;
	//高度
	[Range (0.45f, 0.76f)]
	public float initHeightAtDist;
	//相機環繞移動的速度
	[Range (0, 10f)]
	public float RoundSpeed;
	//	private bool dzEnabled;

	//	相機要移動的位置
	private Vector3 cameraPosition;
	private Transform mTrans;
	private Camera m_Camera;
	private float number;
	private Vector3 target = Vector3.zero;

	void Awake ()
	{
		m_Camera = GetComponentInChildren<Camera> ();
		mTrans = transform;
	}

	void Start ()
	{
		cameraPosition.y = mTrans.position.y;
	}

	private void FixedUpdate ()
	{
		FindTarget ();
		RotateAround ();
		Zoom ();
		LookAtTargets ();
	}

	void FindTarget ()
	{
		var point = Vector3.zero;
		int count = Level2_DB.BALLList.Count;
		for (int i = 0; i < count; i++) {
			if (Level2_DB.BALLList.Count == 0 || Level2_DB.BALLList [i] == null)
				continue;
			point += Level2_DB.BALLList [i].transform.position;
		}

		if (Level2_DB.BALLList.Count != 0)
			target = point / count;
		
	}

	void RotateAround ()
	{
		number += Time.deltaTime * RoundSpeed * 0.1f;
		cameraPosition.x = radius * Mathf.Cos (-number);
		cameraPosition.z = radius * Mathf.Sin (-number);
		transform.position = Vector3.Slerp (mTrans.position, cameraPosition, Time.deltaTime * 5);
	}

	void Zoom ()
	{
//		if (dzEnabled) {
		// Measure the new distance and readjust the FOV accordingly.
		var currDistance = Vector3.Distance (mTrans.position, target);
		m_Camera.fieldOfView = FOVForHeightAndDistance (initHeightAtDist, currDistance);
//		}
	}

	// Calculate the frustum height at a given distance from the camera.
	float FrustumHeightAtDistance (float distance)
	{
		return 2.0f * distance * Mathf.Tan (m_Camera.fieldOfView * 0.5f * Mathf.Deg2Rad);
	}

	// Calculate the FOV needed to get a given frustum height at a given distance.
	float FOVForHeightAndDistance (float height, float distance)
	{
		return 2.0f * Mathf.Atan (height * 0.5f / distance) * Mathf.Rad2Deg;
	}

	void LookAtTargets ()
	{
		Vector3 dir = target - mTrans.position;
		float mag = dir.magnitude;

		if (mag > 0.001f) {
			Quaternion lookRot = Quaternion.LookRotation (dir);
			mTrans.rotation = Quaternion.Slerp (mTrans.rotation, lookRot, Mathf.Clamp01 (100 * Time.deltaTime));
		}
	}


	//		var desiredPosition = (transform.position - target.position).normalized * radius;
	//		//desiredPosition.y = ;
	//		transform.position = Vector3.MoveTowards (transform.position, desiredPosition, Time.deltaTime * 100);
	//		transform.localPosition = new Vector3 (transform.localPosition.x, height, transform.localPosition.z);
	//		transform.localPosition = r;
	//		使用Time.deltaTime，使得移動時更加平滑
	//		將速度進行一定比例縮放，方便控制速度(縮放多少都隨意，自己覺得數值修改方便就好)
	//		number += Time.deltaTime * RoundSpeed * 0.1f;
	//		number += Time.deltaTime * 0.1f;
	//		計算並設定新的x和y軸位置
	//		負數是順時針旋轉，正數是逆時針旋轉
	//		cameraPosition.x = radius * Mathf.Cos (-number);
	//		cameraPosition.z = radius * Mathf.Sin (-number);
	//		cameraPosition = transform.TransformPoint (new Vector3 (cameraPosition.x, height, cameraPosition.z));
	//		var desiredPosition = (transform.position - target.position).normalized * radius;
	//		desiredPosition.y = height;
	//		var r = transform.localPosition;
	//		r.y = height;
	//		transform.position = Vector3.MoveTowards(transform.position, desiredPosition, Time.deltaTime * 100);
	//		cameraPosition.y = radius * Mathf.Sin (-number);
	//		cameraPosition.z = radius * Mathf.Cos (-number);
	//		transform.position = Vector3.Slerp (transform.position, desiredPosition, Time.deltaTime * 1000);
	//		transform.position = cameraPosition;
	//		使相機永遠面對著目標物件
	//		transform.LookAt (target.transform.position);
	//	}
}
