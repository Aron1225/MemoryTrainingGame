using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1_GUI : G_U_I
{
	void Awake ()
	{
		base.DB = GetComponent<Level1_DB> ();
		base.UI = GetComponent<UI_Element> ();
	}

	//遊戲開始
	public void GameStart ()
	{
		Level.GameStart ();
	}

	public void LevelMenu (GameObject go)
	{
		if (go == UI.Button_Menu.gameObject)
			Level.LevelMenu ();
		else
			Level.LevelMenu ("GA");
	}

	//回到主畫面
	public void BackHome ()
	{
		Level.BackHome ();
	}

	public void Again (GameObject go)
	{
		if (go == UI.Button_Again.gameObject)
			Level.Again ();
		else
			Level.Again ("GA");
	}

	public void Next ()
	{
		DB.Select_Level_number = Mathf.Clamp (DB.Select_Level_number + 1, 1, 10);
		Updated ();
		Level.Next ();
	}

	public void Back ()
	{
		DB.Select_Level_number = Mathf.Clamp (DB.Select_Level_number - 1, 1, 10);
		Updated ();
		Level.Back ();
	}

	//選擇難易度
	public void Select_Level (GameObject btn)
	{
		_Select_Level (btn);
	}
}
