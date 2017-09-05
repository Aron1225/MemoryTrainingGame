using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Level1_DB : MonoBehaviour
{
	#region readonly

	//readOnly..........................

	public readonly int TOTAL_LEVEL = 10;

	public readonly int TimeOut_Time = 30;

	#endregion

	#region static

	//Color................................

	static public  GameObject Original_color;

	static public  GameObject Red_color;

	static public  GameObject Gray_color;

	//List.............................

	static public  List<UFO> UFOList;

	static public  List<UFO> UFO;

	static public  List<UFO> UFO_Random;

	//int.............................

	//UFO隨機樣式
	static public int g_iRandom;

	//GameObject......................

	///載入UFO
	static public GameObject[] LoadUFO;

	#endregion

	#region public

	//bool..................................

	//GameStart
	public bool start = false;
	//關卡難度提升
	public bool LevelUP = false;
	//超過時間作答
	public bool TimeOut = false;
	//比較開關
	public bool Compare;

	//int..................................

	//難度選單數字
	public int Select_Level_number;
	//random幾台
	public int random;
	//答對次數
	public int BingoCount;
	//答錯次數
	public int ErrorCount;
	//初始化RotationGroup起始編號
	public int RotationGroup_Index;

	//float................................

	//亮燈時間
	public float lighttime;
	//暗燈時間
	public float darktime;

	//Transform............................

	//UFO物件父節點
	public Transform UFO_group;

	//List................................

	//List
	public List<List<Vector3>> arrangement;

	//TextAsset............................

	//排列圖
	public TextAsset[] map;

	//Vector3...............................

	//bingo與error大小
	public Vector3 CheckedScale;

	//Wait.................................

	//等待UFO全都停止,isMoving=false
	public WaitUntil WaitUntilUFOReady;
	//等待一秒
	public WaitForSeconds WaitOneSecond;

	#endregion

	//lagecy.........................................

	//列為可疑除......................................
	public int arrangement_index;
	//................................................

	//UFO數量平衡
	//public int g_iBalance;
	///暫存值
	//public int g_iTempValue;
	//public List<Level1_RotationFix> RotationGroup;

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
		g_iRandom = 0;

		UFOList.Clear ();
		UFO.Clear ();
		UFO_Random.Clear ();
	}
}
