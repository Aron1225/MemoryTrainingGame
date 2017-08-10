using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class StartMove : MonoBehaviour
{
    [SerializeField] private List<GameObject> objlist = new List<GameObject>();
    /*
    public static int objsum=4;
    public GameObject[] obj = new GameObject[objsum];
    */

    // Use this for initialization
    void Start () {
        //objlist.Add(GameObject.Find("1"));
        //objlist.Add(GameObject.Find("2"));
        //objlist.Add(GameObject.Find("3"));
    }
	
	// Update is called once per frame
	void Update () {
	
	}

 
    public static void StartObjMove()
    {
        //click.clickopen = false;
 //       objlist[0].GetComponent<SpriteRenderer>().sprite = Resources.Load("1'", typeof(Sprite)) as Sprite;
 ////       delaytimer();
 //       objlist[1].GetComponent<SpriteRenderer>().sprite = Resources.Load("2'", typeof(Sprite)) as Sprite;
 //       objlist[2].GetComponent<SpriteRenderer>().sprite = Resources.Load("3'", typeof(Sprite)) as Sprite;
        //for (int i = 0; i < objlist.Count; i++)
        //{
            GameObject.Find("ship").GetComponent<ObjMove>().enabled = true;
        //}
    }
}
