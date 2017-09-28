using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelDatabase : MonoBehaviour
{
	[System.Serializable]
	public class CoffeeCups
	{
		public GameObject Model;
		public GameObject[] cups;
	}

	public CoffeeCups[] m_coffeeCups;

	static public ModelDatabase instance;

	static public CoffeeCups[] coffeeCups {
		get { 
			return instance.m_coffeeCups;
		}
	}

	void Awake ()
	{
		instance = this;	
	}
}
