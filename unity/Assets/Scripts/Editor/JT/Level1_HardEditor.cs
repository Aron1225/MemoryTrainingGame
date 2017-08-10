using UnityEngine;
using UnityEditor;

public class Level1_HardEditor : MonoBehaviour {

//	[CustomEditor (typeof(Level1_Hard))]
//	public class Level1_Select_Editor : Editor
//	{
//		public override void OnInspectorGUI ()
//		{
//			
//			Level1_Hard edit = target as Level1_Hard;
//
//			GUILayout.Space (15);
//
//			EditorGUILayout.BeginHorizontal ();
//
//			GUILayout.Label ("排列圖", GUILayout.Width (40));
//
//			edit.arrangement_index = EditorGUILayout.IntField (edit.arrangement_index);
//
//			edit.popup = EditorGUILayout.Popup (edit.popup, new string[]{ "固定", "旋轉", "隨機移動" });
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
