using UnityEngine;
using UnityEditor;
using System.Collections;

public class EditorExWindow3 : EditorWindow
{

	[MenuItem ("Window/EditorEx3")]
	static void Open ()
	{
		EditorWindow.GetWindow<EditorExWindow3> ("EditorEx3");
	}
	void OnGUI()
	{
		// 基本的には縦並び

		EditorGUILayout.LabelField( "ようこそ！　Unityエディタ拡張の沼へ！" ); // いつまでも居座り続けるぜ！

		// 見た目わかりやすくするため、Boxで囲う。
		// GUIStyleについては別途解説します。
		// 何も指定しなければ背景が変わりません。
		EditorGUILayout.BeginHorizontal( GUI.skin.box );
		{
			// ここの範囲は横並び

			// わかりやすくするために{}で囲ってます。
			// 実際は不要で、このスコープは並びに対して何も機能的効果を持っていません。

			EditorGUILayout.BeginVertical( GUI.skin.box );
			{
				// ここの範囲は縦並び

				EditorGUILayout.LabelField( "左側" );
				EditorGUILayout.LabelField( "Labelとか","いろいろ置いたり。" );
				if( GUILayout.Button( "Buttonとか" ) )
				{
					Debug.Log( "Buttonとか押したよ" );
				}
			}
			EditorGUILayout.EndVertical();

			EditorGUILayout.BeginVertical( GUI.skin.box );
			{
				// ここの範囲は縦並び

				EditorGUILayout.LabelField( "右側" );

				EditorGUILayout.BeginHorizontal( GUI.skin.box );
				{
					// ここの範囲は横並び

					EditorGUILayout.PrefixLabel( "一列に並べる" );

					if( GUILayout.Button("Button1" ) )
					{
						Debug.Log( "Button1押したよ" );
					}

					if( GUILayout.Button("Button2" ) )
					{
						Debug.Log( "Button2押したよ" );
					}

					if( GUILayout.Button("Button3" ) )
					{
						Debug.Log( "Button3押したよ" );
					}
				}
				EditorGUILayout.EndHorizontal();
			}
			EditorGUILayout.EndVertical();
		}
		EditorGUILayout.EndHorizontal();
	}
}
