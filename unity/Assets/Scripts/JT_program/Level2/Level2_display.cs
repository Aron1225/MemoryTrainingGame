using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Threading;

public class Level2_display : MonoBehaviour
{
	[Header ("Object")] 
	[Tooltip("UIRoot-Panel")]
	[SerializeField]private GameObject Panel;
	[Tooltip("BingoIcon")]
	[SerializeField]private GameObject Bingo;
	[Tooltip("ErrorIcon")]
	[SerializeField]private GameObject Error;

	[Space(10)]

	[Header ("GameObject")]
	[Tooltip("亂數序列")]
	public List<GameObject> Ball_sequence = new List<GameObject> ();
	[Tooltip("亂數陣列")]
	public List<GameObject> Ball_Random = new List<GameObject> ();
	///點擊陣列
	public static List<GameObject> Ball = new List<GameObject> ();

	[Space(10)]

	[Header ("Material")]
	[Tooltip("紅")]
	[SerializeField]private Material Red;

	public static Material TiffanyBlue_static;
	[Tooltip("青")]
	[SerializeField]private Material TiffanyBlue;

	public static Material Gray_static;
	[Tooltip("灰")]
	[SerializeField]private Material Gray;

	[Space(10)]

	[Header ("LookAt")]
	[Tooltip("Camera將LookAt的中心點")]
	public GameObject Center;


	delegate  bool Clone (bool boo);

	public static int ball_Arr = 0;

	bool compare = true;


	void Awake ()
	{
		Gray_static = Gray;

		TiffanyBlue_static = TiffanyBlue;
	}


	public class ClickEvent
	{
		public void Action (GameObject obj)
		{
			Debug.Log (obj.name);

			if (obj.GetComponent<Renderer> ().material.color == TiffanyBlue_static.color) {
				obj.GetComponent<Renderer> ().material = Gray_static;
				Ball.Add (obj);
			} else {
				obj.GetComponent<Renderer> ().material = TiffanyBlue_static;
				Ball.Remove (obj);
			}
		}
	}




	void Start ()
	{
		

		makeRandomArr ();
		InvokeRepeating ("ShowLight", 1f, 1f);

		Ball_Random.ForEach (i => UIEventListener.Get (i).onClick = new ClickEvent ().Action);


	}



	// Update is called once per frame
	void Update ()
	{
		gameObject.transform.LookAt (Center.transform.position, Vector3.forward);

		if (Ball.Count == 8 && compare) {

			Clone clone = (bool boo) => {

				GameObject Clone;

				if (boo) {
					//答對
					Clone = NGUITools.AddChild (Panel, Bingo);

				} else {
					//答錯
					Clone = NGUITools.AddChild (Panel, Error);
				}

				Clone.transform.localPosition = new Vector3 (140729, 100632, 26417);
				Clone.transform.Rotate (Vector3.right, 33.24981f);
				Clone.transform.localScale = new Vector3 (25000, 25000, 0);
				iTween.ScaleFrom (Clone, iTween.Hash ("scale", Vector3.zero, "delay", 0.2, "oncomplete", "DestroyClone", "oncompletetarget", gameObject, "oncompleteparams", Clone));
				return boo;
			};

			clone (Ball.SequenceEqual (Ball_Random));


			compare = false;


			Invoke ("restart", 1.5f);
		}

	}

	void DestroyClone (GameObject obj)
	{
		Destroy (obj);
	}

	delegate GameObject go (GameObject go);

	public void restart ()
	{
		
		Ball.ForEach (i => i.GetComponent<Renderer> ().material = TiffanyBlue_static);

		// This will copy all the items from Ball_Random to Ball_sequence
//		Ball_Random.ForEach (i => Ball_sequence.Add (i));
		Ball_sequence.AddRange (Ball_Random);

		Ball.Clear ();

		Ball_Random.Clear ();

		compare = true;

		makeRandomArr ();

		ball_Arr = 0;

		InvokeRepeating ("ShowLight", 1f, 1f);

	}

	void makeRandomArr ()
	{
		for (int i = 0; i < 8; i++) {
			int num = Random.Range (0, Ball_sequence.Count);
			Ball_Random.Add (Ball_sequence [num]);
			Ball_sequence [num] = Ball_sequence [Ball_sequence.Count - 1];
			Ball_sequence.RemoveAt (Ball_sequence.Count - 1);
		}
	}

	public void showarr ()
	{
		Ball_Random.ForEach (i => Debug.Log (i.name));
	}

	public void ShowLight ()
	{
		if (ball_Arr == 8) {
			CancelInvoke ("ShowLight");
			Ball_Random [7].GetComponent<Renderer> ().material = TiffanyBlue;
		} else {
			if (ball_Arr != 0) {
				Ball_Random [ball_Arr].GetComponent<Renderer> ().material = Red;
				Ball_Random [ball_Arr - 1].GetComponent<Renderer> ().material = TiffanyBlue;
			} else {
				Ball_Random [ball_Arr].GetComponent<Renderer> ().material = Red;
			}
			ball_Arr++;
		}
	}

	public void ShowClickBall ()
	{
		Ball.ForEach (i => Debug.Log (i.name));
	}


	public void CameraMove ()
	{
		

		gameObject.GetComponent<UIPlayTween> ().Play (true);


	}
}
