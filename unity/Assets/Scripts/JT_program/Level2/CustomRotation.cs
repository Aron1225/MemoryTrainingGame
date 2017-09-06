using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CustomRotation : MonoBehaviour
{
	public float speed;

	void FixedUpdate ()
	{
		transform.Rotate (transform.up * Time.deltaTime * speed);
	}

	public void setDirection (bool Clockwise)
	{
		speed *= Clockwise ? 1 : -1;
	}

	//直接停止
	public void RotateStop ()
	{
		Destroy (this);//移除腳本
	}

	//	//緩慢停止
	//	public void SmoothStop ()
	//	{
	//		StartCoroutine (smooth ());
	//	}
	//
	//	IEnumerator smooth ()
	//	{
	//		while (speed != 0) {
	//			Debug.Log (speed);
	//			Debug.Log ("1");
	//			if (speed > 0)
	//				speed -= 0.5f;
	//			if (speed < 0)
	//				speed += 0.5f;
	//			yield return null;
	//		}
	////		DisableScript ();//停止旋轉後關閉
	//		DestroyScript ();//停止旋轉後移除腳本
	//	}
	//
	//	void DisableScript ()
	//	{
	//		enabled = false;
	//	}
	//
	//	void DestroyScript ()
	//	{
	//		Destroy (this);
	//	}
}
