using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using System;
using UnityEngine.UI;

public class Level1_Timer : MonoBehaviour
{
	//設定circle
	[SerializeField]private GameObject circle;

	//設定ProgressBar_label
	[SerializeField]private UILabel ProgressBar_label;

	private UISprite m_Fill;
	private float m_Value;
	public float TransitoryValue { get; private set; }//default = 0
	public float ProgressSpeed;
	public bool TriggerOnComplete;
	public bool isDone { get { return m_Value == 1; } }
	public bool isPaused { get { return TransitoryValue == m_Value; } }
	[Serializable]public class OnCompleteEvent : UnityEvent{}
	[SerializeField]private OnCompleteEvent OnCompleteMethods;

	void Start ()
	{
		m_Fill = circle.GetComponent<UISprite> ();
		m_Value = 1;
		SetFillerSize (0);
	}

		
	void Update ()
	{
		if (TransitoryValue != m_Value) {
			
			float Dvalue = m_Value - TransitoryValue;

		
			if (Dvalue > 0) {
				TransitoryValue += ProgressSpeed * Time.deltaTime / 3;
				if (TransitoryValue >= m_Value)
					TransitoryValue = m_Value;
			} else if (Dvalue < 0) {
				TransitoryValue -= ProgressSpeed * Time.deltaTime / 30;
				if (TransitoryValue <= m_Value)
					TransitoryValue = m_Value;
			}


			if (TransitoryValue >= 1)
				TransitoryValue = 1;
			else if (TransitoryValue < 0)
				TransitoryValue = 0;


			SetFillerSize (TransitoryValue);

			if (TriggerOnComplete && isPaused && isDone)
				OnComplete ();
		}
	}

	public void SetFillerSize (float fill)
	{
		if (ProgressBar_label) 
		{
			ProgressBar_label.text = Mathf.RoundToInt (fill * 30).ToString ();

			m_Fill.fillAmount = fill;
		}
	}

	//倒數
	public void reciprocal ()
	{
		m_Value = 0;
	}

	//完成事件
	public void OnComplete ()
	{
		OnCompleteMethods.Invoke ();
	}

	//重新開始倒數
	public void TimeReset ()
	{
		TransitoryValue = 0;
		m_Value = 1;
		ProgressSpeed = 1;
	}

	//時間暫停
	public void pause ()
	{		
		ProgressSpeed = 0;
	}

	//時間歸零
	public void rezero ()
	{		
		TransitoryValue = 0;
		SetFillerSize (0);
	}
}

