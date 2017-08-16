using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class HoresMove : MonoBehaviour {

    Vector3 point = new Vector3();
    static int i;
    public static int Level = 1;
    float Radius = 10;
    private Vector3 pos,rPos;
    private static bool AnsCover;
    private GameObject[] LoadHores;
    public static int[]  SequArr, RandomArr;

    public static List<GameObject> objlist = new List<GameObject>();
    public static List<int> HoresCount = new List<int>();
    static List<int> QusArr = new List<int>();
    static List<string> AnsArr = new List<string>();

    // Use this for initialization

    public class CreatHores
    {
        public static int P_Pos = 0;

        public GameObject GetHores { get; private set; }

        public CreatHores (GameObject GO)
        {
            GO = Instantiate(GO, parent: GameObject.Find("CerculPoint").transform) as GameObject;

            //GO.transform.localScale = Vector3.one;


            GO.name = "Hores(" + P_Pos + ")";

            objlist.Add(GO);

            GetHores = GO;
            P_Pos++;
        }

    }

    public void Initialization()
    {
        foreach (GameObject item in objlist)
        {
            Destroy(item);
        }
        objlist = new List<GameObject>();
        Hores_Click.clickopen = true;
        for (int i = 0; i < HoresCount[Level]; i++)
        {
            new CreatHores(LoadHores[1]);
        }
       RandomArr=SequArr = new int[objlist.Count];
        makeRandomArr(objlist.Count);
        SetRadius(6);
    }

    /// <summary>
    /// 製作亂數，儲存於RandomArr[_Qusnum]
    /// RandomArr[]內存1~objlist.count不重複亂數排列
    /// </summary>
    /// <param name="_Qusnum"></param>
    /// <param name="_Randnum"></param>
    void makeRandomArr(int _Qusnum)
    {

        //RandomArr = new int[_Randnum];
        //Qusnum = _Qusnum;
        //Randnum = _Randnum;
        for (int i = 0; i < SequArr.Length; i++)
        {
            SequArr[i] = i + 1;
        }
        int end = SequArr.Length - 1;
        for (int i = 0; i < _Qusnum; i++)
        {
            int num = Random.Range(0, end + 1);
            RandomArr[i] = SequArr[num];
            SequArr[num] = SequArr[end];
            end--;
        }
    }



    void Start()
    {
        ImporTable();
        LoadHores = Resources.LoadAll<GameObject>("Hoertt/HoresGroup");
        

        
        //rPos = transform.localPosition;
        //      pos = GameObject.Find("background2").transform.position - NewVector3(0,2f,0);
        point = GameObject.Find("CerculPoint").transform.localPosition;
        //MyRenderer = this.GetComponent<Renderer>();
        
        Initialization();
    }
    // Update is called once per frame
    //private void OnCollisionexit2D(Collision2D collision)
    //{
    //    Hashtable argsrota = new Hashtable();

    //    argsrota.Add("rotation", new Vector3(1, 180, 1));

    //    argsrota.Add("islocal", true);

    //    argsrota.Add("time", 1f);

    //    argsrota.Add("easeType", iTween.EaseType.linear);

    //    argsrota.Add("loopType", iTween.LoopType.none);
    //    iTween.RotateAdd(gameObject, argsrota);

    //    Debug.Log("rota");
    //}
    
    void Update () {
        objlist[0].transform.Translate(Mathf.Cos(Time.fixedTime) * 0.02f * Vector3.up);
        objlist[1].transform.Translate(Mathf.Cos(Time.fixedTime) * 0.02f * Vector3.down);
        //objlist[2].transform.Translate(Mathf.Cos(Time.fixedTime) * 0.02f * Vector3.down);

        GameObject.Find("CerculPoint").transform.RotateAround(point, Vector3.up, 20 * Time.deltaTime);
        
    }
    void SetRadius (float t)
    {
        int A = 1;
        Radius = t;
        foreach ( GameObject obj in objlist)
        {
            Debug.Log(360 / HoresCount[Level]);
            obj.transform.position = point;
            obj.transform.Translate(Vector3.forward * (-Radius) * Mathf.Sin(Mathf.PI / 180 * (360 / HoresCount[Level])*A) + Vector3.right * (-Radius) * Mathf.Cos(Mathf.PI / 180 * (360 / HoresCount[Level])*A));
            obj.transform.Rotate(Vector3.up*((360 / HoresCount[Level]) * A + 90));
            A++;
        }
        //objlist[0].transform.Translate(Vector3.forward * (-Radius) * Mathf.Sin(Mathf.PI / 180  *120)+Vector3.right * (-Radius) * Mathf.Cos(Mathf.PI / 180 * 120));
        //objlist[1].transform.Translate(Vector3.forward * (-Radius) * Mathf.Sin(Mathf.PI / 180 * 240) + Vector3.right * (-Radius) * Mathf.Cos(Mathf.PI / 180 * 240));
        //objlist[2].transform.Translate(Vector3.forward * (-Radius) * Mathf.Sin(Mathf.PI / 180 * 360) + Vector3.right * (-Radius) * Mathf.Cos(Mathf.PI / 180 * 360));

    }

    public static void AnsList (string name)
    {
        Debug.Log(name);
        if (name != null)
        {

            if (i >= objlist.Count-1)
            {
                i = 0;
                AnsCover = true;
            }
            //若點選超過3個覆蓋最舊的
            if (AnsCover)
            {
                GameObject.Find(AnsArr[i]).GetComponent<SpriteRenderer>().sprite = Resources.Load("Hoertt/hores1", typeof(Sprite)) as Sprite;
                AnsArr[i] = name;
            }
            else
            {
                AnsArr.Add(name);
                
            }


                GameObject.Find(AnsArr[i]).GetComponent<SpriteRenderer>().sprite = Resources.Load("Hoertt/hores2", typeof(Sprite)) as Sprite;
                i++;


            
        }

}

    void ImporTable ()
    {
        HoresCount.Add(2);
        HoresCount.Add(3);
        HoresCount.Add(4);
        HoresCount.Add(5);
    }
}
