using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GA_Controller : MonoBehaviour
{

	// ########################################
	// Variables
	// ########################################

	#region Variables

	// Canvas
	public Canvas m_Canvas;

	// GUIAnimFREE objects of title text
	//	public GUIAnimFREE m_Title1;
	//	public GUIAnimFREE m_Title2;
	//
	//	// GUIAnimFREE objects of top and bottom bars
	//	public GUIAnimFREE m_TopBar;
	//	public GUIAnimFREE m_BottomBar;

	// GUIAnimFREE objects of primary buttons
	public GUIAnimFREE m_PrimaryButton1;
	//	public GUIAnimFREE m_PrimaryButton2;

	// GUIAnimFREE objects of secondary buttons
	public GUIAnimFREE m_SecondaryButton1;
	//	public GUIAnimFREE m_SecondaryButton2;

	// Toggle state of buttons
	bool m_Button1_IsOn = false;
	//	bool m_Button2_IsOn = false;


	#endregion // Variables

	// ########################################
	// MonoBehaviour Functions
	// http://docs.unity3d.com/ScriptReference/MonoBehaviour.html
	// ########################################

	#region MonoBehaviour

	// Awake is called when the script instance is being loaded.
	// http://docs.unity3d.com/ScriptReference/MonoBehaviour.Awake.html
	void Awake ()
	{
		if (enabled) {
			// Set GUIAnimSystemFREE.Instance.m_AutoAnimation to false in Awake() will let you control all GUI Animator elements in the scene via scripts.
			GUIAnimSystemFREE.Instance.m_AutoAnimation = false;
		}

		GUIAnimSystemFREE.Instance.gameObject.SetActive (false);//發現這關掉可以減少很多GC
//		Destroy (GUIAnimSystemFREE.Instance.gameObject);
	}

	// Start is called on the frame when a script is enabled just before any of the Update methods is called the first time.
	// http://docs.unity3d.com/ScriptReference/MonoBehaviour.Start.html
	void Start ()
	{
		// MoveIn m_TopBar and m_BottomBar
//		m_TopBar.MoveIn (GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
//		m_BottomBar.MoveIn (GUIAnimSystemFREE.eGUIMove.SelfAndChildren);

		// MoveIn m_Title1 m_Title2
//		StartCoroutine (MoveInTitleGameObjects ());

		// MoveIn dialogs
//		StartCoroutine (MoveInPrimaryButtons ());

		// Enable all scene switch buttons
		// http://docs.unity3d.com/Manual/script-GraphicRaycaster.html
//		GUIAnimSystemFREE.Instance.SetGraphicRaycasterEnable (m_Canvas, true);

		// Disable all scene switch buttons
		// http://docs.unity3d.com/Manual/script-GraphicRaycaster.html
//		GUIAnimSystemFREE.Instance.SetGraphicRaycasterEnable (m_Canvas, false);
	}

	public void start ()
	{
		StartCoroutine (MoveInPrimaryButtons ());
	}

	// Update is called every frame, if the MonoBehaviour is enabled.
	// http://docs.unity3d.com/ScriptReference/MonoBehaviour.Update.html
	void Update ()
	{

	}

	#endregion // MonoBehaviour

	// ########################################
	// MoveIn/MoveOut functions
	// ########################################

	#region MoveIn/MoveOut

	// Move In m_Title1 and m_Title2
	//	IEnumerator MoveInTitleGameObjects ()
	//	{
	////		yield return new WaitForSeconds (1f);
	//
	//		// Move In m_Title1 and m_Title2
	////		m_Title1.MoveIn (GUIAnimSystemFREE.eGUIMove.Self);
	////		m_Title2.MoveIn (GUIAnimSystemFREE.eGUIMove.Self);
	//
	//		// MoveIn dialogs
	//		StartCoroutine (MoveInPrimaryButtons ());
	//
	//		// Enable all scene switch buttons
	//		// http://docs.unity3d.com/Manual/script-GraphicRaycaster.html
	//		GUIAnimSystemFREE.Instance.SetGraphicRaycasterEnable (m_Canvas, true);
	//
	//		yield break;
	//	}

	// MoveIn all primary buttons
	IEnumerator MoveInPrimaryButtons ()
	{
		yield return new WaitForSeconds (0.1f);

		// MoveIn all primary buttons
		m_PrimaryButton1.MoveIn (GUIAnimSystemFREE.eGUIMove.Self);	
//		m_PrimaryButton2.MoveIn (GUIAnimSystemFREE.eGUIMove.Self);	
	

		// Enable all scene switch buttons
		StartCoroutine (EnableAllDemoButtons ());
	}

	// MoveOut all primary buttons
	public void HideAllGUIs ()
	{
		// MoveOut all primary buttons
		m_PrimaryButton1.MoveOut (GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
//		m_PrimaryButton2.MoveOut (GUIAnimSystemFREE.eGUIMove.SelfAndChildren);


		// MoveOut all secondary buttons
		if (m_Button1_IsOn == true)
			m_SecondaryButton1.MoveOut (GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
//		if (m_Button2_IsOn == true)
//			m_SecondaryButton2.MoveOut (GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
		
		// MoveOut m_Title1 and m_Title2
//		StartCoroutine (HideTitleTextMeshes ());
	}

	//	// MoveOut m_Title1 and m_Title2
	//	IEnumerator HideTitleTextMeshes ()
	//	{
	//		yield return new WaitForSeconds (1f);
	//
	////		// MoveOut m_Title1 and m_Title2
	////		m_Title1.MoveOut (GUIAnimSystemFREE.eGUIMove.Self);
	////		m_Title2.MoveOut (GUIAnimSystemFREE.eGUIMove.Self);
	////
	////		// MoveOut m_TopBar and m_BottomBar
	////		m_TopBar.MoveOut (GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
	////		m_BottomBar.MoveOut (GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
	//	}

	#endregion // MoveIn/MoveOut

	// ########################################
	// Enable/Disable button functions
	// ########################################

	#region Enable/Disable buttons

	// Enable/Disable all scene switch Coroutine
	IEnumerator EnableAllDemoButtons ()
	{
		yield return new WaitForSeconds (1f);

		// Enable all scene switch buttons
		// http://docs.unity3d.com/Manual/script-GraphicRaycaster.html
		GUIAnimSystemFREE.Instance.SetGraphicRaycasterEnable (m_Canvas, true);
	}

	// Disable all buttons for a few seconds
	IEnumerator DisableAllButtonsForSeconds (float DisableTime)
	{
		// Disable all buttons
		GUIAnimSystemFREE.Instance.EnableAllButtons (false);

		yield return new WaitForSeconds (DisableTime);

		// Enable all buttons
		GUIAnimSystemFREE.Instance.EnableAllButtons (true);
	}

	#endregion // Enable/Disable buttons

	// ########################################
	// UI Responder functions
	// ########################################

	#region UI Responder

	public void OnButton_1 ()
	{
		// Disable all buttons for a few seconds
		StartCoroutine (DisableAllButtonsForSeconds (0.1f));//點下後冷卻時間

		// Toggle m_Button1
		ToggleButton_1 ();

		// Toggle other buttons
//		if (m_Button2_IsOn == true) {
//			ToggleButton_2 ();
//		}

	}

	//	public void OnButton_2 ()
	//	{
	//		// Disable all buttons for a few seconds
	//		StartCoroutine (DisableAllButtonsForSeconds (0.6f));
	//
	//		// Toggle m_Button2
	//		ToggleButton_2 ();
	//
	//		// Toggle other buttons
	//		if (m_Button1_IsOn == true) {
	//			ToggleButton_1 ();
	//		}
	//
	//	}


	#endregion // UI Responder

	// ########################################
	// Toggle button functions
	// ########################################

	#region Toggle Button

	// Toggle m_Button1
	public void ToggleButton_1 ()
	{
		m_Button1_IsOn = !m_Button1_IsOn;
		if (m_Button1_IsOn == true) {
			// MoveIn m_SecondaryButton1
			m_SecondaryButton1.MoveIn (GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
		} else {
			// MoveOut m_SecondaryButton1
			m_SecondaryButton1.MoveOut (GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
		}
	}

	//	// Toggle m_Button2
	//	void ToggleButton_2 ()
	//	{
	//		m_Button2_IsOn = !m_Button2_IsOn;
	//		if (m_Button2_IsOn == true) {
	//			// MoveIn m_SecondaryButton2
	//			m_SecondaryButton2.MoveIn (GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
	//		} else {
	//			// MoveOut m_SecondaryButton2
	//			m_SecondaryButton2.MoveOut (GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
	//		}
	//	}

	#endregion // Toggle Button
}
