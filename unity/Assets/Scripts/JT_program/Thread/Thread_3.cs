using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class Thread_3 : MonoBehaviour
{

	//執行緒使用 Join()

	//當執行緒本身無法決定暫停多久，必須等到其他的執行緒完成，才能繼續剩下的工作，使用這個方法，

	//會封鎖目前的執行緒，直到引用這個方法的執行緒執行完成之後，再進行未完成的工作。


	//欄位
	private Thread ThreadA;
	private Thread ThreadB;


	void Start ()
	{
		//建立執行緒 A
		ThreadA = new Thread (new ThreadStart (PrintNumber));
		ThreadA.Name = "A Thread";
		//建立執行緒 B
		ThreadB = new Thread (new ThreadStart (JoinPrintNumber));
		ThreadB.Name = "B Thread";

		//啟動執行緒
		ThreadA.Start ();
		ThreadB.Start ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	private void PrintNumber ()
	{
		for (int n1 = 1; n1 <= 10; n1++) {
			Debug.Log (Thread.CurrentThread.Name +" 迴圈： " + n1 + " 次");
			Thread.Sleep (1000);
			if (n1 == 5) {
				Debug.Log ("暫停執行緒"+ Thread.CurrentThread.Name);
				//暫停目前執行緒，等待 ThreadB 執行完
				ThreadB.Join ();
			}

		}
	}

	private void JoinPrintNumber ()
	{
		for (int n1 = 11; n1 <= 20; n1++) {
			Debug.Log(Thread.CurrentThread.Name +" 迴圈開始執行迄今第 " + n1 + " 次");
			Thread.Sleep (1000);
		}
	}
}
