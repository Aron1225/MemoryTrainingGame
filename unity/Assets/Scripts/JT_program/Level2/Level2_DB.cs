using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Level2_DB : MonoBehaviour
{
	//readOnly..........................

	public readonly int TOTAL_LEVEL = 10;

	public readonly int TimeOut_Time = 5;

	//Color............................

	static public Material Red;

	static public Material TiffanyBlue;

	static public Material Gray;

	//array.............................

	static public  List<BALL> BALLList;

	static public  List<BALL> BALL;

	static public  List<BALL> BALL_Random;

	//Level.............................

	//GameStart
	public bool start = false;
	///關卡難度提升
	public bool LevelUP = false;
	//超過時間作答
	public bool TimeOut = false;
	//比較開關
	public bool Compare;
	//難度選單數字
	public int Select_Level_number;
	//random幾台
	public int random;
	//答對次數
	public int BingoCount;
	//答錯次數
	public int ErrorCount;

	public float lighttime;

	public float darktime;

	public GameObject Main_Cylinder;

	public GameObject[] Cups;

	//bingo與error大小
	public Vector3 CheckedScale;
	//等待一秒
	public WaitForSeconds WaitOneSecond;

	//lagecy
	//public int index;
	//UFO數量平衡
	//	public int g_iBalance;
	//暫存值
	//	public int g_iTempValue;

	void Awake ()
	{
		BALLList = new List<BALL> ();

		BALL = new List<BALL> ();

		BALL_Random = new List<BALL> ();

		Red = Resources.Load<Material> ("JT/Materials/Red");

		TiffanyBlue = Resources.Load<Material> ("JT/Materials/TiffanyBlue");

		Gray = Resources.Load<Material> ("JT/Materials/Gray");

		Select_Level_number = 1;
	}

	void OnDestroy ()
	{
		//Color
		Red = null;
		TiffanyBlue = null;
		Gray = null;

		//array
		BALLList.Clear ();
		BALL.Clear ();
		BALL_Random.Clear ();
	}
}
