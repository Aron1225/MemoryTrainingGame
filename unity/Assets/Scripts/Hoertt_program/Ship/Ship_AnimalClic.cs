using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship_AnimalClic : MonoBehaviour {
    Ship_Control Control;
    public GameObject obj;

    public static bool clickopen = false;
    //int ID;
    new string name;


    // Use this for initialization
    void Start()
    {
        Control = GetComponent<Ship_Control>();
        UIEventListener.Get(obj).onClick = clickenvent;
    }

    // Update is called once per frame
    void Update()
    {

    }
    void clickenvent(GameObject go)
    {
        Debug.Log(go.name);
        Debug.Log("click: " + clickopen);
        if (clickopen)
        {

            name = go.name;
            Ship_Control.ClickReaction(name);
        }
    }
}
