using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class DataHolder : ScriptableObject
{
	public GameObject[] UFO;

	public GameObject[] UFO_Gray;

	public GameObject[] UFO_Red;

	#if UNITY_EDITOR

	[MenuItem("ScriptableObject/Create Data Asset")]
	static void CreateDataAsset(){

		//資料 Asset 路徑
		string holderAssetPath = "Assets/Resources/JT/";

		if(!Directory.Exists(holderAssetPath)) Directory.CreateDirectory(holderAssetPath);

		//建立實體
		DataHolder holder = ScriptableObject.CreateInstance<DataHolder> ();

		//使用 holder 建立名為 dataHolder.asset 的資源
		AssetDatabase.CreateAsset(holder, holderAssetPath + "dataHolder.asset");
	}

	#endif
}
