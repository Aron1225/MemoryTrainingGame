using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class WritePos : MonoBehaviour
{
	//來源txt檔
	public TextAsset target;
	//陣列index
	public int index;
	//所有子物件
	Transform[] childrens;

	void Start ()
	{
		
	}
	#if UNITY_EDITOR
	//Write some text to file
	public void WritePosition ()
	{
		//取得所有子物件Transform
		childrens = transform.GetComponentsInChildren<Transform> ();

		//當txt存在
		if (target) {
			//檔案位置

			string path = UnityEditor.AssetDatabase.GetAssetPath (target);


			//寫入資料
			using (StreamWriter writer = new StreamWriter (path, true)) {

				try {
					childrens = transform.GetComponentsInChildren<Transform> ();

					for (int i = 1; i <= childrens.Length - 1; i += 2) {
						Vector3 pos = childrens [i].localPosition;
						writer.WriteLine (index + "#" + pos.x + ", " + pos.y + ", " + pos.z);
					}

					writer.WriteLine ("\n");

				} catch (IOException ex) {
					Debug.LogError ("Write Error");
				} finally {
					writer.Close ();
					writer.Dispose ();
				}
			}
		} else {
			Debug.Log ("target not found");
		}
	}
	#endif
}





