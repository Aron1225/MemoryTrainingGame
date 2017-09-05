using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
	public UIButton[] Game;

	void Awake ()
	{
		ButtonEvent ();
	}

	void Start ()
	{
		
	}

	private void ButtonEvent ()
	{
		Game [0].onClick.Add (new EventDelegate (() => SceneManager.LoadScene(1)));
		Game [1].onClick.Add (new EventDelegate (() => SceneManager.LoadScene(7)));
	}
	

}
