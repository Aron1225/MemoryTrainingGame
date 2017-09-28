using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GA_Controller : MonoBehaviour
{
	// Canvas
	public Canvas m_Canvas;

	// GUIAnimFREE objects of primary buttons
	public GUIAnimFREE m_PrimaryButton1;
	//	public GUIAnimFREE m_PrimaryButton2;

	// GUIAnimFREE objects of secondary buttons
	public GUIAnimFREE m_SecondaryButton1;
	//	public GUIAnimFREE m_SecondaryButton2;

	// Toggle state of buttons
	bool m_Button1_IsOn = false;

	bool PrimaryButton1_IsOn = false;

	void Awake ()
	{
		if (enabled) {
			// Set GUIAnimSystemFREE.Instance.m_AutoAnimation to false in Awake() will let you control all GUI Animator elements in the scene via scripts.
			GUIAnimSystemFREE.Instance.m_AutoAnimation = false;
		}

		GUIAnimSystemFREE.Instance.gameObject.SetActive (false);//發現這關掉可以減少很多GC
	}

	void Start ()
	{
	}

	void Update ()
	{
	}

	public void start ()
	{
		if (!PrimaryButton1_IsOn) {
			StartCoroutine (MoveInPrimaryButtons ());
			PrimaryButton1_IsOn = true;
		}
	}

	public void OnButton_1 ()
	{
		// Disable all buttons for a few seconds
		StartCoroutine (DisableAllButtonsForSeconds (0.1f));//點下後冷卻時間

		// Toggle m_Button1
		ToggleButton_1 ();
	}

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

	// MoveOut all primary buttons
	public void HideAllGUIs ()
	{
		if (PrimaryButton1_IsOn) {

			// MoveOut all primary buttons
			m_PrimaryButton1.MoveOut (GUIAnimSystemFREE.eGUIMove.SelfAndChildren);

			// MoveOut all secondary buttons
			if (m_Button1_IsOn == true)
				m_SecondaryButton1.MoveOut (GUIAnimSystemFREE.eGUIMove.SelfAndChildren);

			PrimaryButton1_IsOn = false;
		}
		m_Button1_IsOn = false;
	}

	// MoveIn all primary buttons
	IEnumerator MoveInPrimaryButtons ()
	{
		yield return new WaitForSeconds (0.1f);

		// MoveIn all primary buttons
		m_PrimaryButton1.MoveIn (GUIAnimSystemFREE.eGUIMove.Self);		

		// Enable all scene switch buttons
		StartCoroutine (EnableAllDemoButtons ());
	}

	// Enable/Disable all scene switch Coroutine
	IEnumerator EnableAllDemoButtons ()
	{
		yield return new WaitForSeconds (0.1f);

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
}
