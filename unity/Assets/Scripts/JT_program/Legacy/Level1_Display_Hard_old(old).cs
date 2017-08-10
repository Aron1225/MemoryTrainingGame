using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using System.Reflection;

//清除監控的Error,可刪除

public class Level1_Display_Hard_old : Level1
{
	/*
	WaitForSeconds LightTime;


	WaitForSeconds DarkTime;

	List<Vector3> Point = new List<Vector3> ();

	List<int> ReRandom = new List<int> ();

	bool g_bReRandom = false;

	Level1_RotationFix class_RotationFix;

	int the;

	bool NeedChangePattern;


	void Start ()
	{
		
		//初始化
		Initialization ();

		//遊戲開始
		StartCoroutine (GameStart ());

		//ClearLog ();//清除監控的Error,可刪除

	}

	void Update ()
	{
		
	}

	///初始化
	public override void InitializationParameter ()
	{
		LightTime = new WaitForSeconds (0.1f);

		DarkTime = new WaitForSeconds (0.1f);

		class_RotationFix = UFO_group.gameObject.GetComponent<Level1_RotationFix> ();
	}

	//清除監控的Error,可刪除
	public void ClearLog ()
	{
		var assembly = Assembly.GetAssembly (typeof(UnityEditor.ActiveEditorTracker));
		var type = assembly.GetType ("UnityEditorInternal.LogEntries");
		var method = type.GetMethod ("Clear");
		method.Invoke (new object (), null);
	}

	IEnumerator GameStart ()
	{
		//UFO排列圖座標陣列
		UFO_position ();

		while (true) {


			if (Level1_Select._arrangement_index < 27) {
				the = arrangement [Level1_Select._arrangement_index].Count / 2;
				NeedChangePattern = true;
			} else if (Level1_Select._arrangement_index >= 27) {
				the = arrangement [Level1_Select._arrangement_index].Count;
				NeedChangePattern = false;
			}

			//關卡設定
			yield return StartCoroutine (LevelManagement ());

			//隨機亂數
			yield return StartCoroutine (MakeRandom (UFO_OriginalOrder.Count));

			//亮燈
			yield return StartCoroutine (ShowLight ());


			yield return StartCoroutine (ChangePattern ());

			//答案比對
			yield return StartCoroutine (AnswerCompare ());

			//重置
			yield return StartCoroutine (Reset ());

			//等待下一幀
			yield return null;
		}
	}

	///關卡設定
	IEnumerator LevelManagement ()
	{
//		Level1_RotationFix.startRotate = false;

		DisplaySliderBar ();

		if (!LevelUP) {

			//進入遊戲後初始，只執行一次
			if (UFOList.Count == 0) {

				//隨機值
				g_iRandom = UnityEngine.Random.Range (0, 5);


				for (int i = 0; i < the; i++)
					UFOList.Add (new CreatUFO (LoadUFO [g_iRandom], false));
				

				//取得當前UFO原始圖名稱
				UFO_DefaultLight = UFO_sequence [0].GetComponent<UISprite> ().spriteName;

				//取得當前UFO的亮燈圖名稱
				UFO_RedLight = UFO_DefaultLight + "_red";

				UFO_GrayLight = UFO_DefaultLight + "_gray";


			} else {//當答錯時執行
				
				var iFlag = 0;

				UFO_OriginalOrder.Clear ();

				UFO.ForEach (go1 => {

					TweenPosition.Begin (go1, 0.5f, arrangement [Level1_Select._arrangement_index] [iFlag++]);

					TweenScale.Begin (go1, 0.5f, Vector3.one);

					UFO_OriginalOrder.Add (go1); 

					go1.GetComponent<UISprite> ().spriteName = UFO_DefaultLight;

					//isMoving = true
					(UFOList.Find (go2 => go2.getUFO.Equals (go1))).isMoving = true;

				});


//				if (!NeedChangePattern) {
//					UFO.ForEach (go => {
//						go.transform.parent = UFO_group.transform;
//						if (Level1_RotationFix.children.All (list => list != go))
//							Level1_RotationFix.children.Add (go.transform);
//					});
//				}



				if (ReRandom.Any (list => list.Equals (Level1_Select._arrangement_index))) {
					
					//reReRandom

					//test...

				}

			}
		} else {

			//暫存值
			g_iTempValue = Level1_Select._arrangement_index;

			//下一關圖形
			s_bNextLevel = true;

			//值改變時執行
			yield return WaitValueChange;




			if (Level1_Select._arrangement_index < 27) {
				//缺(多)幾台UFO
				g_iBalance = (arrangement [g_iTempValue].Count - arrangement [Level1_Select._arrangement_index].Count) / 2;
			} else if (Level1_Select._arrangement_index == 27) {
				//缺(多)幾台UFO
				g_iBalance = arrangement [g_iTempValue].Count / 2 - arrangement [Level1_Select._arrangement_index].Count;
			} else if (Level1_Select._arrangement_index > 27) {
				//缺(多)幾台UFO
				g_iBalance = arrangement [g_iTempValue].Count - arrangement [Level1_Select._arrangement_index].Count;
			}



			//lack
			if (g_iBalance < 0) {

				g_iBalance *= -1;

				//少幾台UFO
				for (int j = 0; j < g_iBalance; j++) {
					UFOList.Add (new CreatUFO (LoadUFO [g_iRandom], true));
				}

				//extra
			} else if (g_iBalance > 0) {
				
				//Destroy幾台
				for (int i = 0; i < g_iBalance; i++) {

					UFOList.Remove (UFOList.Find (go2 => go2.getUFO.Equals (UFO_sequence.Last ())));

					UFO_sequence.Remove (UFO_sequence.Last ());

					TweenPosition.Begin (UFO.Last (), 0.5f, GeneratePoint [i % 4]);
				
					TweenAlpha.Begin (UFO.Last (), 0.5f, 0);

					Destroy (UFO.Last (), 1.5f);

					UFO.Remove (UFO.Last ());

					CreatUFO.m_s_iPos--;

				}
			}

			//走訪旗標
			int iFlag = 0;

			UFO_OriginalOrder.Clear ();

			UFO.ForEach (go1 => { 
				//設定下個座標
				TweenPosition.Begin (go1, 0.5f, arrangement [Level1_Select._arrangement_index] [iFlag++]);

				UFO_OriginalOrder.Add (go1);

				go1.GetComponent<UISprite> ().spriteName = UFO_DefaultLight;

				//開始移動
				go1.GetComponent<UIPlayTween> ().Play (true);

				//isMoving = true
				(UFOList.Find (go2 => go2.getUFO.Equals (go1))).isMoving = true;

				go1.transform.parent = UFO_group.transform;

			});




			//重新給暫存值
			g_iTempValue = Level1_Select._arrangement_index;

			DisplaySliderBar ();
		}






		yield return WaitUFOReady;


		if (!NeedChangePattern) {


			if (class_RotationFix == null) {
				//				yield return new WaitForSeconds(3);
				class_RotationFix = UFO_group.gameObject.AddComponent<Level1_RotationFix> ();
			} else {
				UFO.ForEach (go => {
					go.transform.parent = UFO_group.transform;

					if (Level1_RotationFix.children.All (list => list != go))
						Level1_RotationFix.children.Add (go.transform);
				});
			}


		}

//		Level1_RotationFix.startRotate = true;
	}
	//隨機亂數
	IEnumerator MakeRandom (int key)//key->需要幾個亂數
	{
		//清空
		UFO_Random.Clear ();

		//設定亂數種子
		//UnityEngine.Random.InitState (System.Guid.NewGuid ().GetHashCode ());

		for (int i = 0; i < key; i++) {
			int num = UnityEngine.Random.Range (0, UFO_sequence.Count);
			UFO_Random.Add (UFO_sequence [num]);
			UFO_sequence [num] = UFO_sequence [UFO_sequence.Count - 1];
			UFO_sequence.RemoveAt (UFO_sequence.Count - 1);
		}

		//將UFO_Random加回UFO_sequence
		UFO_sequence.AddRange (UFO_Random);

		yield return null;
	}

	IEnumerator ShowLight ()
	{
		//當陣列全部等於false時執行
		yield return WaitUFOReady;

		foreach (GameObject arr in UFO_Random) {

			arr.GetComponent<UISprite> ().spriteName = UFO_RedLight;

			yield return LightTime;

			arr.GetComponent<UISprite> ().spriteName = UFO_DefaultLight;

			//當走訪至最後時跳出迴圈
			if (arr == UFO_Random.Last ())
				break;

			yield return DarkTime;
		}
	}

	IEnumerator ChangePattern ()
	{
		//yield return WaitOneSecond;


		if (NeedChangePattern) {
			for (int i = 0; i < UFO_OriginalOrder.Count; i++) {
				TweenPosition.Begin (UFO_OriginalOrder [i], 2f, arrangement [Level1_Select._arrangement_index] [i + (arrangement [Level1_Select._arrangement_index].Count / 2)]);

//				if (i == UFO_Random.Count - 1)
//					break;

				//yield return WaitOneSecond;
			}
		}
			
		//開啟點擊
		UFO_Random.ForEach (go => go.GetComponent<SphereCollider> ().enabled = true);

		//開啟點擊
		//UFO_sequence.ForEach (go => go.GetComponent<SphereCollider> ().enabled = true);

		yield return null;
	}

	IEnumerator AnswerCompare ()
	{
		//清空
		UFO.Clear ();

		while (true) {
			//UFO數量到達時判斷
			if (UFO.Count == UFO_Random.Count) {

				//關閉點擊
				UFO_sequence.ForEach (go => go.GetComponent<SphereCollider> ().enabled = false);

				//答對答錯
				if (UFO.SequenceEqual (UFO_Random))
					LevelUP = true;
				else
					LevelUP = false;

				//比對陣列是否一致  答對=>clone = Bingo,反之,答對=>clone = Error
				GameObject clone = (UFO.SequenceEqual (UFO_Random)) ? NGUITools.AddChild (Panel, Bingo) : NGUITools.AddChild (Panel, Error);

				//設定大小
				clone.transform.localScale = CheckedScale;

				//設定大小tween
				iTween.ScaleFrom (clone, iTween.Hash ("scale", Vector3.zero, "delay", 0.2));

				Destroy (clone, 1f);

				break;//跳出while迴圈
			}
			yield return null;//等待下一幀
		}
		yield return WaitOneSecond;
	}

	//重置
	IEnumerator Reset ()
	{
		//重置點擊移動開關
		UFOList.ForEach (go => go.m_bToggle = true);

		Level1.CreatUFO.m_s_iClick = 0;

		s_iReferencePoint = -500;

		yield return null;
	}

	void DisplaySliderBar ()
	{

	}


	void RandomPos (int LevelNumber)
	{
		RandomPos (LevelNumber, 0, 0);
	}

	void RandomPos (int LevelNumber, int key)
	{
		RandomPos (LevelNumber, key, 0);
	}

	/// <summary>
	/// Randoms the position.
	/// </summary>
	/// <param name="number">Number = Level1_Select._arrangement_index</param>
	/// <param name="key">Key = 0 Add,Key = 1 Insert,Key = 2 add quantity</param>
	void RandomPos (int LevelNumber, int key, int quantity)
	{
		ReRandom.Add (LevelNumber);

		if (LevelNumber >= 0 && key >= 0 && quantity >= 0) {

			var count = arrangement [LevelNumber].Count;

			if (key == 0) {
				for (int i = 0; i < count; i++) {
					int RandomNum = UnityEngine.Random.Range (0, Point.Count);
					arrangement [LevelNumber].Add (Point [RandomNum]); 
					Point [RandomNum] = Point [Point.Count - 1];
					Point.RemoveAt (Point.Count - 1);	
				}
				Point.AddRange (arrangement [LevelNumber].GetRange (count, count));
			} else if (key == 1) {
				for (int i = 0; i < count; i++) {
					int RandomNum = UnityEngine.Random.Range (0, Point.Count);
					arrangement [LevelNumber].Insert (0, Point [RandomNum]); 
					Point [RandomNum] = Point [Point.Count - 1];
					Point.RemoveAt (Point.Count - 1);	
				}
				Point.AddRange (arrangement [LevelNumber].GetRange (0, count));
			} else if (key == 2) {
				for (int i = 0; i < quantity * 2; i++) {
					int RandomNum = UnityEngine.Random.Range (0, Point.Count);
					arrangement [LevelNumber].Insert (0, Point [RandomNum]); 
					Point [RandomNum] = Point [Point.Count - 1];
					Point.RemoveAt (Point.Count - 1);	
				}
				Point.AddRange (arrangement [LevelNumber]);
			} else {
				Debug.LogError ("RandomPos參數Key錯誤");
			}
		} else {
			Debug.LogError ("RandomPos參數不能為負值");
		}
	}

	//UFO排列圖座標陣列
	void UFO_position ()
	{

		for (int x = -3; x <= 3; x++) {
			for (int y = -1; y <= 2; y++) {
				Point.Add (new Vector3 ((200f * x), (150f * y), 100));
			}
		}

		for (int x = -1; x <= 3; x++) {
			for (int y = -2; y <= -2; y++) {
				Point.Add (new Vector3 ((200f * x), (150f * y), 100));
			}
		}
			


//		//test
//		arrangement.Add (new List<Vector3> ());
//		arrangement [x].AddRange (Point);
//		arrangement [x].AddRange (Point);

		//圖0-part1
		arrangement.Add (new List<Vector3> ());
		arrangement [0].Add (new Vector3 (370, 200, 0)); 
		arrangement [0].Add (new Vector3 (0, 200, 0));
		arrangement [0].Add (new Vector3 (-370, 200, 0));
		//圖0-part2
		arrangement [0].Add (new Vector3 (370, -250, 0)); 
		arrangement [0].Add (new Vector3 (0, -250, 0));
		arrangement [0].Add (new Vector3 (-370, -250, 0));

		//圖1-part1
		arrangement.Add (new List<Vector3> ());
		arrangement [1].Add (new Vector3 (320, 200, 0)); 
		arrangement [1].Add (new Vector3 (110, 200, 0));
		arrangement [1].Add (new Vector3 (-110, 200, 0));
		arrangement [1].Add (new Vector3 (-320, 200, 0));
		//圖1-part2
		arrangement [1].Add (new Vector3 (320, -250, 0)); 
		arrangement [1].Add (new Vector3 (110, -250, 0));
		arrangement [1].Add (new Vector3 (-110, -250, 0));
		arrangement [1].Add (new Vector3 (-320, -250, 0));

		//圖2-part1
		arrangement.Add (new List<Vector3> ());
		arrangement [2].Add (new Vector3 (400, 200, 0)); 
		arrangement [2].Add (new Vector3 (200, 200, 0));
		arrangement [2].Add (new Vector3 (0, 200, 0));
		arrangement [2].Add (new Vector3 (-200, 200, 0));
		arrangement [2].Add (new Vector3 (-400, 200, 0));
		//圖2-part2
		arrangement [2].Add (new Vector3 (400, -200, 0)); 
		arrangement [2].Add (new Vector3 (200, -200, 0));
		arrangement [2].Add (new Vector3 (0, -200, 0));
		arrangement [2].Add (new Vector3 (-200, -200, 0));
		arrangement [2].Add (new Vector3 (-400, -200, 0));

		//圖3-part1
		arrangement.Add (new List<Vector3> ());
		arrangement [3].Add (new Vector3 (250, 0, 0)); 
		arrangement [3].Add (new Vector3 (0, 0, 0));
		arrangement [3].Add (new Vector3 (-250, 0, 0));
		//圖3-part2
		arrangement [3].Add (new Vector3 (200, -130, 0));
		arrangement [3].Add (new Vector3 (0, 130, 0));
		arrangement [3].Add (new Vector3 (-200, -130, 0)); 

		//圖4-part1
		arrangement.Add (new List<Vector3> ());
		arrangement [4].Add (new Vector3 (300, 0, 0)); 
		arrangement [4].Add (new Vector3 (100, 0, 0));
		arrangement [4].Add (new Vector3 (-100, 0, 0));
		arrangement [4].Add (new Vector3 (-300, 0, 0));
		//圖4-part2
		arrangement [4].Add (new Vector3 (150, 150, 0));
		arrangement [4].Add (new Vector3 (150, -150, 0));
		arrangement [4].Add (new Vector3 (-150, -150, 0)); 
		arrangement [4].Add (new Vector3 (-150, 150, 0));

		//圖5-part1
		arrangement.Add (new List<Vector3> ());
		arrangement [5].Add (new Vector3 (400, 0, 0)); 
		arrangement [5].Add (new Vector3 (200, 0, 0));
		arrangement [5].Add (new Vector3 (0, 0, 0));
		arrangement [5].Add (new Vector3 (-200, 0, 0));
		arrangement [5].Add (new Vector3 (-400, 0, 0));
		//圖5-part2
		arrangement [5].Add (new Vector3 (200, 200, 0));
		arrangement [5].Add (new Vector3 (200, -200, 0));
		arrangement [5].Add (new Vector3 (0, 0, 0));
		arrangement [5].Add (new Vector3 (-200, -200, 0)); 
		arrangement [5].Add (new Vector3 (-200, 200, 0));


//		圖6-part1
		arrangement.Add (new List<Vector3> ());
		arrangement [6].Add (new Vector3 (250, 0, 0)); 
		arrangement [6].Add (new Vector3 (0, 0, 0));
		arrangement [6].Add (new Vector3 (-250, 0, 0));
		//圖6-part2
		RandomPos (6);

		//圖7-part1
		arrangement.Add (new List<Vector3> ());
		arrangement [7].Add (new Vector3 (300, 0, 0)); 
		arrangement [7].Add (new Vector3 (100, 0, 0));
		arrangement [7].Add (new Vector3 (-100, 0, 0));
		arrangement [7].Add (new Vector3 (-300, 0, 0));
		//圖7-part2
		RandomPos (7);


		//圖8-part1
		arrangement.Add (new List<Vector3> ());
		arrangement [8].Add (new Vector3 (400, 0, 0)); 
		arrangement [8].Add (new Vector3 (200, 0, 0));
		arrangement [8].Add (new Vector3 (0, 0, 0));
		arrangement [8].Add (new Vector3 (-200, 0, 0));
		arrangement [8].Add (new Vector3 (-400, 0, 0));
		//圖8-part2
		RandomPos (8);


		//圖9-part1
		arrangement.Add (new List<Vector3> ());
		arrangement [9].Add (new Vector3 (200, -130, 0));
		arrangement [9].Add (new Vector3 (0, 130, 0));
		arrangement [9].Add (new Vector3 (-200, -130, 0));
		//圖9-part2
		arrangement [9].Add (new Vector3 (250, 0, 0)); 
		arrangement [9].Add (new Vector3 (0, 0, 0));
		arrangement [9].Add (new Vector3 (-250, 0, 0));

		//圖10-part1
		arrangement.Add (new List<Vector3> ());
		arrangement [10].Add (new Vector3 (150, 150, 0));
		arrangement [10].Add (new Vector3 (150, -150, 0));
		arrangement [10].Add (new Vector3 (-150, -150, 0)); 
		arrangement [10].Add (new Vector3 (-150, 150, 0));
		//圖10-part2
		arrangement [10].Add (new Vector3 (300, 0, 0)); 
		arrangement [10].Add (new Vector3 (100, 0, 0));
		arrangement [10].Add (new Vector3 (-100, 0, 0));
		arrangement [10].Add (new Vector3 (-300, 0, 0));

		//圖11-part1
		arrangement.Add (new List<Vector3> ());
		arrangement [11].Add (new Vector3 (200, 200, 0));
		arrangement [11].Add (new Vector3 (200, -200, 0));
		arrangement [11].Add (new Vector3 (0, 0, 0));
		arrangement [11].Add (new Vector3 (-200, -200, 0)); 
		arrangement [11].Add (new Vector3 (-200, 200, 0));
		//圖11-part2
		arrangement [11].Add (new Vector3 (400, 0, 0)); 
		arrangement [11].Add (new Vector3 (200, 0, 0));
		arrangement [11].Add (new Vector3 (0, 0, 0));
		arrangement [11].Add (new Vector3 (-200, 0, 0));
		arrangement [11].Add (new Vector3 (-400, 0, 0));

		//圖12-part1
		arrangement.Add (new List<Vector3> ());
		arrangement [12].Add (new Vector3 (200, -130, 0));
		arrangement [12].Add (new Vector3 (0, 130, 0));
		arrangement [12].Add (new Vector3 (-200, -130, 0)); 
		//圖12-part2
		arrangement [12].Add (new Vector3 (200, 130, 0));
		arrangement [12].Add (new Vector3 (-200, 130, 0));
		arrangement [12].Add (new Vector3 (0, -200, 0)); 

		//圖13-part1
		arrangement.Add (new List<Vector3> ());
		arrangement [13].Add (new Vector3 (150, 150, 0));
		arrangement [13].Add (new Vector3 (150, -150, 0));
		arrangement [13].Add (new Vector3 (-150, -150, 0)); 
		arrangement [13].Add (new Vector3 (-150, 150, 0));
		//圖13-part2
		arrangement [13].Add (new Vector3 (0, 200, 0));
		arrangement [13].Add (new Vector3 (200, 0, 0));
		arrangement [13].Add (new Vector3 (0, -200, 0)); 
		arrangement [13].Add (new Vector3 (-200, 0, 0));

		//圖14-part1
		arrangement.Add (new List<Vector3> ());
		arrangement [14].Add (new Vector3 (200, 200, 0));
		arrangement [14].Add (new Vector3 (200, -200, 0));
		arrangement [14].Add (new Vector3 (0, 0, 0));
		arrangement [14].Add (new Vector3 (-200, -200, 0)); 
		arrangement [14].Add (new Vector3 (-200, 200, 0));
		//圖14-part2
		arrangement [14].Add (new Vector3 (0, 250, 0));
		arrangement [14].Add (new Vector3 (250, 0, 0));
		arrangement [14].Add (new Vector3 (0, 0, 0));
		arrangement [14].Add (new Vector3 (0, -250, 0)); 
		arrangement [14].Add (new Vector3 (-250, 0, 0));

		//圖15-part1
		arrangement.Add (new List<Vector3> ());
		arrangement [15].Add (new Vector3 (250, 0, 0)); 
		arrangement [15].Add (new Vector3 (0, 0, 0));
		arrangement [15].Add (new Vector3 (-250, 0, 0));
		//圖15-part2
		RandomPos (15);


		//圖13-part1
		arrangement.Add (new List<Vector3> ());
		arrangement [16].Add (new Vector3 (150, 150, 0));
		arrangement [16].Add (new Vector3 (150, -150, 0));
		arrangement [16].Add (new Vector3 (-150, -150, 0)); 
		arrangement [16].Add (new Vector3 (-150, 150, 0));
		//圖16-part2
		RandomPos (16);

		//圖17-part1
		arrangement.Add (new List<Vector3> ());
		arrangement [17].Add (new Vector3 (200, 200, 0));
		arrangement [17].Add (new Vector3 (200, -200, 0));
		arrangement [17].Add (new Vector3 (0, 0, 0));
		arrangement [17].Add (new Vector3 (-200, -200, 0)); 
		arrangement [17].Add (new Vector3 (-200, 200, 0));
		//圖17-part2
		RandomPos (17);


//		圖18-part1
		arrangement.Add (new List<Vector3> ());
		arrangement [18].Add (new Vector3 (250, 0, 0)); 
		arrangement [18].Add (new Vector3 (0, 0, 0));
		arrangement [18].Add (new Vector3 (-250, 0, 0));
		//圖18-part2
		RandomPos (18, 1);

		//圖19-part1
		arrangement.Add (new List<Vector3> ());
		arrangement [19].Add (new Vector3 (300, 0, 0)); 
		arrangement [19].Add (new Vector3 (100, 0, 0));
		arrangement [19].Add (new Vector3 (-100, 0, 0));
		arrangement [19].Add (new Vector3 (-300, 0, 0));
		//圖19-part2
		RandomPos (19, 1);


		//圖20-part1
		arrangement.Add (new List<Vector3> ());
		arrangement [20].Add (new Vector3 (400, 0, 0)); 
		arrangement [20].Add (new Vector3 (200, 0, 0));
		arrangement [20].Add (new Vector3 (0, 0, 0));
		arrangement [20].Add (new Vector3 (-200, 0, 0));
		arrangement [20].Add (new Vector3 (-400, 0, 0));
		//圖20-part2
		RandomPos (20, 1);


		//圖21-part1
		arrangement.Add (new List<Vector3> ());
		arrangement [21].Add (new Vector3 (200, -130, 0));
		arrangement [21].Add (new Vector3 (0, 130, 0));
		arrangement [21].Add (new Vector3 (-200, -130, 0)); 
		//圖21-part2
		RandomPos (21, 1);


		//圖22-part1
		arrangement.Add (new List<Vector3> ());
		arrangement [22].Add (new Vector3 (150, 150, 0));
		arrangement [22].Add (new Vector3 (150, -150, 0));
		arrangement [22].Add (new Vector3 (-150, -150, 0)); 
		arrangement [22].Add (new Vector3 (-150, 150, 0));
		//圖22-part2
		RandomPos (22, 1);

		//圖23-part1
		arrangement.Add (new List<Vector3> ());
		arrangement [23].Add (new Vector3 (200, 200, 0));
		arrangement [23].Add (new Vector3 (200, -200, 0));
		arrangement [23].Add (new Vector3 (0, 0, 0));
		arrangement [23].Add (new Vector3 (-200, -200, 0)); 
		arrangement [23].Add (new Vector3 (-200, 200, 0));
		//圖23-part2
		RandomPos (23, 1);

		//圖24-part1
		arrangement.Add (new List<Vector3> ());
		//圖24-part2
		RandomPos (24, 2, 3);

		//圖25-part1
		arrangement.Add (new List<Vector3> ());
		//圖25-part2
		RandomPos (25, 2, 4);

		//圖26-part1
		arrangement.Add (new List<Vector3> ());
		//圖26-part2
		RandomPos (26, 2, 5);


		//27-part1
		arrangement.Add (new List<Vector3> ());
		arrangement [27].Add (new Vector3 (200, -130, 0));
		arrangement [27].Add (new Vector3 (0, 130, 0));
		arrangement [27].Add (new Vector3 (-200, -130, 0));


		//圖28-part1
		arrangement.Add (new List<Vector3> ());
		arrangement [28].Add (new Vector3 (150, 150, 0));
		arrangement [28].Add (new Vector3 (150, -150, 0));
		arrangement [28].Add (new Vector3 (-150, -150, 0)); 
		arrangement [28].Add (new Vector3 (-150, 150, 0));

		//圖29-part1
		arrangement.Add (new List<Vector3> ());
		arrangement [29].Add (new Vector3 (0, 250, 0));
		arrangement [29].Add (new Vector3 (-250, 50, 0));
		arrangement [29].Add (new Vector3 (-150, -225, 0)); 
		arrangement [29].Add (new Vector3 (150, -225, 0));
		arrangement [29].Add (new Vector3 (250, 50, 0));

		//圖30-part1
		arrangement.Add (new List<Vector3> ());
		arrangement [30].Add (new Vector3 (132, 209, 100));
		arrangement [30].Add (new Vector3 (-136, 213, 100));
		arrangement [30].Add (new Vector3 (-270, 0, 100)); 
		arrangement [30].Add (new Vector3 (-136, -220, 100));
		arrangement [30].Add (new Vector3 (134, -220, 100));
		arrangement [30].Add (new Vector3 (270, 0, 100));

	}
*/
}
