using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class Thread_5 : MonoBehaviour {
/*
	Monitor 類別，與 Lock 不同的是， Monitor 類別進一步提供阻斷或是繼續特定執行緒的執行動作，讓資源的存取能夠
    更進一步獲得控制，Monitor 提供一些靜態方法。

	Enter ：取得指定物件的獨佔鎖定，通常我們會直接傳入 this 關鍵字，表示監控目前產生執行緒的物件。
	Wait：多載。 釋出物件的鎖並且封鎖目前的執行緒，直到這個執行緒重新取得鎖定為止。
	Pulse：通知等候佇列中的執行緒，鎖定物件的狀態有所變更，總是會恢復第一個被暫停的執行緒。
	Exit：釋出指定物件的獨佔鎖定。

*/

	private int dataSum = 0;
	private int dataOutput = 0;


	void Start () {
		//建立執行緒
		Thread TA = new Thread(new ThreadStart(DataHandle));
		Thread TB = new Thread(new ThreadStart(DataPrint));
		TA.Name = "執行緒 A ";
		TB.Name = "執行緒 B ";
		//啟動執行緒
		TB.Start();
		TA.Start();
		//暫停主執行緒，等待 A、B 完成工作
		TA.Join();
		TB.Join();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void DataHandle() {
		//監控進入點
		Monitor.Enter(this);

		for (int n1 = 0; n1 < 10; n1++) {

			//若 dataOutput 等於 10，則鎖定目前的執行緒，並將這個執行緒鎖定的資源釋放
			if (dataOutput == 5) Monitor.Wait(this);

			dataOutput++;
			Debug.Log (Thread.CurrentThread.Name +" 正在處理第 " + dataOutput + "筆資料 !! ");
			Thread.Sleep(100);
			if (dataOutput == 5) {
				//總是會恢復第一個被暫停的執行緒 TB 會被叫醒
				Monitor.Pulse(this);
			}
		}
		//結束監控
		Monitor.Exit(this);
	}

	void DataPrint() {
		//監控進入點
		Monitor.Enter(this);
		do {
			//若 dataOutput 等於 0，則鎖定目前的執行緒，並將這個執行緒鎖定的資源釋放
			//所以 TB 一開始就會暫停工作
			if (dataOutput == 0) Monitor.Wait(this);

			Debug.Log (Thread.CurrentThread.Name +" 正在列印第 " + dataOutput + "筆資料 !! ");
			Thread.Sleep(100);
			dataOutput--;
			dataSum++;
			Debug.Log ("\t總處理資料筆數!!"+dataSum);
			if (dataOutput == 0) {
				//總是會恢復第一個被暫停的執行緒 TA 會被叫醒
				Monitor.Pulse(this);
			}
		} while (dataSum < 10);
		//結束監控
		Monitor.Exit(this);
	}
}
