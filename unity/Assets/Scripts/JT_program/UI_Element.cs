using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Element : MonoBehaviour
{
	//公佈欄
	public GameObject Billboard;
	//連續錯誤返回
	public GameObject Wrong;
	//閒置
	public GameObject TimeOut;
	//UI物件
	public GameObject Object;

	public GameObject Select_Level;

	public GameObject Slider_Level;

	public GameObject GameObject_Bingo;

	public GameObject GameObject_Error;

	public UILabel label_Bingo;

	public UILabel label_Error;

	public UILabel label_Time;

	public UILabel Label_Level;

	public UISlider slider_level;

	public UISlider slider_percent;

	public UIButton Button_UP;

	public UIButton Button_DOWN;

	public UIButton Button_CONFIRM;

	public UIButton Button_BackHome;

	public UIButton Button_TimeOutBackHome;

	public UIButton Button_Menu;

	public UIButton Button_NextLevel;

	public UIButton Button_BackLevel;

	public UIButton Button_Again;
}
