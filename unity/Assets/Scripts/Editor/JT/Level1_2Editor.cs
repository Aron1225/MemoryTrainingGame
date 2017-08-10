using UnityEngine;
using UnityEditor;

public class Level1_2Editor : MonoBehaviour
{
//
//	[CustomEditor (typeof(Level1_2))]
//	public class Level1_Select_Editor : Editor
//	{
//		public override void OnInspectorGUI ()
//		{
//
//			Level1_2 edit = target as Level1_2;
//
//			GUILayout.Space (15);
//
//			EditorGUILayout.BeginHorizontal ();
//
//			GUILayout.Label ("排列圖", GUILayout.Width (40));
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
//			EditorGUILayout.BeginHorizontal ();
//			{
//				GUILayout.Label ("隨機數", GUILayout.Width (40));
//
//				edit.random = EditorGUILayout.IntField (edit.random);
//
//				if (GUILayout.Button ("+", GUILayout.Width (30))) {
//					if (edit.random < Level1_DataBase.UFOList.Count)
//						edit.random++;
//				}
//				if (GUILayout.Button ("-", GUILayout.Width (30))) {
//					if ((edit.random > 0))
//						edit.random--;
//				}
//			}
//			EditorGUILayout.EndHorizontal ();
//
//
//			EditorGUILayout.BeginHorizontal ();
//			{
//				GUILayout.Label ("LightTime", GUILayout.Width (60));
//
//				edit.lighttime = EditorGUILayout.FloatField (edit.lighttime);
//
//				if (GUILayout.Button ("+", GUILayout.Width (30))) {
//					edit.lighttime += 0.5f;///要設計最大不可超過值
//				}
//				if (GUILayout.Button ("-", GUILayout.Width (30))) {
//					if (edit.lighttime > 0) {
//						edit.lighttime -= 0.5f;
//					}
//				}
//			}
//
//			EditorGUILayout.EndHorizontal ();
//
//			EditorGUILayout.BeginHorizontal ();
//			{
//				GUILayout.Label ("DarkTime", GUILayout.Width (60));
//
//				edit.darktime = EditorGUILayout.FloatField (edit.darktime);
//
//				if (GUILayout.Button ("+", GUILayout.Width (30))) {
//					edit.darktime += 0.5f;///要設計最大不可超過值
//				}
//				if (GUILayout.Button ("-", GUILayout.Width (30))) {
//					if (edit.darktime > 0) {
//						edit.darktime -= 0.5f;
//					}
//				}
//			}
//			EditorGUILayout.EndHorizontal ();
//
//
//			//顯示預設檢視面板屬性編輯器
//			//DrawDefaultInspector ();
//		}
//	}
}
