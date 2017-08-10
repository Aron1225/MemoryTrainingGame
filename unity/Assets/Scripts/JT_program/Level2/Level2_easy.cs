using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2_easy : MonoBehaviour
{

	#region Parameter...

	//圖案
	[Header ("Object")]

	//UIRoot-Panel
	[SerializeField]
	private GameObject Panel;
	//BingoIcon
	[SerializeField]
	private GameObject Bingo;
	//ErrorIcon
	[SerializeField]
	private GameObject Error;

	#endregion

	void Initialization ()
	{
		//取得Panel物件
		Panel = GameObject.Find ("Panel");

		//取得Bingo物件
		Bingo = Resources.Load<GameObject> ("JT/" + "checked-Bingo");

		//取得Error物件
		Error = Resources.Load<GameObject> ("JT/" + "checked-Error");
	}



	void Start ()
	{
		Initialization ();

		StartCoroutine (GameStart ());
	}

	void Update ()
	{

	}



	IEnumerator GameStart ()
	{
//		while (true) {
//
//			//關卡設定
//			yield return StartCoroutine (LevelManagement ());
//
//			//隨機亂數
//			yield return StartCoroutine (MakeRandom (4));
//
//			//亮燈
//			yield return StartCoroutine (ShowLight ());
//
//			//答案比對
//			yield return StartCoroutine (AnswerCompare ());
//
//			//重置
//			yield return StartCoroutine (Reset ());
//
//			//等待下一幀
			yield return null;
//		}
	}

//	///關卡設定
//	IEnumerator LevelManagement ()
//	{
//	}
//
//	//隨機亂數
//	IEnumerator MakeRandom (int key)//key->需要幾個亂數
//	{
//		//清空
//		UFO_Random.Clear ();
//
//		//設定亂數種子
//		//UnityEngine.Random.InitState (System.Guid.NewGuid ().GetHashCode ());
//
//		List<Level1_UFO> TempList = UFOList.ToList ();
//
//		for (int i = 0; i < key; i++) {
//			int num = UnityEngine.Random.Range (0, TempList.Count);
//			UFO_Random.Add (TempList [num]);
//			TempList [num] = TempList [TempList.Count - 1];
//			TempList.RemoveAt (TempList.Count - 1);
//		}
//		yield break;
//	}
//
//	IEnumerator ShowLight ()
//	{
//		//當陣列全部等於false時執行
//		yield return WaitUntilUFOReady;
//
//		foreach (Level1_UFO ufo in UFO_Random) {
//
//			ufo.LightOn ();
//
//			yield return LightTime;
//
//			ufo.LightOff ();
//
//			//當走訪至最後時跳出迴圈
//			//			if (ufo == UFO_Random.Last ())
//			//				break;
//
//			yield return DarkTime;
//		}
//	}
//
//	IEnumerator AnswerCompare ()
//	{
//	}
//
//	//重置
//	IEnumerator Reset ()
//	{
//		s_iClick = 0;
//
//		s_iReferencePoint = -500;
//
//		yield break;
//	}

}
