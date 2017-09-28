using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public abstract class Menu : G_U_I
{
	//public field...........................

	//主選單
	public GameObject LevelSelect;

	//進度畫面
	public GameObject Loading;

	//進度條
	public MaterialUI.ProgressBar progressBar;

	//按鈕欄位
	public UIButton[] Button_Level;

	//protected field...........................

	//WaitForEndOfFrame快取
	protected WaitForEndOfFrame waitforendOfframe;


	//抽象方法 按鈕事件
	public abstract void ButtonEvent ();


	protected void init ()
	{
		waitforendOfframe = new WaitForEndOfFrame ();	
	}

	//顯示Loading進度、跳轉Scene
	protected virtual IEnumerator DisplayLoadingScreen (int SceneNumber)
	{
		//隱藏選擇關卡
		LevelSelect.SetActive (false);
		//顯示Loading畫面
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

		//Resources.UnloadUnusedAssets ();//讓Unity 自行去卸載掉不使用的資源

		//跳轉Scene
		LoadScene.allowSceneActivation = true;
	}
}
