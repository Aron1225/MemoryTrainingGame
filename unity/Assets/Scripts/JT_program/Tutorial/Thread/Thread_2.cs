using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class Thread_2 : MonoBehaviour
{

	//暫停執行緒使用 Sleep()

	void Start ()
	{
		//建立委派物件並指向 PrintNumber 方法
		ThreadStart myThreadStart = new ThreadStart (PrintNumber);
		//建立執行緒物件
		Thread myThread = new Thread (myThreadStart);
		myThread.Start (); //啟動執行緒
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	public void PrintNumber ()
	{
		for (int n1 = 0; n1 <= 10; n1++) {
			Debug.Log (Thread.CurrentThread.Name + "迴圈次數" + n1 + " 次");
			if (n1 == 5) {
				Debug.Log (" 執行緒暫停 5 秒鐘 !!");
				Thread.Sleep (5000);   // 暫停執行緒 
			}
		}
	}
}
