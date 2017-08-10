using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger : MonoBehaviour {
    // Use this for initialization
    static int AniNum = 0;
    void Start () {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        AniNum++;
        switch(AniNum%3)
        {
            case 0:
                sound.playmusic("dog");
                break;
            case 1:
                sound.playmusic("cat");
                break;
            case 2:
                sound.playmusic("sheep");
                break;
        }
        Debug.Log(AniNum);
    }
    
    // Update is called once per frame
    void Update () {
		
	}
}
