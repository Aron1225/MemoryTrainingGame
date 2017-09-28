using UnityEngine;
using System.Linq;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class Level1_Menu : Menu
{
	//public..................................

	public UIButton BackMainHome;


	void Awake ()
	{
		init ();
		ButtonEvent ();
	}

	public override void ButtonEvent ()
	{
		BackMainHome.onClick.Add (new EventDelegate (() => SceneManager.LoadSceneAsync (0)));
		Button_Level [0].onClick.Add (new EventDelegate (() => StartCoroutine (DisplayLoadingScreen (2))));
		Button_Level [1].onClick.Add (new EventDelegate (() => StartCoroutine (DisplayLoadingScreen (3))));
		Button_Level [2].onClick.Add (new EventDelegate (() => StartCoroutine (DisplayLoadingScreen (4))));
		Button_Level [3].onClick.Add (new EventDelegate (() => StartCoroutine (DisplayLoadingScreen (5))));
		Button_Level [4].onClick.Add (new EventDelegate (() => StartCoroutine (DisplayLoadingScreen (6))));
	}
}
