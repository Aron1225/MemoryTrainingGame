using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inheritance : MonoBehaviour
{

	public int type;

	void Start ()
	{
		try {
			Debug.Log ("請選擇所要列印的報表規格");
			Debug.Log ("1.標準 2.A4尺寸 3.A3尺寸");
			Debug.Log ("*******************************************************");
			switch (type) {
			case 1:
				printreport pr = new printreport ();
				pr.printstart ();
				break;
			case 2:
				printA4 pa = new printA4 ();
				pa.printstart ();
				break;
			case 3:
				printA3 pa3 = new printA3 ();
				pa3.printstart ();
				break;
			}
		} catch (System.Exception e) {
			Debug.Log ("Bug!!!");
		}
	}


	void Update ()
	{
		
	}

	class printreport
	{
		public printreport ()
		{
			Debug.Log ("繼承:報表程式啟動......");
		}

		public virtual void printstart ()
		{
			Debug.Log ("報表開始列印..");
			Debug.Log ("列印標準尺寸報表...");
			Debug.Log ("工作完成...");
			finishedwork ("標準");
		}

		protected void finishedwork (string type)
		{
			Debug.Log ("多載:" + type + "報表列印完成...");
			Debug.Log ("多載:清楚佇列工作.....");
		}
	}

	class printA4 : printreport
	{
		public override void printstart ()
		{
			Debug.Log ("報表開始列印..");
			Debug.Log ("列印A4尺寸報表...");
			Debug.Log ("工作完成...");
			finishedwork ("A4");
		}
	}

	class printA3 : printreport
	{
		public override void printstart ()
		{
			Debug.Log ("報表開始列印..");
			Debug.Log ("列印A3尺寸報表...");
			Debug.Log ("工作完成...");
			finishedwork ("A3");
		}
	}
}
