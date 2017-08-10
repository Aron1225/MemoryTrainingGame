using UnityEngine;
using UnityEditor;

public class Level1_6Editor : MonoBehaviour {

//	[CustomEditor (typeof(Level1_6))]
//	public class Level1_Select_Editor : Editor
//	{
//		public override void OnInspectorGUI ()
//		{
//			Level1_6 edit = target as Level1_6;
//
//			GUILayout.Space (15);
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
//			EditorGUILayout.BeginHorizontal ();
//			{
//				GUILayout.Label ("x", GUILayout.Width (60));
//
//				edit.x = EditorGUILayout.FloatField (edit.x);
//
//			}
//			EditorGUILayout.EndHorizontal ();
//
//			EditorGUILayout.BeginHorizontal ();
//			{
//				GUILayout.Label ("y", GUILayout.Width (60));
//
//				edit.y = EditorGUILayout.FloatField (edit.y);
//
//			}
//			EditorGUILayout.EndHorizontal ();
//
//			EditorGUILayout.BeginHorizontal ();
//			{
//				GUILayout.Label ("z", GUILayout.Width (60));
//
//				edit.z = EditorGUILayout.FloatField (edit.z);
//
//			}
//			EditorGUILayout.EndHorizontal ();
//
//			//顯示預設檢視面板屬性編輯器
//			//			DrawDefaultInspector ();
//		}
//	}
}
