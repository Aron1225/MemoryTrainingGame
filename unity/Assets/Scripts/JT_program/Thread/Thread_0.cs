using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class Thread_0 : MonoBehaviour {

	//建立執行緒，其中 ThreadStart 是一個委派型別，可以指向沒有參數沒有回傳值得方法。


	void Start () {
		//建立一個執行緒，並且傳入一個委派物件 ThreadStart，並且指向 PrintOddNumber 方法。
		Thread oThreadA = new Thread(new ThreadStart(PrintOddNumber));
		oThreadA.Name = "A Thread";

		//建立一個執行緒，並且傳入一個委派物件 ThreadStart，並且指向 PrintNumber 方法。
		Thread oThreadB = new Thread(new ThreadStart(PrintNumber));
		oThreadB.Name = "B Thread";

		//啟動執行緒物件
		oThreadA.Start();
		oThreadB.Start();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//印出奇數
	private void PrintOddNumber() {
		for (int n1 = 1; n1 < 10; n1++) {
			if (n1 % 2 != 0) {
				Debug.Log("執行緒"+Thread.CurrentThread.Name+"輸出奇數"+n1);
			}
		}
	}

	//印出偶數
	private void PrintNumber() {
		for (int n1 = 1; n1 < 10; n1++) {
			if (n1 % 2 == 0) {
				Debug.Log("執行緒"+Thread.CurrentThread.Name+"輸出奇數"+n1);
			}
		}
	}
}
