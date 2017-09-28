using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class Level : MonoBehaviour
{
	//Mono.............................

	void Awake ()
	{
		OnAwake ();
	}

	void Start ()
	{
		OnStart ();
	}

	void OnDestroy ()
	{
		On_OnDestroy ();
	}

	public virtual void OnAwake ()
	{
	}

	public virtual void OnStart ()
	{
	}

	public virtual void On_OnDestroy ()
	{
	}
		
	public static  Level level_instance;

	public static  Controller controller;

	public abstract IEnumerator GameLoop ();

	public abstract IEnumerator LevelManagement (params object[] args);

	public abstract IEnumerator MakeRandom (int key);

	public abstract IEnumerator ShowLight ();

	public abstract IEnumerator AnswerCompare ();

	public abstract IEnumerator Reset ();

	public abstract void _GameStart ();

	public abstract void _LevelMenu (string str);

	public abstract void _BackHome ();

	public abstract void _Again (string str);

	public abstract void _Next ();

	public abstract void _Back ();

	public static void GameStart ()
	{
		level_instance._GameStart ();
	}

	public static void LevelMenu (string str = "")
	{
		level_instance._LevelMenu (str);
	}

	public static void BackHome ()
	{
		level_instance._BackHome ();
	}

	public static void Again (string str = "")
	{
		level_instance._Again (str);
	}

	public static void Next ()
	{
		level_instance._Next ();
	}

	public static void Back ()
	{
		level_instance._Back ();
	}
}
