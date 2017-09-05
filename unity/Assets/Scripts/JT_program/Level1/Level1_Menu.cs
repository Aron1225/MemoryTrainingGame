using UnityEngine;
using System.Linq;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class Level1_Menu : MonoBehaviour
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

	void Start ()
	{
		init ();
		ButtonEvent ();
	}

	void init ()
	{
		waitforendOfframe = new WaitForEndOfFrame ();
	}

	void ButtonEvent ()
	{
		BackMainHome.onClick.Add (new EventDelegate (() => SceneManager.LoadScene (0)));
		Button_Level [0].onClick.Add (new EventDelegate (() => StartCoroutine (DisplayLoadingScreen (2))));
		Button_Level [1].onClick.Add (new EventDelegate (() => StartCoroutine (DisplayLoadingScreen (3))));
		Button_Level [2].onClick.Add (new EventDelegate (() => StartCoroutine (DisplayLoadingScreen (4))));
		Button_Level [3].onClick.Add (new EventDelegate (() => StartCoroutine (DisplayLoadingScreen (5))));
		Button_Level [4].onClick.Add (new EventDelegate (() => StartCoroutine (DisplayLoadingScreen (6))));
//		UIEventListener.Get (music.transform.gameObject).onClick = (GameObject go) => {
//
//			state = state == SwitchState.On ? SwitchState.Off : SwitchState.On;
//
//			switch (state) {
//			case SwitchState.On:
//				music.normalSprite = "Music_On";
//				break;
//			case SwitchState.Off:
//				music.normalSprite = "Music_Off";
//				break;
//			}
//		};
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
				yield return new WaitForEndOfFrame ();
			}
		}

		Progress = 1f;

		while (displayProgress < Progress) {
			progressBar.slider.value = (displayProgress += 0.01f) * 100;
			yield return waitforendOfframe;
		}

		progressBar.LoadingAnimFinished ();

		yield return new WaitForSeconds (0.4f);

		//跳轉Scene
		LoadScene.allowSceneActivation = true;
	}

	//	public void SetBackGround ()
	//	{
	//		switch (center.centeredObject.name) {
	//
	//		case "EasyBlock":
	//			BackGround.spriteName = MenuBackGround [0].sprite;
	//			break;
	//
	//		case "NormalBlock":
	//			BackGround.spriteName = MenuBackGround [1].sprite;
	//			break;
	//
	//		case "HardBlock":
	//			BackGround.spriteName = MenuBackGround [2].sprite;
	//			break;
	//
	//		}
	//	}
	//	public void ReSetBackGround ()
	//	{
	//		BackGround.spriteName = "Blank";
	//	}
	//	void SetProgressBar (float Value)
	//	{
	//		if (progressBar) {
	//			progressBar.value = Value;
	//			return;
	//		}
	//		Debug.LogError ("progressBar is not found");
	//	}
	//	#region Parameter...
	//
	//	public GameObject Menu;
	//	public GameObject Loading;
	//	public MaterialUI.sliderSetting progressBar;
	//	public UIButton music;
	//
	//	private GameObject currentGameObject;
	//	private GameObject[] Button_Level;
	//	private WaitForEndOfFrame waitforendOfframe = new WaitForEndOfFrame ();
	//
	//	//	private UICenterOnChild center;
	//	//	public List<BackGroundSprite> MenuBackGround = new List<BackGroundSprite> ();
	//	//	private UISprite BackGround;
	//
	//	#endregion
	//	[System.Serializable]
	//	public class BackGroundSprite
	//	{
	//		public string sprite;
	//	}
	//	public enum SwitchState
	//	{
	//		On,
	//		Off
	//	}
	//
	//	private SwitchState _state = SwitchState.On;
	//
	//	public SwitchState state {
	//		get{ return _state; }
	//		set { _state = value; }
	//	}
}
