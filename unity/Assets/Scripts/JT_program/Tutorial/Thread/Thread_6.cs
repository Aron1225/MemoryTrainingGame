using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class Thread_6 : MonoBehaviour {

/*
	終止執行緒，可以使用 Interrupt 方法，這個方法會阻斷處於 WaitSleepJoin 狀態下的執行緒。

	msdn :

	如果這個執行緒目前沒有封鎖於等候、休眠或聯結 (Join) 狀態中，就會在下一次要開始封鎖時被插斷。

	插斷的執行緒中會擲回 ThreadInterruptedException，但必須等到執行緒封鎖後才會擲回。如果執行緒一直沒有封鎖，就永遠不會擲回此例外狀況，因此執行緒完成時可能完全沒有插斷。
*/

	long fSum1 = 0;
	long fSum2 = 2;
	Thread Threading1;
	Thread Threading2;

	void Start () {
		Threading1 = new Thread(new ThreadStart(FibonnacciSeries1));
		Threading1.Name = "ThreadA";

		Threading2 = new Thread(new ThreadStart(FibonnacciSeries2));
		Threading2.Name = "ThreadB";

		Threading1.Start(); //啟動第一個執行緒
		Threading2.Start(); //啟動第二個執行緒 

		Threading1.Join();
		Threading2.Join();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	private void FibonnacciSeries1() {
		try {
			for (int n1 = 0; n1 < 10; n1++) {
				Thread.Sleep(1000);
				fSum1 += n1;
				if (n1 > 5) {
					//終止執行緒
					Threading1.Interrupt();
				}
				Debug.Log(Thread.CurrentThread.Name + " : " + " 目前總合為  = " + fSum1);
			}
		}      //捕捉例外             
		catch (ThreadInterruptedException) {
			Debug.Log(Thread.CurrentThread.Name + " 終止");
		}
	}
	private void FibonnacciSeries2() {
		try {
			for (int n1 = 0; n1 < 10; n1++) {
				Thread.Sleep(1000);
				fSum2 += n1;
				Debug.Log(Thread.CurrentThread.Name + " : " + " 目前總合為  = " + fSum2);
			}
		}
		catch (ThreadInterruptedException) {
			Debug.Log(Thread.CurrentThread.Name + " 終止");
		}
	} 
}
