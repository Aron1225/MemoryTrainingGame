using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Level1_DB : Database
{
	//Color................................

	static public GameObject Original_color;

	static public GameObject Red_color;

	static public GameObject Gray_color;

	//List.............................

	static public  List<UFO> UFOList;

	static public  List<UFO> UFO;

	static public  List<UFO> UFO_Random;

	//int.............................

	//UFO隨機樣式
	static public int g_iRandom;

	//初始化RotationGroup起始編號
	public int RotationGroup_Index;

	//GameObject......................

	///載入UFO
	static public  GameObject[] LoadUFO;

	//Transform............................

	//UFO物件父節點
	public Transform UFO_group;

	//List................................

	//List
	public List<List<Vector3>> arrangement;

	//TextAsset............................

	//排列圖
	public TextAsset[] map;

	//Wait.................................

	//等待UFO全都停止,isMoving=false
	public WaitUntil WaitUntilUFOReady;


	//Mono.........................................

	void Awake ()
	{
		UFOList = new List<UFO> ();

		UFO = new List<UFO> ();

		UFO_Random = new List<UFO> ();

		arrangement = new List<List<Vector3>> ();

		Select_Level_number = 1;
	}

	void OnDestroy ()
	{
		//Color
		Original_color = null;
		Red_color = null;
		Gray_color = null;

		///載入UFO
		LoadUFO = null;

		//UFO隨機樣式
		g_iRandom =0;

		UFOList = null;
		UFO = null;
		UFO_Random = null;

//		UFOList.Clear ();
//		UFO.Clear ();
//		UFO_Random.Clear ();
	}
}
