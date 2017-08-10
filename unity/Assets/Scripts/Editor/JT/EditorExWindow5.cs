using UnityEngine;
using UnityEditor;
using System.Collections;

public class EditorExWindow5 : EditorWindow {

	[MenuItem ("Window/EditorEx5")]
	static void Open ()
	{
		EditorWindow.GetWindow<EditorExWindow5> ("EditorEx5");
	}
	int leftSize = 10;
	Vector2 leftScrollPos = Vector2.zero;
	int rightSize = 10;
	Vector2 rightScrollPos = Vector2.zero;

	void OnGUI()
	{
		EditorGUILayout.LabelField( "ようこそ！　Unityエディタ拡張の沼へ！" ); // いつまでも居座り続けるぜ！

		EditorGUILayout.BeginHorizontal( GUI.skin.box );

		EditorGUILayout.BeginVertical( GUI.skin.box,GUILayout.Width ( 300 ) );
		EditorGUILayout.LabelField( "左側" );

		leftSize = EditorGUILayout.IntSlider ( "Size",leftSize,10,100,GUILayout.ExpandWidth(false) );

		// 左側のスクロールビュー(横幅300px)
		leftScrollPos = EditorGUILayout.BeginScrollView( leftScrollPos,GUI.skin.box );
		{
			// スクロール範囲

			for( int i=0;i<leftSize;i++ )
			{
				EditorGUILayout.LabelField( "Index " + i );
			}
		}
		EditorGUILayout.EndScrollView();

		EditorGUILayout.EndVertical();

		EditorGUILayout.BeginVertical( GUI.skin.box );

		EditorGUILayout.LabelField( "右側" );

		rightSize = EditorGUILayout.IntSlider ( "Size",rightSize,10,100,GUILayout.ExpandWidth(false) );

		// 右側のスクロール
		rightScrollPos = EditorGUILayout.BeginScrollView( rightScrollPos,GUI.skin.box );
		{
			// スクロール範囲

			for( int y = 0;y<rightSize;y++ )
			{
				EditorGUILayout.BeginHorizontal( GUI.skin.box );
				{
					// ここの範囲は横並び

					EditorGUILayout.PrefixLabel( "Index " + y );

					// 下に行くほどボタン数増やす
					for( int i=0;i<y+1;i++ )
					{
						// ボタン(横幅100px)
						if( GUILayout.Button("Button"+i,GUILayout.Width(100) ) )
						{
							Debug.Log( "Button"+i+"押したよ" );
						}
					}
				}
				EditorGUILayout.EndHorizontal();
			}
			// こんな感じで横幅固定しなくても、範囲からはみ出すときにスクロールバー出してくれる。
		}
		EditorGUILayout.EndScrollView();

		EditorGUILayout.EndVertical();

		EditorGUILayout.EndHorizontal();
	}
}
