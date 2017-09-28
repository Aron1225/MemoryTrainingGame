using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Toast
{
	AndroidJavaClass UnityPlayer;
	AndroidJavaObject currentActivity;
	AndroidJavaObject context;

	static private string toastString;

	static public Toast makeText(string str){
		toastString = str;
		return new Toast();
	}

	public Toast show()
	{
		if (Application.platform == RuntimePlatform.Android) {
			UnityPlayer = new AndroidJavaClass ("com.unity3d.player.UnityPlayer");
			currentActivity = UnityPlayer.GetStatic<AndroidJavaObject> ("currentActivity");
			context = currentActivity.Call<AndroidJavaObject> ("getApplicationContext");
			currentActivity.Call ("runOnUiThread", new AndroidJavaRunnable (showToast));
		}

		if (Application.platform == RuntimePlatform.WindowsEditor) {
			Debug.Log ("Toast:" + toastString);
		}
		return this;
	}

	private void showToast ()
	{
		AndroidJavaClass Toast = new AndroidJavaClass ("android.widget.Toast");
		AndroidJavaObject javaString = new AndroidJavaObject ("java.lang.String", toastString);
		AndroidJavaObject toast = Toast.CallStatic<AndroidJavaObject> ("makeText", context, javaString, Toast.GetStatic<int> ("LENGTH_SHORT"));
		toast.Call ("show");
	}
}
