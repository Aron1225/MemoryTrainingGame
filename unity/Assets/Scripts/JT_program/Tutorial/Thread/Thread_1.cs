using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System;

public class Thread_1 : MonoBehaviour {

	//建立可以傳入參數的執行緒 ，ParameterizedThreadStart。

	void Start () {
		//建立一個執行緒，並且傳入一個委派物件 ParameterizedThreadStart，'
		//並且設定指向 PrintOddNumber 方法。               
		Thread oThreadA = new Thread(new ParameterizedThreadStart(PrintOddNumber));

		//設定執行緒的 Name
		oThreadA.Name = "A Thread";

		//建立一個執行緒，並且傳入一個委派物件 PrintNumber，'
		//並且設定指向 PrintNumber 方法。               
		Thread oThreadB = new Thread(new ParameterizedThreadStart(PrintNumber));

		//設定執行緒的 Name
		oThreadB.Name = "B Thread";

		//啟動執行緒物件，並且傳入參數
		oThreadA.Start(10);
		oThreadB.Start(10);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	//印出奇數
	private void PrintOddNumber(object value) {
		int Number = Convert.ToInt32(value);
		for (int n1 = 1; n1 <= Number; n1++) {
			if (n1 % 2 != 0) {
				Debug.Log("執行緒"+ Thread.CurrentThread.Name+"輸出奇數"+n1);
			}
		}
	}

	//印出偶數
	private void PrintNumber(object value) {
		int Number = Convert.ToInt32(value);
		for (int n1 = 1; n1 <= Number; n1++) {
			if (n1 % 2 == 0) {
				Debug.Log("執行緒"+ Thread.CurrentThread.Name+"輸出奇數"+n1);
			}
		}
	}
}
