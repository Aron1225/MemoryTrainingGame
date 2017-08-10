using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Level1_Select : MonoBehaviour
{
//	public int popup;
//
//	public  int radio = 0;
//
//	public int item = 5;
//
//	public static int _item;
//
//	public  float[] floatFieldLeft;
//
//	public  static List<float> _floatFieldLeft = new List<float> ();
//
//
//	public  float[] floatFieldRight;
//
//	public  static List<float> _floatFieldRight = new List<float> ();
//
//
//	public  int arrangement_index;
//
//	public static int _arrangement_index;
//
//
//
//
//	void swap (float small, float big, string Key)
//	{
//		if (Key == "L") {
//			floatFieldLeft [0] = big;
//			floatFieldLeft [item - 1] = small;
//		}
//
//
//		if (Key == "R") {
//			floatFieldRight [0] = big;
//			floatFieldRight [item - 1] = small;
//		}
//	}
//
//	[CustomEditor (typeof(Level1_Select))]
//	public class Level1_Select_Editor : Editor
//	{
//		public override void OnInspectorGUI ()
//		{
//
//			Level1_Select edit = target as Level1_Select;
//
//			GUILayout.Space (10);
//
//			EditorGUILayout.BeginHorizontal ();
//
////			edit.radio = GUILayout.SelectionGrid (edit.radio, new string[]{ "Easy", "Normal", "Hard" }, 3, EditorStyles.boldLabel);
//			edit.radio = GUILayout.Toolbar (edit.radio, new string[]{ "Easy", "Normal", "Hard" });
//
//
//			EditorGUILayout.EndHorizontal ();
//
//			GUILayout.Space (15);
//
//			if (edit.radio == 2) {
//
//
//				edit.popup = EditorGUILayout.Popup (edit.popup, new string[]{ "固定", "旋轉", "隨機移動" });
////				EditorGUILayout.LabelField( "模式 = " , edit.popup.ToString() );
//		
//			}
//
//			EditorGUILayout.BeginHorizontal ();
//
//
//			GUILayout.Label ("排列圖", GUILayout.Width (40));
//		
//			edit.arrangement_index = EditorGUILayout.IntField (edit.arrangement_index);
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
//
////			GUILayout.Space (15);
////
////			EditorGUILayout.BeginHorizontal ();
////			if (GUILayout.Button ("X", GUILayout.Width (30))) {
////				edit.item = 0;
////			}
////			GUILayout.Space (50);
////			GUILayout.Label ("亮燈時間");
////			GUILayout.Space (10);
////			GUILayout.Label ("間隔");
//
////			EditorGUILayout.EndHorizontal ();
////
////
////			for (int i = 0; i < edit.item; i++) {
////				
////				EditorGUILayout.BeginHorizontal ();
////
////				if (GUILayout.Button ("Re", GUILayout.Width (30), GUILayout.Height (20))) {
////					
////					edit.floatFieldLeft [i] = 0;
////
////					edit.floatFieldRight [i] = 0;
////				}
////				GUILayout.Label (i + ":");
////
////
////				edit.floatFieldLeft [i] = EditorGUILayout.FloatField (edit.floatFieldLeft [i]);
////
////				edit.floatFieldRight [i] = EditorGUILayout.FloatField (edit.floatFieldRight [i]);
////
////				EditorGUILayout.EndHorizontal ();
////			}
////
////			EditorGUILayout.BeginHorizontal ();
////
////
////			if (GUILayout.Button ("+", GUILayout.Width (23)))
////				edit.item++;
////
////			if (GUILayout.Button ("-", GUILayout.Width (23)))
////				edit.item--;
////
////
////
////
////		
////			if (GUILayout.Button ("分配")) {
////				//edit.floatFieldLeft.GetUpperBound(0) = edit.floatFieldLeft.Length-1
////				if (edit.floatFieldLeft [0] < edit.floatFieldLeft [edit.item - 1]) {
////					edit.swap (edit.floatFieldLeft [0], edit.floatFieldLeft [edit.item - 1], "L");
////				}
////
////				float d = (edit.floatFieldLeft [0] - edit.floatFieldLeft [edit.item - 1]) / (edit.item - 1);
////				for (int i = 0; i < edit.item - 1; i++) {
////					edit.floatFieldLeft [i] = edit.floatFieldLeft [0] - i * d;
////				}
////			}
////
////			if (GUILayout.Button ("分配")) {
////				if (edit.floatFieldRight [0] < edit.floatFieldRight [edit.item - 1]) {
////					edit.swap (edit.floatFieldRight [0], edit.floatFieldRight [edit.item - 1], "R");
////				}
////
////				float d = (edit.floatFieldRight [0] - edit.floatFieldRight [edit.item - 1]) / (edit.item - 1);
////				for (int i = 0; i < edit.item - 1; i++) {
////					edit.floatFieldRight [i] = edit.floatFieldRight [0] - i * d;
////				}
////			}
////
////			EditorGUILayout.EndHorizontal ();
//
//
//		}
//	}
//
//	void Start ()
//	{
//
//		//選擇掛載難度
//		switch (radio) {
//		case 0:
//			gameObject.AddComponent<Level1_Easy> ();
//			break;
//		case 1:
//			gameObject.AddComponent<Level1_Normal> ();
//			break;
//		case 2:
////			StartCoroutine (a.GameStart ());
////			gameObject.AddComponent<Level1_Display_Hard> ();
//			gameObject.AddComponent<Level1_Hard> ();
//			break;
//		}
//
//
//		_item = item;
//
//		//將floatFieldLeft複製到_floatFieldLeft
//		_floatFieldLeft.AddRange (floatFieldLeft);
//	
//		//將ffloatFieldRight複製到_floatFieldRight
//		_floatFieldRight.AddRange (floatFieldRight);
//
//		_arrangement_index = arrangement_index;
//
//
//	}
//
//
//
//	void Update ()
//	{
//		_arrangement_index = arrangement_index;
//
////		if (Level1_Display_Hard_old(old).s_bNextLevel ) {
//			arrangement_index++;
////			Level1_Easy.s_bNextLevel = false;
////			Level1_Normal.s_bNextLevel = false;
////			Level1_Display_Hard_old(old).s_bNextLevel = false;
////			Level1_Game.s_bNextLevel = false;
//		}
////	}

}