using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1_4 : Level1
{
	/*field*/

	//main camera
	public CameraControl mCamera;

	//關卡參數
	private	int[][,] LevelParameter = null;

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
		SetCameraSteps ();
	}

	//function......................

	public override void Parameter ()
	{
		//{ Loop, arrangement_index, random,CameraStep}
		LevelParameter = new int[][,] {
			new int[,] { { 20, 0, 2, 0 } },//1
			new int[,] { { 20, 0, 3, 0 } },//2
			new int[,] { { 25, 1, 3, 1 } },//3
			new int[,] { { 25, 1, 4, 1 } },//4
			new int[,] { { 30, 2, 4, 2 } },//5
			new int[,] { { 30, 2, 5, 2 } },//6
			new int[,] { { 35, 3, 5, 3 } },//7
			new int[,] { { 35, 3, 6, 3 } },//8
			new int[,] { { 20, 4, 6, 4 }, { 20, 4, 7, 4 } },//9
			new int[,] { { 20, 4, 7, 4 }, { 20, 5, 8, 4 } },//10
		};
	}

	public override void MAP ()
	{
		CT1.useL1DB.map = Resources.LoadAll<TextAsset> ("JT/maps");
		//讀入txt
		CT1.LoadMap (Resources.LoadAll<TextAsset> ("JT/maps") [3].text);
	}

	public override IEnumerator Loop1 (int Select_Level_number)
	{
		int number = Select_Level_number - 1;
		
		IEnumerator e = null;
		
		for (int i = 0; i < LevelParameter [number].GetLength (0); i++) {
		
			var Loop = LevelParameter [number] [i, 0];
		
			var mapIndex = LevelParameter [number] [i, 1];
		
			var random = LevelParameter [number] [i, 2];
		
			var CameraStep = LevelParameter [number] [i, 3];
		
			e = Loop2 (Loop, random, CameraStep, mapIndex);
		
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
		var step = (int)args [2];
		var mapIndex = (int)args [3];

		CT1.useL1DB.random = random;

		mCamera.Step (step);
		
		int CheckCode = 0;
		
		if (!CT1.useL1DB.start)
			for (int j = 0; j <= mapIndex; j++)
				yield return StartCoroutine (LevelManagement (CT1.Get_arrangement (j)));
		
		for (int i = 0; i < Loop; i++) {
		
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

	public override IEnumerator LevelManagement (params object[] args)
	{
		var map = (List<Vector3>)args [0];

		CT1.DisplaySliderBar ();//更新難度條
		
		var Balance = map.Count; //多(少)幾台
		
		List<UFO> Group = UFO.InstantiateUFOs (Balance);//實例化UFO
		
		//重設場上所有UFO座標
		for (int i = 0; i < Group.Count; i++)
			Group [i].moveTo (0.7f, map [i], true, 0.1f);
		
		yield break;
	}

	//設定camera距離
	private void SetCameraSteps ()
	{
		mCamera.step = new float[] {
			-417,
			-862,
			-1350,
			-1746,
			-2184,
		};
	}
}
