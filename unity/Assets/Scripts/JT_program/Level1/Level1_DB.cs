using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Level1_DB : MonoBehaviour
{
	//readOnly..........................

	public readonly int TOTAL_LEVEL = 10;

	public readonly int TimeOut_Time = 3;

	//UFO................................

	//Color
	static public  GameObject Original_color;

	static public  GameObject Red_color;

	static public  GameObject Gray_color;

	///載入UFO
	static public GameObject[] LoadUFO;

	//UFO隨機樣式
	static public int g_iRandom;

	static public  List<UFO> UFOList;

	static public  List<UFO> UFO;

	static public  List<UFO> UFO_Random;

	//......................................
	public int arrangement_index;//列為可疑除
	//......................................

	//Level.............................

	//難度選單數字
	public int Select_Level_number;

	public float lighttime;

	public float darktime;

	///UFO物件父節點
	public Transform UFO_group;

	//GameStart
	public bool start = false;
	///關卡難度提升
	public bool LevelUP = false;
	//超過時間作答
	public bool TimeOut = false;

	public bool Compare;

	//List
	public  List<List<Vector3>> arrangement;
	//rotate
	public List<Level1_RotationFix> RotationGroup;
	//初始化RotationGroup起始編號
	public int RotationGroup_Index;
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

	//排列圖
	public TextAsset[] map;
	//bingo與error大小
	public Vector3 CheckedScale;
	//等待UFO全都停止,isMoving=false
	public WaitUntil WaitUntilUFOReady;
	//等待一秒
	public WaitForSeconds WaitOneSecond;

	void Awake ()
	{
		UFOList = new List<UFO> ();

		UFO = new List<UFO> ();

		UFO_Random = new List<UFO> ();

		arrangement = new List<List<Vector3>> ();

		RotationGroup = new List<Level1_RotationFix> ();

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
		g_iRandom = 0;

		UFOList.Clear ();
		UFO.Clear ();
		UFO_Random.Clear ();
	}
}
