using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Level2_DB : MonoBehaviour
{

	static public  List<BALL> BALLList;

	static public  List<BALL> BALL;

	static public  List<BALL> BALL_Random;

	static public Material Red;

	static public Material TiffanyBlue;

	static public Material Gray;

	//Level.............................

	public GameObject Main_Cylinder;

	public GameObject[] Cups;

	public int MaxLevel;

	public int index;

	public float lighttime;

	public float darktime;

	//GameStart
	public bool start = false;
	///關卡難度提升
	public bool LevelUP = false;

	//random幾台
	public int random;
	//UFO數量平衡
	public int g_iBalance;
	///暫存值
	public int g_iTempValue;
	//答對次數
	public int BingoCount;
	//答錯次數
	public int ErrorCount;

	//bingo與error大小
	public Vector3 CheckedScale;
	//等待一秒
	public WaitForSeconds WaitOneSecond;


	void Awake ()
	{
		BALLList = new List<BALL> ();
		BALL = new List<BALL> ();
		BALL_Random = new List<BALL> ();
		Red = Resources.Load<Material> ("JT/Materials/Red");
		TiffanyBlue = Resources.Load<Material> ("JT/Materials/TiffanyBlue");
		Gray = Resources.Load<Material> ("JT/Materials/Gray");
	}

	void OnDestroy ()
	{
		Red = null;
		TiffanyBlue = null;
		Gray = null;

		BALLList.Clear ();
		BALL.Clear ();
		BALL_Random.Clear ();
	}
}
