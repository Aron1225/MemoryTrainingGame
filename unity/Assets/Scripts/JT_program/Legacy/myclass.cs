using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class myclass : MonoBehaviour
{
//	[SerializeField]private List<GameObject> Cylinder = new List<GameObject> ();
//	GameObject abc;
//
//	string Name;
//	float Height;
//	float Weight;
//	int i;
//
//	[CustomEditor (typeof(myclass))]
//	public class myclassEditor : Editor
//	{
//		private bool disabled;
//		private bool disabled2;
//
//
//		public override void OnInspectorGUI ()
//		{
//			myclass my = target as myclass;
//
//			disabled = EditorGUILayout.Toggle ("禁止", disabled);
//			disabled2 = EditorGUILayout.Toggle ("禁止", disabled2);
//
//			my.abc = (GameObject)EditorGUILayout.ObjectField ("物件", my.abc, typeof(GameObject), true);
//
//
//			EditorGUI.BeginDisabledGroup (disabled);//禁止使用開始
//
//			my.Name = EditorGUILayout.TextField (new GUIContent ("名字", "請輸入名字"), my.Name);
//			my.Height = EditorGUILayout.FloatField ("高度", my.Height);
//			my.Weight = EditorGUILayout.FloatField ("重量", my.Weight);
//
//			EditorGUI.EndDisabledGroup ();//禁止使用結束
//
//			if (disabled2)//true時顯示
//				my.i = EditorGUILayout.IntSlider ("I field:", my.i, 1, 100);
//
//
////			DrawDefaultInspector ();
//
//			/**
//			 * EditorGUIUtility.LookLikeControls();
//			 * 這將使默認樣式使用與EditorGUI，看起來像是檢視面板。
//			 * (檢視功能)
//			 * 
//			 * EditorGUIUtility.LookLikeInspector();
//			 * 這將使默認樣式使用於EditorGUI看起來像控件（例如EditorGUI.Popup成為一個完整的彈出菜單）
//			 * (設定功能)
//			 * 
//			 * 
//			 * EditorGUI.BeginChangeCheck();
//			 * BeginChangeCheck() 用來檢查在 BeginChangeCheck() 和 EndChangeCheck() 之間是否有 Inspector 變數改變
//			 * 
//			 * 如果 Inspector 變數有改變，EndChangeCheck() 會回傳 True，才有必要去做變數存取
//			 * if (EditorGUI.EndChangeCheck()){
//			 * 
//			 *   DoSome... 
//			 * 
//			 * }
//			 * 
//			 * 
//			 * // show the default inspector so we can set some values
//			 * DrawDefaultInspector ();
//			 * DrawDefaultInspector() 會將原本 Inspector 上有的東西先畫出來。
//			 * 這麼一來可能會造成 Inspector 中的 Types 欄位被畫兩次(Default一次，下面 Editor Script 又會在畫一次)
//		   	 * 因此，你可以在原先 public List<BrickType> Types 的欄位前加入 [HideInInspector]，把 Default Inspector 關掉 
//			 * */
//
//
//			//		EditorGUILayout.LabelField("Custom editor:");
//			//		var serializedObject = new SerializedObject(target);
//			//		var property = serializedObject.FindProperty("list");
//			//		serializedObject.Update();
//			//		EditorGUILayout.PropertyField(property, true);
//			//		serializedObject.ApplyModifiedProperties();
//
//
//		}
//	}
}