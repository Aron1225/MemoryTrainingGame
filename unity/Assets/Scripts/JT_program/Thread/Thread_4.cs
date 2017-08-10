using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class Thread_4 : MonoBehaviour
{

	//執行緒同步化，避免資源存取衝突 ，使用 Lock；

	//藉由 Lock 敘述句完成執行緒同步作業，用以控制程式上某一段資源，這時，其他的執行緒沒權限

	//可以存取這份資源。


	private int addSum;

	void Start ()
	{
		//建立執行緒陣列
		Thread[] threads = new Thread[3];
		//依序設定陣列內容
		for (int n1 = 0; n1 < 3; n1++) {
			Thread myThread = new Thread (new ThreadStart (DoSum));
			threads [n1] = myThread;
			threads [n1].Name = "執行緒" + n1;
		}
		//依序啟動執行緒
		for (int n1 = 0; n1 < 3; n1++) {
			threads [n1].Start ();
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	void DoSum ()
	{
//		for (int n1 = 0; n1 < 7; n1++) {
//			//當目前執行緒執行這個方法時，會鎖住資源，其他執行緒無法存取，直到該執行緒工作完成
//			lock (this) {//this 表示，目前執行緒所在的類別，也就是鎖住這個類別的資源
//				addSum += 2;
//				Thread.Sleep (1);
//				Debug.Log (Thread.CurrentThread.Name + "，執行第 " + n1 + " 次，addSum =" + addSum);
//			}
//		}
	}
}
