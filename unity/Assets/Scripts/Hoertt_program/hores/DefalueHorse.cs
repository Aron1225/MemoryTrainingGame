using UnityEngine;
using System.Collections;

public class DefalueHorse : MonoBehaviour {
    public static int HorseNum = 2;
    public GameObject[] horse = new GameObject[HorseNum];
    // Use this for initialization
    void Start()
    {
		Debug.Log( Mathf.Atan(45f));
        StartCoroutine("DelayHorse1");

    }
    IEnumerator DelayHorse1()
    {
        yield return new WaitForSeconds(2);

        StartCoroutine("DelayHorse2");
        //ShowQusStatus = false;
    }
    IEnumerator DelayHorse2()
    {
        yield return new WaitForSeconds(2);
        //ShowQusStatus = false;

    }
    // Update is called once per frame
    void Update()
    {

    }
}
