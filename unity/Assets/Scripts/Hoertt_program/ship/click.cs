using UnityEngine;
using System.Collections;
using System.Collections.Specialized;

public class click : MonoBehaviour {
	public GameObject obj;

    public static bool clickopen = false;
	//int ID;
    new string name;



	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
        
        
	}

	void OnMouseDown(){
        Debug.Log(clickopen);
        if (clickopen)
        {
            //show.StaPos(obj.transform.position);
            //obj.SetActive(false);
            //  obj.s
            //Debug.Log( "消失" );
            //ID = obj.GetInstanceID ();
            //Debug.Log(ID);
            //Debug.Log(name);
            name = obj.name;
            defalue.AnsList(name);
        }
    }
}