using UnityEngine;
using System.Collections;

public class HoresMove : MonoBehaviour {
    [SerializeField]private float TimerX, TimerY;
    [SerializeField]private bool turn;
    private  Renderer MyRenderer;
    private int sortorder=0;

    private Vector3 pos;
    // Use this for initialization
    void Start() {
        //      pos = GameObject.Find("background2").transform.position - NewVector3(0,2f,0);
        
        MyRenderer= this.GetComponent<Renderer>();

        Hashtable args = new Hashtable();

        //这里是设置类型，iTween的类型又很多种，在源码中的枚举EaseType中  
        //例如移动的特效，先震动在移动、先后退在移动、先加速在变速、等等  
        args.Add("easeType", iTween.EaseType.linear);

        //移动的速度，  
        args.Add("speed", 2f);
        //移动的整体时间。如果与speed共存那么优先speed  
        args.Add("time", 6f);
        //这个是处理颜色的。可以看源码的那个枚举。  
        //args.Add("NamedValueColor", "_SpecColor");
        //延迟执行时间  
        //args.Add("delay", 0.1f);

        //是否让游戏对象始终面朝路径行进的方向，拐弯的地方会自动旋转。  
        //    args.Add("orienttopath", true);
        //移动的过程中面朝一个点，当“orienttopath”为true时该参数失效 

        // args.Add("looktarget", Vector3.zero);
        //游戏对象看向“looktarget”的秒数。  
        // args.Add("looktime", 1.1);


        //游戏对象移动的路径可以为Vector3[]或Transform[] 类型。可通过iTweenPath编辑获取路径  
        //Vector3[] testPath = { new Vector3(0, 0, 0), new Vector3(0, 1, 0), new Vector3(0, 1, 1), new Vector3(1, 1, 1), new Vector3(1, 5, 1) };
        //args.Add("path", testPath);
        args.Add("path", iTweenPath.GetPath(gameObject.name + "Path"));
        //是否移动到路径的起始位置（false：游戏对象立即处于路径的起始点，true：游戏对象将从原是位置移动到路径的起始点）  
        args.Add("movetopath", false);

        //当包含“path”参数且“orienttopath”为true时，该值用于计算“looktarget”的值，表示游戏物体看着前方点的位置，（百分比，默认0.05）  
        // args.Add("lookahead", 100);

        //限制仅在指定的轴上旋转  
        // args.Add("axis", "z");
        //是否使用局部坐标(默认为false)  
        args.Add("islocal", false);


        //args.Add("oncomplete", "AnimationEnd");
        //args.Add("oncompleteparams", "end");
        //args.Add("oncompletetarget", gameObject);
        //三个循环类型 none loop pingPong (一般 循环 来回)    
        //args.Add("loopType", "none");  
        //args.Add("loopType", "loop");   
        //args.Add("loopType", iTween.LoopType.pingPong);
        args.Add("loopType", "loop");
        iTween.MoveTo(gameObject, args);
    }
    static Vector3 NewVector3(float x, float y, float z)
    {
        Vector3 test = new Vector3(x, y, z);
        return test;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name != "horse1" && collision.gameObject.name != "horse2" && collision.gameObject.name != "horse3")
        {			
            if (turn == true && collision.gameObject.name == "Wall_Left" )
            {
                sortorder = 0;
                MyRenderer.sortingOrder = sortorder;
                turn = false;
                Hashtable argsrota = new Hashtable();

                argsrota.Add("rotation", new Vector3(0, 0, 0));
                argsrota.Add("x", 0);
                argsrota.Add("y", 180);
                argsrota.Add("z", 0);
                //argsrota.Add("islocal", true);

                argsrota.Add("time", 2.5f);

                argsrota.Add("easeType", iTween.EaseType.linear);

                argsrota.Add("loopType", iTween.LoopType.none);

                iTween.RotateAdd(gameObject, argsrota);

                Debug.Log(gameObject.name + " rota " + collision.gameObject.name+ gameObject.layer);
            }
            else if (turn==false&& collision.gameObject.name == "Wall_Right")
            {
                sortorder = 2;
                MyRenderer.sortingOrder = sortorder;
                turn = true;
                Hashtable argsrota = new Hashtable();

                argsrota.Add("rotation", new Vector3(0, 0, 0));
                argsrota.Add("x", 0);
                argsrota.Add("y", -180);
                argsrota.Add("z", 0);
                //argsrota.Add("islocal", true);

                argsrota.Add("time", 2.5f);

                argsrota.Add("easeType", iTween.EaseType.linear);

                argsrota.Add("loopType", iTween.LoopType.none);

                iTween.RotateAdd(gameObject, argsrota);

                Debug.Log(gameObject.name + " rota " + collision.gameObject.name+ gameObject.layer);
            }
        }
    }
    void Update () {
        ////TimerX += 0.02f;
        //TimerY += 0.05f;
        //Vector3 rPos = pos;
        //rPos.x = rPos.x + Mathf.Cos(TimerX) * 10f;
        //rPos.y = rPos.y - (Mathf.Sin(TimerY)) * 1.5f;
        //if (rPos.x>=GameObject.Find("background2").transform.position.x + 7)
        //{
        //    transform.rotation=Quaternion.Euler(0f, 0f, 0f);
        //}
        //else if (rPos.x <= GameObject.Find("background2").transform.position.x - 7)
        //{
        //    transform.rotation=Quaternion.Euler(0f,180f,0f);
            
            
        //}
        ////Debug.Log((int)(Mathf.Cos(TimerX) * 100));
        //transform.position = rPos;
    }
}
