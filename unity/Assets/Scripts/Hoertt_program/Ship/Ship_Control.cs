using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using TETCSharpClient;
using TETCSharpClient.Data;
using UnityEngine;

public class Ship_Control : MonoBehaviour, IGazeListener
{
    Ship_Animal Animal;
    Ship_LevelData Data;
    private static GameObject CompBut;
    private GameObject[] LoadAnimal;
    public static bool AnsCover = false,AnsStatus=true,GameLoopSta=true,FinalStat = false; 
    public static int Level = 1,AnsNum=0;
    public static List<GameObject> Animalist = new List<GameObject>();
    public static List<Ship_Animal.CreatAnimal> AnimalPrefabList = new List<Ship_Animal.CreatAnimal>();
    public static List<int> Quiz = new List<int>();
    public static List<int> AllQuiz = new List<int>();
    public static List<string> AnsList = new List<string>();
    public static List<string> QuizS = new List<string>();

    GameObject UserSight;
    //private TcpClient socket;
    //private Thread incomingThread;
    //private System.Timers.Timer timerHeartbeat;
    //public event EventHandler<ReceivedDataEventArgs> OnData;
    //public static bool isRunning = false;


    public void OnGazeUpdate(GazeData gazeData)
    {
        double gX = gazeData.SmoothedCoordinates.X;
        double gY = gazeData.SmoothedCoordinates.Y;
        Debug.Log(gX + "," + gY);
        UserSight.transform.position = new Vector2((float)gX, (float)gY);
        // Move point, do hit-testing, log coordinates etc.
    }
    void Awake()
    {
       
    }
    void Start()
    {
        Animal = GetComponent<Ship_Animal>();
        Data = GetComponent<Ship_LevelData>();
        CompBut = GameObject.Find("CompBut");
        UserSight = GameObject.Find("UserSight");
        StartCoroutine(GameLoop());

        GazeManager.Instance.Activate(GazeManager.ApiVersion.VERSION_1_0, GazeManager.ClientMode.Push);

        // Register this class for events
        GazeManager.Instance.AddGazeListener(this);
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
            //開啟可點擊
            yield return StartCoroutine(OpenClickEnable());
            yield return StartCoroutine(GameFinal());
        

        yield return null ;
    }
    //初始化
    IEnumerator init()
    {
        CompBut.GetComponent<UITexture>().enabled = false;
        //清空Animalist
        foreach (var item in Animalist){ Destroy(item); }
        //清空AnsList
        AnsList = new List<string>();
        //關閉可點擊
        Ship_AnimalClic.clickopen = false;
        //初始化loadAnimal
        //LoadAnimal.Initialize();
        //讀取所有AnimalGroup下的GameObj prefab
        LoadAnimal = Resources.LoadAll<GameObject>("Hoertt/AnimalGroup");
        //重置Animalist
        Animalist = new List<GameObject>();
        QuizS = new List<string>();

        FinalStat = false;

        AnsCover = false;

        Ship_Animal.CreatAnimal.P_Pos = 0;

        AnsNum = 0;
        yield break;
    }
    //建置物件並移動至題目位置
    IEnumerator AnimalSet()
    {
        yield return new WaitForSeconds(1.5f);
       Ship_LevelData.Postable[Level].ForEach(GO => AnimalPrefabList.Add(new Ship_Animal.CreatAnimal(LoadAnimal[0])));
        
        

        yield break;
    }
    //製造亮燈題目，存於Quiz。所有可選擇題目存於AllQuiz。
    IEnumerator MKRanQuiz()
    {
        //初始化List
        Quiz = new List<int>();
        AllQuiz = new List<int>();
        //製造物件NM 範圍N M=3 MAX=16
        iarray nm = new n_m_array(Ship_LevelData.Quiznum[Level],Ship_LevelData.AllQuiznum[Level]- Ship_LevelData.Quiznum[Level], Ship_LevelData.AllQuiznum[Level]);

        //將題目陣列N從入Quiz(int)及QuizS(string)
        foreach (var num in nm.n()){ Quiz.Add(num);  }
        int x = 0;
        foreach(var num in Quiz)
        {
            QuizS.Add(Animalist[num].name);
            x++;
        }
        //將以打亂的可選擇題目存入AllQuiz
        foreach(var i in nm.n_m()) { AllQuiz.Add(i); }
        yield break;
    }

    //將應選擇的題目閃爍
    IEnumerator ShowTheQuiz()
    {
        yield return StartCoroutine(Ship_Animal.shine(Quiz));
        
        yield break;
    }
    //將可選擇題目移置題目區
    IEnumerator QuizToQuizP ()
    {
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
    //開啟可點擊
    IEnumerator OpenClickEnable()
    {
        Ship_AnimalClic.clickopen = true;
        GameLoopSta = false;
        yield break;
    }

    // Update is called once per frame
    void Update () {

    }
    //物件點擊反應
    public static void ClickReaction (string name)
    {
        if (name != null)
        {
            //如果按下確認按鈕
            if (name == "CompBut")
            {
                foreach (string AnsName in AnsList)
                {
                    if (!QuizS.Contains(AnsName)) AnsStatus = false;
                }
                if (AnsStatus)
                {
                    Level++;
                    FinalStat = true;
                }
                else
                {
                    FinalStat = true;
                }
            }
            else
            {

                
                //若點選超過n個覆蓋最舊的
                if (AnsCover)
                {
                    //GameObject.Find(AnsArr[i]).GetComponent<SpriteRenderer>().sprite = Resources.Load("Hoertt/white", typeof(Sprite)) as Sprite;
                    GameObject.Find(AnsList[AnsNum]).GetComponent<UI2DSprite>().color = new Color(1, 1, 1, 1);
                    AnsList[AnsNum] = name;
                }
                else
                {
                    AnsList.Add(name);
                }

                GameObject.Find(name).GetComponent<UI2DSprite>().color = new Color(0, 1, 1, 1);
                AnsNum++;
                if (AnsNum >= Ship_LevelData.Quiznum[Level])
                {
                    AnsNum = 0;
                    AnsCover = true;
                    CompBut.GetComponent<UITexture>().enabled = true;
                }

            }
        }
    }

    IEnumerator GameFinal()
    {
        while (true)
        {
        if (FinalStat == true)
            {
                StartCoroutine(GameLoop());
            }
        yield return null;
        }
    }


    //======================================================
    //public bool Connect(string host, int port)
    //{
    //    try
    //    {
    //        socket = new TcpClient("localhost", 6555);
    //    }
    //    catch (Exception ex)
    //    {
    //        Console.Out.WriteLine("Error connecting: " + ex.Message);
    //        return false;
    //    }

    //    // Send the obligatory connect request message
    //    string REQ_CONNECT = "{\"values\":{\"push\":true,\"version\":1},\"category\":\"tracker\",\"request\":\"set\"}";
    //    Send(REQ_CONNECT);

    //    // Lauch a seperate thread to parse incoming data
    //    incomingThread = new Thread(ListenerLoop);
    //    incomingThread.Start();

    //    // Start a timer that sends a heartbeat every 250ms.
    //    // The minimum interval required by the server can be read out 
    //    // in the response to the initial connect request.   

    //    string REQ_HEATBEAT = "{\"category\":\"heartbeat\",\"request\":null}";
    //    timerHeartbeat = new System.Timers.Timer(250);
    //    timerHeartbeat.Elapsed += delegate { Send(REQ_HEATBEAT); };
    //    timerHeartbeat.Start();

    //    return true;
    //}
    //private void Send(string message)
    //{
    //    if (socket != null && socket.Connected)
    //    {
    //        StreamWriter writer = new StreamWriter(socket.GetStream());
    //        writer.WriteLine(message);
    //        writer.Flush();
    //    }
    //}

    //private void ListenerLoop()
    //{
    //    StreamReader reader = new StreamReader(socket.GetStream());
    //    isRunning = true;

    //    while (isRunning)
    //    {
    //        string response = string.Empty;

    //        try
    //        {
    //            response = reader.ReadLine();

    //            JObject jObject = JObject.Parse(response);

    //            Packet p = new Packet();
    //            p.RawData = (string)jObject;

    //            p.Category = (string)jObject["category"];
    //            p.Request = (string)jObject["request"];
    //            p.StatusCode = (string)jObject["statuscode"];

    //            JToken values = jObject.GetValue("values");

    //            if (values != null)
    //            {
    //                /* 
    //                  We can further parse the Key-Value pairs from the values here.
    //                  For example using a switch on the Category and/or Request 
    //                  to create Gaze Data or CalibrationResult objects and pass these 
    //                  via separate even ts.

    //                  To get the estimated gaze coordinate (on-screen pixels):
    //                  JObject gaze = JObject.Parse(jFrame.SelectToken("avg").ToString());
    //                  double gazeX = (double) gaze.Property("x").Value;
    //                  double gazeY = (double) gaze.Property("y").Value;
    //                */
    //            }

    //            // Raise event with the data
    //            if (OnData != null)
    //                OnData(this, new ReceivedDataEventArgs(p));
    //        }
    //        catch (Exception ex)
    //        {
    //            Console.Out.WriteLine("Error while reading response: " + ex.Message);
    //        }
    //    }
    //}
    //public class Packet
    //{
    //    public string time = DateTime.UtcNow.Ticks.ToString();
    //    public string Category = string.Empty;
    //    public string Request = string.Empty;
    //    public string StatusCode = string.Empty;
    //    public string values = string.Empty;
    //    public string RawData = string.Empty;

    //    public Packet() { }
    //}
    //public class ReceivedDataEventArgs : EventArgs
    //{
    //    private Packet packet;

    //    public ReceivedDataEventArgs(Packet _packet)
    //    {
    //        this.packet = _packet;
    //    }

    //    public Packet Packet
    //    {
    //        get { return packet; }
    //    }
    //}



}

