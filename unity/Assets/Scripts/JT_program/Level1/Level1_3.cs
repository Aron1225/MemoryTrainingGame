using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1_3 : Level1
{
	/*field*/

	//關卡參數
	private	int[][,,] LevelParameter = null;

	/*methods*/

	//mono..........................

	public override void OnAwake ()
	{
		base.OnAwake ();
		level_instance = this;
		CT1 = GetComponent<Level1_Controller> ();
		controller = CT1;
	}

	public override void OnStart ()
	{
		base.OnStart ();
		Parameter ();
		MAP ();
	}

	//function......................

	public override void Parameter ()
	{
		//{Loop,Random},{range1,range2}
		LevelParameter = new int[][,,] {
			new int[,,]{ { { 20, 2 }, { 0, 4 } } },//1
			new int[,,]{ { { 20, 3 }, { 5, 9 } } }, //2
			new int[,,]{ { { 25, 3 }, { 10, 14 } } },//3
			new int[,,]{ { { 25, 4 }, { 15, 19 } } },//4
			new int[,,]{ { { 30, 4 }, { 20, 24 } } },//5
			new int[,,]{ { { 30, 5 }, { 25, 29 } } },//6
			new int[,,]{ { { 35, 5 }, { 30, 34 } } }, //7
			new int[,,]{ { { 35, 6 }, { 35, 39 } } },//8
			new int[,,]{ { { 20, 6 }, { 40, 44 } }, { { 20, 7 }, { 40, 44 } } },//9
			new int[,,]{ { { 20, 7 }, { 45, 49 } }, { { 20, 8 }, { 45, 49 } } },//10
		};
	}

	public override void MAP ()
	{
		CT1.useL1DB.map = Resources.LoadAll<TextAsset> ("JT/maps");
		//讀入txt
		CT1.LoadMap (Resources.LoadAll<TextAsset> ("JT/maps") [2].text);
	}

	public override IEnumerator Loop1 (int Select_Level_number)
	{
		int number = Select_Level_number - 1;
		
		IEnumerator e = null;
		
		for (int i = 0; i < LevelParameter [number].GetLength (0); i++) {
		
			var Loop = LevelParameter [number] [i, 0, 0];
		
			var random = LevelParameter [number] [i, 0, 1];
		
			var mapRange1 = LevelParameter [number] [i, 1, 0];//0
		
			var mapRange2 = LevelParameter [number] [i, 1, 1];//3
		
			var maps = CT1.Get_MapRange (mapRange1, mapRange2);//0~3,取得指定範圍地圖陣列
		
			e = Loop2 (Loop, random, maps);
		
			yield return StartCoroutine (e);
		
			if ((int)e.Current != 0)
				break;
		}
		
		yield return e.Current;//回傳至GameLoop
	}

	public override IEnumerator Loop2 (params object[] args)
	{
		var Loop = (int)args [0];
		var random = (int)args [1];
		var maps = (List<List<Vector3>>)args [2];

		CT1.useL1DB.random = random;

		int CheckCode = 0, Count = 0, index = 0;
		
		while (Count++ != Loop) {
		
			if (index == maps.Count)
				index = 0;
		
			yield return StartCoroutine (LevelManagement (maps [index++], false));
		
			//隨機亂數
			yield return StartCoroutine (MakeRandom (CT1.useL1DB.random));
		
			//亮燈
			yield return StartCoroutine (ShowLight ());
		
			//答案比對
			yield return StartCoroutine (AnswerCompare ());
		
			//重置
			yield return StartCoroutine (Reset ());
		
			if (CT1.Feedback ()) {
				CheckCode = 1;
				break;
			}

			if (CT1.IfTimeOut) {
				CheckCode = 2;
				break;
			}
			yield return null;
		}
		yield return CheckCode;//回傳至Loop1
	}

}
