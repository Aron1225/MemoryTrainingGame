using UnityEngine;
using UnityEditor;

public class Level2_DB_Editor : MonoBehaviour
{
	[CustomEditor (typeof(Level2_DB))]
	public class Level2_Select_Editor : Editor
	{
		public override void OnInspectorGUI ()
		{
			Level2_DB DB = target as Level2_DB;

			GUILayout.Space (15);

			//只有數值變化時執行
			if (GUI.changed) {
				Debug.Log ("value change");
			}

//			EditorGUILayout.BeginHorizontal ();
//			GUILayout.Label ("排列圖", GUILayout.Width (40));
//
//			DB.index = EditorGUILayout.IntField (DB.index);
//
//			if (GUILayout.Button ("Re", GUILayout.Width (30))) {
//				DB.index = 0;
//			}
//
//			if (GUILayout.Button ("+", GUILayout.Width (30))) {
//				DB.index++;///要設計最大不可超過值
//			}
//			if (GUILayout.Button ("-", GUILayout.Width (30))) {
//				if (DB.index > 0) {
//					DB.index--;
//				}
//			}
//
//			EditorGUILayout.EndHorizontal ();

			EditorGUILayout.BeginHorizontal ();

			GUILayout.Label ("隨機數", GUILayout.Width (40));

			DB.random = EditorGUILayout.IntField (DB.random);

			if (GUILayout.Button ("Re", GUILayout.Width (30))) {
				DB.random = 0;
			}

			if (GUILayout.Button ("+", GUILayout.Width (30))) {
				DB.random++;///要設計最大不可超過值
			}
			if (GUILayout.Button ("-", GUILayout.Width (30))) {
				if (DB.random > 3) {
					DB.random--;
				}
			}

			EditorGUILayout.EndHorizontal ();

			EditorGUILayout.BeginHorizontal ();
			{
				GUILayout.Label ("LightTime", GUILayout.Width (60));

				DB.lighttime = EditorGUILayout.FloatField (DB.lighttime);

				if (GUILayout.Button ("+", GUILayout.Width (30))) {
					DB.lighttime += 0.5f;///要設計最大不可超過值
				}
				if (GUILayout.Button ("-", GUILayout.Width (30))) {
					if (DB.lighttime > 0) {
						DB.lighttime -= 0.5f;
					}
				}
			}
			EditorGUILayout.EndHorizontal ();

			EditorGUILayout.BeginHorizontal ();
			{
				GUILayout.Label ("DarkTime", GUILayout.Width (60));

				DB.darktime = EditorGUILayout.FloatField (DB.darktime);

				if (GUILayout.Button ("+", GUILayout.Width (30))) {
					DB.darktime += 0.5f;///要設計最大不可超過值
				}
				if (GUILayout.Button ("-", GUILayout.Width (30))) {
					if (DB.darktime > 0) {
						DB.darktime -= 0.5f;
					}
				}
			}
			EditorGUILayout.EndHorizontal ();

			EditorGUILayout.BeginHorizontal ();
			{
				DB.Main_Cylinder = (GameObject)EditorGUILayout.ObjectField ("Main_Cylinder", DB.Main_Cylinder, typeof(GameObject), true);
			}
			EditorGUILayout.EndHorizontal ();

			EditorGUILayout.BeginHorizontal ();
			{
				serializedObject.Update ();
				EditorGUILayout.PropertyField (serializedObject.FindProperty ("Cups"), true);//true顯示陣列內容
				serializedObject.ApplyModifiedProperties ();//不加就不能動陣列
			}
			EditorGUILayout.EndHorizontal ();

			//顯示預設檢視面板屬性編輯器
//			DrawDefaultInspector ();
		}
	}
}
