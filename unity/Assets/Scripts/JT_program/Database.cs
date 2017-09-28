using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Database : MonoBehaviour
{
	//readOnly..........................

	public readonly int TOTAL_LEVEL = 10;

	public readonly int TimeOut_Time = 5;

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

	//bingo與error大小
	public Vector3 ResultScale;
	//bingo與error位置
	public Vector3 ResultPosition;
	//等待一秒
	public WaitForSeconds WaitOneSecond;
}
