using UnityEngine;
using System.Linq;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class Level1_Menu : MonoBehaviour
{
	#region Parameter...

	public static int level = -1;

	public GameObject Menu;
	public GameObject Loading;

	private GameObject currentGameObject;
	private GameObject[] Button_Level;
	public MaterialUI.sliderSetting progressBar;
	public UIButton music;
	private WaitForEndOfFrame waitforendOfframe = new WaitForEndOfFrame ();

	//	private UICenterOnChild center;
	//	public List<BackGroundSprite> MenuBackGround = new List<BackGroundSprite> ();
	//	private UISprite BackGround;

	#endregion

	public enum SwitchState
	{
		On,
		Off
	}

	private SwitchState _state = SwitchState.On;

	public SwitchState state {
		get{ return _state; }
		set { _state = value; }
	}

	[System.Serializable]
	public class BackGroundSprite
	{
		public string sprite;
	}

	void Start ()
	{
		Initialization ();

		EventListener ();
	}

	void Update ()
	{
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
	////		BackGround.spriteName = "Blank";
	//	}


	void Initialization ()
	{
		int count = Menu.transform.Find ("LevelSelect/Scroll View/ScrollViewGrid").transform.childCount;
		Button_Level = new GameObject[count];

//		music = Menu.transform.Find ("MainStart/Music").GetComponent<UIButton> ();
//		progressBar = Loading.transform.Find ("ProgressBar").GetComponent<UISlider> ();
//		center = Menu.transform.Find ("LevelSelect/Scroll View/ScrollViewGrid").GetComponent<UICenterOnChild> ();

		for (int i = 1; i <= count; i++)
			Button_Level [i - 1] = Menu.transform.Find ("LevelSelect/Scroll View/ScrollViewGrid/Level" + i + "/Button_Level" + i).gameObject;
	}

	void EventListener ()
	{
		UIEventListener.Get (Button_Level [0]).onClick = (GameObject go) => StartCoroutine (DisplayLoadingScreen (1));
		UIEventListener.Get (Button_Level [1]).onClick = (GameObject go) => StartCoroutine (DisplayLoadingScreen (2));
		UIEventListener.Get (Button_Level [2]).onClick = (GameObject go) => StartCoroutine (DisplayLoadingScreen (3));
		UIEventListener.Get (Button_Level [3]).onClick = (GameObject go) => StartCoroutine (DisplayLoadingScreen (4));
		UIEventListener.Get (Button_Level [4]).onClick = (GameObject go) => StartCoroutine (DisplayLoadingScreen (5));
		UIEventListener.Get (Button_Level [5]).onClick = (GameObject go) => StartCoroutine (DisplayLoadingScreen (6));


		UIEventListener.Get (music.transform.gameObject).onClick = (GameObject go) => {

			state = state == SwitchState.On ? SwitchState.Off : SwitchState.On;

			switch (state) {
			case SwitchState.On:
				music.normalSprite = "Music_On";
				break;
			case SwitchState.Off:
				music.normalSprite = "Music_Off";
				break;
			}
		};
	}

	//顯示Loading進度、跳轉Scene
	IEnumerator DisplayLoadingScreen (int SceneNumber)
	{
		Menu.SetActive (false);
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
//				SetProgressBar (displayProgress += 0.01f);
				yield return new WaitForEndOfFrame ();
			}
		}

		Progress = 1f;

		while (displayProgress < Progress) {
			progressBar.slider.value = (displayProgress += 0.01f) * 100;
//			SetProgressBar (displayProgress += 0.01f);
			yield return waitforendOfframe;
		}

		progressBar.LoadingAnimFinished ();

		yield return new WaitForSeconds (0.4f);

		//跳轉Scene
		LoadScene.allowSceneActivation = true;
	}
	//	void SetProgressBar (float Value)
	//	{
	//		if (progressBar) {
	//			progressBar.value = Value;
	//			return;
	//		}
	//		Debug.LogError ("progressBar is not found");
	//	}
}
