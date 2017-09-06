using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level2_Menu : MonoBehaviour
{
	//public..................................

	//主選單
	public GameObject LevelSelect;
	//進度畫面
	public GameObject Loading;
	//進度條
	public MaterialUI.sliderSetting progressBar;
	//回到主頁面
	public UIButton BackMainHome;
	//遊戲玩法
	public UIButton[] Button_Level;

	//private..................................

	private WaitForEndOfFrame waitforendOfframe;


	void Awake ()
	{
		init ();
		ButtonEvent ();
	}

	void Start ()
	{
		
	}

	void Update ()
	{
		
	}

	void init ()
	{
		waitforendOfframe = new WaitForEndOfFrame ();	
	}

	void ButtonEvent ()
	{
		BackMainHome.onClick.Add (new EventDelegate (() => SceneManager.LoadScene (0)));
		Button_Level [0].onClick.Add (new EventDelegate (() => StartCoroutine (DisplayLoadingScreen (8))));
		Button_Level [1].onClick.Add (new EventDelegate (() => StartCoroutine (DisplayLoadingScreen (9))));
		Button_Level [2].onClick.Add (new EventDelegate (() => StartCoroutine (DisplayLoadingScreen (10))));
		Button_Level [3].onClick.Add (new EventDelegate (() => StartCoroutine (DisplayLoadingScreen (11))));
	}

	//顯示Loading進度、跳轉Scene
	IEnumerator DisplayLoadingScreen (int SceneNumber)
	{
		LevelSelect.SetActive (false);
		Loading.SetActive (true);

		progressBar.LoadingAnimStart ();

		yield return new WaitForSeconds (0.5f);

		AsyncOperation LoadScene = SceneManager.LoadSceneAsync (SceneNumber);
		//載入完後先不跳轉Scene
		LoadScene.allowSceneActivation = false;

		float Progress = 0;

		float displayProgress = 0;

		while (LoadScene.progress < 0.9f) {
			Progress = LoadScene.progress;
			while (displayProgress < Progress) {
				progressBar.slider.value = (displayProgress += 0.01f) * 100;
				yield return waitforendOfframe;
			}
		}

		Progress = 1f;

		while (displayProgress < Progress) {
			progressBar.slider.value = (displayProgress += 0.01f) * 100;
			yield return waitforendOfframe;
		}

		progressBar.LoadingAnimFinished ();

		yield return new WaitForSeconds (0.4f);

		Resources.UnloadUnusedAssets ();//讓Unity 自行去卸載掉不使用的資源

		//跳轉Scene
		LoadScene.allowSceneActivation = true;
	}
}
