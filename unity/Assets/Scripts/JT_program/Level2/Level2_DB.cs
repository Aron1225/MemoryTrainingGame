using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Level2_DB : Database
{
	//Color............................

	static public Material Red;

	static public Material TiffanyBlue;

	static public Material Gray;

	//array.............................

	static public  List<BALL> BALLList;

	static public  List<BALL> BALL;

	static public  List<BALL> BALL_Random;

	//Mono............................

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
		BALL = null;
		BALL_Random = null;
	}
}
