using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractClass : MonoBehaviour
{
	abstract class DataObject
	{
		// Methods
		abstract public void Connect ();

		abstract public void Select ();

		abstract public void Process ();

		abstract public void Disconnect ();

		// The "Template Method"
		public void Run ()
		{
			Connect ();
			Select ();
			Process ();
			Disconnect ();
		}
	}

	// "ConcreteClass"
	class CustomerDataObject : DataObject
	{
		public override void Connect ()
		{
			Debug.Log ("Connect");
		}

		public override void Select ()
		{
			Debug.Log ("Select");
		}

		public override void Process ()
		{
			Debug.Log ("Process");
		}

		public override void Disconnect ()
		{
			Debug.Log ("Disconnect");
		}
	}


	void Start ()
	{
		CustomerDataObject cd = new CustomerDataObject ();
		cd.Run ();
	}


	void Update ()
	{
		
	}
}
