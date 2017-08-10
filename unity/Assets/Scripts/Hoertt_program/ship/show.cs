using UnityEngine;
using System.Collections;

public class show : MonoBehaviour
{

    public static int  QusSum = defalue.AnsArr.Length;
    private static Vector3[] SOpos=new Vector3[QusSum];
    public GameObject[] obj = new GameObject[QusSum];
	static public string[] order = new string[QusSum];
	public static int i = 0;
	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame


	void Update ()
	{
		/*
		if (Input.GetKeyDown (KeyCode.B)) {
			obj1.SetActive (true);
			obj2.SetActive (true);
			obj3.SetActive (true);
			obj4.SetActive (true);
			obj5.SetActive (true);
			Debug.Log ("出現");
		}
	*/
	}
    //public static void StaPos (Vector3 Opos)
    //{
        
    //        SOpos[x] = Opos;
    //        x++;
    //    if (x >= objsum)  x = 0;
    //}

	//public void ShowAll ()
	//{
	//	for (int i = 0; i < objsum; i++)
 //       {
 //           obj[i].transform.position = SOpos[i];
 //           Debug.Log(SOpos[i]);
 //           obj [i].SetActive (true);
	//	}		
	//}

	public void showorderlist(){	
		for (int i = 0; i < QusSum; i++) {
            Debug.Log(defalue.AnsArr[i]);
		}
	}

	//public  static  void orderlist (string name)
	//{
        

 //   }

	/*
	void OnMouseOver(){
		if (Input.GetMouseButtonDown (1)) {
			obj1.SetActive (true);
			obj2.SetActive (true);
			obj3.SetActive (true);
			obj4.SetActive (true);
			obj5.SetActive (true);
			Debug.Log( "出現" );
		}
	}
*/
}
