using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Level2_Cylinder_rotation : MonoBehaviour
{

//	[Header ("Object")]
//	[Tooltip("Cylinder物件")]
//	[SerializeField]private GameObject Cylinder;
//	[SerializeField]private List<GameObject> Anchor = new List<GameObject> ();
//
//
//	[Header ("Status")]
//	[Range (0, 10)]
//	[Tooltip("Cylinder轉速")]
//	public int Cylinder_speed = 5;
//
//	[Range (0, 10)]
//	[Tooltip("Anchor轉速")]
//	public int Anchor_speed = 5;
//
//	[Header ("ShowLight")]
//	public Level2_display ShowLight_instantiate;
//
//	bool rotation = false;
//
//
//
//	void Start ()
//	{
//		
//	}
//	
//	// Update is called once per frame
//	void Update ()
//	{
//		Cylinder.transform.Rotate (Vector3.up, Time.deltaTime * Cylinder_speed * 10);
//		if (rotation) {
//			Anchor.ForEach (i => i.transform.Rotate (Vector3.up, Time.deltaTime * Anchor_speed * 10));
//		}
//	}
//
//	public void click ()
//	{
//		if (rotation) {
//			rotation = false;
//			CancelInvoke ("ShowLight");
//		} else {
//			rotation = true;
//			Level2_display.ball_Arr = 0;
//			InvokeRepeating ("ShowLight", 1f, 1f);
//
//		}
//	}
//
//	void ShowLight ()
//	{
//		ShowLight_instantiate.ShowLight ();
//	}

}
