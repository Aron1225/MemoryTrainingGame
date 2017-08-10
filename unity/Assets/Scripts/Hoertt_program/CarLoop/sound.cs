using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sound : MonoBehaviour {
    public static AudioClip[] musicList;

    public const string MusicPath = "Hoertt/sound/";
    void Start()
    {
    }
    // Use this for initialization
    public static new AudioSource audio = null;
    public static void playmusic(string name)
    {
        audio = Camera.main.gameObject.AddComponent<AudioSource>();
        
        audio.clip = Resources.Load<AudioClip>(MusicPath + name);
        Debug.Log(MusicPath + name);
        audio.Play();
            


    }
	// Update is called once per frame
	void Update () {
		
	}
}
