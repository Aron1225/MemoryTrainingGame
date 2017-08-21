using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship_Animal : MonoBehaviour {
    void Awake()
    {
    }

     static Vector3[] AppearPos = new Vector3[]
    {
        new Vector3(-383f,384f)   ,new Vector3(367f,384f) ,
        new Vector3(-38f,-269f)   ,new Vector3(367f,-269f),
    };

    public class CreatAnimal
    {
        public static int P_Pos = 0;

        public GameObject GetAnimal { get; private set; }

        public CreatAnimal(GameObject GO)
        {
            GO = Instantiate(GO, parent: GameObject.Find("AnimalG").transform) as GameObject;
            int Level = Ship_Control.Level;


            GO.transform.localScale = Vector3.one;

            GO.name = "Player(" + P_Pos + ")";
            Debug.Log("1");
            GO.transform.position = AppearPos[P_Pos / 4];
            //TweenPosition.Begin(GO, 0.01f, AppearPos[P_Pos/4]);
            switch (Ship_LevelData.QuizMoveSet[Level])
            {
                case 1:
                    Debug.Log("2");
                    TweenPosition.Begin(GO, 1.5f, Ship_LevelData.Postable[Level][P_Pos++]);
                    //GO.transform.position = Ship_LevelData.Postable[Level][P_Pos++];
                    Debug.Log("3");
                    break;
                case 2:
                   
                default:
                    //TweenPosition.Begin(GO, 1f, Postable[Level][P_Pos++]);
                break;
            }

            //  AnimalList.Add(GO);

            Ship_Control.Animalist.Add(GO);

            GetAnimal = GO;

        }

    }
    public static IEnumerator shine(GameObject GO)
    {
        for (int i = 0; i < 3; i++)
        {
            Debug.Log("r");
        GO.GetComponent<UI2DSprite>().color = new Color(1, 0, 0, 1);
        yield return (new WaitForSeconds(1f));
            Debug.Log("w");
        GO.GetComponent<UI2DSprite>().color = new Color(1, 1, 1, 1);
        yield return (new WaitForSeconds(1f));
        }
        yield break;
    }
}
