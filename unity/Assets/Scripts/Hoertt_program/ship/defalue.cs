using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class defalue : MonoBehaviour {
    [SerializeField] private List <GameObject> objlist = new List<GameObject>();

    private static int i=0 ,x = 0;
    private static int minvalue = 1;//大於等於1 
    public static int maxvalue = 9;//小於9
    public static int QusAmount = 3;
    int[] sequence = new int[maxvalue];
    public static int[] RandomArr = new int[QusAmount];
    public static string[] QusArr = new string[QusAmount];
    public static string[] AnsArr = new string[QusAmount];
    
    private static int Score = 0;

    // Use this for initialization
    void Start () {
        objlist.Add(GameObject.Find("11"));
        objlist.Add(GameObject.Find("21"));
        objlist.Add(GameObject.Find("31"));
        objlist.Add(GameObject.Find("12"));
        objlist.Add(GameObject.Find("22"));
        objlist.Add(GameObject.Find("32"));
        objlist.Add(GameObject.Find("13"));
        objlist.Add(GameObject.Find("23"));
        objlist.Add(GameObject.Find("33"));

        makeRandomArr();
        ShowRandom();
	}
    ///製作隨機亂數
    void makeRandomArr()
    {
        for (int i = 0; i < sequence.Length; i++)
        {
            sequence[i] = i + 1;
        }
        int end = sequence.Length - 1;
        for (int i = 0; i < QusAmount; i++)
        {
            int num = Random.Range(0, end + 1);
            RandomArr[i] = sequence[num];
            sequence[num] = sequence[end];
            end--;
        }
    }

    ///顯示隨機亂數
    public void ShowRandom()
    {
        foreach (int Arr in RandomArr)
        {
            //Debug.Log(Arr);
            //紀錄題目至QusArr
                QusArr[x] = objlist[Arr - 1].name;
                Debug.Log(QusArr[x]);
            x++;
            if (x >= 3) x = 0;
            //顯示題目為black
			objlist[Arr-1].GetComponent<SpriteRenderer>().sprite = Resources.Load("Hoertt/black", typeof(Sprite)) as Sprite;
        }
        DelayRecover();
    }
    // Update is called once per frame

    //呼叫後2秒執行下列程序
    IEnumerator delay()
    {
        //等2秒後
        yield return new WaitForSeconds(2);
        //ShowQusStatus = false;
        //將顯示為black的題目返回至white
        foreach (int Arr in RandomArr)
        {
            //Debug.Log(Arr);
            objlist[Arr - 1].GetComponent<SpriteRenderer>().sprite = Resources.Load("Hoertt/white", typeof(Sprite)) as Sprite;
            click.clickopen = true;
        }
        //開始移動
        StartMove.StartObjMove();
    }
    //呼叫delay函數
    void DelayRecover()
    {
        StartCoroutine("delay");
        //ShowQusStatus = true;
    }
    static bool AnsCover = false;
    public static void AnsList(string name)
    {
        if (name != null)
        {
            
            if (i >= 3)
            {
                i = 0;
                AnsCover = true;
            }
            //若點選超過3個覆蓋最舊的
            if (AnsCover)
            {
				GameObject.Find(AnsArr[i]).GetComponent<SpriteRenderer>().sprite = Resources.Load("Hoertt/white", typeof(Sprite)) as Sprite;
            }
            //紀錄
            AnsArr[i] = name;
			GameObject.Find(AnsArr[i]).GetComponent<SpriteRenderer>().sprite = Resources.Load("Hoertt/chack", typeof(Sprite)) as Sprite;
            i++;
            
        }
    }

    public  void CompareArr()
    {
        for(int c=0;c<3;c++)
        {
            for (int c2=0;c2<3;c2++)
            {
                //比對相等回傳0
                if(string.Compare(QusArr[c],AnsArr[c2])==0)
                {
                    Score += 10;
                }

            }
        }
        Debug.Log(Score);
        GameObject.Find("ScoreText").GetComponent<Text>().text = "Score:" + Score;
    }
    void Update () {
	
	}

}
