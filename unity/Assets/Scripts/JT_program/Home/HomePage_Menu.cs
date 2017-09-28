using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class HomePage_Menu : Menu
{
	void Awake ()
	{
		init ();
		ButtonEvent ();
	}

	public override void ButtonEvent ()
	{
		Button_Level [0].onClick.Add (new EventDelegate (() => StartCoroutine (DisplayLoadingScreen (1))));
		Button_Level [1].onClick.Add (new EventDelegate (() => StartCoroutine (DisplayLoadingScreen (7))));
	}

	protected override IEnumerator DisplayLoadingScreen (int SceneNumber)
	{
		//隱藏選擇關卡
		LevelSelect.SetActive (false);
		//顯示Loading畫面
		Loading.SetActive (true);

		yield return new WaitForSeconds (0.5f);

		AsyncOperation LoadScene = SceneManager.LoadSceneAsync (SceneNumber);
		//載入完後先不跳轉Scene
		LoadScene.allowSceneActivation = false;

		float Progress = 0;

		float displayProgress = 0;

		while (LoadScene.progress < 0.9f) {
			Progress = LoadScene.progress;
			while (displayProgress < Progress) {
				displayProgress += 0.01f;
				yield return waitforendOfframe;
			}
		}

		Progress = 1f;

		while (displayProgress < Progress) {
			displayProgress += 0.01f;
			yield return waitforendOfframe;
		}

		yield return new WaitForSeconds (0.4f);

//		Resources.UnloadUnusedAssets ();//讓Unity 自行去卸載掉不使用的資源

		//跳轉Scene
		LoadScene.allowSceneActivation = true;
	}
}
