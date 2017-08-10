using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BALL : MonoBehaviour
{
	//點擊移動開關 default = false
	public bool m_bToggle{ get; set; }

	void Awake ()
	{
		this.m_bToggle = true;
	}

	void Start ()
	{
		//加入陣列
		Level2_DB.BALLList.Add (this);
		AddListener ();//Onclick
	}

	void Update ()
	{
		
	}

	//Add Listener
	private void AddListener ()
	{
		//Listen
		UIEventListener.Get (gameObject).onClick = Onclick;//不要使用UIEventListener裡存在的同名函数OnClick!!!
	}

	//點擊事件
	private void Onclick (GameObject ball)
	{
		if (this.m_bToggle) {

			this.Gray ();

			//加入BALL陣列
			Level2_DB.BALL.Add (this);

		} else {

			this.Original ();

			//從BALL陣列移除
			Level2_DB.BALL.Remove (this);
		}
	}

	//BALL原始顏色
	public void Original (bool Collider = true)
	{
		var color = Level2_DB.TiffanyBlue;

		if (color == null) {
			Debug.LogError ("Missing TiffanyBlue");
			return;
		}

		this.ReplaceTheBALL (color);
		this.m_bToggle = true;
		this.ColliderEnabled (Collider);
	}


	//BALL紅色
	public void Red ()
	{
		var color = Level2_DB.Red;

		if (color == null) {
			Debug.LogError ("Missing Red");
			return;
		}

		this.ReplaceTheBALL (color);
	}

	//BALL灰色
	public void Gray ()
	{
		var color = Level2_DB.Gray;

		if (color == null) {
			Debug.LogError ("Missing Gray");
			return;
		}

		this.ReplaceTheBALL (color);
		this.m_bToggle = false;
		this.ColliderEnabled (true);
	}

	//替換BALL
	private void ReplaceTheBALL (Material colorball)
	{
		GetComponent<Renderer> ().material = colorball;
	}

	private void ColliderEnabled (bool Collider)
	{
		if (Collider)
			this.GetComponent<SphereCollider> ().enabled = true;
	}
}
