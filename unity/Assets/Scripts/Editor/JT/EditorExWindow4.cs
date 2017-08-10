using UnityEngine;
using UnityEditor;
using System.Collections;

public class EditorExWindow4 : EditorWindow {

	[MenuItem ("Window/EditorEx4")]
	static void Open ()
	{
		EditorWindow.GetWindow<EditorExWindow4> ("EditorEx4");
	}
	Vector2 buttonSize = new Vector2( 100,20 );

	Vector2 buttonMinSize = new Vector2( 100,20 );
	Vector2 buttonMaxSize = new Vector2( 1000,200 );

	bool expandWidth = true;
	bool expandHeight = true;

	void OnGUI()
	{
		EditorGUILayout.LabelField( "ようこそ！　Unityエディタ拡張の沼へ！" ); // いつまでも居座り続けるぜ！

		// 直接サイズを指定する場合は、
		// GUILayout.Width/Heightを使う。
		buttonSize = EditorGUILayout.Vector2Field( "ButtonSize",buttonSize );

		if( GUILayout.Button ( "サイズ指定ボタン",GUILayout.Width( buttonSize.x ),GUILayout.Height( buttonSize.y ) ) )
		{
			Debug.Log ( "サイズ指定ボタン" );
		}

		// 自動的にサイズ変更される範囲を指定する場合は
		// GUILayout.MinWidth/MaxWidth/MinHeight/MaxHeightを使う。
		buttonMinSize = EditorGUILayout.Vector2Field( "ButtonMinSize",buttonMinSize );
		buttonMaxSize = EditorGUILayout.Vector2Field( "ButtonMaxSize",buttonMaxSize );


		if( GUILayout.Button ( "最小最大指定ボタン",
			GUILayout.MinWidth( buttonMinSize.x ),GUILayout.MinHeight( buttonMinSize.y ),
			GUILayout.MaxWidth( buttonMaxSize.x ),GUILayout.MaxHeight( buttonMaxSize.y ) ) )
		{
			Debug.Log ( "最小最大指定ボタン" );
		}

		// 有効範囲内全体に広げるかどうかは
		// GUILayout.ExpandWidth/ExpandHeightで指定する。
		expandWidth = EditorGUILayout.Toggle( "ExpandWidth",expandWidth );
		expandHeight = EditorGUILayout.Toggle( "ExpandHeight",expandHeight );
		if( GUILayout.Button ( "Expandボタン",GUILayout.ExpandWidth( expandWidth ),GUILayout.ExpandHeight( expandHeight ) ) )
		{
			Debug.Log ( "Expandボタン" );
		}
	}
}
