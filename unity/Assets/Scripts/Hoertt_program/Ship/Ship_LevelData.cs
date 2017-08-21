using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship_LevelData : MonoBehaviour {
    public static List<int> AllQuiznum = new List<int>();
    public static List<int> Quiznum = new List<int>();
    public static List<int> QuizMoveSet = new List<int>();
    public static List<int> ShipMoveSet = new List<int>();
    public static List<List<Vector3>> Postable = new List<List<Vector3>>();
    public static List<Vector3> QuizPos = new List<Vector3>();
    // Use this for initialization
    void Start () {
        
    }
    void Awake()
    {
        ImportTable();
    }

    public void ImportTable()
    {
        //可選擇的題目數量
        AllQuiznum.Add(2);
        AllQuiznum.Add(4);
        AllQuiznum.Add(6);
        //該選擇的題目數量
        Quiznum.Add(1);
        Quiznum.Add(2);
        Quiznum.Add(3);
        //船移動方式(1.不動 2.轉圓 3.晃動 4.遇浪)
        ShipMoveSet.Add(1);
        ShipMoveSet.Add(1);
        ShipMoveSet.Add(1);
        //題目移動方式(1.一起移動(不變位置) 2.個別移動 3.一起移動(位置調換) 4.遇浪特殊移動)
        QuizMoveSet.Add(1);
        QuizMoveSet.Add(1);
        QuizMoveSet.Add(1);


        QuizPos.Add(new Vector3(-138f, -315f, 0f));
        QuizPos.Add(new Vector3(124f, -315f, 0f));
        QuizPos.Add(new Vector3(-394f, -315f, 0f));
        QuizPos.Add(new Vector3(409f, -315f, 0f));
        QuizPos.Add(new Vector3(-399f, -71f, 0f));
        QuizPos.Add(new Vector3(409f, -71f, 0f));


        Postable.Add(new List<Vector3>());
        Postable[0].Add(new Vector3(-147f, -11f, 0f));
        Postable[0].Add(new Vector3(156f, -12f, 0f));

        Postable.Add(new List<Vector3>());
        Postable[1].Add(new Vector3(-222f, -10f, 0f));
        Postable[1].Add(new Vector3(3f, -10f, 0f));
        Postable[1].Add(new Vector3(226f, -10f, 0f));

        Postable.Add(new List<Vector3>());
        Postable[2].Add(new Vector3(-3f, 0.2f, 0f));
        Postable[2].Add(new Vector3(-1f, 0.2f, 0f));
        Postable[2].Add(new Vector3(1f, 0.2f, 0f));
        Postable[2].Add(new Vector3(3f, 0.2f, 0f));
        Postable[2].Add(new Vector3(3f, 0.2f, 0f));

        //Postable.Add(new List<Vector3>());
        //Postable[3].Add(new Vector3(-3f, 0.2f, 0.4f));
        //Postable[3].Add(new Vector3(-1f, 0.2f, 0.4f));
        //Postable[3].Add(new Vector3(1f, 0.2f, 0.4f));
        //Postable[3].Add(new Vector3(3f, 0.2f, 0.4f));

        //Postable.Add(new List<Vector3>());
        //Postable[4].Add(new Vector3(-3f, 0.2f, 0.4f));
        //Postable[4].Add(new Vector3(-1f, 0.2f, 0.4f));
        //Postable[4].Add(new Vector3(1f, 0.2f, 0.4f));
        //Postable[4].Add(new Vector3(3f, 0.2f, 0.4f));

        //Postable.Add(new List<Vector3>());
        //Postable[5].Add(new Vector3(-1f, 1.5f, 0.4f));
        //Postable[5].Add(new Vector3(2f, 1.5f, 0.4f));
        //Postable[5].Add(new Vector3(2, -1.5f, 0.4f));
        //Postable[5].Add(new Vector3(-1f, -1.5f, 0.4f));

        //Postable.Add(new List<Vector3>());
        //Postable[6].Add(new Vector3(-1f, 1.5f, 0.4f));
        //Postable[6].Add(new Vector3(2f, 1.5f, 0.4f));
        //Postable[6].Add(new Vector3(2f, -1.5f, 0.4f));
        //Postable[6].Add(new Vector3(-1f, -1.5f, 0.4f));

        //Postable.Add(new List<Vector3>());
        //Postable[7].Add(new Vector3(-1.9f, 1.52f, 0.4f));
        //Postable[7].Add(new Vector3(1.74f, 1.52f, 0.4f));
        //Postable[7].Add(new Vector3(-0f, 0f, 0.4f));
        //Postable[7].Add(new Vector3(-1.9f, -1.5f, 0.4f));
        //Postable[7].Add(new Vector3(1.74f, -1.5f, 0.4f));

        //Postable.Add(new List<Vector3>());
        //Postable[8].Add(new Vector3(-1f, 1.3f, 0.4f));
        //Postable[8].Add(new Vector3(2f, 1.3f, 0.4f));
        //Postable[8].Add(new Vector3(-3f, -1.5f, 0.4f));
        //Postable[8].Add(new Vector3(0.6f, -1.5f, 0.4f));
        //Postable[8].Add(new Vector3(4f, -1.5f, 0.4f));

        //Postable.Add(new List<Vector3>());
        //Postable[9].Add(new Vector3(-3.9f, -1f, 0.4f));
        //Postable[9].Add(new Vector3(-1.35f, -1f, 0.4f));
        //Postable[9].Add(new Vector3(1.1f, -1f, 0.4f));
        //Postable[9].Add(new Vector3(3.65f, -1f, 0.4f));
        //Postable[9].Add(new Vector3(6.2f, -1f, 0.4f));
        //Postable[9].Add(new Vector3(-1.8f, 1.6f, 0.4f));
        //Postable[9].Add(new Vector3(0.75f, 1.6f, 0.4f));
        //Postable[9].Add(new Vector3(3.5f, 1.6f, 0.4f));
        //Postable[9].Add(new Vector3(-1.25f, 3.9f, 0.4f));
        //Postable[9].Add(new Vector3(1.77f, 3.9f, 0.4f));
        //Postable[9].Add(new Vector3(-6f, 2f, 0.4f));
        //Postable[9].Add(new Vector3(7.9f, 1.9f, 0.4f));

    }
}
