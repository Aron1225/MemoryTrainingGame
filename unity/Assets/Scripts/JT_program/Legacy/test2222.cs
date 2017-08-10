using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test2222 : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
		testttt component = gameObject.GetComponent<testttt> ();
		Debug.Log ("22"+component.value);

		testttt[] stringContainers = GetComponents<testttt> ();

		foreach (var stringContainer in stringContainers) {
			Debug.Log (stringContainer.value);
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
}
