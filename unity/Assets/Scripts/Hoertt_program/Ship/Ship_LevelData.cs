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
        AllQuiznum.Add(5);
        AllQuiznum.Add(6);
        //該選擇的題目數量
        Quiznum.Add(1);
        Quiznum.Add(2);
        Quiznum.Add(3);
        Quiznum.Add(3);
        //船移動方式(1.不動 2.轉圓 3.晃動 4.遇浪)
        ShipMoveSet.Add(1);
        ShipMoveSet.Add(1);
        ShipMoveSet.Add(1);
        ShipMoveSet.Add(1);
        //題目移動方式(1.一起移動(不變位置) 2.個別移動 3.一起移動(位置調換) 4.遇浪特殊移動)
        QuizMoveSet.Add(1);
        QuizMoveSet.Add(1);
        QuizMoveSet.Add(1);
        QuizMoveSet.Add(1);

        //答題題目位置
        QuizPos.Add(new Vector3(-138f, -315f, 0f));
        QuizPos.Add(new Vector3(124f, -315f, 0f));
        QuizPos.Add(new Vector3(-394f, -315f, 0f));
        QuizPos.Add(new Vector3(409f, -315f, 0f));
        QuizPos.Add(new Vector3(-399f, -71f, 0f));
        QuizPos.Add(new Vector3(409f, -71f, 0f));

        //中間題目移動位置  
        Postable.Add(new List<Vector3>());
        Postable[0].Add(new Vector3(-147f, -11f, 0f));
        Postable[0].Add(new Vector3(156f, -12f, 0f));

        Postable.Add(new List<Vector3>());
        Postable[1].Add(new Vector3(-290f, -10f, 0f));
        Postable[1].Add(new Vector3(-106f, -10f, 0f));
        Postable[1].Add(new Vector3(104f, -10f, 0f));
        Postable[1].Add(new Vector3(278f, -10f, 0f));

        Postable.Add(new List<Vector3>());
        Postable[2].Add(new Vector3(-292f, -10f, 0f));
        Postable[2].Add(new Vector3(-145f, -10f, 0f));
        Postable[2].Add(new Vector3(0f, -10f, 0f));
        Postable[2].Add(new Vector3(141f, -10f, 0f));
        Postable[2].Add(new Vector3(297f, -10f, 0f));

        Postable.Add(new List<Vector3>());
        Postable[3].Add(new Vector3(-214f, 53f, 0f));
        Postable[3].Add(new Vector3(0f, 53f, 0f));
        Postable[3].Add(new Vector3(200f, 53f, 0f));
        Postable[3].Add(new Vector3(-214f, -121f, 0f));
        Postable[3].Add(new Vector3(0f, -121f, 0f));
        Postable[3].Add(new Vector3(200f, -121f, 0f));

    }
}
