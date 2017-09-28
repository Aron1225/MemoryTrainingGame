using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CoffeeCup : ICoffeeCup
{
	//實體
	static private CoffeeCup instance;
	//cache
	private CustomRotation[] CR;
	//個別存值
	private int m_modelIndex;
	//主圈速度
	private int m_cylinder_speed;
	//小圈們速度
	private int[] m_cups_speed;

	//	public static System.Action CoffeeCupStop;

	//建構子
	private CoffeeCup (int modelIndex)
	{
		this.m_modelIndex = modelIndex;
		int length = ModelDatabase.coffeeCups [modelIndex].cups.Length + 1;//取得小圈+大圈數量
		CR = new CustomRotation[length];
//		CoffeeCupStop += stop;
	}

	///工廠方法
	public static CoffeeCup build (Model modelIndex)
	{
		instance = new CoffeeCup ((int)modelIndex);
		return instance;
	}

	//設定主圈速度
	public CoffeeCup cylinder_speed (int cylinder_speed)
	{
		if (cylinder_speed != 0)
			m_cylinder_speed = cylinder_speed;
		return this;
	}
	
	//設定小圈個別速度
	public CoffeeCup cups_speed (params int[] cups_speed)
	{
		if (CR.Length - 1 < cups_speed.Length)
			Debug.LogError ("LevelParameter ICC(cups_speed)參數數量超過");

		if (cups_speed.Length != 0) {
			
			m_cups_speed = new int[cups_speed.Length];

			for (int i = 0; i < cups_speed.Length; i++) {
				m_cups_speed [i] = cups_speed [i];
			}
		}
		return this;
	}

	public CoffeeCup camera_perspective (CameraCircularMovement camera, float duration)
	{
		iTween.ValueTo (camera.gameObject, iTween.Hash (
			"from", 0.01f,
			"to", 2f,
			"time", duration,
			"easetype", iTween.EaseType.linear,
			"loopType", iTween.LoopType.pingPong,
			"onupdate", (Action<object>)(value => camera.radius = (float)value)
		));
		return this;
	}

	//開始旋轉
	public void start ()
	{
		//關閉是enable的物件
		var alive = ModelDatabase.coffeeCups;
		for (int i = 0; i < alive.Length; i++) {
			if (alive [i].Model.activeSelf) {
				alive [i].Model.SetActive (false);
				break;
			}
		}

		//主圈
		var cylinder = ModelDatabase.coffeeCups [m_modelIndex].Model;
		cylinder.SetActive (true);
		if (m_cylinder_speed != 0) {
			CR [0] = cylinder.AddComponent<CustomRotation> ();//加上旋轉腳本
			CR [0].speed = m_cylinder_speed;
		}

		//小圈
		if (m_cups_speed != null) {
			for (int i = 1; i <= m_cups_speed.Length; i++) {
				var cup = ModelDatabase.coffeeCups [m_modelIndex].cups [i - 1];
				if (m_cups_speed [i - 1] != 0) {
					CR [i] = cup.AddComponent<CustomRotation> ();//加上旋轉腳本
					CR [i].speed = m_cups_speed [i - 1];
				}
			}
		}
	}

	//停止旋轉
	public void stop ()
	{
		if (this != null)
			for (int i = 0; i < CR.Length; i++)
				if (CR [i] != null)
					CR [i].RotateStop ();
	}

	//	private void init_m_cups_speed (out CustomRotation[] CR, int model)
	//	{
	//		int length = ModelDatabase.coffeeCups [model].cups.Length + 1;//取得小圈+大圈數量
	//		CR = new CustomRotation[length];
	//	}
	//		var cylinder = ModelDatabase.coffeeCups [model].Model;
	//		CR [0] = cylinder.AddComponent<CustomRotation> ();//加上旋轉腳本
	//		CR [0].enabled = false;//加上旋轉腳本後先關閉
	//		for (int i = 1; i <= length - 1; i++) {
	//			var cup = ModelDatabase.coffeeCups [model].cups [i - 1];
	//			CR [i] = cup.AddComponent<CustomRotation> ();//加上旋轉腳本
	//			CR [i].enabled = false;//加上旋轉腳本後先關閉
	//		}
	//	private CustomRotation[] Rotate<T> (out CustomRotation[] CR, int model) where T : Component
	//	{
	//		int length = ModelDatabase.coffeeCups [model].cups.Length + 1;//取得小圈+大圈數量
	//		CR = new CustomRotation[length];
	//		var cylinder = ModelDatabase.coffeeCups [model].cylinder;
	//		CR [0] = cylinder.AddComponent<CustomRotation> ();//加上旋轉腳本
	//		CR [0].enabled = false;//加上旋轉腳本後先關閉
	//		for (int i = 1; i <= length - 1; i++) {
	//			var cup = ModelDatabase.coffeeCups [model].cups [i - 1];
	//			CR [i] = cup.AddComponent<CustomRotation> ();//加上旋轉腳本
	//			CR [i].enabled = false;//加上旋轉腳本後先關閉
	//		}
	//		return CR;
	//	}
	//
	//	//一主圈二小圈模組
	//	public class Cup_twoCup : CoffeeCup,ICoffeeCup
	//	{
	//		static Cup_twoCup twoCup;
	//
	//		public enum style
	//		{
	//			twoBall = 0,
	//			threeBall = 1,
	//			fourBall = 2,
	//		}
	//
	//		private Cup_twoCup (int model)
	//		{
	//			ModelDatabase.coffeeCups [model].cylinder.SetActive (true);
	//			Rotate<Cup_twoCup> (out CR, model);
	//		}
	//
	//		public void start ()
	//		{
	//			CR [0].enabled = true;
	//			CR [1].enabled = true;
	//			CR [2].enabled = true;
	//		}
	//
	//		public void stop ()
	//		{
	//			CR [0].SmoothStop ();
	//			CR [1].SmoothStop ();
	//			CR [2].SmoothStop ();
	//		}
	//
	//		///工廠方法,設定主圈與其他小圈
	//		public static Cup_twoCup build (Cup_twoCup.style model)
	//		{
	//			twoCup = new Cup_twoCup ((int)model);
	//			return twoCup;
	//		}
	//
	//		//設定主圈速度
	//		public Cup_twoCup cylinder_speed (int cylinder_speed)
	//		{
	//			twoCup.CR [0].speed = cylinder_speed;
	//			return twoCup;
	//		}
	//
	//		//設定小圈個別速度
	//		public Cup_twoCup cups_speed (int cup1_velocity, int cup2_velocity)
	//		{
	//			twoCup.CR [1].speed = cup1_velocity;
	//			twoCup.CR [2].speed = cup2_velocity;
	//			return twoCup;
	//		}
	//	}
	//
	//	//一主圈三小圈模組
	//	public class Cup_threeCup : CoffeeCup,ICoffeeCup
	//	{
	//		static Cup_threeCup threeCup;
	//
	//		public enum style
	//		{
	//			twoBall = 3,
	//			threeBall = 4,
	//			fourBall = 5,
	//		}
	//
	//		private Cup_threeCup (int model)
	//		{
	//			ModelDatabase.coffeeCups [model].cylinder.SetActive (true);
	//				Rotate<Cup_threeCup> (out CR, model);
	//		}
	//
	//		public void start ()
	//		{
	//			CR [0].enabled = true;
	//			CR [1].enabled = true;
	//			CR [2].enabled = true;
	//			CR [3].enabled = true;
	//		}
	//
	//		public void stop ()
	//		{
	//			CR [0].SmoothStop ();
	//			CR [1].SmoothStop ();
	//			CR [2].SmoothStop ();
	//			CR [3].SmoothStop ();
	//		}
	//
	//		///工廠方法,設定主圈與其他小圈
	//		public static Cup_threeCup build (Cup_threeCup.style model)
	//		{
	//			threeCup = new Cup_threeCup ((int)model);
	//			return threeCup;
	//		}
	//
	//		//設定主圈速度
	//		public Cup_threeCup cylinder_speed (int cylinder_speed)
	//		{
	//			threeCup.CR [0].speed = cylinder_speed;
	//			return threeCup;
	//		}
	//
	//		//設定小圈個別速度
	//		public Cup_threeCup cups_speed (int cup1_velocity, int cup2_velocity, int cup3_velocity)
	//		{
	//			threeCup.CR [1].speed = cup1_velocity;
	//			threeCup.CR [2].speed = cup2_velocity;
	//			threeCup.CR [3].speed = cup3_velocity;
	//			return threeCup;
	//		}
	//	}
	//
	//	//一主圈四小圈模組
	//	public class Cup_fourCup : CoffeeCup,ICoffeeCup
	//	{
	//		static Cup_fourCup fourCup;
	//
	//		public enum style
	//		{
	//			twoBall = 6,
	//			threeBall = 7,
	//			fourBall = 8,
	//		}
	//
	//		private Cup_fourCup (int model)
	//		{
	//			ModelDatabase.coffeeCups [model].cylinder.SetActive (true);
	//			Rotate<Cup_fourCup> (out CR, model);
	//		}
	//
	//		public void start ()
	//		{
	//			CR [0].enabled = true;
	//			CR [1].enabled = true;
	//			CR [2].enabled = true;
	//			CR [3].enabled = true;
	//			CR [4].enabled = true;
	//		}
	//
	//		public void stop ()
	//		{
	//			CR [0].SmoothStop ();
	//			CR [1].SmoothStop ();
	//			CR [2].SmoothStop ();
	//			CR [3].SmoothStop ();
	//			CR [4].SmoothStop ();
	//		}
	//
	//		///工廠方法,設定主圈與其他小圈
	//		public static Cup_fourCup build (style model)
	//		{
	//			fourCup = new Cup_fourCup ((int)model);
	//			return fourCup;
	//		}
	//
	//		//設定主圈速度
	//		public Cup_fourCup cylinder_speed (int cylinder_speed)
	//		{
	//			fourCup.CR [0].speed = cylinder_speed;
	//			return fourCup;
	//		}
	//
	//		//設定小圈個別速度
	//		public Cup_fourCup cups_speed (int cup1_velocity, int cup2_velocity, int cup3_velocity, int cup4_velocity)
	//		{
	//			fourCup.CR [1].speed = cup1_velocity;
	//			fourCup.CR [2].speed = cup2_velocity;
	//			fourCup.CR [3].speed = cup3_velocity;
	//			fourCup.CR [4].speed = cup4_velocity;
	//			return fourCup;
	//		}
	//	}
}
