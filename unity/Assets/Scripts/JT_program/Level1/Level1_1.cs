using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1_1 : Level1
{
	/*field*/

	//關卡參數
	private int[][,] LevelParameter = null;

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
		//{ Loop, arrangement_index, random }
		LevelParameter = new int[][,] {
			new int[,] { { 20, 0, 2 } },//1
			new int[,] { { 20, 0, 3 } },//2
			new int[,] { { 25, 1, 3 } },//3
			new int[,] { { 25, 1, 4 } },//4
			new int[,] { { 30, 2, 4 } },//5
			new int[,] { { 30, 2, 5 } },//6
			new int[,] { { 35, 3, 5 } },//7
			new int[,] { { 35, 3, 6 } },//8
			new int[,] { { 20, 4, 6 }, { 20, 4, 7 } },//9
			new int[,] { { 20, 5, 7 }, { 20, 5, 8 } },//10
		};
	}

	public override void MAP ()
	{
		CT1.useL1DB.map = Resources.LoadAll<TextAsset> ("JT/maps");
		//讀入txt
		CT1.LoadMap (Resources.LoadAll<TextAsset> ("JT/maps") [0].text);
	}

	public override IEnumerator Loop1 (int Select_Level_number)
	{
		int number = Select_Level_number - 1;

		IEnumerator e = null;

		for (int i = 0; i < LevelParameter [number].GetLength (0); i++) {

			var Loop = LevelParameter [number] [i, 0];

			var map = CT1.Get_arrangement (LevelParameter [number] [i, 1]);

			var random = LevelParameter [number] [i, 2];

			e = Loop2 (Loop, random, map);

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
		var map = (List<Vector3>)args [2];

		CT1.useL1DB.random = random;

		int CheckCode = 0;

		for (int i = 0; i < Loop; i++) {

			yield return StartCoroutine (LevelManagement (map, true));

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
		}

		yield return CheckCode;//回傳至Loop1
	}
}
