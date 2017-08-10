using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class testtt : MonoBehaviour
{
	
	public float timer;

	public int newtarget;

	public float speed;

	public NavMeshAgent nav;

	public Vector3 Target;

	void Start ()
	{
		nav = gameObject.GetComponent<NavMeshAgent> ();
	}

	void Update ()
	{
		timer += Time.deltaTime;

		if (timer >= newtarget) {
			newTarget ();
			timer = 0;
		}
	}

	void newTarget ()
	{
		float myX = gameObject.transform.position.x;
		float myZ = gameObject.transform.position.y;

		float xPos = myX + Random.Range (myX - 100, myZ + 100);
		float zPos = myZ + Random.Range (myZ - 100, myZ + 100);

		Target = new Vector3 (xPos, gameObject.transform.position.y, zPos);
		Debug.Log (Target);

		nav.SetDestination (Target);
	}
}
