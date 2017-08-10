using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Level3_Cylinder_rotation : MonoBehaviour
{



	[Header ("Status")]
	//Main_Cylinder旋轉速度
	public float Main_Cylinder_speed;

	//Anchor選轉速度
	public float Anchor_speed;


	[Header ("Object")]
	//Cylinder選轉臂
	[SerializeField]private List<GameObject> Cylinder = new List<GameObject> ();

	//Cylinder選轉軸
	[SerializeField]private List<GameObject> Anchor = new List<GameObject> ();



	JointMotor myJointMotor;



//	[CustomEditor (typeof(Level3_Cylinder_rotation))]
//	public class Level3_Cylinder_rotation_Editor : Editor
//	{
//		private bool Cylinder_enable = true;
//		private bool Anchor_enable = true;
//
//		public override void OnInspectorGUI ()
//		{
//			Level3_Cylinder_rotation edit = target as Level3_Cylinder_rotation;
//
//			EditorGUILayout.LabelField ("Status", EditorStyles.boldLabel);//顯示粗體"Status"
//
//			Cylinder_enable = EditorGUILayout.ToggleLeft ("Enable", Cylinder_enable);//左邊核取方塊
//
//			EditorGUI.BeginDisabledGroup (!Cylinder_enable);//禁止使用開始
//
//			edit.Main_Cylinder_speed = EditorGUILayout.Slider ("Main_Cylinder_speed", edit.Main_Cylinder_speed, 1, 10);//速度調整
//
//			EditorGUI.EndDisabledGroup ();//禁止使用結束
//
//
//			Anchor_enable = EditorGUILayout.ToggleLeft ("Enable", Anchor_enable);//左邊核取方塊
//
//			EditorGUI.BeginDisabledGroup (!Anchor_enable);//禁止使用開始
//
//			edit.Anchor_speed= EditorGUILayout.Slider ("Anchor_speed", edit.Anchor_speed, 1, 10);//速度調整
//
//			EditorGUI.EndDisabledGroup ();//禁止使用結束
//
//
//			//關閉後數值歸零
//			if (!Cylinder_enable)
//				edit.Main_Cylinder_speed = 0;
//			
//			if (!Anchor_enable)
//				edit.Anchor_speed = 0;
//			
//
//			SerializedProperty Cylinder = serializedObject.FindProperty ("Cylinder");
//
//			EditorGUILayout.PropertyField (Cylinder, true);
//
//			SerializedProperty Anchor = serializedObject.FindProperty ("Anchor");
//
//			EditorGUILayout.PropertyField (Anchor, true);
//
//			//DrawDefaultInspector ();// show the default inspector so we can set some values
//
//		}
//
//
//	}



	void Start ()
	{

	}


	void Update ()
	{
		gameObject.transform.Rotate (Vector3.up, -Time.deltaTime * Main_Cylinder_speed * 10);

		Anchor.ForEach (i => i.transform.Rotate (Vector3.up, -Time.deltaTime * Anchor_speed * 10));

		myJointMotor.targetVelocity = Mathf.Lerp (0, 120, Main_Cylinder_speed / 10);

		myJointMotor.force = Mathf.Lerp (0, 120, Main_Cylinder_speed / 10);

		Cylinder.ForEach (i => i.GetComponent<HingeJoint> ().motor = myJointMotor);
	}





}
