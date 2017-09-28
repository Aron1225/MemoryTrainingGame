using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level2_Menu : Menu
{
	//public..................................

	public GameObject Window_AskUseBrainWave;

	//藍芽檢查
	public GameObject Window_OpenBluetooth;

	//回到主頁面
	public UIButton BackMainHome;

	//使用腦波儀
	public UIButton EnableBrainWave;

	//不使用腦波儀
	public UIButton DisableBrainWave;


	//private..................................

	//TweenPosition

	private TweenPosition TP_UseBrainWave;

	private TweenPosition TP_OpenBluetooth;


	//第一次進入遊戲詢問始使用腦波
	public static bool AskUseBrainWave = true;

	//要使用腦波嗎
	public static bool UseBrainWave = false;


	void Awake ()
	{
		init ();
		ButtonEvent ();
	}

	void Start ()
	{
		if (AskUseBrainWave)
			UI_BrainWave_dir (true);
		else
			LevelSelect.SetActive (true);
	}

	void Update ()
	{
		
	}

	public override void ButtonEvent ()
	{
		BackMainHome.onClick.Add (new EventDelegate (() => {
			AskUseBrainWave = true;
			SceneManager.LoadSceneAsync (0);
		}));

		EnableBrainWave.onClick.Add (new EventDelegate (() => {
			AskUseBrainWave = false;
			UseBrainWave = true;
			UI_BrainWave_dir (false);

			#if !UNITY_EDITOR
			bool bluetoothEnable = Connect.jo.Call<bool> ("CheckBluetoothState");
			if (bluetoothEnable)
				LevelSelect.SetActive (true);
			else
				UI_OpenBluetooth_dir (true);
			#endif
			
		}));

		DisableBrainWave.onClick.Add (new EventDelegate (() => {
			AskUseBrainWave = false;
			UseBrainWave = false;
			UI_BrainWave_dir (false);
			LevelSelect.SetActive (true);
		}));
		base.Button_Level [0].onClick.Add (new EventDelegate (() => StartCoroutine (DisplayLoadingScreen (8))));
		base.Button_Level [1].onClick.Add (new EventDelegate (() => StartCoroutine (DisplayLoadingScreen (9))));
		base.Button_Level [2].onClick.Add (new EventDelegate (() => StartCoroutine (DisplayLoadingScreen (10))));
		base.Button_Level [3].onClick.Add (new EventDelegate (() => StartCoroutine (DisplayLoadingScreen (11))));
		base.Button_Level [4].onClick.Add (new EventDelegate (() => StartCoroutine (DisplayLoadingScreen (12))));
	}

	private void UI_BrainWave_dir (bool Forward)
	{
		UI_dir (Forward, false, Window_AskUseBrainWave, ref TP_UseBrainWave, 0.6f, new Vector3 (0, -34, 0));
	}

	private void UI_OpenBluetooth_dir (bool Forward)
	{
		UI_dir (Forward, false, Window_OpenBluetooth, ref TP_OpenBluetooth, 0.6f, new Vector3 (0, -34, 0));
	}
}


