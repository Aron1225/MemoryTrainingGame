using UnityEngine;
using UnityEditor;

public class Level1_EasyEditor : MonoBehaviour {

//	[CustomEditor (typeof(Level1_Easy))]
//	public class Level1_Select_Editor : Editor
//	{
//		public override void OnInspectorGUI ()
//		{
//			Level1_Easy edit = target as Level1_Easy;
//
//			GUILayout.Space (15);
//
//			EditorGUILayout.BeginHorizontal ();
//
//			GUILayout.Label ("排列圖", GUILayout.Width (40));
//
//
////			EditorGUILayout.IntField (edit.arrangement_index);
//
//			edit.arrangement_index = EditorGUILayout.IntField (edit.arrangement_index);
//
//
//			//只有數值變化時執行
//			if (GUI.changed) {
//				Debug.Log ("value change");
//			}
//
//			if (GUILayout.Button ("Re", GUILayout.Width (30))) {
//				edit.arrangement_index = 0;
//			}
//
//			if (GUILayout.Button ("+", GUILayout.Width (30))) {
//				edit.arrangement_index++;///要設計最大不可超過值
//			}
//			if (GUILayout.Button ("-", GUILayout.Width (30))) {
//				if (edit.arrangement_index > 0) {
//					edit.arrangement_index--;
//				}
//			}
//
//			EditorGUILayout.EndHorizontal ();
//
//			//顯示預設檢視面板屬性編輯器
//			DrawDefaultInspector ();
//		}
//	}
}
