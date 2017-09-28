using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

	[HideInInspector]
	public float[] step;

	public void Step (int flag)
	{
		if (flag >= 0 && flag < step.Length)
			TweenPosition.Begin (gameObject, 0.7f, new Vector3 (transform.localPosition.x, transform.localPosition.y, step [flag]));
	}
}
