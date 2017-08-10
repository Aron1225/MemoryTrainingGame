using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Level2_Menu_start : MonoBehaviour {

	[SerializeField]private GameObject obj;

	void Start () {
		UIEventListener.Get (obj).onClick = game;
	}

	void game(GameObject obj){
		//Application.LoadLevel("1");
		SceneManager.LoadScene ("Level2");
	}
}
