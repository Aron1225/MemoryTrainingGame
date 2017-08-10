using UnityEngine;
using UnityEditor;

public class WritePos_Editor : MonoBehaviour {

	[CustomEditor (typeof(WritePos))]
	public class WritePos_Select_Editor : Editor
	{
		public override void OnInspectorGUI ()
		{
			//顯示預設檢視面板屬性編輯器
			DrawDefaultInspector ();

			WritePos edit = target as WritePos;

			if (GUILayout.Button ("+", GUILayout.Width (30))) {
				edit.index++;
			}
			if (GUILayout.Button ("-", GUILayout.Width (30))) {
				if (edit.index > 0) {
					edit.index--;
				}
			}

			GUILayout.Space (15);

			EditorGUILayout.BeginHorizontal ();

			GUILayout.Label ("座標寫檔", GUILayout.Width (60));

			if (GUILayout.Button ("Write", GUILayout.Width (60))) {
				edit.WritePosition ();
			}

			EditorGUILayout.EndHorizontal ();

		}
	}
}
