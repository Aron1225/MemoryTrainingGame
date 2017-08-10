using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3_display : MonoBehaviour
{

	[Header ("List")]
	public List<GameObject> Ball_sequence = new List<GameObject> ();
	public List<GameObject> Ball_Random = new List<GameObject> ();
	public static List<GameObject> Ball = new List<GameObject> ();

	[Header ("Material")]
	[SerializeField]private Material Red;

	public static Material TiffanyBlue_static;
	[SerializeField]private Material TiffanyBlue;

	public static Material Gray_static;
	[SerializeField]private Material Gray;

	public static int ball_Arr = 0;


	public class ClickEvent
	{
		public void Action (GameObject obj)
		{
			Debug.Log (obj.name);

			if(obj.GetComponent<Rigidbody> () == null)
			obj.AddComponent<Rigidbody> ();

			if (obj.GetComponent<Renderer> ().material.color == TiffanyBlue_static.color) {
				obj.GetComponent<Renderer> ().material = Gray_static;
				Ball.Add (obj);
			} else {
				obj.GetComponent<Renderer> ().material = TiffanyBlue_static;
				Ball.Remove (obj);
			}
		}
	}



	void Awake ()
	{
		Gray_static = Gray;

		TiffanyBlue_static = TiffanyBlue;
	}

	void Start ()
	{
		makeRandomArr ();
		InvokeRepeating ("ShowLight", 1f, 1f);

		Ball_Random.ForEach (i => UIEventListener.Get (i).onClick = new ClickEvent ().Action);
	}


	void Update ()
	{
		
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

	public void CameraMove ()
	{
		gameObject.GetComponent<TweenPosition> ().from = Vector3.zero;
		gameObject.GetComponent<TweenPosition> ().to = new Vector3 (0f, 37776f, 33827f);
		gameObject.GetComponent<TweenRotation> ().from = Vector3.zero;
		gameObject.GetComponent<TweenRotation> ().to = new Vector3 (90, 0, 0);
		gameObject.GetComponent<UIPlayTween> ().Play (true);


	}
	public void CameraMoveDown ()
	{

		gameObject.GetComponent<TweenPosition> ().from = Vector3.zero;
		gameObject.GetComponent<TweenPosition> ().to = new Vector3 (215.3552f, -31374.82f, 33770f);
		gameObject.GetComponent<TweenRotation> ().from = Vector3.zero;
		gameObject.GetComponent<TweenRotation> ().to = new Vector3 (-90, 0, 0);
		gameObject.GetComponent<UIPlayTween> ().Play (true);


	}
}
