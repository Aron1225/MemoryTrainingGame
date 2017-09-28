using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Level1_RotationFix : MonoBehaviour
{
	//子物件的parent
	public GameObject Group;

	///旋轉方向(順時=1,逆時=-1)
	[Range (-2, 2)]
	public int direction = 1;

	//半徑
	//	public int radius_length = 100;

	//子物件成員
	//	public List<Transform> children = new List<Transform> ();
	//	public bool inverse = true;
	//	public float offset = 0;

	void Start ()
	{
		
	}

	//	void OnDestroy ()
	//	{
	//		Destroy (gameObject);
	//	}

	void FixedUpdate ()
	{
		Rotate ();
	}

	private void Rotate ()
	{
		//當子物件為空就移除群組gameobject
		if (transform.childCount == 0)
			Destroy (gameObject);
//			return;
			
		//旋轉整個群組
		transform.Rotate (Vector3.forward * direction * 0.25f);

		//持續修正底下所有UFO
		for (int i = 0; i < transform.childCount; i++) {

			if (!transform.GetChild (i))
				continue;

			//更改子物件角度
			transform.GetChild (i).GetChild (0).localEulerAngles = Vector3.up * transform.localRotation.eulerAngles.z;
		}
	}
}

#region lagency

//	//設定旋轉方式
//	public void SetMode (Mode mode)
//	{
//		Debug.Log ("1");
//
//		//將腳本enable
//		this.enabled = true;
//
//		switch (mode) {
//		case Mode.line:
//			{
//				//Skip(1)省略掉父節點(第一個)
////				children.AddRange (transform.GetComponentsInChildren<Transform> ().Skip (1));
//
//				break;
//			}
//		case Mode.allocate:
//			{
////				children.AddRange (transform.GetComponentsInChildren<Transform> ().Skip (1));
////
////				int angle = 360 / (children.Count / 2);
////
////				for (int i = 0; i < children.Count / 2; i++) {
////					Vector3 pos = new Vector3 (Mathf.Cos (angle * i * Mathf.Deg2Rad) * radius_length, Mathf.Sin (angle * i * Mathf.Deg2Rad) * radius_length, 0);
////					children [i * 2].localPosition = pos;
////				}
//				break;
//			}
//		}
//	}


//		if (inverse) {
//			int angle = 360 / (children.Count / 2);
//
//			for (int i = 0; i < children.Count / 2; i++) {
//				Vector3 pos = new Vector3 (Mathf.Cos (angle * i * Mathf.Deg2Rad) * radius_length, Mathf.Sin (angle * i * Mathf.Deg2Rad) * radius_length, 0);
//				children [i * 2].localPosition = pos;
//			}
//		} else {
//
//			int angle = 360 / (children.Count / 2);
//
//			for (int i = 0; i < children.Count / 2; i++) {
//				Vector3 pos = new Vector3 (Mathf.Cos (offset + angle * i * Mathf.Deg2Rad) * radius_length, Mathf.Sin (offset + angle * i * Mathf.Deg2Rad) * radius_length, 0);
//				children [i * 2].localPosition = pos;
//			}
//		}
//旋轉整個Group

//		//旋轉整個Group
//		transform.Rotate (Vector3.forward * direction * 0.5f);
//
//		//持續修正底下所有UFO
//		for (int i = 0; i < children.Count; i++) {
//
//			if (!children [i]) {
//				//當被點擊時陣列之列會先移除,此步驟是將空的陣列移除
//				children.RemoveAt (i);//刪除物件
//				GetChildren ();
//				continue;
//			}
//
//			//更改子物件角度
//			children [i].GetChild (0).localEulerAngles = Vector3.up * transform.localRotation.eulerAngles.z;
//		}

//		//持續修正底下所有UFO
//		for (int i = 1; i < children.Count; i += 2) {
//
//			if (!children [i]) {
//				//當被點擊時陣列之列會先移除,此步驟是將空的陣列移除
//				children.RemoveRange (i - 1, 2);//刪除父物件與子物件
//				children.AddRange (transform.GetComponentsInChildren<Transform> ().Except (children).Skip (1));//排除掉原本的新增新的
//				continue;
//			}
//
//			children [i].localEulerAngles = Vector3.up * transform.localRotation.eulerAngles.z;
//
////			if (children [i])
////				children [i].localEulerAngles = Vector3.up * transform.localRotation.eulerAngles.z;
////			else {
////				//當被點擊時陣列之列會先移除,此步驟是將空的陣列移除
////				children.RemoveRange (i - 1, 2);//刪除父物件與子物件
////				children.AddRange (transform.GetComponentsInChildren<Transform> ().Except (children).Skip (1));//排除掉原本的新增新的
////			}
//		}


//		if (transform.GetComponentInChildren<Transform> ().childCount > Count) {
//
//			children.AddRange (transform.GetComponentsInChildren<Transform> ().Except (children));
//
//			Count = transform.GetComponentInChildren<Transform> ().childCount;
//
//		} else if (transform.GetComponentInChildren<Transform> ().childCount < Count) {
//
//			children.RemoveAll (list => list != transform.GetComponentsInChildren<Transform> ().Any());
//
//			Count = transform.GetComponentInChildren<Transform> ().childCount;
//		}
//
//		children1 = children;



//		transform.Rotate(new Vector3(0,0,1)*Direction);

//		Quaternion.Inverse (transform.rotation)

//		Vector3 v = new Vector3(0,1,0) * Direction;

//		Debug.Log (transform.localRotation.z);

//		Vector3 k = Quaternion.AngleAxis (0, transform.forward) * Vector3.one;

//		Debug.Log (k);
//		Quaternion v = Quaternion.Euler (100, 0, 0);
//		transform.localRotation.eulerAngles.z = 0f;
//		Debug.Log ("child"+children [1].transform.localRotation);

//		for (int i = 0; i < children.Count; i += 2) {
//			if (children [i]) {
//				children [i].RotateAround (Vector3.zero, Vector3.forward, Time.deltaTime * 20);
//				if (children [i].eulerAngles.x == 270)
//					ck = true;
//				children [i].transform.Rotate(new Vector3(0,1,0));
//				children [i].transform.rotation.eulerAngles.Set(0,10,0);
//				children [i].localEulerAngles = new Vector3(0f, transform.localRotation.eulerAngles.z, 0f);
//				Debug.Log(children [i].localRotation.w);
//				children [i].localRotation = transform.localRotation;
//				children [i].localRotation.eulerAngles = Vector3.zero;
//				children [i].localRotation = Quaternion.identity;
//				Debug.Log (children [i].rotation);
//				if (children [i].eulerAngles.x == 90)
//					ck = false;
//
//				children [i + 1].localEulerAngles = ck ? new  Vector3 (0, children [i].eulerAngles.x + 90f, 0) : new  Vector3 (0, -(children [i].eulerAngles.x + 90f), 0);
//
//			} else {
//				//當被點擊時陣列之列會先移除,此步驟是將空的陣列移除
//				children.RemoveRange (i, 2);
//				children.AddRange (transform.GetComponentsInChildren<Transform> ().Except (children).Skip (1));
//			}
//		}
#endregion