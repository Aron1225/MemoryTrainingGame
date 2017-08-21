using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship_Control : MonoBehaviour {
    Ship_Animal Animal;
    Ship_LevelData Data;
    private GameObject[] LoadAnimal;
    public static int Level = 0;
    public static List<GameObject> Animalist = new List<GameObject>();
    public static List<Ship_Animal.CreatAnimal> AnimalPrefabList = new List<Ship_Animal.CreatAnimal>();
    public static List<int> Quiz = new List<int>();
    public static List<int> AllQuiz = new List<int>();

    void Awake()
    {
       
    }
    void Start()
    {
        Animal = GetComponent<Ship_Animal>();
        Data = GetComponent<Ship_LevelData>();

        StartCoroutine(GameLoop());


    }
    IEnumerator GameLoop()
    {
        //初始化
        yield return StartCoroutine(init());
        //建置物件並移動至題目位置
        yield return StartCoroutine(AnimalSet());
        //製造亮燈題目，存於Quiz。所有可選擇題目存於AllQuiz。
        yield return StartCoroutine(MKRanQuiz());
        //將應選擇的題目閃爍
        yield return StartCoroutine(ShowTheQuiz());
        //將可選擇題目移置題目區
        yield return StartCoroutine(QuizToQuizP()); 
        yield break;
    }
    //初始化
    IEnumerator init()
    {
        //清空Animalist
        foreach (var item in Animalist){ Destroy(item); }

        LoadAnimal = Resources.LoadAll<GameObject>("Hoertt/AnimalGroup");
        //重置Animalist
        Animalist = new List<GameObject>();
        yield break;
    }
    //建置物件並移動至題目位置
    IEnumerator AnimalSet()
    {
        
         Ship_LevelData.Postable[Level].ForEach(GO => AnimalPrefabList.Add(new Ship_Animal.CreatAnimal(LoadAnimal[0])));
       
        yield break;
    }
    //製造亮燈題目，存於Quiz。所有可選擇題目存於AllQuiz。
    IEnumerator MKRanQuiz()
    {

        //製造物件NM 範圍N M=3 MAX=16
        iarray nm = new n_m_array(Ship_LevelData.Quiznum[Level],Ship_LevelData.AllQuiznum[Level]- Ship_LevelData.Quiznum[Level], Ship_LevelData.AllQuiznum[Level]);
        //將題目陣列N從入Quiz
        foreach (var num in nm.n()) { Quiz.Add(num); }
        //將以打亂的可選擇題目存入AllQuiz
        foreach(var i in nm.n_m()) { AllQuiz.Add(i); }
        yield break;
    }

    //將應選擇的題目閃爍
    IEnumerator ShowTheQuiz()
    {
        foreach (var Quiznum in Quiz)
        {
            Debug.Log(Quiz.Count);
            Debug.Log(Quiznum);
            yield return StartCoroutine(Ship_Animal.shine(Animalist[Quiznum]));
        }
        Debug.Log("end");
        
        yield break;
    }
    
    IEnumerator QuizToQuizP ()
    {
        Debug.Log(Quiz.Count);
        switch (Ship_LevelData.QuizMoveSet[Level])
        {
            case 1:
                for (int i = 0; i < Ship_LevelData.AllQuiznum[Level]; i++)
                {
                    TweenPosition.Begin(Animalist[i], 0.5f, Ship_LevelData.QuizPos[i]);
                }
                break;
            default:
                break;
        }
        yield break;
    }

    // Update is called once per frame
    void Update () {
		
	}
    //物件點擊反應
    public static void ClickReaction (string name)
    {
        if(name!=null)
        {
            GameObject.Find(name).GetComponent<UI2DSprite>().color = new Color(0, 1, 1, 1);
           

        }
    }
}
