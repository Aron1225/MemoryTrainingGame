using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Connect : MonoBehaviour
{
	private AndroidJavaClass jc;
	private AndroidJavaClass unity;
	public static  AndroidJavaObject jo;

	void Awake ()
	{
		#if !UNITY_EDITOR
		jc = new AndroidJavaClass ("com.unity3d.player.UnityPlayer");  
		jo = jc.GetStatic<AndroidJavaObject> ("currentActivity");	
		//找到MainUnity.java
		unity = new AndroidJavaClass ("tw.com.jt.aron.brainwave.MainUnity");
		#endif
	}


	void Start ()
	{
//		#if !UNITY_EDITOR
//		//回傳藍芽是否正常開啟
//		bool result = jo.Call<bool> ("StartBrainWave");
//		if (result) {
//
//		} else {
//
//		L2menu.UI_BluetoothIsNotOpen ();
//		}
//		#endif
	}

	void OnDestroy ()
	{
//		#if !UNITY_EDITOR
//		jo.Call ("StopBrainWave");
//		#endif
	}

	public void setBluetooth ()
	{	
		#if !UNITY_EDITOR
//		AndroidJavaClass androidJC = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
//		AndroidJavaObject jo= androidJC.GetStatic<AndroidJavaObject>("currentActivity");
//		AndroidJavaClass jc = new AndroidJavaClass("tw.com.jt.aron.brainwave.MainUnity");
//		jc.CallStatic("Launch",jo);

		using (AndroidJavaClass cls_UnityPlayer = new AndroidJavaClass ("com.unity3d.player.UnityPlayer")) {
			using (AndroidJavaObject obj_Activity = cls_UnityPlayer.GetStatic<AndroidJavaObject> ("currentActivity")) {
				obj_Activity.CallStatic ("SetBluetooth", obj_Activity);
			}
		}
		#endif
	}
}
