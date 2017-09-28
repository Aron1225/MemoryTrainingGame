using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1_5 : Level1
{
	/*field*/

	//main camera
	public CameraControl mCamera;

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
		SetCameraSteps ();
	}

	//function......................

	public override void Parameter ()
	{
		//{ mode, Loop, arrangement_index, random,CameraStep}

		//只抓取陣列第一筆資料
		LevelParameter = new int[][,,] {
		
			//直線.........................

			new int[,,] { { 
					{ 1, 20, 0, 2, 0 }
				} 
			},//1
			new int[,,] { { 
					{ 1, 20, 1, 3, 1 }
				}
			},//2
			new int[,,] { { { 1, 25, 2, 3, 2 } }
			},//3
			new int[,,] { {
					{ 1, 25, 3, 4, 3 }
				}
			},//4
			new int[,,] { 
				{ { 1, 30, 3, 5, 3 } } 
			},//5
		
			//圓形.........................

			//往後增加的都從第一個開始再增加
			// 1(第一章圖
			// 1+2(第二章圖
			// 1+2+3(第三張圖
			//依此類推.....

			new int[,,] { { 
					{ 0, 30, 4, 3, 4 } 
				} 
			},//6
		
			new int[,,] { {
					{ 0, 35, 4, 4, 5 }, 
					{ 0, 35, 5, 4, 5 }
				},
			},//7
		
			new int[,,] { {
					{ 0, 35, 4, 5, 5 },
					{ 0, 35, 5, 5, 5 }, 
					{ 0, 35, 6, 5, 5 } 
				},
			},//8
		
			new int[,,] { {
					{ 0, 40, 4, 6, 6 }, 
					{ 0, 40, 5, 6, 6 }, 
					{ 0, 40, 6, 6, 6 }, 
					{ 0, 40, 7, 6, 6 }
				},
			},//9
		
			new int[,,] { {
					{ 0, 40, 4, 7, 7 }, 
					{ 0, 40, 5, 7, 7 }, 
					{ 0, 40, 6, 7, 7 }, 
					{ 0, 40, 7, 7, 7 }, 
					{ 0, 40, 8, 7, 7 },
				},
			},//10
		};
	}

	public override void MAP ()
	{
		CT1.useL1DB.map = Resources.LoadAll<TextAsset> ("JT/maps");
		//讀入txt
		CT1.LoadMap (Resources.LoadAll<TextAsset> ("JT/maps") [4].text);
	}

	public override IEnumerator Loop1 (int Select_Level_number)
	{
		int number = Select_Level_number - 1;
		
		IEnumerator e = Loop2 (number);
		
		yield return StartCoroutine (e);
		
		yield return e.Current;//回傳至GameLoop
	}

	public override IEnumerator Loop2 (params object[] args)
	{ 
		var number = (int)args [0];

		//只抓取陣列第一筆資料
		var Loop = LevelParameter [number] [0, 0, 1];
		
		var CameraStep = LevelParameter [number] [0, 0, 4];
		
		mCamera.Step (CameraStep);//設定camera距離
		
		//用來使群組能順逆轉
		int dirCount = 0;
		int dir = 1;

		int random = 0;

		for (int i = 0; i < LevelParameter [number].GetLength (0); i++) {
			for (int j = 0; j < LevelParameter [number].GetLength (1); j++) {//每次都從第一個開始 一直跑到最後
		
				var mode = LevelParameter [number] [i, j, 0];
		
				var map = CT1.Get_arrangement (LevelParameter [number] [i, j, 2]);
		
				random = LevelParameter [number] [i, j, 3];
		
				CT1.useL1DB.random = random;

				yield return StartCoroutine (LevelManagement (mode, Forward_OR_Reverse (ref dir, ref dirCount), map));
			}
		}

		IEnumerator e = Loop3 (Loop);
		
		yield return StartCoroutine (e);
								
		yield return e.Current;//回傳至Loop1
	}

	IEnumerator Loop3 (int Loop)
	{
		int CheckCode = 0;
	
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
		yield return CheckCode;//回傳至Loop2
	}

	///關卡設定
	public override IEnumerator LevelManagement (params object[] args)
	{
		//旋轉模式
		var mode = (int)args [0];

		//旋轉方向(順或逆)
		var dir = (int)args [1];

		//排列地圖
		var maps = (List<Vector3>)args [2];

		//更新難度條
		CT1.DisplaySliderBar ();
	
		//創造旋轉群組
		Level1_RotationFix RotateGroup = CT1.CreateGroup ();
	
		if (mode == 0) {
			RotateGroup.direction = dir;
		}
	
		//建置UFO位置
		UFO.UFO_group = RotateGroup.transform;
	
		var Balance = maps.Count; //多(少)幾台
	
		var Group = UFO.InstantiateUFOs (Balance);//實例化UFO
	
		//重設場上所有UFO座標
		for (int i = 0; i < Group.Count; i++)
			Group [i].moveTo (0.7f, maps [i], true, 0.1f);
	
		yield break;
	}

	//使多層旋轉群組可以(順逆順逆)旋轉
	private int Forward_OR_Reverse (ref int dir, ref int dirCount)
	{
		if (dirCount++ == 0) {
			dir *= -1;
			return dir;
		}
	
		if (dirCount % 2 == 0) {
			dir *= -1;
		}
		return dir;
	}

	//設定camera距離
	private void SetCameraSteps ()
	{
		mCamera.step = new float[] {
			-1634,
			-1730,
			-2205,
			-2877,
			-921,
			-1592,
			-2502,
			-2569
		};
	}
}
