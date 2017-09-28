using UnityEngine;
using System.Collections;

public class test2 : MonoBehaviour {

	//float time = 0;

//	test1 test;

	void Awake(){
		//Debug.Log (gameObject.GetComponent<test1> ().ok);
	}


	void Start () {
		
//		test = gameObject.AddComponent<test1> ();
//		gameObject.AddComponent<Rigidbody> ();
//		Debug.Log (gameObject.GetComponent<Rigidbody> ());
//		int x = gameObject.GetComponent<test1> ().ok;


//		test = gameObject.AddComponent<test1>();
//		int x  = gameObject.GetComponent<test1> ().ok;
//

//		run ();

//		test = gameObject.GetComponent<test1> ();

//		test.abc [0] = 1;
//		test.abc [1] = 2;
//		test.abc [2] = 3;
//
	}
	void Update(){
//		//Debug.Log (test.go ());
//		time += Time.deltaTime;
//		if (time > 3) {
////			Destroy (gameObject);
////			gameObject.GetComponent<Rigidbody>().useGravity = false;
//			Debug.Log ("testestset");
//		}
	}

	/// <summary>
	/// 跑跑跑跑
	/// </summary>
//	void run(){
//		
//	}
}
/*
using ProgressBar.Utils;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace ProgressBar
{
    /// <summary>
    /// This Script is directed at radially progressing designs.
    /// </summary>
    [RequireComponent(typeof(Image))]
    public class ProgressRadialBehaviour : MonoBehaviour
    {
        /// <summary>
        /// This script's Filler is its own Image component
        /// </summary>
        private Image m_Fill;

        /// <summary>
        /// Current value as a fraction of Filling.
        /// </summary>
        private float m_Value;

        /// <summary>
        /// This is the core of the Filler animation. If there is a difference between m_Value and TransitoryValue,
        /// the latter will play catch up in the Update Method.
        /// </summary>
        /// <remarks>
        /// Keep in mind that this means that you get the actual Filler value from the property Value only,
        /// If the animation is playing, TransitoryValue will be different until it catches up.
        /// </remarks>
		public float TransitoryValue {get;private set;}


        /// <summary>
        /// In pixels per seconds, the speed at which the Filler will be animated.
        /// </summary>
        public float ProgressSpeed;

        void Start()
        {
            m_Fill = GetComponent<Image>();
            m_Value = 1;//設定開關
            SetFillerSize(0);
        }

        void Update()
        {
			
            //If theses two values aren't equals this means m_Value has been updated and the animation needs to start.
            if (TransitoryValue != m_Value)
            {
                //The difference between the two values.
                float Dvalue = m_Value - TransitoryValue;


                //If the difference is positive:
                //  TransitoryValue needs to be incremented.
                if (Dvalue > 0)
				{
					TransitoryValue += (1f/show.maxvalue)* Time.deltaTime;
                    if (TransitoryValue >= m_Value)
                        TransitoryValue = m_Value;
                }
                //If the difference is negative:
                //  TransitoryValue needs to be decremented.
                else if (Dvalue < 0)
                {
					TransitoryValue -= (1f/show.maxvalue) * Time.deltaTime;
                    if (TransitoryValue <= m_Value)
                        TransitoryValue = m_Value;
                }

                //Clamping:
                //  If the TransitoryValue is now over the max value we set it to be equal to it.
                if (TransitoryValue >= 1)
                    TransitoryValue = 1;
                //  If the TransitoryValue is inferior to zero, we set it to zero
                else if (TransitoryValue < 0)
                    TransitoryValue = 0;

                //We set the Filler to be the new value
                //We don't pass the value as a percentage because we directly use SetFillerSize here which takes a fraction as a parameter.
                SetFillerSize(TransitoryValue);

            }
        }

        /// <summary>
        /// This method is used to set the Fill amount
        /// </summary>
        /// <param name="fill">new Fill amount as a fraction</param>
        public void SetFillerSize(float fill){
          m_Fill.fillAmount = fill;
        }

    }
}


		void GameObjectFind(){
//			time = GameObject.Find ("timelabel").GetComponent<GUIText> ();
			//level = GameObject.Find ("Level").GetComponent<GUIText> ();
		}



//原本UFO移動程式碼

using UnityEngine;
using System.Collections;
using System.Collections.Specialized;

//[ExecuteInEditMode]
public class click : MonoBehaviour {
	public static int interval;//UFO間距
	//public GameObject obj;//UFO遊戲物件
	public int nameID;//UFO的ID
    new string name;//UFO名稱
    bool move = false;//UFO移動開關
	public static bool checkmove = true;//UFO移動指標

	//UFO X,Y軸
	int posx=-1300;
	int posy=-600;
	//UFO縮小大小
	float UFOScale = 0.6f;
	//UFO間隔
	int intervalplus = 500;

	Vector2 current;


	void Start () {
		//取得當前UFO位置
		current = transform.position;
		interval=0;



	}
		
	void Update () {
		if (move) {    //UFO移動開關預設false
			MoveUFO ();
		}
	}

	//滑鼠點擊事件
	void OnMouseDown(){
		//if (checkmoveTorF ()) {
			//gameObject.SetActive(false);//點擊後消失
			name = gameObject.name;//紀錄點擊物件名稱
			show.orderlist (name, nameID);//傳送物件名稱、ID至orderlist
			//move = true;//開啟移動開關



			iTween.MoveTo(gameObject,iTween.Hash("position",new Vector3(-1200+interval,-500,0),"time",1));

			click.interval += intervalplus;
//			checkmove = false;
//
//			//StartCoroutine (wait ());
//			checkmove = true;

		//}
	}

///判斷一次移動一個UFO
// bool checkmoveTorF(){
//		if ((!move && !checkmove)||(move && checkmove)) {
//			checkmove = true;
//			return true;
//		}
//		else
//			return false;
	//}

	///移動+縮小UFO到下方
	//void MoveUFO(){
//		GameObject pos= GameObject.Find (gameObject.name);                                  //移動速度
//		current = Vector2.MoveTowards (current, new  Vector2(posx+click.interval,posy), 70f);
//		if (pos.transform.localScale.x > UFOScale && gameObject.transform.localScale.y > UFOScale) {
//				for(int i=0;i<=3;i++){pos.transform.localScale -= new Vector3 (0.01f, 0.01f, 0);}
//			}
//		if(pos.transform.position.y <= posy && pos.transform.localScale.x <= UFOScale){
//				move = false;
//			    checkmove = false;
//			}
//		pos.transform.position = current;
	//}
}

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class Bingo : MonoBehaviour {

	//設定GUIText
	private GUIText gui = new GUIText();
	private Vector3 pos;
	//GUIText移動函數時間軸
	private float timer; 
	public static int levelnumber=1;

	void Start () {
//		//GUIText函數時間週期
//		timer = 2f;
//		//取得GUIText位置
//		pos = transform.position;
//		gui = gameObject.GetComponent<GUIText> ();

	}
		

	void Update () {
//		Vector3 rPos = pos;
//
//		timer += (Time.deltaTime);
//
//		//讓GUIText從左到右跑
//		rPos.x = rPos.x + Mathf.Tan (timer) * 0.25f;
//
//		//顯示GUIText的文字
//		gui.text = "你答對了"+show.BingoCount+"題";
//
//	    //持續更新GUIText位置
//		transform.position = rPos;
//
//	    //GUIText由左往右跑後消失
//		if (timer>4.5) {             //好像不能加 == 
//			gameObject.SetActive(false);
//			if (show.maxvalue < 5) {
//				show.maxvalue++;
//				levelnumber++;
//			}
//			
//			SceneManager.LoadScene ("text");
//			Resources.UnloadUnusedAssets ();
//			click.clickopen = false;//前置倒數完成使滑鼠能點擊
//			//Destroy(gameObject);
//		}
	}
}
using UnityEngine;
using System.Collections;

public class show : MonoBehaviour
{
	public GameObject[] obj = new GameObject[10];//建立UFO遊戲物件
	public GameObject showbingo;//GUIText-Bingo
	public static int BingoCount;//點擊UFO正確數量
	public static int AnswerCount;//點擊UFO數量
	bool CheckTheSameTorF = true;//確認順序開關
	private float time;//每秒UFO亮燈計秒

	//製作介於minvalue到maxvalue之間的不重複亂數
	private static int minvalue = 1;//大於等於1 
	public static int maxvalue = 3 ;//小於6
	int [] sequence = new int[maxvalue];
	int [] RandomArr = new int[maxvalue];
	public static string[] order = new string[5];//點擊物件名稱順序表
	public static int[] orderID = new int[5];//點擊物件ID順序表
	private static int ordernumber;//物件順序表旗標


	Bingo bingo;


	[SerializeField] private Sprite Sprite;


//	GameObject love;

	void Start (){
		
		time = 1;
		BingoCount = 0;
		ordernumber = 0;
		AnswerCount = 0;
		makeRandomArr();
		prefab ();//hearts prefab



	for(int i=maxvalue;i<(obj.Length/2);i++) {
			obj [i].SetActive (false);
		}
	}

	void Update (){
		//當點擊數量到達UFO數量時，開始確認順序and關閉計時器
		if ((AnswerCount == maxvalue)&&CheckTheSameTorF) {
			CheckTheSame ();//確認點擊順序與隨機順序是否一致
			CheckTheSameTorF = false;
			ProgressBar.ProgressRadialBehaviour.TimeCount = false;//計時停止
		}
	}
		
	void FixedUpdate(){
		//速度7以上幾乎看不見
//		time += 3*Time.deltaTime;
//		time += Time.deltaTime;
//		//每秒顯示隨機UFO
//		switch ((int)time) {
//		case 1:
//			Debug.Log (RandomArr [0]);
//			obj [RandomArr[0]+4].SetActive (true);
//			break;
//		case 2:
//			Debug.Log (RandomArr [1]);
//			obj [RandomArr[1]+4].SetActive (true);
//			obj [RandomArr[0]+4].SetActive (false);
//			break;
//		case 3:
//			Debug.Log (RandomArr [2]);
//			obj [RandomArr[2]+4].SetActive (true);
//			obj [RandomArr[1]+4].SetActive (false);
//			break;
//		case 4:
//			if (maxvalue > 3) {
//				Debug.Log (RandomArr [3]);
//				obj [RandomArr [3] + 4].SetActive (true);
//				obj [RandomArr [2] + 4].SetActive (false);
//				break;
//			} else
//				goto default;
//		case 5:
//			if (maxvalue > 4) {
//				Debug.Log (RandomArr [4]);
//				obj [RandomArr [4] + 4].SetActive (true);
//				obj [RandomArr [3] + 4].SetActive (false);
//				break;
//			} else
//				goto default;
//		default:
//			for (int i = maxvalue; i < obj.Length; i++) {
//				//obj [i].SetActive (false);
//				Destroy (obj [i]);//Destroy全部UFO
//			}
//			break;
//		}

		GameObject.Find("New Sprite").GetComponent<SpriteRenderer> ().sprite = Sprite;
	






	}


	///製作隨機亂數
	void makeRandomArr(){
		for (int i = 0; i < RandomArr.Length; i++) {
			sequence [i] = i+1;
		}
		int end = RandomArr.Length-1;
		for (int i = 0; i < RandomArr.Length; i++) {
			int num = Random.Range (0, end+1);
			RandomArr[i] = sequence [num];
			sequence[num]=sequence[end];
			end--;
		}
	}

	///顯示隨機亂數
	public void ShowRandom (){
		foreach (int Arr in RandomArr) {
			Debug.Log (Arr);
		}
	}

    ///顯示所有隱藏圖UFO
	public void ShowAll (){
		for (int i = 0; i < maxvalue; i++) {
			obj [i].SetActive (true);
		}		
	}

	///點擊物件名稱順序表
	public  static  void orderlist (string name,int nameID){
		if (name != null) {
			order [ordernumber] = name;
			orderID [ordernumber] = nameID;
			ordernumber++;
			AnswerCount++;
		if (ordernumber > maxvalue - 1)
				ordernumber = 0;
		}
	}

	///顯示點擊物件名稱順序表
	public void showorderlist (){	
		for (int i = 0; i < maxvalue; i++) {
			Debug.Log (order [i]);
		}
	}		

	//確認點擊順序與隨機順序是否一致
	public void CheckTheSame(){
		print("點擊"+AnswerCount+"個開始確認");
		for (int i = 0; i < maxvalue; i++) {
			if (orderID[i] == RandomArr [i]) {
				BingoCount++;
			}
		}
//		if(BingoCount != AnswerCount){
//			GameObject heart = GameObject.Find("hearts"+5);
//			Destroy (heart);
//			TimerGUIText.index--;
//		}

		//掛載Bingo腳本，顯示"checked"打勾
		bingo = gameObject.AddComponent<Bingo> ();

	}

	void prefab(){
		// Quaternion.identity( READ ONLY) : 毫無旋轉，回歸原始旋轉值，簡單來說就rotation(0,0,0)
		//Instantiate (love,new Vector2(love.transform.position.x+20,love.transform.position.y),Quaternion.identity);

//		love = GameObject.Find("hearts");

		for(int i=1;i<=ProgressBar.ProgressRadialBehaviour.index;i++){
			GameObject obj = Instantiate (Resources.Load("hearts"), new Vector2(-1450+(i*140),710), transform.rotation)as GameObject;
			obj.name = "hearts"+i;
		}
	}
}

		//GameObject.Find("New Sprite").GetComponent<SpriteRenderer> ().sprite = Sprite;


		// Quaternion.identity( READ ONLY) : 毫無旋轉，回歸原始旋轉值，簡單來說就rotation(0,0,0)
		//Instantiate (love,new Vector2(love.transform.position.x+20,love.transform.position.y),Quaternion.identity);


using UnityEngine;
using System.Collections;

public class camera2 : MonoBehaviour {

	[SerializeField]private GameObject target;//Camera要面向的物件
	[SerializeField]private float speed;//相機環繞移動的速度
	private Vector3 cameraPosition;//相機要移動的位置
	private float number;
	[SerializeField] private float radius;//移動的半徑

	private void Start ()
	{
		//由於我這個範例是x和z軸的移動，而y軸不會改變，所以要先設定好y軸的初始位置
		//		cameraPosition.y = gameObject.transform.position.y;
		//		gameObject.transform.position = cameraPosition;

		//計算當前攝影機和目標物件的半徑
		radius = Vector3.Distance(target.transform.position, gameObject.transform.position);
	}


	private void Update ()
	{
		//使用Time.deltaTime，使得移動時更加平滑
		//將速度進行一定比例縮放，方便控制速度(縮放多少都隨意，自己覺得數值修改方便就好)
		number += Time.deltaTime * speed * 0.1f;

		//計算並設定新的x和y軸位置
		//負數是順時針旋轉，正數是逆時針旋轉
		cameraPosition.x = radius * Mathf.Cos(-number+180);
		cameraPosition.z = radius * Mathf.Sin(-number+180);
		gameObject.transform.position = cameraPosition;

		//使相機永遠面對著目標物件
		transform.LookAt(target.transform.position);

	
//gameObject.transform.RotateAround (obj.transform.localPosition, Vector3.up , speed * Time.deltaTime*10);
	}
}



		//速度控制
//		number += Time.deltaTime * speed;

		//計算並設定新的x和y軸位置
		//負數是順時針旋轉，正數是逆時針旋轉

//		cup_position1.x = radius * Mathf.Cos (number);
//		cup_position1.z = radius * Mathf.Sin (number);
//		cup1.transform.localPosition = cup_position1;
//
//		cup_position2.x = radius * Mathf.Cos (number+179.1f);
//		cup_position2.z = radius * Mathf.Sin (number+179.1f);
//		cup2.transform.localPosition = cup_position2;

		//使相機面對著目標物件
//		cup1.transform.LookAt(obj.transform.position);
//		cup2.transform.LookAt(obj.transform.position);


//		circle.transform.Rotate(new Vector3 (0f, -1.5f, 0f));
using UnityEngine;
using System.Collections;

public class MakeUFO : MonoBehaviour {

	public GameObject obj;
	public GameObject obj2;

	// Use this for initialization
	void Start (){
		//GameObject.Find("UI Root (3D)").transform.parent = Instantiate (Resources.Load("UFO_group"),new Vector3(0,496,0),transform.rotation)as Transform;
		GameObject k = NGUITools.AddChild (obj,Resources.Load("Display"));

	//Instantiate (Resources.Load("hearts"), new Vector2(-1450+(i*140),710), transform.rotation)as GameObject;
		//UIPanel ui = NGUITools.FindInParents<UIPanel>(Panel);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Display : MonoBehaviour {

	[SerializeField]private GameObject Panel;
	[SerializeField]private GameObject prefab;
	public static int ReferencePoint = 0;



	public class ClickEvent{
		bool op  = true;
		int i = 0;
		public void Action(GameObject obj){
			Debug.Log(obj.name);

			i++;
			switch(i){
			case 1:
				obj.GetComponent<TweenPosition> ().from = new Vector3 (ReferencePoint, -316, 0);
				obj.GetComponent<TweenPosition>().to = obj.transform.localPosition;
				ReferencePoint += 150;
			    break;
			default:
				ReferencePoint -= 150;
				i = 0;
				break;
			}
//
//			if(op){
////				obj.GetComponent<TweenPosition> ().from = obj.transform.localPosition;
////				obj.GetComponent<TweenPosition>().to = new Vector3 (0, -316, 0);
//				obj.GetComponent<TweenPosition> ().from = new Vector3 (0, -316, 0);
//				obj.GetComponent<TweenPosition>().to = obj.transform.localPosition;
//				ReferencePoint += 150;
//				op = false;
//			}
//			iTween.MoveTo (obj, iTween.Hash ("position", new Vector3 (0,-319f,0), "islocal", true,"easetype",iTween.EaseType.easeOutBack,"time",0.5));
		}
	}

	void Start (){		
		//NGUITools.AddChild (Panel,prefab);

		UIEventListener.Get(GameObject.Find("UFO-0")).onClick = new ClickEvent().Action;
		UIEventListener.Get(GameObject.Find("UFO-1")).onClick = new ClickEvent().Action;
		UIEventListener.Get(GameObject.Find("UFO-2")).onClick = new ClickEvent().Action;
	  //UIEventListener.Get(GameObject.Find("UFO-2")).onClick = new ClickEvent(GameObject.Find("UFO-2")).Action;
	}


	void Update () {

	}

	public void OpenBoxCollider(){
		GameObject.Find("UFO-0").GetComponent<BoxCollider> ().enabled = true;
		GameObject.Find("UFO-1").GetComponent<BoxCollider> ().enabled = true;
		GameObject.Find("UFO-2").GetComponent<BoxCollider> ().enabled = true;
		GameObject.Find("UFO-0").GetComponent<TweenPosition> ().duration = 0.5f;
		GameObject.Find("UFO-1").GetComponent<TweenPosition> ().duration = 0.5f;
		GameObject.Find("UFO-2").GetComponent<TweenPosition> ().duration = 0.5f;
		GameObject.Find("UFO-0").GetComponent<TweenPosition>().delay = 0f;
		GameObject.Find("UFO-1").GetComponent<TweenPosition>().delay = 0f;
		GameObject.Find("UFO-2").GetComponent<TweenPosition>().delay = 0f;
//		UIEventListener.Get(GameObject.Find("UFO-1")).GetComponent<BoxCollider> ().enabled = true;
//		UIEventListener.Get(GameObject.Find("UFO-2")).GetComponent<BoxCollider> ().enabled = true;

	}
}
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Display : MonoBehaviour {

	[SerializeField]private GameObject Panel;
	[SerializeField]private GameObject prefab;
	public static int ReferencePoint = -200;
	public static int interval = 200;


	public class ClickEvent{
		int i = 0;
		public void Action(GameObject obj){
			Debug.Log(obj.name);

			i++;
			switch(i){
			case 1:
				obj.GetComponent<TweenPosition> ().from = new Vector3 (ReferencePoint, -316, 0);
				obj.GetComponent<TweenPosition>().to = obj.transform.localPosition;
				ReferencePoint += interval;
			    break;
			default:
				ReferencePoint -= interval;
				i = 0;
				break;
			}
		}
	}

	void Start (){		
		//NGUITools.AddChild (Panel,prefab);

		UIEventListener.Get(GameObject.Find("UFO-0")).onClick = new ClickEvent().Action;
		UIEventListener.Get(GameObject.Find("UFO-1")).onClick = new ClickEvent().Action;
		UIEventListener.Get(GameObject.Find("UFO-2")).onClick = new ClickEvent().Action;
//      UIEventListener.Get (GameObject.Find ("UFO-0")).onClick = new Display.ClickEvent ().Action;

//		//汽車
//		Car BMW = new Car();
//		BMW.Fly(30);
//
//
//		//小鳥
//		Bird bird1 = new Bird();
//		bird1.Fly(5);
//	
//		//機車
//		Motocycle Yamaha = new Motocycle();
//		Yamaha.Add_Oil(6);  //加油
//		Yamaha.Fly(10);   //實作IFly

	}


	void Update () {

	}


	class box{
		public box(GameObject obj){
			obj.GetComponent<BoxCollider> ().enabled = true;
			obj.GetComponent<TweenPosition> ().duration = 0.5f;
			obj.GetComponent<TweenPosition>().delay = 0f;
		}
	}


	public void OpenBoxCollider(){
		new box (GameObject.Find ("UFO-0"));
		new box (GameObject.Find ("UFO-1"));
		new box (GameObject.Find ("UFO-2"));


//		GameObject.Find("UFO-0").GetComponent<BoxCollider> ().enabled = true;
//		GameObject.Find("UFO-1").GetComponent<BoxCollider> ().enabled = true;
//		GameObject.Find("UFO-2").GetComponent<BoxCollider> ().enabled = true;
//		GameObject.Find("UFO-0").GetComponent<TweenPosition> ().duration = 0.5f;
//		GameObject.Find("UFO-1").GetComponent<TweenPosition> ().duration = 0.5f;
//		GameObject.Find("UFO-2").GetComponent<TweenPosition> ().duration = 0.5f;
//		GameObject.Find("UFO-0").GetComponent<TweenPosition>().delay = 0f;
//		GameObject.Find("UFO-1").GetComponent<TweenPosition>().delay = 0f;
//		GameObject.Find("UFO-2").GetComponent<TweenPosition>().delay = 0f;
//		UIEventListener.Get(GameObject.Find("UFO-1")).GetComponent<BoxCollider> ().enabled = true;




	}




//
//	interface IFly //定義IFly介面 
//	{
//		void Fly(int n); //宣告Fly方法
//	}
//	class Car : IFly    //Car類別實作IFly介面
//	{
//		public void SpeedUp(int n)
//		{
//			Debug.Log("車子加速前進 {0} 公里"+n);
//		}
//		//Car類別的Fly方法實作IFly介面的Fly方法
//
//		public void Fly(int n)
//		{
//			Debug.Log("車子飛上天前進 {0} 公里"+n);
//		}
//	}
//	class Bird : IFly //Bird類別實作IFly介面
//	{
//		public void Eat(int n)
//		{
//			Debug.Log("小鳥吃了 {0} 公斤的飼料"+n);
//		}
//		//Bird類別的Fly方法實作IFly介面的Fly方法
//		public void Fly(int n)
//		{
//			Debug.Log("小鳥飛上天前進 {0} 公里"+n);
//		}
//	}
//	class Motocycle : IFly //Motocycle類別實作IFly介面
//	{
//		public void Add_Oil(int n)
//		{
//			Debug.Log("機車加油 {0} 公升 "+n);
//		}
//		//Motocycle類別的Fly方法實作IFly介面的Fly方法
//		public void Fly(int n)
//		{
//			Debug.Log("機車飛上天前進 {0} 公里"+n);
//		}
//	}
}
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Display : MonoBehaviour {

	[SerializeField]private GameObject Panel;
	[SerializeField]private GameObject prefab;
	public static int ReferencePoint = -200;
	public static int interval = 200;


	public class ClickEvent{
		int i = 0;
		public void Action(GameObject obj){
			Debug.Log(obj.name);

			i++;
			switch(i){
			case 1:
				obj.GetComponent<TweenPosition> ().from = new Vector3 (ReferencePoint, -316, 0);
				obj.GetComponent<TweenPosition>().to = obj.transform.localPosition;
				ReferencePoint += interval;
			    break;
			default:
				ReferencePoint -= interval;
				i = 0;
				break;
			}
		}
	}

	void Start (){		
		//NGUITools.AddChild (Panel,prefab);

		UIEventListener.Get(GameObject.Find("UFO-0")).onClick = new ClickEvent().Action;
		UIEventListener.Get(GameObject.Find("UFO-1")).onClick = new ClickEvent().Action;
		UIEventListener.Get(GameObject.Find("UFO-2")).onClick = new ClickEvent().Action;
//      UIEventListener.Get (GameObject.Find ("UFO-0")).onClick = new Display.ClickEvent ().Action;

//		//汽車
//		Car BMW = new Car();
//		BMW.Fly(30);
//
//
//		//小鳥
//		Bird bird1 = new Bird();
//		bird1.Fly(5);
//	
//		//機車
//		Motocycle Yamaha = new Motocycle();
//		Yamaha.Add_Oil(6);  //加油
//		Yamaha.Fly(10);   //實作IFly

	}


	void Update () {

	}


	class ClickTweenset{
		public ClickTweenset(int key){
			for(int i=0;i<=key;i++){
				GameObject.Find ("UFO-"+i).GetComponent<BoxCollider> ().enabled = true;
				GameObject.Find ("UFO-"+i).GetComponent<TweenPosition> ().duration = 0.5f;
				GameObject.Find ("UFO-"+i).GetComponent<TweenPosition>().delay = 0f;
			}
		}
	}


	public void OpenBoxCollider(){
		new ClickTweenset (2);
//		new ClickTweenset (GameObject.Find ("UFO-1"));
//		new ClickTweenset (GameObject.Find ("UFO-2"));
	}




//
//	interface IFly //定義IFly介面 
//	{
//		void Fly(int n); //宣告Fly方法
//	}
//	class Car : IFly    //Car類別實作IFly介面
//	{
//		public void SpeedUp(int n)
//		{
//			Debug.Log("車子加速前進 {0} 公里"+n);
//		}
//		//Car類別的Fly方法實作IFly介面的Fly方法
//
//		public void Fly(int n)
//		{
//			Debug.Log("車子飛上天前進 {0} 公里"+n);
//		}
//	}
//	class Bird : IFly //Bird類別實作IFly介面
//	{
//		public void Eat(int n)
//		{
//			Debug.Log("小鳥吃了 {0} 公斤的飼料"+n);
//		}
//		//Bird類別的Fly方法實作IFly介面的Fly方法
//		public void Fly(int n)
//		{
//			Debug.Log("小鳥飛上天前進 {0} 公里"+n);
//		}
//	}
//	class Motocycle : IFly //Motocycle類別實作IFly介面
//	{
//		public void Add_Oil(int n)
//		{
//			Debug.Log("機車加油 {0} 公升 "+n);
//		}
//		//Motocycle類別的Fly方法實作IFly介面的Fly方法
//		public void Fly(int n)
//		{
//			Debug.Log("機車飛上天前進 {0} 公里"+n);
//		}
//	}
}
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Display : MonoBehaviour {

	[SerializeField]private GameObject Panel;
	[SerializeField]private GameObject prefab;
	public static int ReferencePoint = -200;
	public static int interval = 200;

	public static List<GameObject> UFO = new List<GameObject>();

	public class ClickEvent{
		int i = 0;
		static int j = -1;




		public void Action(GameObject obj){
			Debug.Log(obj.name);

			i++;


	 switch(i){
			case 1:
				obj.GetComponent<TweenPosition> ().from = new Vector3 (ReferencePoint, -316, 0);
				obj.GetComponent<TweenPosition> ().to = obj.transform.localPosition;
				ReferencePoint += interval;
				UFO.Add (obj);

				switch(j){
				case 0:
					UFO [0].GetComponent<BoxCollider> ().enabled = false;
					break;
				case 1:
					UFO [1].GetComponent<BoxCollider> ().enabled = false;
					break;
				}
//
//				if(j == 0)
//					UFO [0].GetComponent<BoxCollider> ().enabled = false;
//				if(j == 1)
//					UFO [1].GetComponent<BoxCollider> ().enabled = false;
				j++;
			    break;
			default:
				ReferencePoint -= interval;
				i = 0;
				j--;
				switch(j){
				  case 0:UFO [0].GetComponent<BoxCollider> ().enabled = true;break;
				  case 1:UFO [1].GetComponent<BoxCollider> ().enabled = true;break;
				}
//				if (j == 0)
//					UFO [0].GetComponent<BoxCollider> ().enabled = true;
//				if (j == 1)
//					UFO [1].GetComponent<BoxCollider> ().enabled = true;

				UFO.Remove (obj);

				break;
			}
		}
	}

	public void show(){
//		Debug.Log(UFO[0].name);
		foreach (GameObject obj in UFO) {
			Debug.Log (obj.name);
		}
	}


	void Start (){		
		//NGUITools.AddChild (Panel,prefab);

		UIEventListener.Get(GameObject.Find("UFO-0")).onClick = new ClickEvent().Action;
		UIEventListener.Get(GameObject.Find("UFO-1")).onClick = new ClickEvent().Action;
		UIEventListener.Get(GameObject.Find("UFO-2")).onClick = new ClickEvent().Action;
//      UIEventListener.Get (GameObject.Find ("UFO-0")).onClick = new Display.ClickEvent ().Action;


	}


	void Update () {

	}
		
	public void OpenBoxCollider(){
		for(int i=0;i<=2;i++){
			GameObject.Find ("UFO-"+i).GetComponent<BoxCollider> ().enabled = true;
			GameObject.Find ("UFO-"+i).GetComponent<TweenPosition> ().duration = 0.5f;
			GameObject.Find ("UFO-"+i).GetComponent<TweenPosition>().delay = 0f;
		}
	}
}
	public enum UFO_second : int{
		second1 = 1,
		second2 = 2,
		second3 = 3,
	}


	void Update () {

		time += Time.deltaTime;
		switch(Mathf.CeilToInt(time)){
		case (int)UFO_second.second1:
			UFO_second A = UFO_second.second1;
			Debug.Log (A);
			break;
		case (int)UFO_second.second2:
			UFO_second B = UFO_second.second2;
			Debug.Log (B);
			break;
		case (int)UFO_second.second3:
			UFO_second C = UFO_second.second3;
			Debug.Log (C);
			break;
		}
	}
		GameObject [] target;
		target = GameObject.FindGameObjectsWithTag ("UFO");
		for(int i=0;i<=2;i++) {
			target[i].GetComponent<BoxCollider> ().enabled = true;
			target[i].GetComponent<TweenPosition> ().duration = 0.5f;
			target[i].GetComponent<TweenPosition>().delay = 0f;
		}
		using UnityEngine;
using System.Collections;
using System.Collections.Generic;
 

public class Display : MonoBehaviour {

	[SerializeField]private GameObject Panel;
	[SerializeField]private GameObject prefab;
	public static int ReferencePoint = -200;//UFO移動至下方X軸之位置
	public static int interval = 200;//UFO間隔

	public static List<GameObject> UFO = new List<GameObject>();//UFO陣列

	int [] sequence = new int[3];
	int [] RandomArr = new int[3];


	private float time = -5;




	//點擊事件
	public class ClickEvent{
//		public bool op = true;
	    public static int j = -1;//BoxCollider開關

//		public  void iget(GameObject obj){
//			this.i = 0;
//		}

//		public bool iget{
//			get {return this.op;}
//			set {this.op = value;}
//		}

//		public void iget(){
//			this.op = true;
//		}

		public void Action(GameObject obj){
			Debug.Log(obj.name);





			if(obj.GetComponent<Listener> ().op){

				obj.GetComponent<TweenPosition> ().from = new Vector3 (ReferencePoint, -316, 0);
				obj.GetComponent<TweenPosition> ().to = obj.transform.localPosition;
				ReferencePoint += interval;
				UFO.Add (obj);

		switch(j){
				   case 0:UFO [0].GetComponent<BoxCollider> ().enabled = false;break;
				   case 1:UFO [1].GetComponent<BoxCollider> ().enabled = false;break;
				   case 2:UFO [2].GetComponent<BoxCollider> ().enabled = false;break;
		       }

				j++;
				obj.GetComponent<Listener> ().op = false;

			}else{
				ReferencePoint -= interval;
				obj.GetComponent<Listener> ().op = true;
				j--;
				switch (j) { 
				case 0:
					UFO [0].GetComponent<BoxCollider> ().enabled = true;
					break;
				case 1:
					UFO [1].GetComponent<BoxCollider> ().enabled = true;
					break;
				case 2:
					UFO [2].GetComponent<BoxCollider> ().enabled = true;
					break;
				}

				UFO.Remove (obj);
			}
		}
	}

	public void show(){
//		Debug.Log(UFO[0].name);
		foreach (GameObject obj in UFO) {
			Debug.Log (obj.name);
		}
	}


	void Start (){	
	
	


		//NGUITools.AddChild (Panel,prefab);
		makeRandomArr();


//		ClickEvent clk = new ClickEvent ();
//		ClickEvent clk2 = new ClickEvent ();
//
//		clk.iget = 10;
//		Debug.Log ("rrr"+clk.iget);
//
//		clk2.iget = 20;
//		Debug.Log ("2222"+clk2.iget);

		UIEventListener.Get(GameObject.Find("UFO-0")).onClick = new ClickEvent().Action;
		UIEventListener.Get(GameObject.Find("UFO-1")).onClick = new ClickEvent().Action;
		UIEventListener.Get(GameObject.Find("UFO-2")).onClick = new ClickEvent().Action;
//      UIEventListener.Get (GameObject.Find ("UFO-0")).onClick = new Display.ClickEvent ().Action;
	}

	public enum UFO_redlight : int{
		ufo0 = 0,
		ufo1 = 1,
		ufo2 = 2,
		ufo3 = 3,
		ufo4 = 4,
    	ufo0_red = 5,
		ufo1_red = 6,
		ufo2_red = 7,
		ufo3_red = 8,
		ufo4_red = 9,
	}


	void Update () {

		Debug.Log ("ReferencePoint"+ ReferencePoint);
//		Debug.Log ("interval"+ interval);

		time += Time.deltaTime;
		switch(Mathf.CeilToInt(time)){
		case 1:
			GameObject.Find ("UFO-"+RandomArr[0]).GetComponent<UITexture>().mainTexture = Resources.Load<Texture> ("UFO_light/" + (UFO_redlight)5);
			break;
		case 2:
			GameObject.Find ("UFO-"+RandomArr[1]).GetComponent<UITexture>().mainTexture = Resources.Load<Texture> ("UFO_light/" + (UFO_redlight)5);
			GameObject.Find ("UFO-"+RandomArr[0]).GetComponent<UITexture>().mainTexture = Resources.Load<Texture> ("UFO_light/" + (UFO_redlight)0);
			break;
		case 3:
			GameObject.Find ("UFO-"+RandomArr[2]).GetComponent<UITexture>().mainTexture = Resources.Load<Texture> ("UFO_light/" + (UFO_redlight)5);
			GameObject.Find ("UFO-"+RandomArr[1]).GetComponent<UITexture>().mainTexture = Resources.Load<Texture> ("UFO_light/" + (UFO_redlight)0);
			break;
		default:
			GameObject.Find ("UFO-"+RandomArr[2]).GetComponent<UITexture>().mainTexture = Resources.Load<Texture> ("UFO_light/" + (UFO_redlight)0);
			break;
		}
	}
		
	public void OpenBoxCollider(){
		GameObject [] target;
		target = GameObject.FindGameObjectsWithTag ("UFO");
		for(int i=0;i<=2;i++) {
			target[i].GetComponent<BoxCollider> ().enabled = true;
			target[i].GetComponent<TweenPosition> ().duration = 0.5f;
			target[i].GetComponent<TweenPosition>().delay = 0f;
		}
	}

	void makeRandomArr(){
		for (int i = 0; i < RandomArr.Length; i++) {
			sequence [i] = i;
		}
		int end = RandomArr.Length-1;
		for (int i = 0; i < RandomArr.Length; i++) {
			int num = Random.Range (0, end+1);
			RandomArr[i] = sequence [num];
			sequence[num]=sequence[end];
			end--;
		}

		//寫一個判斷兩次random值一樣的話在執行makeRandomArr一次

	}

	public void ShowRandom (){
		foreach (int Arr in RandomArr) {
			Debug.Log (Arr);
		}
	}

	public void restart(){
		time = -2;

		makeRandomArr();
	

		GameObject.Find (UFO[2].name).GetComponent<UIPlayTween> ().Play (true);
		GameObject.Find (UFO[1].name).GetComponent<UIPlayTween> ().Play (true);
		GameObject.Find (UFO[0].name).GetComponent<UIPlayTween> ().Play (true);

	
		GameObject.Find (UFO[2].name).GetComponent<Listener> ().op = true;
		GameObject.Find (UFO[1].name).GetComponent<Listener> ().op = true;
		GameObject.Find (UFO[0].name).GetComponent<Listener> ().op = true;

		GameObject.Find ("UFO-0").GetComponent<BoxCollider> ().enabled = true;
		GameObject.Find ("UFO-1").GetComponent<BoxCollider> ().enabled = true;
		GameObject.Find ("UFO-2").GetComponent<BoxCollider> ().enabled = true;


		ReferencePoint = -200;








		UFO.Clear ();

//		UIEventListener.Get (GameObject.Find ("UFO-0")).onSubmit = new ClickEvent ().iget;
//		UIEventListener.Get (GameObject.Find ("UFO-1")).onSubmit = new ClickEvent ().iget;
//		UIEventListener.Get (GameObject.Find ("UFO-2")).onSubmit = new ClickEvent ().iget;

		ClickEvent.j = -1;






	}

}
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
 

public class Display : MonoBehaviour {

	[SerializeField]private GameObject Panel;
	[SerializeField]private GameObject prefab;
	public static int ReferencePoint = -200;//UFO移動至下方X軸之位置
	public static int interval = 200;//UFO間隔

	public static List<GameObject> UFO = new List<GameObject>();//UFO陣列

	int [] sequence = new int[3];
	int [] RandomArr = new int[3];


	private float time = -5;




	//點擊事件
	public class ClickEvent{
//		public bool op = true;
	    public static int j = -1;//BoxCollider開關

//		public  void iget(GameObject obj){
//			this.i = 0;
//		}

//		public bool iget{
//			get {return this.op;}
//			set {this.op = value;}
//		}

//		public void iget(){
//			this.op = true;
//		}

		public void Action(GameObject obj){
			Debug.Log(obj.name);





			if(obj.GetComponent<Listener> ().op){

				obj.GetComponent<TweenPosition> ().from = new Vector3 (ReferencePoint, -316, 0);
				obj.GetComponent<TweenPosition> ().to = obj.transform.localPosition;
				ReferencePoint += interval;
				UFO.Add (obj);

		switch(j){
				   case 0:UFO [0].GetComponent<BoxCollider> ().enabled = false;break;
				   case 1:UFO [1].GetComponent<BoxCollider> ().enabled = false;break;
				   case 2:UFO [2].GetComponent<BoxCollider> ().enabled = false;break;
		       }

				j++;
				obj.GetComponent<Listener> ().op = false;

			}else{
				ReferencePoint -= interval;
				obj.GetComponent<Listener> ().op = true;
				j--;
				switch (j) { 
				case 0:
					UFO [0].GetComponent<BoxCollider> ().enabled = true;
					break;
				case 1:
					UFO [1].GetComponent<BoxCollider> ().enabled = true;
					break;
				case 2:
					UFO [2].GetComponent<BoxCollider> ().enabled = true;
					break;
				}

				UFO.Remove (obj);
			}
		}
	}

	public void show(){
//		Debug.Log(UFO[0].name);
		foreach (GameObject obj in UFO) {
			Debug.Log (obj.name);
		}
	}


	void Start (){	
	
	


		//NGUITools.AddChild (Panel,prefab);
		makeRandomArr();


//		ClickEvent clk = new ClickEvent ();
//		ClickEvent clk2 = new ClickEvent ();
//
//		clk.iget = 10;
//		Debug.Log ("rrr"+clk.iget);
//
//		clk2.iget = 20;
//		Debug.Log ("2222"+clk2.iget);

		UIEventListener.Get(GameObject.Find("UFO-0")).onClick = new ClickEvent().Action;
		UIEventListener.Get(GameObject.Find("UFO-1")).onClick = new ClickEvent().Action;
		UIEventListener.Get(GameObject.Find("UFO-2")).onClick = new ClickEvent().Action;
//      UIEventListener.Get (GameObject.Find ("UFO-0")).onClick = new Display.ClickEvent ().Action;
	}

	public enum UFO_redlight : int{
		ufo0 = 0,
		ufo1 = 1,
		ufo2 = 2,
		ufo3 = 3,
		ufo4 = 4,
    	ufo0_red = 5,
		ufo1_red = 6,
		ufo2_red = 7,
		ufo3_red = 8,
		ufo4_red = 9,
	}


	void Update () {

		Debug.Log ("ReferencePoint"+ ReferencePoint);
//		Debug.Log ("interval"+ interval);

		time += Time.deltaTime;
		switch(Mathf.CeilToInt(time)){
		case 1:
			GameObject.Find ("UFO-"+RandomArr[0]).GetComponent<UITexture>().mainTexture = Resources.Load<Texture> ("UFO_light/" + (UFO_redlight)5);
			break;
		case 2:
			GameObject.Find ("UFO-"+RandomArr[1]).GetComponent<UITexture>().mainTexture = Resources.Load<Texture> ("UFO_light/" + (UFO_redlight)5);
			GameObject.Find ("UFO-"+RandomArr[0]).GetComponent<UITexture>().mainTexture = Resources.Load<Texture> ("UFO_light/" + (UFO_redlight)0);
			break;
		case 3:
			GameObject.Find ("UFO-"+RandomArr[2]).GetComponent<UITexture>().mainTexture = Resources.Load<Texture> ("UFO_light/" + (UFO_redlight)5);
			GameObject.Find ("UFO-"+RandomArr[1]).GetComponent<UITexture>().mainTexture = Resources.Load<Texture> ("UFO_light/" + (UFO_redlight)0);
			break;
		default:
			GameObject.Find ("UFO-"+RandomArr[2]).GetComponent<UITexture>().mainTexture = Resources.Load<Texture> ("UFO_light/" + (UFO_redlight)0);
			break;
		}
	}
		
	public void OpenBoxCollider(){
		GameObject [] target;
		target = GameObject.FindGameObjectsWithTag ("UFO");
		for(int i=0;i<=2;i++) {
			target[i].GetComponent<BoxCollider> ().enabled = true;
			target[i].GetComponent<TweenPosition> ().duration = 0.5f;
			target[i].GetComponent<TweenPosition>().delay = 0f;
		}
	}

	void makeRandomArr(){
		for (int i = 0; i < RandomArr.Length; i++) {
			sequence [i] = i;
		}
		int end = RandomArr.Length-1;
		for (int i = 0; i < RandomArr.Length; i++) {
			int num = Random.Range (0, end+1);
			RandomArr[i] = sequence [num];
			sequence[num]=sequence[end];
			end--;
		}

		//寫一個判斷兩次random值一樣的話在執行makeRandomArr一次

	}

	public void ShowRandom (){
		foreach (int Arr in RandomArr) {
			Debug.Log (Arr);
		}
	}

	public void restart(){
		time = -2;

		makeRandomArr();
	
		for(int i=2;i>=0;i--){
			UFO[i].GetComponent<UIPlayTween> ().Play (true);
			UFO[i].GetComponent<Listener> ().op = true;
			UFO[i].GetComponent<BoxCollider> ().enabled = true;
		}



//		UFO[2].GetComponent<UIPlayTween> ().Play (true);
//		UFO[1].GetComponent<UIPlayTween> ().Play (true);
//		UFO[0].GetComponent<UIPlayTween> ().Play (true);
//
//		UFO[2].GetComponent<Listener> ().op = true;
//		UFO[1].GetComponent<Listener> ().op = true;
//		UFO[0].GetComponent<Listener> ().op = true;
//
//		UFO[2].GetComponent<BoxCollider> ().enabled = true;
//		UFO[1].GetComponent<BoxCollider> ().enabled = true;
//		UFO[0].GetComponent<BoxCollider> ().enabled = true;

//		GameObject.Find ("UFO-0").GetComponent<BoxCollider> ().enabled = true;
//		GameObject.Find ("UFO-1").GetComponent<BoxCollider> ().enabled = true;
//		GameObject.Find ("UFO-2").GetComponent<BoxCollider> ().enabled = true;


		ReferencePoint = -200;


		UFO.Clear ();


		ClickEvent.j = -1;






	}

}


  DieTimer dieTimer = newObject.AddComponent<DieTimer>() as DieTimer;
                dieTimer.SecondsToDie = Life;


[Header("Status")]
[Range(1,10)]
	public int speed =5;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Level2_display : MonoBehaviour
{

	[Header ("List")]
	public List<GameObject> ball_sequence = new List<GameObject> ();
	public List<GameObject> ball = new List<GameObject> ();

	[Header ("Material")]
	[SerializeField]private Material Red;

	public static Material TiffanyBlue_static;
	[SerializeField]private Material TiffanyBlue;

	public static Material Gray_static;
	[SerializeField]private Material Gray;

	public static int ball_Arr = 0;

	public GameObject Cylinder;


	void Awake ()
	{
		Gray_static = Gray;

		TiffanyBlue_static = TiffanyBlue;
	}


	public class ClickEvent
	{
		public void Action (GameObject obj)
		{
			Debug.Log (obj.name);

			if (obj.GetComponent<Renderer> ().material.color == TiffanyBlue_static.color)
				obj.GetComponent<Renderer> ().material = Gray_static;
			else
				obj.GetComponent<Renderer> ().material = TiffanyBlue_static;
		}
	}



	// Use this for initialization
	void Start ()
	{
		makeRandomArr ();
		InvokeRepeating ("ShowLight", 1f, 1f);

		UIEventListener.Get (ball [0]).onClick = new ClickEvent ().Action;
		UIEventListener.Get (ball [1]).onClick = new ClickEvent ().Action;
		UIEventListener.Get (ball [2]).onClick = new ClickEvent ().Action;
		UIEventListener.Get (ball [3]).onClick = new ClickEvent ().Action;
		UIEventListener.Get (ball [4]).onClick = new ClickEvent ().Action;
		UIEventListener.Get (ball [5]).onClick = new ClickEvent ().Action;
		UIEventListener.Get (ball [6]).onClick = new ClickEvent ().Action;
		UIEventListener.Get (ball [7]).onClick = new ClickEvent ().Action;
	}
	
	// Update is called once per frame
	void Update ()
	{
		gameObject.transform.LookAt (Cylinder.transform.position,Vector3.forward);
	}



	void makeRandomArr ()
	{
		for (int i = 0; i < 8; i++) {
			int num = Random.Range (0, ball_sequence.Count);
			ball.Add (ball_sequence [num]);
			ball_sequence [num] = ball_sequence [ball_sequence.Count - 1];
			ball_sequence.RemoveAt (ball_sequence.Count - 1);
		}
	}

	public void showarr ()
	{
		foreach (GameObject obj in ball) {
			Debug.Log (obj.name);
		}
	}

	public void ShowLight ()
	{
		if (ball_Arr == 8) {
			CancelInvoke ("ShowLight");
			ball [7].GetComponent<Renderer> ().material = TiffanyBlue;
		} else {
			if (ball_Arr != 0) {
				ball [ball_Arr].GetComponent<Renderer> ().material = Red;
				ball [ball_Arr - 1].GetComponent<Renderer> ().material = TiffanyBlue;
			} else {
				ball [ball_Arr].GetComponent<Renderer> ().material = Red;
			}
			ball_Arr++;
		}
	}


	public void CameraMove(){
		
//		gameObject.GetComponent<TweenPosition>().enabled = true;
//		gameObject.GetComponent<TweenOrthoSize> ().enabled = true;
		gameObject.GetComponent<UIPlayTween> ().Play (true);


	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Level2_display : MonoBehaviour
{
	[Header ("Object")]
	[SerializeField]private GameObject Panel;
	[SerializeField]private GameObject Bingo;
	[SerializeField]private GameObject Error;


	[Header ("List")]
	public List<GameObject> Ball_sequence = new List<GameObject> ();
	public List<GameObject> Ball_Random = new List<GameObject> ();
	public static List<GameObject> Ball = new List<GameObject> ();

	[Header ("Material")]
	[SerializeField]private Material Red;

	public static Material TiffanyBlue_static;
	[SerializeField]private Material TiffanyBlue;

	public static Material Gray_static;
	[SerializeField]private Material Gray;

	public static int ball_Arr = 0;

	bool compare = true;


	[Header ("LookAt")]
	//Camera將LookAt的中心點
	public GameObject Center;


	void Awake ()
	{
		Gray_static = Gray;

		TiffanyBlue_static = TiffanyBlue;
	}


	public class ClickEvent
	{
		public void Action (GameObject obj)
		{
			Debug.Log (obj.name);



			if (obj.GetComponent<Renderer> ().material.color == TiffanyBlue_static.color) {
				obj.GetComponent<Renderer> ().material = Gray_static;
				Ball.Add (obj);
			} else {
				obj.GetComponent<Renderer> ().material = TiffanyBlue_static;
				Ball.Remove (obj);
			}
		}
	}




	void Start ()
	{
		

		makeRandomArr ();
		InvokeRepeating ("ShowLight", 1f, 1f);

		UIEventListener.Get (Ball_Random [0]).onClick = new ClickEvent ().Action;
		UIEventListener.Get (Ball_Random [1]).onClick = new ClickEvent ().Action;
		UIEventListener.Get (Ball_Random [2]).onClick = new ClickEvent ().Action;
		UIEventListener.Get (Ball_Random [3]).onClick = new ClickEvent ().Action;
		UIEventListener.Get (Ball_Random [4]).onClick = new ClickEvent ().Action;
		UIEventListener.Get (Ball_Random [5]).onClick = new ClickEvent ().Action;
		UIEventListener.Get (Ball_Random [6]).onClick = new ClickEvent ().Action;
		UIEventListener.Get (Ball_Random [7]).onClick = new ClickEvent ().Action;

	

	}

//	delegate  GameObject Clone (GameObject obj);

	// Update is called once per frame
	void Update ()
	{
		gameObject.transform.LookAt (Center.transform.position, Vector3.forward);

		if (Ball.Count == 8 && compare) {
			
			GameObject clone;



			if (Ball.SequenceEqual (Ball_Random)) {
				//答對
				clone = NGUITools.AddChild (Panel, Bingo);
			} else {
				//答錯
				clone = NGUITools.AddChild (Panel, Error);
			}

			clone.transform.localPosition = new Vector3 (140729, 100632, 26417);
			clone.transform.Rotate (Vector3.right, 33.24981f);
			clone.transform.localScale = new Vector3 (25000, 25000, 0);
			iTween.ScaleFrom (clone, iTween.Hash ("scale", Vector3.zero, "delay", 0.2, "oncomplete", "DestroyClone", "oncompletetarget", gameObject, "oncompleteparams", clone));

			compare = false;
			Invoke ("restart", 1.5f);
		}

	}

	void DestroyClone (GameObject obj)
	{
		Destroy (obj);
	}


	public void restart ()
	{


		Ball [0].GetComponent<Renderer> ().material = TiffanyBlue_static;
		Ball [1].GetComponent<Renderer> ().material = TiffanyBlue_static;
		Ball [2].GetComponent<Renderer> ().material = TiffanyBlue_static;
		Ball [3].GetComponent<Renderer> ().material = TiffanyBlue_static;
		Ball [4].GetComponent<Renderer> ().material = TiffanyBlue_static;
		Ball [5].GetComponent<Renderer> ().material = TiffanyBlue_static;
		Ball [6].GetComponent<Renderer> ().material = TiffanyBlue_static;
		Ball [7].GetComponent<Renderer> ().material = TiffanyBlue_static;

		// This will copy all the items from Ball_Random to Ball_sequence
//		Ball_Random.ForEach (i => Ball_sequence.Add (i));
		Ball_sequence.AddRange (Ball_Random);

		Ball.Clear ();

		Ball_Random.Clear ();

//		compare = true;

		//找出可以複製Ball到Ball_Random的方法 
		//清空Ball

	}

	void makeRandomArr ()
	{
		for (int i = 0; i < 8; i++) {
			int num = Random.Range (0, Ball_sequence.Count);
			Ball_Random.Add (Ball_sequence [num]);
			Ball_sequence [num] = Ball_sequence [Ball_sequence.Count - 1];
			Ball_sequence.RemoveAt (Ball_sequence.Count - 1);
		}
	}

	public void showarr ()
	{
		foreach (GameObject obj in Ball_Random) {
			Debug.Log (obj.name);
		}
	}

	public void ShowLight ()
	{
		if (ball_Arr == 8) {
			CancelInvoke ("ShowLight");
			Ball_Random [7].GetComponent<Renderer> ().material = TiffanyBlue;
		} else {
			if (ball_Arr != 0) {
				Ball_Random [ball_Arr].GetComponent<Renderer> ().material = Red;
				Ball_Random [ball_Arr - 1].GetComponent<Renderer> ().material = TiffanyBlue;
			} else {
				Ball_Random [ball_Arr].GetComponent<Renderer> ().material = Red;
			}
			ball_Arr++;
		}
	}

	public void ShowClickBall ()
	{
		foreach (GameObject obj in Ball)
			Debug.Log (obj.name);
	}


	public void CameraMove ()
	{
		

		gameObject.GetComponent<UIPlayTween> ().Play (true);


	}
}



	delegate int test(int x);

	test t = (int y) => y + 5;
		Debug.Log (t (5));

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class level2test1 : MonoBehaviour
{
	public string myString = "Hello World";
	public bool group_timeEffect;
	public  bool isPermanent;
	bool isDividedOvertime;
	float duration;
	float tick;

	// Add menu item named "My Window" to the Window menu
	[MenuItem("Window/My Window")]
	public static void ShowWindow()
	{
		//Show existing window instance. If one doesn't exist, make one.
//		EditorWindow.GetWindow(typeof(level2test1));
	}

	void OnGUI()
	{
		GUILayout.Label("Base Settings", EditorStyles.boldLabel);
		myString = EditorGUILayout.TextField("Text Field", myString);
		group_timeEffect = EditorGUILayout.BeginToggleGroup("Time effect", group_timeEffect);
		EditorGUI.BeginDisabledGroup(isDividedOvertime); //<---
		isPermanent = EditorGUILayout.Toggle("Permanent", isPermanent);
		tick = EditorGUILayout.FloatField("Tick", tick);
		EditorGUI.EndDisabledGroup(); //<---
		EditorGUI.BeginDisabledGroup(isPermanent); //<---
		isDividedOvertime = EditorGUILayout.Toggle("Overtime", isDividedOvertime);
		duration = EditorGUILayout.FloatField("Duration", duration);
		EditorGUI.EndDisabledGroup(); //<---
		EditorGUILayout.EndToggleGroup();
	}


//	public bool boo;
//	bool   isTrue; 
//
//	void  OnInspectorGUI()    
//	{  
//		EditorGUILayout.Toggle("disable",isTrue); 
//
//		EditorGUI.BeginDisabledGroup(isTrue);   //如果nextPath == null為真，在Inspector面板上顯示，承灰色（即不可操作） 
//
//
//		 
//
//		EditorGUI.EndDisabledGroup();  
//
//	}     


//	public bool flag;
//	public int i = 1;
//	[CustomEditor (typeof(level2test1))]
//	public class MyScriptEditor : Editor
//	{
//		override public void OnInspectorGUI ()
//		{
//			level2test1 myScript = (level2test1)target;
//			
//			myScript.flag = GUILayout.Toggle (myScript.flag, "Flag");
//			
//			if (myScript.flag)
//				myScript.i = EditorGUILayout.IntSlider ("I field:", myScript.i, 1, 100);
//
//		}
//	}
//

	void Start ()
	{
		
	}
	

}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Level1_Display : MonoBehaviour
{

	[SerializeField]private GameObject Panel;
	[SerializeField]private GameObject prefab;

	//設定UFO
	[SerializeField]private GameObject UFO_0;
	[SerializeField]private GameObject UFO_1;
	[SerializeField]private GameObject UFO_2;

	//設定Bingo,Error圖
	[SerializeField]private GameObject Bingo;
	[SerializeField]private GameObject Error;

	//Timer物件
	[SerializeField]private Level1_Timer timer;

	///UFO移動至下方X軸之位置
	public static int ReferencePoint = -200;

	///UFO間隔
	public static int interval = 200;

	///UFO發光時間
	private float time = -5;

	///點擊UFO陣列，依序放入點擊UFO
	public static List<GameObject> UFO = new List<GameObject> ();

	///亂數UFO陣列，與點擊UFO比對
	public static List<GameObject> RandomUFO = new List<GameObject> ();


	///比對開關
	bool compare = true;

	//亂數元素
	int[] sequence = new int[3];
	int[] RandomArr = new int[3];


	//點擊事件
	public class ClickEvent
	{
		public static int j = -1;
		//BoxCollider開關
		public void Action (GameObject obj)
		{
			Debug.Log (obj.name);

			if (obj.GetComponent<Level1_Listener> ().op) {

				obj.GetComponent<TweenPosition> ().from = new Vector3 (ReferencePoint, -316, 0);
				obj.GetComponent<TweenPosition> ().to = obj.transform.localPosition;
				ReferencePoint += interval;
				UFO.Add (obj);

				switch (j) {
				case 0:
					UFO [0].GetComponent<BoxCollider> ().enabled = false;
					break;
				case 1:
					UFO [1].GetComponent<BoxCollider> ().enabled = false;
					break;
				case 2:
					UFO [2].GetComponent<BoxCollider> ().enabled = false;
					break;
				}

				j++;
				obj.GetComponent<Level1_Listener> ().op = false;

			} else {
				ReferencePoint -= interval;
				obj.GetComponent<Level1_Listener> ().op = true;
				j--;
				switch (j) { 
				case 0:
					UFO [0].GetComponent<BoxCollider> ().enabled = true;
					break;
				case 1:
					UFO [1].GetComponent<BoxCollider> ().enabled = true;
					break;
				case 2:
					UFO [2].GetComponent<BoxCollider> ().enabled = true;
					break;
				}
				UFO.Remove (obj);
			}
		}
	}

	void Start ()
	{
		//NGUITools.AddChild (Panel,prefab);

		//製作亂數
		makeRandomArr ();

		//Listener每個UFO
		UIEventListener.Get (UFO_0).onClick = new ClickEvent ().Action;
		UIEventListener.Get (UFO_1).onClick = new ClickEvent ().Action;
		UIEventListener.Get (UFO_2).onClick = new ClickEvent ().Action;
//      UIEventListener.Get (GameObject.Find ("UFO-0")).onClick = new Display.ClickEvent ().Action;
	}

	public enum UFO_redlight : int
	{
		ufo0 = 0,
		ufo1 = 1,
		ufo2 = 2,
		ufo3 = 3,
		ufo4 = 4,
		ufo0_red = 5,
		ufo1_red = 6,
		ufo2_red = 7,
		ufo3_red = 8,
		ufo4_red = 9,
	}

	bool LightToggle = true;

	void LightToggleOp ()
	{
		LightToggle = true;
	}

	void UFOLight (int i)
	{
		if (LightToggle) {
			switch (i) {
			case 1:
				GameObject.Find ("UFO-" + RandomArr [0]).GetComponent<UITexture> ().mainTexture = Resources.Load<Texture> ("JT/UFO_light/" + (UFO_redlight)5);
				GameObject.Find ("ProgressBar").GetComponent<Level1_Timer> ().enabled = true;
				RandomUFO.Add (GameObject.Find ("UFO-" + RandomArr [0]));
				LightToggle = false;
				Invoke ("LightToggleOp", 1f);
				timer.TimeReset ();
				break;
			case 2:
				GameObject.Find ("UFO-" + RandomArr [1]).GetComponent<UITexture> ().mainTexture = Resources.Load<Texture> ("JT/UFO_light/" + (UFO_redlight)5);
				GameObject.Find ("UFO-" + RandomArr [0]).GetComponent<UITexture> ().mainTexture = Resources.Load<Texture> ("JT/UFO_light/" + (UFO_redlight)0);
				RandomUFO.Add (GameObject.Find ("UFO-" + RandomArr [1]));
				LightToggle = false;
				Invoke ("LightToggleOp", 1f);
				break;
			case 3:
				GameObject.Find ("UFO-" + RandomArr [2]).GetComponent<UITexture> ().mainTexture = Resources.Load<Texture> ("JT/UFO_light/" + (UFO_redlight)5);
				GameObject.Find ("UFO-" + RandomArr [1]).GetComponent<UITexture> ().mainTexture = Resources.Load<Texture> ("JT/UFO_light/" + (UFO_redlight)0);
				RandomUFO.Add (GameObject.Find ("UFO-" + RandomArr [2]));
				LightToggle = false;
				Invoke ("LightToggleOp", 1f);
				break;
			case 4:
				GameObject.Find ("UFO-" + RandomArr [2]).GetComponent<UITexture> ().mainTexture = Resources.Load<Texture> ("JT/UFO_light/" + (UFO_redlight)0);
				OpenBoxCollider ();
				break;
			}
		}
	}


	void Update ()
	{

		//UFO發光
		time += Time.deltaTime;
		UFOLight (Mathf.CeilToInt (time));

		if (UFO.Count == 3 && compare) 
		{
			//比對陣列是否一致
			if (UFO.SequenceEqual (RandomUFO))
			{
				//答對
				GameObject clone = NGUITools.AddChild (Panel, Bingo);
				clone.transform.localScale = new Vector3 (140, 140, 0);
				iTween.ScaleFrom (clone, iTween.Hash ("scale", Vector3.zero, "delay", 0.2, "oncomplete", "DestroyClone", "oncompletetarget", gameObject, "oncompleteparams", clone));
				timer.pause ();
			} else
			
			{
				//答錯
				GameObject clone = NGUITools.AddChild (Panel, Error);
				clone.transform.localScale = new Vector3 (140, 140, 0);
				iTween.ScaleFrom (clone, iTween.Hash ("scale", Vector3.zero, "delay", 0.2, "oncomplete", "DestroyClone", "oncompletetarget", gameObject, "oncompleteparams", clone));
				timer.pause ();
			}
			compare = false;
			Invoke ("restart", 1f);
		}
	}




	//設定Tween數值
	public void OpenBoxCollider ()
	{
		GameObject[] target;
		target = GameObject.FindGameObjectsWithTag ("UFO");
		for (int i = 0; i <= 2; i++) {
			target [i].GetComponent<BoxCollider> ().enabled = true;
			target [i].GetComponent<TweenPosition> ().duration = 0.5f;
			target [i].GetComponent<TweenPosition> ().delay = 0f;
		}
	}

	//製作RandomArr陣列
	void makeRandomArr ()
	{
		for (int i = 0; i < RandomArr.Length; i++)
		{
			sequence [i] = i;
		}

		int end = RandomArr.Length - 1;

		for (int i = 0; i < RandomArr.Length; i++) 
		{
			int num = Random.Range (0, end + 1);
			RandomArr [i] = sequence [num];
			sequence [num] = sequence [end];
			end--;
		}
	}
		
	//顯示RandomArr陣列
	public void ShowRandom ()
	{
		foreach (int Arr in RandomArr)
			Debug.Log (Arr);
	}

	//顯示點擊UFO陣列
	public void ShowClickUFO ()
	{
		foreach (GameObject obj in UFO)
			Debug.Log (obj.name);
	}

	//顯示亂數UFO陣列
	public void ShowRandomUFO ()
	{
		foreach (GameObject obj in RandomUFO)
			Debug.Log (obj.name);
	}


	void DestroyClone (GameObject obj)
	{
		Destroy (obj);
		timer.rezero ();
	}


	public void restart ()
	{
		//重製UFO發光時間
		time = -2;

		//使前後亂數不同
		int[] check = (int[])RandomArr.Clone ();
		makeRandomArr ();
		if (RandomArr.SequenceEqual (check))
			makeRandomArr ();

		//重製UFO位置
		for (int i = 2; i >= 0; i--) {
			UFO [i].GetComponent<UIPlayTween> ().Play (true);
			UFO [i].GetComponent<Level1_Listener> ().op = true;
			UFO [i].GetComponent<BoxCollider> ().enabled = false;
		}

		//重製方X軸之位置
		ReferencePoint = -200;

		//清空點擊UFO陣列
		UFO.Clear ();

		//清空亂數UFO陣列
		RandomUFO.Clear ();


		//重製BoxCollider開關
		ClickEvent.j = -1;
		 
		//判斷RandomUFO與UFO 開關
		compare = true;
	
	}
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

public class Level1_Display : MonoBehaviour
{
	[Header ("Object")]
	[Tooltip ("UIRoot-Panel")]
	[SerializeField]protected GameObject Panel;
	[Tooltip ("BingoIcon")]
	[SerializeField]protected GameObject Bingo;
	[Tooltip ("ErrorIcon")]
	[SerializeField]protected GameObject Error;

	[Space (10)]

	[Header ("GameObject")]
	[Tooltip ("亂數序列")]
	public List<GameObject> UFO_sequence = new List<GameObject> ();
	[Tooltip ("亂數陣列")]
	public List<GameObject> UFO_Random = new List<GameObject> ();
	///點擊陣列
	public static List<GameObject> UFO = new List<GameObject> ();

	///比對開關
	protected bool compare = true;

	///UFO移動至下方X軸之位置
	public static int ReferencePoint = -200;

	///UFO間隔
	public static int interval = 200;

	/// UFO指標
	public static int UFO_Arr = 0;


	float time = 1f;


	//點擊事件
	public class ClickEvent
	{
		public static int j = -1;
		//BoxCollider開關
		public void Action (GameObject obj)
		{
			Debug.Log (obj.name);

			//掛上<Level1_Listener>腳本
			if (!obj.GetComponent<Level1_Listener> ())
				obj.AddComponent<Level1_Listener> ();

			//讓UFO能返回上一步
			if (obj.GetComponent<Level1_Listener> ().op) {
				//修改NGUI數值
				obj.GetComponent<TweenPosition> ().from = new Vector3 (ReferencePoint, -316, 0);
				obj.GetComponent<TweenPosition> ().to = obj.transform.localPosition;
				//指向下一個位置
				ReferencePoint += interval;
				//加入UFO陣列
				UFO.Add (obj);

				switch (j) {
				case 0:
					UFO [0].GetComponent<BoxCollider> ().enabled = false;
					break;
				case 1:
					UFO [1].GetComponent<BoxCollider> ().enabled = false;
					break;
				case 2:
					UFO [2].GetComponent<BoxCollider> ().enabled = false;
					break;
				case 3:
					UFO [3].GetComponent<BoxCollider> ().enabled = false;
					break;
				}

				j++;
				obj.GetComponent<Level1_Listener> ().op = false;

			} else {
				//指向上一個位置
				ReferencePoint -= interval;
				obj.GetComponent<Level1_Listener> ().op = true;
				j--;
				switch (j) { 
				case 0:
					UFO [0].GetComponent<BoxCollider> ().enabled = true;
					break;
				case 1:
					UFO [1].GetComponent<BoxCollider> ().enabled = true;
					break;
				case 2:
					UFO [2].GetComponent<BoxCollider> ().enabled = true;
					break;
				case 3:
					UFO [3].GetComponent<BoxCollider> ().enabled = true;
					break;
				}
				//從UFO陣列移除
				UFO.Remove (obj);
			}
		}
	}

	void Start ()
	{
		//設定初始值
		Initialization ();

		//製作亂數
		makeRandomArr (3);

		//Listen所有UFO
		UFO_Random.ForEach (i => UIEventListener.Get (i).onClick = new ClickEvent ().Action);

		//調用ShowLight方法 5秒後 1秒1次
		InvokeRepeating ("ShowLight", 5f, 1f);

	}

	void Update ()
	{
		AnswerCompare ();
	}

	public virtual void Initialization ()
	{
		Panel = GameObject.Find ("Panel");
		Bingo = Resources.Load<GameObject> ("JT/" + "checked-Bingo");
		Error = Resources.Load<GameObject> ("JT/" + "checked-Error");
		GameObject.Find ("UFO-3").SetActive (false);
		GameObject.Find ("UFO-4").SetActive (false);

		for (int i = 0; i < 3; i++) {
			UFO_sequence.Add (GameObject.Find ("UFO-" + i));
		}
	}

	protected void AnswerCompare ()
	{
		if (UFO.Count == UFO_Random.Count && compare) {
			//比對陣列是否一致
			if (UFO.SequenceEqual (UFO_Random)) {
				//答對
				GameObject clone = NGUITools.AddChild (Panel, Bingo);
				clone.transform.localScale = new Vector3 (140, 140, 0);
				iTween.ScaleFrom (clone, iTween.Hash ("scale", Vector3.zero, "delay", 0.2, "oncomplete", "DestroyClone", "oncompletetarget", gameObject, "oncompleteparams", clone));
				//				timer.pause ();
				Debug.Log ("yes");
			} else {
				//答錯
				GameObject clone = NGUITools.AddChild (Panel, Error);
				clone.transform.localScale = new Vector3 (140, 140, 0);
				iTween.ScaleFrom (clone, iTween.Hash ("scale", Vector3.zero, "delay", 0.2, "oncomplete", "DestroyClone", "oncompletetarget", gameObject, "oncompleteparams", clone));
				//				timer.pause ();
				Debug.Log ("no");
			}

			//關閉比較開關,使不會重複進行比對判斷
			compare = false;

			//1秒後調用restart()
			Invoke ("restart", 1f);
		}
	}


	protected void ShowLight ()
	{
		try {
			if (UFO_Arr == UFO_Random.Count) {
				//停止Invoke
				CancelInvoke ("ShowLight");
				//關閉最後一個燈
				UFO_Random [UFO_Random.Count - 1].GetComponent<UITexture> ().mainTexture = Resources.Load<Texture> ("JT/UFO_light/ufo0");	
				//開啟Collider
				OpenBoxCollider ();
			} else {
				if (UFO_Arr != 0) {
					//亮下一個燈
					UFO_Random [UFO_Arr].GetComponent<UITexture> ().mainTexture = Resources.Load<Texture> ("JT/UFO_light/ufo0_red");
					//關比上一個燈
					UFO_Random [UFO_Arr - 1].GetComponent<UITexture> ().mainTexture = Resources.Load<Texture> ("JT/UFO_light/ufo0");
				} else {
					//UFO_Arr == 0 亮第一個燈
					UFO_Random [UFO_Arr].GetComponent<UITexture> ().mainTexture = Resources.Load<Texture> ("JT/UFO_light/ufo0_red");
				}
			}

			//指向下一個
			UFO_Arr++;
				
		} catch (System.Exception e) {
			Debug.Log ("ShowLight_fail");
		}
		
		//timer.TimeReset ();
		//OpenBoxCollider ();
		//GameObject.Find ("ProgressBar").GetComponent<Level1_Timer> ().enabled = true;
	}


	//設定Tween數值
	public void OpenBoxCollider ()
	{
		GameObject[] target;
		target = GameObject.FindGameObjectsWithTag ("UFO");
		target.Select (i => i.GetComponent<BoxCollider> ().enabled = true).ToArray ();

		//修改NGUI數值
		target.Select (i => i.GetComponent<TweenPosition> ().duration = 0.5f).ToArray ();
		target.Select (i => i.GetComponent<TweenPosition> ().delay = 0f).ToArray ();
	}

	//製作RandomArr陣列
	protected void makeRandomArr (int key)
	{
		//設定亂數種子
		Random.InitState (System.Guid.NewGuid().GetHashCode());

		for (int i = 0; i < key; i++) {
			int num = Random.Range (0, UFO_sequence.Count);
			UFO_Random.Add (UFO_sequence [num]);
			UFO_sequence [num] = UFO_sequence [UFO_sequence.Count - 1];
			UFO_sequence.RemoveAt (UFO_sequence.Count - 1);
		}
	}
		
	//顯示UFO_Random陣列
	public void ShowUFO_Random ()
	{
		UFO_Random.ForEach (i => Debug.Log (i.name));
	}

	//顯示UFO陣列
	public void ShowUFO ()
	{
		UFO.ForEach (i => Debug.Log (i.name));
	}


	//用來Destroy Bingo、Error物件
	void DestroyClone (GameObject obj)
	{
		Destroy (obj);
//			timer.rezero ();
	}


	protected void restart ()
	{

		//重製UFO位置
		foreach (GameObject i in UFO) {
			//執行UIPlayTween
			i.GetComponent<UIPlayTween> ().Play (true);
			i.GetComponent<Level1_Listener> ().op = true;
			//關閉所有BoxCollider
			i.GetComponent<BoxCollider> ().enabled = false;
		}

		//指標歸零
		UFO_Arr = 0;

		// This will copy all the items from Ball_Random to Ball_sequence
		UFO_sequence.AddRange (UFO_Random);

		//清空UFO陣列
		UFO.Clear ();

		//清空UFO_Random陣列
		UFO_Random.Clear ();

		//使前後亂數不同
		MakeDifference ();


		//重製方X軸之位置
		ReferencePoint = -200;

		//調用ShowLight方法 5秒後 1秒1次
		InvokeRepeating ("ShowLight", 1f, time);
		if(time >0.2f)
		time -= 0.2f;

		//重製BoxCollider開關
		ClickEvent.j = -1;
		 
		//判斷RandomUFO與UFO 開關
		compare = true;
	}

	protected virtual void MakeDifference ()
	{
		List<GameObject> check = UFO_Random.ToList ();
		makeRandomArr (3);
		if (UFO_Random.SequenceEqual (check))
			makeRandomArr (3);
	}
}
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEditor;

public class Level1_Display : MonoBehaviour
{
	[Header ("Object")]
	[Tooltip ("UIRoot-Panel")]
	[SerializeField]protected GameObject Panel;
	[Tooltip ("UIRoot-Panel-Display-UFO_group")]
	[SerializeField]protected GameObject UFO_group;
	[Tooltip ("BingoIcon")]
	[SerializeField]protected GameObject Bingo;
	[Tooltip ("ErrorIcon")]
	[SerializeField]protected GameObject Error;

	[Space (10)]

	[Header ("GameObject")]
	[Tooltip ("亂數序列")]
	public List<GameObject> UFO_sequence = new List<GameObject> ();
	[Tooltip ("亂數陣列")]
	public List<GameObject> UFO_Random = new List<GameObject> ();
	///點擊陣列
	public static List<GameObject> UFO = new List<GameObject> ();

	private List<List<Vector3>> arrangement = new List<List<Vector3>> ();



	///ShowLightTiggle開關
	bool toggle = true;

	public static bool ready = false;

	///UFO移動至下方X軸之位置
	public static int ReferencePoint = -500;

	///UFO間隔
	public static int interval = 90;

	/// UFO指標
	public static int UFO_Arr = 0;

	/// UFO Level指標
	int UFO_Level = 0;



	//點擊事件
	public class ClickEvent
	{
		///BoxCollider開關
		public static int j = -1;

		///BoxCollider開關
		public void Action (GameObject obj)
		{
			Debug.Log (obj.name);

			//掛上<Level1_Listener>腳本
			if (!obj.GetComponent<Level1_Listener> ())
				obj.AddComponent<Level1_Listener> ();

			//讓UFO能返回上一步
			if (obj.GetComponent<Level1_Listener> ().op) {
				//修改NGUI數值
				obj.GetComponent<TweenPosition> ().from = new Vector3 (ReferencePoint, -316, 0);
				obj.GetComponent<TweenPosition> ().to = obj.transform.localPosition;
				//指向下一個位置
				ReferencePoint += interval;
				//加入UFO陣列
				UFO.Add (obj);

				switch (j++) {
				case 0:
					UFO [0].GetComponent<BoxCollider> ().enabled = false;
					break;
				case 1:
					UFO [1].GetComponent<BoxCollider> ().enabled = false;
					break;
				case 2:
					UFO [2].GetComponent<BoxCollider> ().enabled = false;
					break;
				case 3:
					UFO [3].GetComponent<BoxCollider> ().enabled = false;
					break;
				}
					
				obj.GetComponent<Level1_Listener> ().op = false;

			} else {
				//指向上一個位置
				ReferencePoint -= interval;
				obj.GetComponent<Level1_Listener> ().op = true;

				switch (--j) { 
				case 0:
					UFO [0].GetComponent<BoxCollider> ().enabled = true;
					break;
				case 1:
					UFO [1].GetComponent<BoxCollider> ().enabled = true;
					break;
				case 2:
					UFO [2].GetComponent<BoxCollider> ().enabled = true;
					break;
				case 3:
					UFO [3].GetComponent<BoxCollider> ().enabled = true;
					break;
				}
				//從UFO陣列移除
				UFO.Remove (obj);
			}
		}
	}

	void Start ()
	{
		//設定初始值
		Initialization ();

		//製作亂數
		makeRandomArr ((Level1_Select._arrangement_index > 3) ? 4 : 3);

		//Listen所有UFO
		UFO_Random.ForEach (i => UIEventListener.Get (i).onClick = new ClickEvent ().Action);

		//持續比對答案
		StartCoroutine (AnswerCompare ());


	}



	void Update ()
	{
		
	}

	///設定初始值
	public virtual void Initialization ()
	{
		//取得Panel物件
		Panel = GameObject.Find ("Panel");

		//取得UFO_group物件
		UFO_group = GameObject.Find ("UFO_group");

		//取得Bingo物件
		Bingo = Resources.Load<GameObject> ("JT/" + "checked-Bingo");

		//取得Error物件
		Error = Resources.Load<GameObject> ("JT/" + "checked-Error");

		UFO_position ();

		//位移指標
		int i = 0;

		foreach (GameObject arr in Resources.LoadAll("JT/UFO_group")) {

			GameObject go = Instantiate (arr)as GameObject;

			go.transform.parent = UFO_group.transform;

			go.transform.localPosition = Vector3.zero;

			go.transform.localScale = Vector3.one;

			UFO_sequence.Add (go);

			//修改NGUI數值
			go.GetComponent<TweenPosition> ().from = Vector3.zero;
			go.GetComponent<TweenPosition> ().to = arrangement [Level1_Select._arrangement_index] [i++];


			if (Level1_Select._arrangement_index >= 4) {
				if (i == 4)
					break;
			} else {
				if (i == 3)
					break;
			}
		}
	}

	///製作RandomArr陣列
	///將 UFO_sequence亂數後放進 UFO_Random
	protected void makeRandomArr (int key)
	{
		//設定亂數種子
		Random.InitState (System.Guid.NewGuid ().GetHashCode ());

		for (int i = 0; i < key; i++) {
			int num = Random.Range (0, UFO_sequence.Count);
			UFO_Random.Add (UFO_sequence [num]);
			UFO_sequence [num] = UFO_sequence [UFO_sequence.Count - 1];
			UFO_sequence.RemoveAt (UFO_sequence.Count - 1);
		}
	}

	//比對答案
	protected IEnumerator AnswerCompare ()
	{
		while (true) {
			//UFO亮燈
			if (ready) {
				StartCoroutine (ShowLight_TimeManagement (0f, Level1_Select._floatFieldLeft [UFO_Level], Level1_Select._floatFieldRight [UFO_Level], UFO_Random.Count));
				ready = !ready;
			} else {
				//UFO數量到達時判斷
				if (UFO.Count == UFO_Random.Count) {
					//比對陣列是否一致
					if (UFO.SequenceEqual (UFO_Random)) {
						//答對
						GameObject clone = NGUITools.AddChild (Panel, Bingo);
						clone.transform.localScale = new Vector3 (140, 140, 0);
						iTween.ScaleFrom (clone, iTween.Hash ("scale", Vector3.zero, "delay", 0.2, "oncomplete", "DestroyClone", "oncompletetarget", gameObject, "oncompleteparams", clone));
						//				timer.pause ();
					} else {
						//答錯
						GameObject clone = NGUITools.AddChild (Panel, Error);
						clone.transform.localScale = new Vector3 (140, 140, 0);
						iTween.ScaleFrom (clone, iTween.Hash ("scale", Vector3.zero, "delay", 0.2, "oncomplete", "DestroyClone", "oncompletetarget", gameObject, "oncompleteparams", clone));
						//				timer.pause ();
					}

					//1秒後調用restart()
					Invoke ("restart", 1f);
                     
					break;//跳出while迴圈
				}
			}
			yield return null;//等待下一幀
		}
	}

	protected void ShowLightToggle ()
	{
		//timer.TimeReset ();
		//OpenBoxCollider ();
		//GameObject.Find ("ProgressBar").GetComponent<Level1_Timer> ().enabled = true;
		try {
			if (toggle) {
				//亮下一個燈
				if (UFO_Arr <= UFO_Random.Count - 1)
					UFO_Random [UFO_Arr].GetComponent<UITexture> ().mainTexture = Resources.Load<Texture> ("JT/UFO_light/ufo0_red");

				//toggle = false
				toggle = !toggle;

			} else {
				if (UFO_Arr == UFO_Random.Count - 1) {

					//開啟Collider
					OpenBoxCollider ();

					//關閉最後一個燈
					UFO_Random [UFO_Arr].GetComponent<UITexture> ().mainTexture = Resources.Load<Texture> ("JT/UFO_light/ufo0");
				} else {
					//關閉上一個燈
					UFO_Random [UFO_Arr].GetComponent<UITexture> ().mainTexture = Resources.Load<Texture> ("JT/UFO_light/ufo0");
				
					//指向下一個
					UFO_Arr++;

					//toggle = true
					toggle = !toggle;
				}
			}
		} catch (System.Exception e) {
			Debug.Log ("ShowLight_fail" + e);
		}
	}


	///開啟Collider+設定Tween數值
	public void OpenBoxCollider ()
	{
		GameObject[] target;
		target = GameObject.FindGameObjectsWithTag ("UFO");
		//開啟Collider
		target.Select (i => i.GetComponent<BoxCollider> ().enabled = true).ToArray ();

		//修改NGUI數值
		target.Select (i => i.GetComponent<TweenPosition> ().duration = 0.5f).ToArray ();
		target.Select (i => i.GetComponent<TweenPosition> ().delay = 0f).ToArray ();
	}



	///使前後亂數不同
	protected virtual void MakeDifference ()
	{
		List<GameObject> check = UFO_Random.ToList ();
		makeRandomArr ((Level1_Select._arrangement_index > 3) ? 4 : 3);
		if (UFO_Random.SequenceEqual (check))
			makeRandomArr ((Level1_Select._arrangement_index > 3) ? 4 : 3);
	}

	///顯示UFO_Random陣列
	public void ShowUFO_Random ()
	{
		UFO_Random.ForEach (i => Debug.Log (i.name));
	}

	///顯示UFO陣列
	public void ShowUFO ()
	{
		UFO.ForEach (i => Debug.Log (i.name));
	}


	///用來Destroy Bingo、Error物件
	void DestroyClone (GameObject obj)
	{
		Destroy (obj);
//			timer.rezero ();
	}

	///重置
	protected virtual void restart ()
	{
		//重置UFO位置
		foreach (GameObject i in UFO) {
			//執行UIPlayTween
			i.GetComponent<UIPlayTween> ().Play (true);
			//重置op開關
			i.GetComponent<Level1_Listener> ().op = true;
			//關閉所有BoxCollider
			i.GetComponent<BoxCollider> ().enabled = false;
		}

		//指標歸零
		UFO_Arr = 0;

		// This will copy all the items from Ball_Random to Ball_sequence
		UFO_sequence.AddRange (UFO_Random);

		//清空UFO陣列
		UFO.Clear ();

		//清空UFO_Random陣列
		UFO_Random.Clear ();

		//使前後亂數不同
		MakeDifference ();

		//重置方X軸之位置
		ReferencePoint = -500;

		UFO_Level = (UFO_Level < Level1_Select._item - 1) ? UFO_Level+=1 : 0;

//		if (UFO_Level < Level1_Select._item - 1)
//			UFO_Level++;
//		else
//			UFO_Level = 0;

		//UFO亮燈
		StartCoroutine (ShowLight_TimeManagement (1f, Level1_Select._floatFieldLeft [UFO_Level], Level1_Select._floatFieldRight [UFO_Level], UFO_Random.Count));

		//重置ShowLightTiggle開關
		toggle = true;

		//重置BoxCollider開關
		ClickEvent.j = -1;

		//持續比對答案
		StartCoroutine (AnswerCompare ());
	}


	/// <summary>
	/// Shows the light time management.
	/// </summary>
	/// delay1:延遲幾秒後執行
	/// delay2:亮燈時間
	/// delay3:亮燈間隔
	/// loop:輸入UFO數量
	protected IEnumerator ShowLight_TimeManagement (float delay1, float delay2, float delay3, int loop)
	{
		yield return new WaitForSeconds (delay1);

		for (int i = 0; i < loop; i++) {
			ShowLightToggle ();
			yield return new WaitForSeconds (delay2);
			ShowLightToggle ();
			yield return new WaitForSeconds (delay3);
		}
	}

	void UFO_position ()
	{


		//圖1,圖2,圖3,圖4
		arrangement.Add (new List<Vector3> ());
		arrangement [0].Add (new Vector3 (370, 0, 0)); 
		arrangement [0].Add (new Vector3 (0, 0, 0));
		arrangement [0].Add (new Vector3 (-370, 0, 0));

		//圖5
		arrangement.Add (new List<Vector3> ());
		arrangement [1].Add (new Vector3 (0, 280, 0)); 
		arrangement [1].Add (new Vector3 (0, 0, 0));
		arrangement [1].Add (new Vector3 (-0, -280, 0));

		//圖6
		arrangement.Add (new List<Vector3> ());
		arrangement [2].Add (new Vector3 (173, -100, 0)); 
		arrangement [2].Add (new Vector3 (0, 200, 0));
		arrangement [2].Add (new Vector3 (-173, -100, 0));

		//圖7
		arrangement.Add (new List<Vector3> ());
		arrangement [3].Add (new Vector3 (173, 100, 0)); 
		arrangement [3].Add (new Vector3 (0, -200, 0));
		arrangement [3].Add (new Vector3 (-173, 100, 0));

		//圖8
		arrangement.Add (new List<Vector3> ());
		arrangement [4].Add (new Vector3 (285, -90, 0)); 
		arrangement [4].Add (new Vector3 (85, 100, 0));
		arrangement [4].Add (new Vector3 (-115, -90, 0));
		arrangement [4].Add (new Vector3 (-315, 100, 0));

		//圖9
		arrangement.Add (new List<Vector3> ());
		arrangement [5].Add (new Vector3 (173, 100, 0)); 
		arrangement [5].Add (new Vector3 (0, -200, 0));
		arrangement [5].Add (new Vector3 (-173, 100, 0));
		arrangement [5].Add (new Vector3 (-173, 100, 0));
	}

}


//	IEnumerator test(){
//				
//		ResourceRequest u0 = Resources.LoadAsync<GameObject>("JT/UFO_group/UFO-0",typeof(GameObject));
//
//		while (u0.isDone == false) {
//			Debug.Log ("Loading progress:" + u0.progress.ToString ());
//		yield return null;//等待下一幀
//
//		}
//
////		yield return u0;//直到u0完成
//
//		GameObject prefab = Instantiate(u0.asset)as GameObject;
//
//		prefab.transform.parent = UFO_group.transform;
//		prefab.transform.localScale = Vector3.one;ㄉ
//
//		Debug.Log (prefab);
//	}

StartCoroutine (test ());


using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEditor;
using AnimationOrTween;
using System;

public class Level1_Display : MonoBehaviour
{
	[Header ("Object")]
	[Tooltip ("UIRoot-Panel")]
	[SerializeField]protected GameObject Panel;
	[Tooltip ("UIRoot-Panel-Display-UFO_group")]
	[SerializeField]protected GameObject UFO_group;
	[Tooltip ("BingoIcon")]
	[SerializeField]protected GameObject Bingo;
	[Tooltip ("ErrorIcon")]
	[SerializeField]protected GameObject Error;
	[Tooltip ("UFO Default Light")]
	[SerializeField]protected Texture UFO_DefaultLight;
	[Tooltip ("UFO Red Light")]
	[SerializeField]protected Texture UFO_RedLight;


	[Space (10)]

	[Header ("GameObject")]
	[Tooltip ("亂數序列")]
	public List<GameObject> UFO_sequence = new List<GameObject> ();
	[Tooltip ("亂數陣列")]
	public static List<GameObject> UFO_Random = new List<GameObject> ();

	//測試用,UFO_Random設為static無法顯示在inspector
	public  List<GameObject> UFO_Random_Clone = new List<GameObject> ();

	///點擊陣列
	public static List<GameObject> UFO = new List<GameObject> ();

	//二維座標陣列
	public static  List<List<Vector3>> arrangement = new List<List<Vector3>> ();

	///ShowLightTiggle開關
	bool toggle = true;

	public static bool ready = false;

	///UFO移動至下方X軸之位置
	public static int ReferencePoint = -500;

	///UFO間隔
	public static int interval = 90;

	/// UFO亮燈指標
	int UFO_Arr = 0;

	/// UFO Level指標
	int UFO_Level = 0;

	/// UFO Load 載入指標
	public static int UFO_Load = 0;


	public static bool open = false;

	public static bool open2 = false;

	int io;

	//點擊事件
	public class ClickEvent
	{
		///BoxCollider開關
		public static int j = -1;

		///BoxCollider開關
		public void Action (GameObject obj)
		{
			Debug.Log (obj.name);

			//掛上<Level1_Listener>腳本
			if (!obj.GetComponent<Level1_Listener> ())
				obj.AddComponent<Level1_Listener> ();

			//讓UFO能返回上一步
			if (obj.GetComponent<Level1_Listener> ().op) {
				//修改NGUI數值
				obj.GetComponent<TweenPosition> ().from = new Vector3 (ReferencePoint, -316, 0);
				obj.GetComponent<TweenPosition> ().to = obj.transform.localPosition;
				//指向下一個位置
				ReferencePoint += interval;
				//加入UFO陣列
				UFO.Add (obj);

				switch (j++) {
				case 0:
					UFO [0].GetComponent<BoxCollider> ().enabled = false;
					break;
				case 1:
					UFO [1].GetComponent<BoxCollider> ().enabled = false;
					break;
				case 2:
					UFO [2].GetComponent<BoxCollider> ().enabled = false;
					break;
				case 3:
					UFO [3].GetComponent<BoxCollider> ().enabled = false;
					break;
				}
					
				obj.GetComponent<Level1_Listener> ().op = false;

			} else {
				//指向上一個位置
				ReferencePoint -= interval;
				obj.GetComponent<Level1_Listener> ().op = true;

				switch (--j) { 
				case 0:
					UFO [0].GetComponent<BoxCollider> ().enabled = true;
					break;
				case 1:
					UFO [1].GetComponent<BoxCollider> ().enabled = true;
					break;
				case 2:
					UFO [2].GetComponent<BoxCollider> ().enabled = true;
					break;
				case 3:
					UFO [3].GetComponent<BoxCollider> ().enabled = true;
					break;
				}
				//從UFO陣列移除
				UFO.Remove (obj);
			}
		}
	}

	void Start ()
	{
		//設定初始值
		Initialization ();

		//製作亂數
		makeRandomArr ((Level1_Select._arrangement_index > 3) ? 4 : 3);

		//Listen所有UFO
		UFO_Random.ForEach (i => UIEventListener.Get (i).onClick = new ClickEvent ().Action);

		//持續比對答案
		StartCoroutine (AnswerCompare ());

		//動態判斷新增或刪除UFO
		StartCoroutine (UFO_InstantiateAndDestory ());


		UFO_Random_Clone.AddRange (UFO_Random);//測試用
	}



	void Update ()
	{

	}

	///設定初始值
	public virtual void Initialization ()
	{
		//取得Panel物件
		Panel = GameObject.Find ("Panel");

		//取得UFO_group物件
		UFO_group = GameObject.Find ("UFO_group");

		//取得Bingo物件
		Bingo = Resources.Load<GameObject> ("JT/" + "checked-Bingo");

		//取得Error物件
		Error = Resources.Load<GameObject> ("JT/" + "checked-Error");

		//取得ufo0物件
		UFO_DefaultLight = Resources.Load<Texture> ("JT/UFO_light/ufo0");

		//取得Eufo0_red物件
		UFO_RedLight = Resources.Load<Texture> ("JT/UFO_light/ufo0_red");

		//UFO排列圖座標
		UFO_position ();

		//位移指標
		int i = 0;

		//走訪 JT/UFO_group的所有prefab
		foreach (GameObject arr in Resources.LoadAll("JT/UFO_group")) {

			//實例化prefab物件
			GameObject go = Instantiate (arr)as GameObject;

			//設定父節點
			go.transform.parent = UFO_group.transform;

			//設定座標為Vector3(0,0,0)
			go.transform.localPosition = Vector3.zero;

			//設定大小為Vector3(1,1,1)
			go.transform.localScale = Vector3.one;

			//加入UFO_sequence陣列
			UFO_sequence.Add (go);

			//修改NGUI數值
			go.GetComponent<TweenPosition> ().from = Vector3.zero;
			go.GetComponent<TweenPosition> ().to = arrangement [Level1_Select._arrangement_index] [i++];


			//判斷UFO數量
			if (Level1_Select._arrangement_index >= 4) {
				if (i == 4) {
					UFO_Load = i;
					break;
				}
			} else {
				if (i == 3) {
					UFO_Load = i;
					break;
				}
			}
		}
	}

	///製作RandomArr陣列
	///將 UFO_sequence亂數後放進 UFO_Random
	protected void makeRandomArr (int key)
	{
		//設定亂數種子
		UnityEngine.Random.InitState (System.Guid.NewGuid ().GetHashCode ());

		for (int i = 0; i < key; i++) {
			int num = UnityEngine.Random.Range (0, UFO_sequence.Count);
			UFO_Random.Add (UFO_sequence [num]);
			UFO_sequence [num] = UFO_sequence [UFO_sequence.Count - 1];
			UFO_sequence.RemoveAt (UFO_sequence.Count - 1);
		}
	}

	//比對答案
	protected IEnumerator AnswerCompare ()
	{
		while (true) {
			//UFO亮燈
			if (ready) {
				StartCoroutine (ShowLight_TimeManagement (0f, Level1_Select._floatFieldLeft [UFO_Level], Level1_Select._floatFieldRight [UFO_Level], UFO_Random.Count));
				ready = !ready;
			} else {
				//UFO數量到達時判斷
				if (UFO.Count == UFO_Random.Count) {
					//比對陣列是否一致  答對=>clone = Bingo,反之,答對=>clone = Error
					GameObject clone = (UFO.SequenceEqual (UFO_Random)) ? NGUITools.AddChild (Panel, Bingo) : NGUITools.AddChild (Panel, Error);

					//設定大小
					clone.transform.localScale = new Vector3 (140, 140, 0);

					//設定大小tween
					iTween.ScaleFrom (clone, iTween.Hash ("scale", Vector3.zero, "delay", 0.2, "oncomplete", "DestroyClone", "oncompletetarget", gameObject, "oncompleteparams", clone));
//					timer.pause ();

					//1秒後調用restart()
					Invoke ("restart", 1f);
                     
					break;//跳出while迴圈
				}
			}
			yield return null;//等待下一幀
		}
	}

	//動態判斷新增或刪除UFO
	protected IEnumerator UFO_InstantiateAndDestory ()
	{
		
		open2 = true;
		while (true) {
			
			if (open2) {
				io = Level1_Select._arrangement_index;
				open2 = false;
			}
			if (Level1_Select._arrangement_index > 3 && UFO_Random.Count < 4) {
				foreach (GameObject arr in Resources.LoadAll("JT/UFO_group")) {
					//陣列中不含有物件時執行
					if (!UFO_Random.Find (go => go.name == arr.name + "(Clone)")) {
						//實例化prefab物件
						GameObject go = Instantiate (arr)as GameObject;

						//設定父節點
						go.transform.parent = UFO_group.transform;

						//設定座標為Vector3(0,0,0)
						go.transform.localPosition = Vector3.zero;

						//設定大小為Vector3(1,1,1)
						go.transform.localScale = Vector3.one;

						//加入UFO_sequence陣列
						UFO_Random.Add (go);

						//修改NGUI數值
						go.GetComponent<TweenPosition> ().from = Vector3.zero;
						try {
							go.GetComponent<TweenPosition> ().to = arrangement [Level1_Select._arrangement_index] [UFO_Load++];
						} catch (Exception e) {
						}
						go.GetComponent<TweenPosition> ().duration = 0.5f;
						go.GetComponent<TweenPosition> ().delay = 0f;
					}
				}
				UFO_Random_Clone.Clear ();//測試用

				UFO_Random_Clone.AddRange (UFO_Random);//測試用


			} else if (Level1_Select._arrangement_index < 4) {
				while (GameObject.Find ("UFO-3(Clone)")) {

					Destroy (GameObject.Find ("UFO-3(Clone)"));
					UFO_Random.RemoveAt (3);
					yield return null;//等待下一幀
				}
			}
			int i = 0;

			if (io - Level1_Select._arrangement_index < 0) {
				foreach (GameObject arr in UFO_Random) {
					//修改NGUI數值
//						arr.GetComponent<TweenPosition> ().from = arrangement [(Level1_Select._arrangement_index - 1 < 0) ? 1 : Level1_Select._arrangement_index - 1] [i];


					try {
//						if (Level1_Select._arrangement_index < 4)
						arr.GetComponent<TweenPosition> ().from = arrangement [io] [i];
					} catch (Exception e) {
					}

					arr.GetComponent<TweenPosition> ().to = arrangement [Level1_Select._arrangement_index] [i++];

					//Reverse觸發模式
					arr.GetComponent<UIPlayTween> ().playDirection = Direction.Forward;

					//防止切換圖時UFO大小跟著改變,所以設定為不同群組
					arr.GetComponent<TweenScale> ().tweenGroup = 1;

					//執行UIPlayTween
					arr.GetComponent<UIPlayTween> ().Play (true);

					//設定為原本群組
					arr.GetComponent<TweenScale> ().tweenGroup = 0;

					//改回Toggle觸發模式
					arr.GetComponent<UIPlayTween> ().playDirection = Direction.Toggle;
				}

				open2 = true;

			} else if (io - Level1_Select._arrangement_index > 0) {
				foreach (GameObject arr in UFO_Random) {
					//修改NGUI數值
					try {
						arr.GetComponent<TweenPosition> ().from = arrangement [Level1_Select._arrangement_index] [i];
					} catch (Exception e) {
					}
					arr.GetComponent<TweenPosition> ().to = arrangement [io] [i++];

					//Forward觸發模式
					arr.GetComponent<UIPlayTween> ().playDirection = Direction.Reverse;


					//防止切換圖時UFO大小跟著改變,所以設定為不同群組
					arr.GetComponent<TweenScale> ().tweenGroup = 1;

					//執行UIPlayTween
					arr.GetComponent<UIPlayTween> ().Play (true);

					//設定為原本群組
					arr.GetComponent<TweenScale> ().tweenGroup = 0;

					//改回Toggle觸發模式
					arr.GetComponent<UIPlayTween> ().playDirection = Direction.Toggle;

				}
				open2 = true;
			}
			yield return null;//等待下一幀
		}
	}

		
	

	protected void ShowLightToggle ()
	{
		//timer.TimeReset ();
		//OpenBoxCollider ();
		//GameObject.Find ("ProgressBar").GetComponent<Level1_Timer> ().enabled = true;
		try {
			if (toggle) {
				//亮下一個燈
				if (UFO_Arr <= UFO_Random.Count - 1)
					UFO_Random [UFO_Arr].GetComponent<UITexture> ().mainTexture = UFO_RedLight;

				//toggle = false
				toggle = !toggle;

			} else {
				if (UFO_Arr == UFO_Random.Count - 1) {

					//開啟Collider
					OpenBoxCollider ();

					//關閉最後一個燈
					UFO_Random [UFO_Arr].GetComponent<UITexture> ().mainTexture = UFO_DefaultLight;
				} else {
					//關閉上一個燈
					UFO_Random [UFO_Arr].GetComponent<UITexture> ().mainTexture = UFO_DefaultLight;
				
					//指向下一個
					UFO_Arr++;

					//toggle = true
					toggle = !toggle;
				}
			}
		} catch (System.Exception e) {
			Debug.Log ("ShowLight_fail" + e);
		}
	}


	///開啟Collider+設定Tween數值
	public void OpenBoxCollider ()
	{
		GameObject[] target;
		target = GameObject.FindGameObjectsWithTag ("UFO");
		//開啟Collider
		target.Select (i => i.GetComponent<BoxCollider> ().enabled = true).ToArray ();

		//修改NGUI數值
		target.Select (i => i.GetComponent<TweenPosition> ().duration = 0.5f).ToArray ();
		target.Select (i => i.GetComponent<TweenPosition> ().delay = 0f).ToArray ();
	}



	///使前後亂數不同
	protected virtual void MakeDifference ()
	{
		List<GameObject> check = UFO_Random.ToList ();
		makeRandomArr ((Level1_Select._arrangement_index > 3) ? 4 : 3);
		if (UFO_Random.SequenceEqual (check))
			makeRandomArr ((Level1_Select._arrangement_index > 3) ? 4 : 3);
	}

	///顯示UFO_Random陣列
	public void ShowUFO_Random ()
	{
		UFO_Random.ForEach (i => Debug.Log (i.name));
	}

	///顯示UFO陣列
	public void ShowUFO ()
	{
		UFO.ForEach (i => Debug.Log (i.name));
	}


	///用來Destroy Bingo、Error物件
	void DestroyClone (GameObject obj)
	{
		Destroy (obj);
//			timer.rezero ();
	}

	///重置
	protected virtual void restart ()
	{
		//重置UFO位置
		foreach (GameObject i in UFO) {
			//執行UIPlayTween
			i.GetComponent<UIPlayTween> ().Play (true);
			//重置op開關
			i.GetComponent<Level1_Listener> ().op = true;
			//關閉所有BoxCollider
			i.GetComponent<BoxCollider> ().enabled = false;
		}

		//指標歸零
		UFO_Arr = 0;

		// This will copy all the items from Ball_Random to Ball_sequence
		UFO_sequence.AddRange (UFO_Random);

		//清空UFO陣列
		UFO.Clear ();

		//清空UFO_Random陣列
		UFO_Random.Clear ();

		//使前後亂數不同
		MakeDifference ();

		//重置方X軸之位置
		ReferencePoint = -500;

		//亮燈間格時間變換與重置
		UFO_Level = (UFO_Level < Level1_Select._item - 1) ? UFO_Level += 1 : 0;

		//UFO亮燈
		StartCoroutine (ShowLight_TimeManagement (1f, Level1_Select._floatFieldLeft [UFO_Level], Level1_Select._floatFieldRight [UFO_Level], UFO_Random.Count));

		//重置ShowLightTiggle開關
		toggle = true;

		//重置BoxCollider開關
		ClickEvent.j = -1;

		//持續比對答案
		StartCoroutine (AnswerCompare ());
	}


	/// <summary>
	/// Shows the light time management.
	/// </summary>
	/// delay1:延遲幾秒後執行
	/// delay2:亮燈時間
	/// delay3:亮燈間隔
	/// loop:輸入UFO數量
	protected IEnumerator ShowLight_TimeManagement (float delay1, float delay2, float delay3, int loop)
	{
		yield return new WaitForSeconds (delay1);

		for (int i = 0; i < loop; i++) {
			ShowLightToggle ();
			yield return new WaitForSeconds (delay2);
			ShowLightToggle ();
			yield return new WaitForSeconds (delay3);
		}
	}

	//UFO動態座標切換
	//	public static void UFO_position_change (string key)
	//	{
	//		//位移指標
	//		int i = 0;
	//
	//		foreach (GameObject arr in UFO_Random) {
	//
	////			Set按鈕
	//			if (key == "Set") {
	//				try {//修改NGUI數值
	//					arr.GetComponent<TweenPosition> ().from = Vector3.zero;
	//
	//					arr.GetComponent<TweenPosition> ().to = arrangement [Level1_Select._arrangement_index] [i++];
	//
	//					arr.GetComponent<UIPlayTween> ().playDirection = Direction.Forward;
	//				} catch (Exception e) {
	//
	//				}
	//			}
	//
	//			//"+"按鈕
	//			if (key == "Up") {
	//				//修改NGUI數值
	//				arr.GetComponent<TweenPosition> ().from = arrangement [Level1_Select._arrangement_index] [i];
	//
	//				arr.GetComponent<TweenPosition> ().to = arrangement [Level1_Select._arrangement_index + 1] [i++];
	//
	//				//Forward觸發模式
	//				arr.GetComponent<UIPlayTween> ().playDirection = Direction.Forward;
	//			}
	//
	//			//"-"按鈕
	//			if (key == "Down") {
	//				//修改NGUI數值
	//				arr.GetComponent<TweenPosition> ().from = arrangement [(Level1_Select._arrangement_index - 1 < 0) ? 1 : Level1_Select._arrangement_index - 1] [i];
	//
	//				arr.GetComponent<TweenPosition> ().to = arrangement [Level1_Select._arrangement_index] [i++];
	//
	//				//Reverse觸發模式
	//				arr.GetComponent<UIPlayTween> ().playDirection = Direction.Reverse;
	//			}
	//
	//			try {//防止切換圖時UFO大小跟著改變,所以設定為不同群組
	//				arr.GetComponent<TweenScale> ().tweenGroup = 1;
	//
	//				//執行UIPlayTween
	//				arr.GetComponent<UIPlayTween> ().Play (true);
	//
	//				//設定為原本群組
	//				arr.GetComponent<TweenScale> ().tweenGroup = 0;
	//
	//				//改回Toggle觸發模式
	//				arr.GetComponent<UIPlayTween> ().playDirection = Direction.Toggle;
	//			} catch (Exception e) {
	//
	//			}
	//		}
	//	}


	//UFO排列圖座標陣列
	void UFO_position ()
	{
		//圖1,圖2,圖3,圖4
		arrangement.Add (new List<Vector3> ());
		arrangement [0].Add (new Vector3 (370, 0, 0)); 
		arrangement [0].Add (new Vector3 (0, 0, 0));
		arrangement [0].Add (new Vector3 (-370, 0, 0));

		//圖5
		arrangement.Add (new List<Vector3> ());
		arrangement [1].Add (new Vector3 (0, 280, 0)); 
		arrangement [1].Add (new Vector3 (0, 0, 0));
		arrangement [1].Add (new Vector3 (-0, -280, 0));

		//圖6
		arrangement.Add (new List<Vector3> ());
		arrangement [2].Add (new Vector3 (173, -100, 0)); 
		arrangement [2].Add (new Vector3 (0, 200, 0));
		arrangement [2].Add (new Vector3 (-173, -100, 0));

		//圖7
		arrangement.Add (new List<Vector3> ());
		arrangement [3].Add (new Vector3 (173, 100, 0)); 
		arrangement [3].Add (new Vector3 (0, -200, 0));
		arrangement [3].Add (new Vector3 (-173, 100, 0));

		//圖8
		arrangement.Add (new List<Vector3> ());
		arrangement [4].Add (new Vector3 (285, -90, 0)); 
		arrangement [4].Add (new Vector3 (85, 100, 0));
		arrangement [4].Add (new Vector3 (-115, -90, 0));
		arrangement [4].Add (new Vector3 (-315, 100, 0));

		//圖9
		arrangement.Add (new List<Vector3> ());
		arrangement [5].Add (new Vector3 (285, 100, 0)); 
		arrangement [5].Add (new Vector3 (85, -90, 0));
		arrangement [5].Add (new Vector3 (-115, 100, 0));
		arrangement [5].Add (new Vector3 (-315, -90, 0));

		//圖10
		arrangement.Add (new List<Vector3> ());
		arrangement [6].Add (new Vector3 (230, 100, 0)); 
		arrangement [6].Add (new Vector3 (-230, 100, 0));
		arrangement [6].Add (new Vector3 (230, -140, 0));
		arrangement [6].Add (new Vector3 (-230, -140, 0));

		//圖11
		arrangement.Add (new List<Vector3> ());
		arrangement [7].Add (new Vector3 (320, 0, 0)); 
		arrangement [7].Add (new Vector3 (110, 0, 0));
		arrangement [7].Add (new Vector3 (-110, 0, 0));
		arrangement [7].Add (new Vector3 (-320, 0, 0));

	}

}



*/
//void UFO_Instantiate(int i,GameObject go,int key){
//
//	//實例化prefab物件
//	GameObject go = Instantiate (arr)as GameObject;
//
//	//設定父節點
//	go.transform.parent = UFO_group.transform;
//
//	//設定座標為Vector3(0,0,0)
//	go.transform.localPosition = Vector3.zero;
//
//	//設定大小為Vector3(1,1,1)
//	go.transform.localScale = Vector3.one;
//
//	//加入UFO_sequence陣列
//	UFO_Random.Add (go);
//
//	//修改NGUI數值
//	go.GetComponent<TweenPosition> ().from = Vector3.zero;
//
//	try {
////		go.GetComponent<TweenPosition> ().to = arrangement [Level1_Select._arrangement_index] [UFO_Load++];
//		go.GetComponent<TweenPosition> ().to = arrangement [Level1_Select._arrangement_index] [key++];
//	} catch (Exception e) {
//	}
//
//	go.GetComponent<TweenPosition> ().duration = 0.5f;
//	go.GetComponent<TweenPosition> ().delay = 0f;
//	
//}


//protected void UFO_StartMove(GameObject arr,string str){
//	if(str == "up"){
//		try {
//			arr.GetComponent<TweenPosition> ().from = arrangement [io] [i];
//		} catch (Exception e) {
//		}
//
//		arr.GetComponent<TweenPosition> ().to = arrangement [Level1_Select._arrangement_index] [i++];
//
//		//Reverse觸發模式
//		arr.GetComponent<UIPlayTween> ().playDirection = Direction.Forward;
//	}else if(struct=="down"){
//		try {
//			arr.GetComponent<TweenPosition> ().from = arrangement [Level1_Select._arrangement_index] [i];
//		} catch (Exception e) {
//		}
//		arr.GetComponent<TweenPosition> ().to = arrangement [io] [i++];
//
//		//Forward觸發模式
//		arr.GetComponent<UIPlayTween> ().playDirection = Direction.Reverse;
//	}d
//	//防止切換圖時UFO大小跟著改變,所以設定為不同群組
//	arr.GetComponent<TweenScale> ().tweenGroup = 1;
//
//	//執行UIPlayTween
//	arr.GetComponent<UIPlayTween> ().Play (true);
//
//	//設定為原本群組
//	arr.GetComponent<TweenScale> ().tweenGroup = 0;
//
//	//改回Toggle觸發模式
//	arr.GetComponent<UIPlayTween> ().playDirection = Direction.Toggle;


//onfinish完後執行
//		EventDelegate.Add (arr.GetComponent<TweenPosition> ().onFinished, () => {
//			arr.GetComponent<TweenPosition> ().from = arr.transform.localPosition;
//			arr.GetComponent<TweenPosition> ().to = arr.transform.localPosition;
//			Debug.Log("set");
//		}, true);
//}
/*
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEditor;
using AnimationOrTween;
using System;


public class Level1_Display : MonoBehaviour
{
	[Header ("Object")]
	[Tooltip ("UIRoot-Panel")]
	[SerializeField]protected GameObject Panel;
	[Tooltip ("UIRoot-Panel-Display-UFO_group")]
	[SerializeField]protected GameObject UFO_group;
	[Tooltip ("BingoIcon")]
	[SerializeField]protected GameObject Bingo;
	[Tooltip ("ErrorIcon")]
	[SerializeField]protected GameObject Error;
	[Tooltip ("UFO Default Light")]
	[SerializeField]protected Texture UFO_DefaultLight;
	[Tooltip ("UFO Red Light")]
	[SerializeField]protected Texture UFO_RedLight;

	[Space (10)]

	[Header ("GameObject")]
	[Tooltip ("亂數序列")]
	public List<GameObject> UFO_sequence = new List<GameObject> ();
	[Tooltip ("亂數陣列")]
	public static List<GameObject> UFO_Random = new List<GameObject> ();

	//測試用,UFO_Random設為static無法顯示在inspector
	public  List<GameObject> UFO_Random_Clone = new List<GameObject> ();

	///點擊陣列
	public static List<GameObject> UFO = new List<GameObject> ();

	///二維座標陣列
	public static  List<List<Vector3>> arrangement = new List<List<Vector3>> ();

	///遊戲開始
	public static bool ready = false;

	///UFO移動至下方X軸之位置
	public static int ReferencePoint = -500;

	///UFO間隔
	public static int interval = 90;

	///ShowLightTiggle開關
	bool toggle = true;

	///作為鎖定當前數值的功能
	bool UFO_InstantiateAndDestory_toggle = false;

	///鎖定值
	int diff;

	/// UFO亮燈指標
	int UFO_Arr = 0;

	/// UFO Level指標
	int UFO_Level = 0;

	/// UFO Load 載入指標
	int UFO_Load = 0;


	public static bool u = false;
	public static bool d = false;



	public List<CreatUFO> UFO_sequence2 = new List<CreatUFO> ();

	public class CreatUFO
	{
		
		private GameObject go;

		public CreatUFO (GameObject go,bool boo)
		{
			this.go = go;
			op = boo;
		}


		public  GameObject ufo { get { return go; } }


		public bool op{ get; set; }
	}

	//點擊事件
	public class ClickEvent
	{
		///BoxCollider開關
		public void Action (GameObject obj)
		{
			Debug.Log (obj.name);

			//掛上<Level1_Listener>腳本
			if (!obj.GetComponent<Level1_Listener> ())
				obj.AddComponent<Level1_Listener> ();

			//讓UFO能返回上一步
			if (obj.GetComponent<Level1_Listener> ().op) {
				//修改NGUI數值
				obj.GetComponent<TweenPosition> ().from = new Vector3 (ReferencePoint, -316, 0);
				obj.GetComponent<TweenPosition> ().to = obj.transform.localPosition;
				//指向下一個位置
				ReferencePoint += interval;
				//加入UFO陣列
				UFO.Add (obj);

				for (int i = 0; i <= UFO.Count - 1; i++) {
					try {
						UFO [i - 1].GetComponent<BoxCollider> ().enabled = false;
					} catch (Exception e) {

					}	
				}

				obj.GetComponent<Level1_Listener> ().op = false;

			} else {
				//指向上一個位置
				ReferencePoint -= interval;
				obj.GetComponent<Level1_Listener> ().op = true;

				for (int i = 0; i <= UFO.Count - 1; i++) {
					try {
						UFO [i - 1].GetComponent<BoxCollider> ().enabled = true;
					} catch (Exception e) {

					}	
				}

				//從UFO陣列移除
				UFO.Remove (obj);
			}
		}
	}


	void Start ()
	{
		//設定初始值
		Initialization ();

		//製作亂數
		makeRandomArr ((Level1_Select._arrangement_index > 3) ? 4 : 3);

		//Listen所有UFO
		UFO_Random.ForEach (i => UIEventListener.Get (i).onClick = new ClickEvent ().Action);

		//持續比對答案
		StartCoroutine (AnswerCompare ());

		//動態判斷新增或刪除UFO
		StartCoroutine (UFO_InstantiateAndDestory ());


		UFO_Random_Clone.AddRange (UFO_Random);//測試用

//		UFOlist = new List<CreatUFO> () {
//			new CreatUFO{ ufo = Resources.Load<GameObject> ("JT/" + "checked-Error"), op = true }
//		};

//		Debug.Log (UFOlist [0].ufo.name);
//		Debug.Log (UFOlist [0].op);

//		CreatUFO j = new CreatUFO (Resources.Load<GameObject> ("JT/" + "checked-Error"));

//		Debug.Log (j.ufo.name);



	}



	void Update ()
	{
		
	}

	///設定初始值
	public virtual void Initialization ()
	{
		//取得Panel物件
		Panel = GameObject.Find ("Panel");

		//取得UFO_group物件
		UFO_group = GameObject.Find ("UFO_group");

		//取得Bingo物件
		Bingo = Resources.Load<GameObject> ("JT/" + "checked-Bingo");

		//取得Error物件
		Error = Resources.Load<GameObject> ("JT/" + "checked-Error");

		//取得ufo0物件
		UFO_DefaultLight = Resources.Load<Texture> ("JT/UFO_light/ufo0");

		//取得Eufo0_red物件
		UFO_RedLight = Resources.Load<Texture> ("JT/UFO_light/ufo0_red");

		//UFO排列圖座標
		UFO_position ();

		//位移指標
		int i = 0;

		//走訪 JT/UFO_group的所有prefab
		foreach (GameObject arr in Resources.LoadAll("JT/UFO_group")) {

			//動態新增UFO(初始)
			UFO_Instantiate (arr, i++, "init");

			//判斷UFO數量
			if (Level1_Select._arrangement_index >= 4) {
				if (i == 4) {
					UFO_Load = i;
					break;
				}
			} else {
				if (i == 3) {
					UFO_Load = i;
					break;
				}
			}
		}
	}

	///製作RandomArr陣列
	///將 UFO_sequence亂數後放進 UFO_Random
	protected void makeRandomArr (int key)
	{
		//設定亂數種子
		UnityEngine.Random.InitState (System.Guid.NewGuid ().GetHashCode ());

		for (int i = 0; i < key; i++) {
			int num = UnityEngine.Random.Range (0, UFO_sequence.Count);
			UFO_Random.Add (UFO_sequence [num]);
			UFO_sequence [num] = UFO_sequence [UFO_sequence.Count - 1];
			UFO_sequence.RemoveAt (UFO_sequence.Count - 1);
		}
	}

	//比對答案
	protected IEnumerator AnswerCompare ()
	{
		while (true) {
			//UFO亮燈
			if (ready) {
				StartCoroutine (ShowLight_TimeManagement (0f, Level1_Select._floatFieldLeft [UFO_Level], Level1_Select._floatFieldRight [UFO_Level], UFO_Random.Count));
				ready = !ready;
			} else {
				//UFO數量到達時判斷
				if (UFO.Count == UFO_Random.Count) {
					//比對陣列是否一致  答對=>clone = Bingo,反之,答對=>clone = Error
					GameObject clone = (UFO.SequenceEqual (UFO_Random)) ? NGUITools.AddChild (Panel, Bingo) : NGUITools.AddChild (Panel, Error);


					//設定大小
					clone.transform.localScale = new Vector3 (140, 140, 0);

					//設定大小tween
					iTween.ScaleFrom (clone, iTween.Hash ("scale", Vector3.zero, "delay", 0.2, "oncomplete", "DestroyClone", "oncompletetarget", gameObject, "oncompleteparams", clone));
//					timer.pause ();

					//1秒後調用restart()
					Invoke ("restart", 1f);
                     
					if (clone.name == "checked-Bingo(Clone)")
						u = true;
					else
						d = true;

					break;//跳出while迴圈
				}
			}
			yield return null;//等待下一幀
		}
	}

	//持續判斷新增或刪除UFO
	protected IEnumerator UFO_InstantiateAndDestory ()
	{
		//開啟
		UFO_InstantiateAndDestory_toggle = true;

		while (true) {

			//給值後鎖定
			if (UFO_InstantiateAndDestory_toggle) {
				diff = Level1_Select._arrangement_index;
				//鎖定
				UFO_InstantiateAndDestory_toggle = false;
			}
			if (Level1_Select._arrangement_index > 3 && UFO_Random.Count < 4) {
				foreach (GameObject arr in Resources.LoadAll("JT/UFO_group")) {
					
					//陣列中不含有物件時執行
					if (!UFO_Random.Find (go => go.name == arr.name + "(Clone)")) {

						//動態新增UFO(初始後)
						UFO_Instantiate (arr, UFO_Load, "add");

					}
				}

				UFO_Random_Clone.Clear ();//測試用

				UFO_Random_Clone.AddRange (UFO_Random);//測試用

			} else if (Level1_Select._arrangement_index < 4) {

				GameObject Go;

				//持續判斷
				while (Go = UFO_Random.Find (go => go.name == "UFO-3(Clone)")) {
					Destroy (Go);
					UFO_Random.Remove (Go);
					yield return null;//等待下一幀
				}
			}

			//位移指標
			int i = 0;

			//輸入欄位數字變大
			if (diff - Level1_Select._arrangement_index < 0) {

				//UFO tween start
				UFO_Random.ForEach (go => UFO_StartMove (go, "up", i++));

				//開啟
				UFO_InstantiateAndDestory_toggle = true;

				//輸入欄位數字變小
			} else if (diff - Level1_Select._arrangement_index > 0) {

				//UFO tween start
				UFO_Random.ForEach (go => UFO_StartMove (go, "down", i++));

				//開啟
				UFO_InstantiateAndDestory_toggle = true;
			}
			yield return null;//等待下一幀
		}
	}

	protected void ShowLightToggle ()
	{
		//timer.TimeReset ();
		//OpenBoxCollider ();
		//GameObject.Find ("ProgressBar").GetComponent<Level1_Timer> ().enabled = true;
		try {
			if (toggle) {
				//亮下一個燈
				if (UFO_Arr <= UFO_Random.Count - 1)
					UFO_Random [UFO_Arr].GetComponent<UITexture> ().mainTexture = UFO_RedLight;

				//toggle = false
				toggle = !toggle;

			} else {
				if (UFO_Arr == UFO_Random.Count - 1) {

					//開啟Collider
					OpenBoxCollider ();

					//關閉最後一個燈
					UFO_Random [UFO_Arr].GetComponent<UITexture> ().mainTexture = UFO_DefaultLight;
				} else {
					//關閉上一個燈
					UFO_Random [UFO_Arr].GetComponent<UITexture> ().mainTexture = UFO_DefaultLight;
				
					//指向下一個
					UFO_Arr++;

					//toggle = true
					toggle = !toggle;
				}
			}
		} catch (System.Exception e) {
			Debug.Log ("ShowLight_fail" + e);
		}
	}


	///開啟Collider+設定Tween數值
	public void OpenBoxCollider ()
	{
		GameObject[] target = GameObject.FindGameObjectsWithTag ("UFO");
		;

		//開啟Collider
		target.Select (i => i.GetComponent<BoxCollider> ().enabled = true).ToArray ();

		//修改NGUI數值
		target.Select (i => i.GetComponent<TweenPosition> ().duration = 0.5f).ToArray ();
		target.Select (i => i.GetComponent<TweenPosition> ().delay = 0f).ToArray ();
	}



	///使前後亂數不同
	protected virtual void MakeDifference ()
	{
		//複製一份比對參考
		List<GameObject> check = UFO_Random.ToList ();

		//執行到與舊陣列值不同時
		while (UFO_Random.SequenceEqual (check)) {
			
			// This will copy all the items from Ball_Random to Ball_sequence
			UFO_sequence.AddRange (UFO_Random);

			//清空UFO_Random陣列
			UFO_Random.Clear ();

			//製作RandomArr陣列
			makeRandomArr ((Level1_Select._arrangement_index > 3) ? 4 : 3);
		}
	}

	///顯示UFO_Random陣列
	public void ShowUFO_Random ()
	{
		UFO_Random.ForEach (i => Debug.Log (i.name));
	}

	///顯示UFO陣列
	public void ShowUFO ()
	{
		UFO.ForEach (i => Debug.Log (i.name));
	}


	///用來Destroy Bingo、Error物件
	void DestroyClone (GameObject obj)
	{
		Destroy (obj);
//			timer.rezero ();
	}

	///重置
	protected virtual void restart ()
	{
		//重置UFO位置
		UFO.ForEach (go => {
			//執行UIPlayTween
			go.GetComponent<UIPlayTween> ().Play (true);
			//重置op開關
			go.GetComponent<Level1_Listener> ().op = true;
			//關閉所有BoxCollider
			go.GetComponent<BoxCollider> ().enabled = false;
		});

		//指標歸零
		UFO_Arr = 0;

		//清空UFO陣列
		UFO.Clear ();

		//使前後亂數不同
		MakeDifference ();

		//重置方X軸之位置
		ReferencePoint = -500;

		//亮燈間格時間變換與重置
		UFO_Level = (UFO_Level < Level1_Select._item - 1) ? UFO_Level += 1 : 0;

		//UFO亮燈
		StartCoroutine (ShowLight_TimeManagement (1f, Level1_Select._floatFieldLeft [UFO_Level], Level1_Select._floatFieldRight [UFO_Level], UFO_Random.Count));

		//重置ShowLightTiggle開關
		toggle = true;

		//持續比對答案
		StartCoroutine (AnswerCompare ());
	}


	/// <summary>
	/// Shows the light time management.
	/// </summary>
	/// delay1:延遲幾秒後執行
	/// delay2:亮燈時間
	/// delay3:亮燈間隔
	/// loop:輸入UFO數量
	protected IEnumerator ShowLight_TimeManagement (float delay1, float delay2, float delay3, int loop)
	{
		yield return new WaitForSeconds (delay1);

		for (int i = 0; i < loop; i++) {
			ShowLightToggle ();
			yield return new WaitForSeconds (delay2);
			ShowLightToggle ();
			yield return new WaitForSeconds (delay3);
		}
	}

	//動態新增UFO
	protected int UFO_Instantiate (GameObject arr, int key, string str)
	{
		//實例化prefab物件&設定父節點
		GameObject go = Instantiate (arr, parent: UFO_group.transform)as GameObject;

		//設定座標為Vector3(0,0,0)
		go.transform.localPosition = Vector3.zero;

		//設定大小為Vector3(1,1,1)
		go.transform.localScale = Vector3.one;

		//加入UFO_sequence陣列
		if (str == "init") {
			UFO_sequence.Add (go);
			UFO_sequence2.Add (new CreatUFO(go,true));
		}
		//加入UFO_Random陣列
		else if (str == "add") {
			UFO_Random.Add (go);
			go.GetComponent<TweenPosition> ().duration = 0.5f;
			go.GetComponent<TweenPosition> ().delay = 0f;
		}

		//修改NGUI數值
		go.GetComponent<TweenPosition> ().from = Vector3.zero;

		try {
			go.GetComponent<TweenPosition> ().to = arrangement [Level1_Select._arrangement_index] [key];
		} catch (Exception e) {
		} 
		return key;
	}


	//UFO tween start
	protected void UFO_StartMove (GameObject arr, string str, int i)
	{
		if (str == "up") {
			
			//修改NGUI數值
			arr.GetComponent<TweenPosition> ().from = arr.transform.localPosition;

			//修改NGUI數值
			arr.GetComponent<TweenPosition> ().to = arrangement [Level1_Select._arrangement_index] [i];

			//Reverse觸發模式
			arr.GetComponent<UIPlayTween> ().playDirection = Direction.Forward;

		} else if (str == "down") {

			//修改NGUI數值
			arr.GetComponent<TweenPosition> ().from = arrangement [Level1_Select._arrangement_index] [i];

			//修改NGUI數值
			arr.GetComponent<TweenPosition> ().to = arr.transform.localPosition;

			//Forward觸發模式
			arr.GetComponent<UIPlayTween> ().playDirection = Direction.Reverse;

		}

		//防止切換圖時UFO大小跟著改變,所以設定為不同群組
		arr.GetComponent<TweenScale> ().tweenGroup = 1;

		//執行UIPlayTween
		arr.GetComponent<UIPlayTween> ().Play (true);

		//設定為原本群組
		arr.GetComponent<TweenScale> ().tweenGroup = 0;

		//改回Toggle觸發模式
		arr.GetComponent<UIPlayTween> ().playDirection = Direction.Toggle;
	}

	//UFO排列圖座標陣列
	void UFO_position ()
	{
		//圖1,圖2,圖3,圖4
		arrangement.Add (new List<Vector3> ());
		arrangement [0].Add (new Vector3 (370, 0, 0)); 
		arrangement [0].Add (new Vector3 (0, 0, 0));
		arrangement [0].Add (new Vector3 (-370, 0, 0));

		//圖5
		arrangement.Add (new List<Vector3> ());
		arrangement [1].Add (new Vector3 (0, 280, 0)); 
		arrangement [1].Add (new Vector3 (0, 0, 0));
		arrangement [1].Add (new Vector3 (-0, -280, 0));

		//圖6
		arrangement.Add (new List<Vector3> ());
		arrangement [2].Add (new Vector3 (173, -100, 0)); 
		arrangement [2].Add (new Vector3 (0, 200, 0));
		arrangement [2].Add (new Vector3 (-173, -100, 0));

		//圖7
		arrangement.Add (new List<Vector3> ());
		arrangement [3].Add (new Vector3 (173, 100, 0)); 
		arrangement [3].Add (new Vector3 (0, -200, 0));
		arrangement [3].Add (new Vector3 (-173, 100, 0));

		//圖8
		arrangement.Add (new List<Vector3> ());
		arrangement [4].Add (new Vector3 (285, -90, 0)); 
		arrangement [4].Add (new Vector3 (85, 100, 0));
		arrangement [4].Add (new Vector3 (-115, -90, 0));
		arrangement [4].Add (new Vector3 (-315, 100, 0));

		//圖9
		arrangement.Add (new List<Vector3> ());
		arrangement [5].Add (new Vector3 (285, 100, 0)); 
		arrangement [5].Add (new Vector3 (85, -90, 0));
		arrangement [5].Add (new Vector3 (-115, 100, 0));
		arrangement [5].Add (new Vector3 (-315, -90, 0));

		//圖10
		arrangement.Add (new List<Vector3> ());
		arrangement [6].Add (new Vector3 (230, 100, 0)); 
		arrangement [6].Add (new Vector3 (-230, 100, 0));
		arrangement [6].Add (new Vector3 (230, -140, 0));
		arrangement [6].Add (new Vector3 (-230, -140, 0));

		//圖11
		arrangement.Add (new List<Vector3> ());
		arrangement [7].Add (new Vector3 (320, 0, 0)); 
		arrangement [7].Add (new Vector3 (110, 0, 0));
		arrangement [7].Add (new Vector3 (-110, 0, 0));
		arrangement [7].Add (new Vector3 (-320, 0, 0));

	}

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using AnimationOrTween;

public class Level1_Display_Normal : MonoBehaviour
{
	[Header ("Object")]
	[Tooltip ("UIRoot-Panel")]
	[SerializeField]private GameObject Panel;
	[Tooltip ("UIRoot-Panel-Display-UFO_group")]
	//	[SerializeField]private GameObject UFO_group;
	public static GameObject UFO_group;
	[Tooltip ("BingoIcon")]
	[SerializeField]private GameObject Bingo;
	[Tooltip ("ErrorIcon")]
	[SerializeField]private GameObject Error;
	[Tooltip ("UFO Default Light")]
	[SerializeField]private Texture UFO_DefaultLight;
	[Tooltip ("UFO Red Light")]
	[SerializeField]private Texture UFO_RedLight;


	[Space (10)]

	[Tooltip ("亂數序列")]
	public static List<GameObject> UFO_sequence = new List<GameObject> ();
	[Tooltip ("亂數陣列")]
	public static List<GameObject> UFO_Random = new List<GameObject> ();

	///點擊陣列
	public static List<GameObject> UFO = new List<GameObject> ();

	///鎖定值
	int diff;

	///作為鎖定當前數值的功能
	bool UFO_InstantiateAndDestory_toggle = true;

	///載入UFO
	private GameObject[] LoadUFO;

	///UFO移動至下方X軸之位置
	public static int ReferencePoint = -500;

	///UFO間隔
	public static int interval = 90;


	///二維座標陣列
	public static  List<List<Vector3>> arrangement = new List<List<Vector3>> ();



	public static List<CreatUFO> UFOList = new List<CreatUFO> ();

	//	public  List<bool> Ready = new List<bool> ();

	public static bool u = false;



	///UFO生成座標
	public static Vector3[] fix = new Vector3[] {
		new Vector3 (800, 500),
		new Vector3 (800, -500),
		new Vector3 (-800, -500),
		new Vector3 (-800, 500)
	};


	public class CreatUFO
	{
		public static int pos = 0;

		//		private GameObject go;

		//		public  GameObject getUFO { get { return go; } set { this.go = value; } }

		public  GameObject getUFO { get; private set; }

		public bool m_bToggle{ get; set; }

		public bool isMoving{ get; set; }


		public void OnClick (GameObject obj)
		{
			Debug.Log (obj.name + m_bToggle);

			isMoving = true;

			if (m_bToggle) {
				//修改NGUI數值
				TweenPosition.Begin (obj, 0.5f, new Vector3 (ReferencePoint, -316, 0));

//				obj.GetComponent<TweenPosition> ().from = new Vector3 (ReferencePoint, -316, 0);
//				obj.GetComponent<TweenPosition> ().to = obj.transform.localPosition;
				//指向下一個位置
				ReferencePoint += interval;
				//加入UFO陣列
				UFO.Add (obj);

				for (int i = 0; i <= UFO.Count - 1; i++) {
					try {
						UFO [i - 1].GetComponent<BoxCollider> ().enabled = false;//設計當點下最後一個UFO時全關閉BoxCollider之後再統一開啟
					} catch (Exception e) {

					}	
				}

				m_bToggle = !m_bToggle;

			} else {
				//指向上一個位置
				ReferencePoint -= interval;

				m_bToggle = !m_bToggle;

				for (int i = 0; i <= UFO.Count - 1; i++) {
					try {
						UFO [i - 1].GetComponent<BoxCollider> ().enabled = true;
					} catch (Exception e) {

					}	
				}
				//從UFO陣列移除
				UFO.Remove (obj);
			}
		}


		//建構子
		public CreatUFO (GameObject go)
		{
//			this.go = go;


			m_bToggle = true;

			isMoving = true;


			go = Instantiate (go, parent: UFO_group.transform) as GameObject;

			//設定座標為Vector3(0,0,0)
//			go.transform.localPosition = Vector3.zero;


			go.transform.localPosition = fix [pos % 4];

			//設定大小為Vector3(1,1,1)
			go.transform.localScale = Vector3.one;

//			go.GetComponent<TweenPosition> ().from = go.transform.localPosition;
////
//			go.GetComponent<TweenPosition> ().to = arrangement [Level1_Select._arrangement_index] [i++];

			TweenPosition.Begin (go, 1f, arrangement [Level1_Select._arrangement_index] [pos++]);

			//加入UFO_sequence陣列
			UFO_sequence.Add (go);



			this.getUFO = go;

			//Listen
			UIEventListener.Get (go).onClick = OnClick;


			EventDelegate.Add (go.GetComponent<TweenPosition> ().onFinished, () => {
				isMoving = false;
				go.GetComponent<TweenPosition> ().duration = 0.5f;
				go.GetComponent<TweenPosition> ().delay = 0f;
			});

		}

	}




	void Start ()
	{
		//初始化
		Initialization ();

		StartCoroutine (GameStart ());




	}


	void Update ()
	{
		
	}


	void Initialization ()
	{
		//取得Panel物件
		Panel = GameObject.Find ("Panel");

		//取得UFO_group物件
		UFO_group = GameObject.Find ("UFO_group");

		//取得Bingo物件
		Bingo = Resources.Load<GameObject> ("JT/" + "checked-Bingo");

		//取得Error物件
		Error = Resources.Load<GameObject> ("JT/" + "checked-Error");

		//載入UFO
		LoadUFO = Resources.LoadAll<GameObject> ("JT/UFO_groupAll");
	}


	bool LevelUP = false;

	IEnumerator GameStart ()
	{
		//UFO排列圖座標陣列
		UFO_position ();

		while (true) {
			
			yield return StartCoroutine (Level ());//第一次不執行

			yield return StartCoroutine (Creat ());

			yield return StartCoroutine (MakeRandom (4));//隨機幾個

			yield return StartCoroutine (ShowLight ());

			yield return StartCoroutine (AnswerCompare ());
		
			yield return StartCoroutine (init ());

			yield return null;
		}

	}

	//	int diff2;

	IEnumerator Level ()
	{
//		if (LevelUP) {
//			
//			u = true;
//
//			while (true) {
//				//給值後鎖定
//				if (UFO_InstantiateAndDestory_toggle) {
//					//給值
//					diff = Level1_Select._arrangement_index;
//					//鎖定
//					UFO_InstantiateAndDestory_toggle = false;
//				}
//
//				int i = 0;
//			
//
//				//輸入欄位數字變大
//				if (diff - Level1_Select._arrangement_index < 0) {
//
//
//					UFO.ForEach (go1 => { 
//						TweenPosition.Begin (go1, 0.5f, arrangement [Level1_Select._arrangement_index] [i++]);
////						iTween.MoveTo (go, iTween.Hash ("position", arrangement [Level1_Select._arrangement_index] [i++], "time", 0.5f, "easetype", iTween.EaseType.easeInOutQuad, "islocal", true));
//						go1.GetComponent<UIPlayTween> ().Play (true);
//						(UFOList.Find (go2 => go2.getUFO.Equals (go1))).isMoving = true;
//					});
//
//				
////					UFO_sequence.Except (UFO).ToList ().ForEach (go => iTween.MoveTo (go, iTween.Hash ("position", arrangement [Level1_Select._arrangement_index] [i++], "time", 0.5f, "easetype", iTween.EaseType.easeInOutQuad, "islocal", true)));
//
//					if (arrangement [Level1_Select._arrangement_index].Count < arrangement [diff2].Count) {
//
//
//						int j = 0;
//						UFO_sequence.Except (UFO).ToList ().ForEach (go1 => {
//							TweenPosition.Begin (go1, 1f, fix [j++ % 4]);
//
//							Destroy (go1, 1.5f);
//
//
//							UFOList.Remove (UFOList.Find (go2 => go2.getUFO.Equals (go1)));
//
//							UFO_sequence.Remove (go1);
//
//						});
//					}
//
//
//
//					try {
//						if (UFO_sequence.Except (UFO).Any ()) {
//							Debug.Log ("good");
//
//							UFO_sequence.Except (UFO).ToList ().ForEach (go => {
//								TweenPosition.Begin (go, 0.5f, arrangement [Level1_Select._arrangement_index] [i++]);
//								go.GetComponent<TweenPosition> ().Play (true);
//							});
//						}
//
//					} catch (Exception ex) {
//						Debug.Log ("bug");
//					}
//
//
//
//					
//
//					diff2 = diff;
//
//					//開啟
//					UFO_InstantiateAndDestory_toggle = true;
//
//					break;
//				} 
//				yield return null;
//			}
//
//		} else {
//			//				foreach(GameObject arr in UFO){
//			//					arr.GetComponent<UIPlayTween> ().Play (true);
//			//					foreach(CreatUFO arr2 in UFOList){
//			//						Debug.Log ("1");
//			//						if(arr2.getUFO.Equals(arr)){
//			//							arr2.isMoving = true;
//			//							Debug.Log ("good");
//			//						}
//			//					}
//			//				}
//
//			if (UFO.Any ()) {
//				UFO.ForEach (go1 => {
//					go1.GetComponent<UIPlayTween> ().Play (true);
//					(UFOList.Find (go2 => go2.getUFO.Equals (go1))).isMoving = true;
//				});
//			}
//		}
		yield return null;
	}

	int random;
	int balance;

	IEnumerator Creat ()
	{
		if (!LevelUP) {
			if (UFOList.Count == 0) {
				//設定亂數種子
				UnityEngine.Random.InitState (System.Guid.NewGuid ().GetHashCode ());

				random = UnityEngine.Random.Range (0, 5);

				foreach (Vector3 arr in arrangement[Level1_Select._arrangement_index]) {
					UFOList.Add (new CreatUFO (LoadUFO [random]));
				}
			} 
			if (UFO.Any ()) {
				UFO.ForEach (go1 => {
					go1.GetComponent<UIPlayTween> ().Play (true);
					(UFOList.Find (go2 => go2.getUFO.Equals (go1))).isMoving = true;
				});
			}
		} else {



			diff = Level1_Select._arrangement_index;

			u = true;

//			while (diff - Level1_Select._arrangement_index < 0) {

//				//給值後鎖定
//				if (UFO_InstantiateAndDestory_toggle) {
//					//給值
//					diff = Level1_Select._arrangement_index;
//					//鎖定
//					UFO_InstantiateAndDestory_toggle = false;
//				}


				

			yield return new WaitUntil (() => diff != Level1_Select._arrangement_index);


			//輸入欄位數字變大
//				if (diff - Level1_Select._arrangement_index < 0) {


//					diff2 = diff;


//					if (arrangement [Level1_Select._arrangement_index].Count > arrangement [diff].Count) {
//
////						for (int j = 0; j < (arrangement [Level1_Select._arrangement_index].Count - arrangement [diff].Count); j++) {
////							UFOList.Add (new CreatUFO (LoadUFO [random]));
////						}
//
//						arrangement [Level1_Select._arrangement_index].Except (arrangement [diff]).ToList ().ForEach (go => Debug.Log ("t"));
//			(arrangement [Level1_Select._arrangement_index].Count-arrangement [diff].Count)
//
//						Debug.Log (arrangement [Level1_Select._arrangement_index].Except (arrangement [diff]).ToList ().Count);
//
////						UFOList.Add (new CreatUFO (LoadUFO [random])
//					}


			//缺(多)幾台UFO
			balance = arrangement [diff].Count - arrangement [Level1_Select._arrangement_index].Count;

			//lack
			if (balance < 0) {

				for (int j = 0; j < Math.Abs (balance); j++) {
					UFOList.Add (new CreatUFO (LoadUFO [random]));
				}


				//extra
			} else if (balance > 0) {

//				for(int j=0;j<balance;j++){
//					TweenPosition.Begin (UFO_sequence.Last(), 1f, fix [balance++ % 4]);
////					Destroy (UFO_sequence.Last(), 1.5f);
////					UFOList.Remove (UFOList.Find (go2 => go2.getUFO.Equals (UFO_sequence.Last())));
////					UFO_sequence.Remove (UFO_sequence.Last());
//				}

				int x = arrangement [diff].Count - UFO.Count;
				int y = arrangement [Level1_Select._arrangement_index].Count - UFO.Count;



				int g_iflag = 0;
				var g_idestroy = arrangement [diff].Count - arrangement [Level1_Select._arrangement_index].Count;
	
				UFO_sequence.Except (UFO).ToList ().ForEach (go1 => {

					if ((g_iflag ++ < g_idestroy)) {
	
							TweenPosition.Begin (go1, 1f, fix [balance++ % 4]);

							Destroy (go1, 1.5f);

							UFOList.Remove (UFOList.Find (go2 => go2.getUFO.Equals (go1)));

							UFO_sequence.Remove (go1);

					}
				});



				//				int br = 0;


				//				var legacy = UFO_sequence.Except (UFO);



				//				foreach (GameObject go1 in legacy) {

				//					TweenPosition.Begin (go1, 1f, fix [balance++ % 4]);
				//
				//					Destroy (go1, 1.5f);

				//					UFOList.Remove (UFOList.Find (go2 => go2.getUFO.Equals (go1)));

				//					UFO_sequence.Remove (go1);

				//					if ((br++ == arrangement [Level1_Select._arrangement_index].Count)) {
				//						break;
				//					}

				//				}




				CreatUFO.pos = 0;

			}


			int i = 0;

			UFO.ForEach (go1 => { 
				TweenPosition.Begin (go1, 0.5f, arrangement [Level1_Select._arrangement_index] [i++]);
				//						iTween.MoveTo (go, iTween.Hash ("position", arrangement [Level1_Select._arrangement_index] [i++], "time", 0.5f, "easetype", iTween.EaseType.easeInOutQuad, "islocal", true));
				go1.GetComponent<UIPlayTween> ().Play (true);
				(UFOList.Find (go2 => go2.getUFO.Equals (go1))).isMoving = true;
			});
			


			if (UFO_sequence.Except (UFO).Any ()) {
				UFO_sequence.Except (UFO).ToList ().ForEach (go => {
					TweenPosition.Begin (go, 0.5f, arrangement [Level1_Select._arrangement_index] [i++]);
					go.GetComponent<TweenPosition> ().Play (true);
				});
			}




			//開啟
//					UFO_InstantiateAndDestory_toggle = true;

			diff = Level1_Select._arrangement_index;


//					break;
//				} 
//				yield return null;
//			}

		


//			if (arrangement [Level1_Select._arrangement_index].Count < arrangement [diff2].Count) {
//
//
//				int j = 0;
//				UFO_sequence.Except (UFO).ToList ().ForEach (go1 => {
//					TweenPosition.Begin (go1, 1f, fix [j++ % 4]);
//
//					Destroy (go1, 1.5f);
//
//
//					UFOList.Remove (UFOList.Find (go2 => go2.getUFO.Equals (go1)));
//
//					UFO_sequence.Remove (go1);
//
//				});
//			}

		}
		yield return null;
	}



	IEnumerator MakeRandom (int key)
	{



		UFO_Random.Clear ();

		//設定亂數種子
		//		UnityEngine.Random.InitState (System.Guid.NewGuid ().GetHashCode ());

		for (int i = 0; i < key; i++) {
			int num = UnityEngine.Random.Range (0, UFO_sequence.Count);
			UFO_Random.Add (UFO_sequence [num]);
			UFO_sequence [num] = UFO_sequence [UFO_sequence.Count - 1];
			UFO_sequence.RemoveAt (UFO_sequence.Count - 1);
		}

		UFO_sequence.AddRange (UFO_Random);
	


		yield return null;
	}

	//	bool once = false;

	IEnumerator ShowLight ()
	{

//		UFO_sequence.ForEach (go => EventDelegate.Add (go.GetComponent<TweenPosition> ().onFinished, () => Ready.Add (true), true));
//
//		if (once) {
//			if (!LevelUP) {
//				for (int i = 0; i < (UFO_sequence.Count - UFO.Count); i++) {
//					Ready.Add (true);
//				}
//			}
//		}
//
//		once = true;


		yield return new WaitUntil (() => UFOList.All (list => !(list.isMoving)));


//		yield return new WaitUntil (() => Ready.All (list => list == true) && Ready.Count == UFOList.Count);


		UFO_DefaultLight = UFO_Random [0].GetComponent<UITexture> ().mainTexture;

		UFO_RedLight = Resources.Load<Texture> ("JT/UFO_light/" + UFO_Random [0].GetComponent<UITexture> ().mainTexture.name + "_red");

		foreach (GameObject arr in UFO_Random) {
			
			arr.GetComponent<UITexture> ().mainTexture = UFO_RedLight;

			yield return new WaitForSeconds (0.1f);

			arr.GetComponent<UITexture> ().mainTexture = UFO_DefaultLight;

			if (arr == UFO_Random.Last ())
				break;

			yield return new WaitForSeconds (0.1f);
		}
			
		//開啟點擊
		UFO_Random.ForEach (go => go.GetComponent<BoxCollider> ().enabled = true);

		UFO_sequence.ForEach (go => go.GetComponent<BoxCollider> ().enabled = true);

		yield return null;
	}

	IEnumerator AnswerCompare ()
	{
		UFO.Clear ();

		while (true) {
			//UFO數量到達時判斷
			if (UFO.Count == UFO_Random.Count) {

				UFO_sequence.ForEach (go => go.GetComponent<BoxCollider> ().enabled = false);

				if (UFO.SequenceEqual (UFO_Random))
					LevelUP = true;
				else
					LevelUP = false;

				//比對陣列是否一致  答對=>clone = Bingo,反之,答對=>clone = Error
				GameObject clone = (UFO.SequenceEqual (UFO_Random)) ? NGUITools.AddChild (Panel, Bingo) : NGUITools.AddChild (Panel, Error);

				//設定大小
				clone.transform.localScale = new Vector3 (140, 140, 0);

				//設定大小tween
				iTween.ScaleFrom (clone, iTween.Hash ("scale", Vector3.zero, "delay", 0.2));

				Destroy (clone, 1f);

				break;//跳出while迴圈
			}
			yield return null;//等待下一幀
		}
		yield return new WaitForSeconds (1);
	}


	IEnumerator init ()
	{
		//清空UFO陣列
//		UFO.Clear ();


		UFOList.ForEach (go => go.m_bToggle = true);


	

		ReferencePoint = -500;

		yield return null;
	}

	//UFO排列圖座標陣列
	void UFO_position ()
	{
		//圖0
		arrangement.Add (new List<Vector3> ());
		arrangement [0].Add (new Vector3 (320, 0, 0)); 
		arrangement [0].Add (new Vector3 (110, 0, 0));
		arrangement [0].Add (new Vector3 (-110, 0, 0));
		arrangement [0].Add (new Vector3 (-320, 0, 0));

		//圖1
		arrangement.Add (new List<Vector3> ());
		arrangement [1].Add (new Vector3 (0, 300, 0)); 
		arrangement [1].Add (new Vector3 (0, 100, 0));
		arrangement [1].Add (new Vector3 (0, -100, 0));
		arrangement [1].Add (new Vector3 (0, -300, 0));

		//圖2
		arrangement.Add (new List<Vector3> ());
		arrangement [2].Add (new Vector3 (-300, 285, 200)); 
		arrangement [2].Add (new Vector3 (-100, 85, 200));
		arrangement [2].Add (new Vector3 (100, -115, 200));
		arrangement [2].Add (new Vector3 (300, -315, 200));

		//圖3
		arrangement.Add (new List<Vector3> ());
		arrangement [3].Add (new Vector3 (300, 285, 200)); 
		arrangement [3].Add (new Vector3 (100, 85, 200));
		arrangement [3].Add (new Vector3 (-100, -115, 200));
		arrangement [3].Add (new Vector3 (-300, -315, 200));

		//圖4
		arrangement.Add (new List<Vector3> ());
		arrangement [4].Add (new Vector3 (-487, 0, 100)); 
		arrangement [4].Add (new Vector3 (-287, 0, 100));
		arrangement [4].Add (new Vector3 (-87, 0, 100));
		arrangement [4].Add (new Vector3 (113, 0, 100));
		arrangement [4].Add (new Vector3 (313, 0, 100));
		arrangement [4].Add (new Vector3 (513, 0, 100));

		//圖5
		arrangement.Add (new List<Vector3> ());
		arrangement [5].Add (new Vector3 (0, 397, 200)); 
		arrangement [5].Add (new Vector3 (0, 235, 200));
		arrangement [5].Add (new Vector3 (0, 72, 200));
		arrangement [5].Add (new Vector3 (0, -87, 200));
		arrangement [5].Add (new Vector3 (0, -246, 200));
		arrangement [5].Add (new Vector3 (0, -406, 200));

		//圖6
		arrangement.Add (new List<Vector3> ());
		arrangement [6].Add (new Vector3 (-400, 200, 200)); 
		arrangement [6].Add (new Vector3 (-200, 102, 200));
		arrangement [6].Add (new Vector3 (0, 0, 200));
		arrangement [6].Add (new Vector3 (200, -98, 200));
		arrangement [6].Add (new Vector3 (400, -206, 200));
		arrangement [6].Add (new Vector3 (600, -298, 200));

		//圖7
		arrangement.Add (new List<Vector3> ());
		arrangement [7].Add (new Vector3 (500, 200, 200)); 
		arrangement [7].Add (new Vector3 (300, 102, 200));
		arrangement [7].Add (new Vector3 (100, 0, 200));
		arrangement [7].Add (new Vector3 (-100, -98, 200));
		arrangement [7].Add (new Vector3 (-300, -206, 200));
		arrangement [7].Add (new Vector3 (-500, -298, 200));

		//圖8
		arrangement.Add (new List<Vector3> ());
		arrangement [8].Add (new Vector3 (150, -150, 0)); 
		arrangement [8].Add (new Vector3 (-150, 150, 0));
		arrangement [8].Add (new Vector3 (150, 150, 0));
		arrangement [8].Add (new Vector3 (-150, -150, 0));

		//圖9
		arrangement.Add (new List<Vector3> ());
		arrangement [9].Add (new Vector3 (-125, 225, 100)); 
		arrangement [9].Add (new Vector3 (125, 225, 100));
		arrangement [9].Add (new Vector3 (-125, 0, 100));
		arrangement [9].Add (new Vector3 (125, 0, 100));
		arrangement [9].Add (new Vector3 (-125, -225, 100));
		arrangement [9].Add (new Vector3 (125, -225, 100));

		//圖10
		arrangement.Add (new List<Vector3> ());
		arrangement [10].Add (new Vector3 (-218, -100, 0));
		arrangement [10].Add (new Vector3 (-218, 100, 0)); 
		arrangement [10].Add (new Vector3 (218, 100, 0));
		arrangement [10].Add (new Vector3 (218, -100, 0));
		arrangement [10].Add (new Vector3 (0, -100, 0));
		arrangement [10].Add (new Vector3 (0, 100, 0));

		//圖11
		arrangement.Add (new List<Vector3> ());
		arrangement [11].Add (new Vector3 (285, -90, 0)); 
		arrangement [11].Add (new Vector3 (85, 100, 0));
		arrangement [11].Add (new Vector3 (-315, 100, 0));
		arrangement [11].Add (new Vector3 (-115, -90, 0));

		//圖12
		arrangement.Add (new List<Vector3> ());
		arrangement [12].Add (new Vector3 (-115, 100, 0));
		arrangement [12].Add (new Vector3 (-315, -90, 0));
		arrangement [12].Add (new Vector3 (85, -90, 0));
		arrangement [12].Add (new Vector3 (285, 100, 0)); 

		//圖13
		arrangement.Add (new List<Vector3> ());
		arrangement [13].Add (new Vector3 (100, -210, 0)); 
		arrangement [13].Add (new Vector3 (-100, -80, 0));
		arrangement [13].Add (new Vector3 (-100, 180, 0));
		arrangement [13].Add (new Vector3 (100, 50, 0));

		//圖14
		arrangement.Add (new List<Vector3> ());
		arrangement [14].Add (new Vector3 (100, -80, 0)); 
		arrangement [14].Add (new Vector3 (100, 180, 0));
		arrangement [14].Add (new Vector3 (-100, 50, 0));
		arrangement [14].Add (new Vector3 (-100, -210, 0));

		//圖15
		arrangement.Add (new List<Vector3> ());
		arrangement [15].Add (new Vector3 (-250, -147, 0)); 
		arrangement [15].Add (new Vector3 (-125, 103, 0));
		arrangement [15].Add (new Vector3 (125, 103, 0));
		arrangement [15].Add (new Vector3 (250, -147, 0));
		arrangement [15].Add (new Vector3 (0, -147, 0));

		//圖16
		arrangement.Add (new List<Vector3> ());
		arrangement [16].Add (new Vector3 (-250, 103, 0)); 
		arrangement [16].Add (new Vector3 (-125, -103, 0));
		arrangement [16].Add (new Vector3 (0, 103, 0));
		arrangement [16].Add (new Vector3 (125, -103, 0));
		arrangement [16].Add (new Vector3 (250, 103, 0));

		//圖17
		arrangement.Add (new List<Vector3> ());
		arrangement [17].Add (new Vector3 (-120, 100, 0)); 
		arrangement [17].Add (new Vector3 (120, 200, 0));
		arrangement [17].Add (new Vector3 (-120, -103, 0));
		arrangement [17].Add (new Vector3 (120, 0, 0));
		arrangement [17].Add (new Vector3 (120, -200, 0));

		//圖18
		arrangement.Add (new List<Vector3> ());
		arrangement [18].Add (new Vector3 (-120, 200, 0)); 
		arrangement [18].Add (new Vector3 (-120, 0, 0));
		arrangement [18].Add (new Vector3 (-120, -200, 0));
		arrangement [18].Add (new Vector3 (120, -103, 0));
		arrangement [18].Add (new Vector3 (120, 100, 0));

		//圖19
		arrangement.Add (new List<Vector3> ());
		arrangement [19].Add (new Vector3 (0, 240, 0)); 
		arrangement [19].Add (new Vector3 (-125, -10, 0));
		arrangement [19].Add (new Vector3 (125, -10, 0));
		arrangement [19].Add (new Vector3 (250, -260, 0));
		arrangement [19].Add (new Vector3 (0, -260, 0));
		arrangement [19].Add (new Vector3 (-250, -260, 0));

		//圖20
		arrangement.Add (new List<Vector3> ());
		arrangement [20].Add (new Vector3 (-250, 167, 0)); 
		arrangement [20].Add (new Vector3 (-130, -62, 0));
		arrangement [20].Add (new Vector3 (0, -280, 0));
		arrangement [20].Add (new Vector3 (110, -62, 0));
		arrangement [20].Add (new Vector3 (0, 167, 0));
		arrangement [20].Add (new Vector3 (250, 167, 0));

		//圖21
		arrangement.Add (new List<Vector3> ());
		arrangement [21].Add (new Vector3 (-200, 56, 0)); 
		arrangement [21].Add (new Vector3 (0, 194, 0));
		arrangement [21].Add (new Vector3 (200, 56, 0));
		arrangement [21].Add (new Vector3 (200, -144, 0));
		arrangement [21].Add (new Vector3 (0, -280, 0));
		arrangement [21].Add (new Vector3 (-200, -144, 0));

		//圖22
		arrangement.Add (new List<Vector3> ());
		arrangement [22].Add (new Vector3 (0, 210, 0)); 
		arrangement [22].Add (new Vector3 (0, 0, 250));
		arrangement [22].Add (new Vector3 (-170, -170, 0));
		arrangement [22].Add (new Vector3 (170, -170, 0));

		//圖23
		arrangement.Add (new List<Vector3> ());
		arrangement [23].Add (new Vector3 (0, 273, 0)); 
		arrangement [23].Add (new Vector3 (0, 175, 400));
		arrangement [23].Add (new Vector3 (0, 0, 800));
		arrangement [23].Add (new Vector3 (185, -98, 400));
		arrangement [23].Add (new Vector3 (-200, -98, 400));
		arrangement [23].Add (new Vector3 (-280, -223, 0));
		arrangement [23].Add (new Vector3 (271, -223, 0));

		//圖24
		arrangement.Add (new List<Vector3> ());
		arrangement [24].Add (new Vector3 (0, 302, 0)); 
		arrangement [24].Add (new Vector3 (0, 218, 400));
		arrangement [24].Add (new Vector3 (0, 0, 1000));
		arrangement [24].Add (new Vector3 (220, -182, 400));
		arrangement [24].Add (new Vector3 (-179, 37, 400));
		arrangement [24].Add (new Vector3 (180, 37, 400));
		arrangement [24].Add (new Vector3 (271, -223, 0));
		arrangement [24].Add (new Vector3 (-220, -182, 400));
		arrangement [24].Add (new Vector3 (-280, -223, 0));
		arrangement [24].Add (new Vector3 (0, -182, 400));

		//圖25
		arrangement.Add (new List<Vector3> ());
		arrangement [25].Add (new Vector3 (0, 302, 0)); 
		arrangement [25].Add (new Vector3 (0, 218, 400));
		arrangement [25].Add (new Vector3 (0, 0, 1000));
		arrangement [25].Add (new Vector3 (220, -182, 400));
		arrangement [25].Add (new Vector3 (-179, 37, 400));
		arrangement [25].Add (new Vector3 (180, 37, 400));
		arrangement [25].Add (new Vector3 (271, -223, 0));
		arrangement [25].Add (new Vector3 (-220, -182, 400));
		arrangement [25].Add (new Vector3 (-280, -223, 0));
		arrangement [25].Add (new Vector3 (0, -182, 400));
		arrangement [25].Add (new Vector3 (280, 75, 0));
		arrangement [25].Add (new Vector3 (-280, 75, 0));
		arrangement [25].Add (new Vector3 (0, -290, 0));

		//圖26
		arrangement.Add (new List<Vector3> ());
		arrangement [26].Add (new Vector3 (150, -150, 0)); 
		arrangement [26].Add (new Vector3 (-150, 150, 0));
		arrangement [26].Add (new Vector3 (150, 150, 0));
		arrangement [26].Add (new Vector3 (-150, -150, 0));
		arrangement [26].Add (new Vector3 (0, 0, 150));

		//圖27
		arrangement.Add (new List<Vector3> ());
		arrangement [27].Add (new Vector3 (150, -150, 200)); 
		arrangement [27].Add (new Vector3 (-150, 150, 200));
		arrangement [27].Add (new Vector3 (150, 150, 200));
		arrangement [27].Add (new Vector3 (-150, -150, 200));
		arrangement [27].Add (new Vector3 (265, -275, 0)); 
		arrangement [27].Add (new Vector3 (-253, 264, 0));
		arrangement [27].Add (new Vector3 (251, 264, 0));
		arrangement [27].Add (new Vector3 (-264, -275, 0));
		arrangement [27].Add (new Vector3 (0, 0, 600));

		//圖28
		arrangement.Add (new List<Vector3> ());
		arrangement [28].Add (new Vector3 (250, -200, 400)); 
		arrangement [28].Add (new Vector3 (-250, 200, 400));
		arrangement [28].Add (new Vector3 (250, 200, 400));
		arrangement [28].Add (new Vector3 (-250, -200, 400));
		arrangement [28].Add (new Vector3 (311, -275, 0)); 
		arrangement [28].Add (new Vector3 (-306, 278, 0));
		arrangement [28].Add (new Vector3 (311, 278, 0));
		arrangement [28].Add (new Vector3 (-306, -275, 0));
		arrangement [28].Add (new Vector3 (-250, 0, 400)); 
		arrangement [28].Add (new Vector3 (0, 200, 400));
		arrangement [28].Add (new Vector3 (250, 0, 400));
		arrangement [28].Add (new Vector3 (0, -200, 400));
		arrangement [28].Add (new Vector3 (0, 0, 900));

		//圖29
		arrangement.Add (new List<Vector3> ());
		arrangement [29].Add (new Vector3 (250, -200, 400)); 
		arrangement [29].Add (new Vector3 (-250, 200, 400));
		arrangement [29].Add (new Vector3 (250, 200, 400));
		arrangement [29].Add (new Vector3 (-250, -200, 400));
		arrangement [29].Add (new Vector3 (311, -275, 0)); 
		arrangement [29].Add (new Vector3 (-306, 278, 0));
		arrangement [29].Add (new Vector3 (311, 278, 0));
		arrangement [29].Add (new Vector3 (-306, -275, 0));
		arrangement [29].Add (new Vector3 (0, 278, 0)); 
		arrangement [29].Add (new Vector3 (311, 0, 0));
		arrangement [29].Add (new Vector3 (0, -275, 0));
		arrangement [29].Add (new Vector3 (-306, 0, 0));
		arrangement [29].Add (new Vector3 (-250, 0, 400)); 
		arrangement [29].Add (new Vector3 (0, 200, 400));
		arrangement [29].Add (new Vector3 (250, 0, 400));
		arrangement [29].Add (new Vector3 (0, -200, 400));
		arrangement [29].Add (new Vector3 (0, 0, 900));

		//圖30
		arrangement.Add (new List<Vector3> ());
		arrangement [30].Add (new Vector3 (-270, 273, 0));
		arrangement [30].Add (new Vector3 (0, 185, 300));
		arrangement [30].Add (new Vector3 (270, 273, 0));
		arrangement [30].Add (new Vector3 (185, -140, 300));
		arrangement [30].Add (new Vector3 (-270, -247, 0));
		arrangement [30].Add (new Vector3 (-185, -140, 300));
		arrangement [30].Add (new Vector3 (270, -247, 0));
		arrangement [30].Add (new Vector3 (0, 0, 600));

		//圖31
		arrangement.Add (new List<Vector3> ());
		arrangement [31].Add (new Vector3 (-270, 273, 0));
		arrangement [31].Add (new Vector3 (0, 185, 300));
		arrangement [31].Add (new Vector3 (270, 273, 0));
		arrangement [31].Add (new Vector3 (185, -140, 300));
		arrangement [31].Add (new Vector3 (-270, -247, 0));
		arrangement [31].Add (new Vector3 (-185, -140, 300));
		arrangement [31].Add (new Vector3 (270, -247, 0));
		arrangement [31].Add (new Vector3 (0, 0, 600));
		arrangement [31].Add (new Vector3 (0, 273, 0));
		arrangement [31].Add (new Vector3 (270, 0, 0));
		arrangement [31].Add (new Vector3 (0, -247, 0));
		arrangement [31].Add (new Vector3 (-270, 0, 0));
		arrangement [31].Add (new Vector3 (160, 60, 300));
		arrangement [31].Add (new Vector3 (0, -150, 300));
		arrangement [31].Add (new Vector3 (-160, 60, 300));

	}
}


		//取得當前UFO原始圖
		UFO_DefaultLight = UFO_Random [0].GetComponent<UITexture> ().mainTexture;

		//取得當前UFO的亮燈圖
		UFO_RedLight = Resources.Load<Texture> ("JT/UFO_light/" + UFO_Random [0].GetComponent<UITexture> ().mainTexture.name + "_red");

		foreach (GameObject arr in UFO_Random) {

			arr.GetComponent<UITexture> ().mainTexture = UFO_RedLight;

			yield return LightTime;

			arr.GetComponent<UITexture> ().mainTexture = UFO_DefaultLight;

			//當走訪至最後時跳出迴圈
			if (arr == UFO_Random.Last ())
				break;

			yield return DarkTime;
		}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1_RotationFix : MonoBehaviour
{

	public Transform target;


	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
//		Vector3 relativePos = target.position - transform.position;
//		Quaternion rotation = Quaternion.LookRotation (relativePos);
//
//		Quaternion current = transform.localRotation;
////
		//transform.LookAt(target);

		transform.localRotation = Quaternion.Inverse(Quaternion.Lerp (target.rotation, Quaternion.identity, Time.deltaTime));

//		transform.localRotation = Quaternion.LookRotation(target.roa);
////		transform.Translate (0, 0, 0);


	}
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class Level1_Game : MonoBehaviour
{



	List<float> parts = new List<float> ();

	public static List<List<Vector3>> arrangement = new List<List<Vector3>> ();



	List<Vector3> Point = new List<Vector3> ();


	public static string UFO_DefaultLight;

	public  string UFO_RedLight;

	public static string UFO_GrayLight;


	///UFO物件父節點   Level1_ufo要用static才抓的到
	public static Transform UFO_group;
	public static Transform UFO_group_Click;



	[Header ("Object")]
	[Tooltip ("UIRoot-Panel")]
	public GameObject Panel;
	[Tooltip ("BingoIcon")]
	public GameObject Bingo;
	[Tooltip ("ErrorIcon")]
	public GameObject Error;

	//UFO隨機樣式
	private int g_iRandom;
	//UFO數量平衡
	private int g_iBalance;
	///暫存值
	private int g_iTempValue;
	///載入UFO
	GameObject[] LoadUFO;

	GameObject SliderBar;

	GameObject BackGround;


	Vector3 CheckedScale;

	WaitUntil WaitValueChange;

	WaitUntil WaitUFOReady;

	WaitForSeconds WaitOneSecond;


	public List<Level1_UFO> UFOList = new List<Level1_UFO> ();

	public static List<GameObject> UFO = new List<GameObject> ();

	public static List<GameObject> UFO_Random = new List<GameObject> ();

	WaitForSeconds LightTime;


	WaitForSeconds DarkTime;




	public Level1_UFO ufo;

	public GameObject abc;

	///下一關圖型
	public static bool s_bNextLevel = false;

	///關卡難度提升
	bool LevelUP = false;


	// Use this for initialization
	void Start ()
	{

		//初始化
		Initialization ();

		//遊戲開始
//		StartCoroutine (GameStart ());

//		ufo = new Level1_UFO (abc);

//		ufo.getUFO.GetComponent<UISprite>().spriteName = "ufo3_red";

	

//		TweenPosition.Begin (ufo.getUFO, 0.5f, new Vector3 (m_iReferencePoint, -316, 0));


	}
	
	// Update is called once per frame
	void Update ()
	{

	}


	public static void UFO_OnClick(GameObject obj,Level1_UFO ufo){
		Debug.Log (obj.name + ufo.m_bToggle);

//		isMoving = true;
//
//		if (m_bToggle) {
//
//			obj.transform.parent = Level1_Game.UFO_group_Click.transform;
//
//			Level1_RotationFix.children.Remove (obj.transform);
//
//			//移動到下方
//			TP = TweenPosition.Begin (obj, 0.5f, new Vector3 (s_iReferencePoint, -316, 0));
//
//
//
//
//			//指向下一個位置
//			s_iReferencePoint += s_iInterval;
//			//加入UFO陣列
//			Level1_Game.UFO.Add (obj);
//
//			try {
//				Level1_Game.UFO [s_iClick - 1].GetComponent<SphereCollider> ().enabled = false;//設計當點下最後一個UFO時全關閉BoxCollider之後再統一開啟
//				Level1_Game.UFO [s_iClick - 1].GetComponent<UISprite> ().spriteName = Level1_Game.UFO_GrayLight;
//			} catch (Exception e) {
//			}	
//
//			s_iClick++;
//
//			m_bToggle = !m_bToggle;
//
//		} else {
//
//			obj.transform.parent = Level1_Game.UFO_group.transform;
//
//			Level1_RotationFix.children.Add (obj.transform);
//
//			//指向上一個位置
//			s_iReferencePoint -= s_iInterval;
//
//			m_bToggle = !m_bToggle;
//
//			s_iClick--;
//
//			try {
//				Level1_Game.UFO [s_iClick - 1].GetComponent<SphereCollider> ().enabled = true;
//				Level1_Game.UFO [s_iClick - 1].GetComponent<UISprite> ().spriteName =Level1_Game.UFO_DefaultLight;
//			} catch (Exception e) {
//			}	
//			//
//			//從UFO陣列移除
//			Level1_Game.UFO.Remove (obj);
//		}
	}




	void Initialization ()
	{
		//讀入txt
		TextAsset map = Resources.Load<TextAsset> ("JT/maps") as TextAsset;

		LoadMap (map.text);

		//取得Panel物件
		Panel = GameObject.Find ("Panel");

		//取得UFO_group物件
		UFO_group = GameObject.Find ("UFO_group").transform;

		UFO_group_Click = GameObject.Find ("UFO_group_Click").transform;

		//取得Control - Colored Slider物件
		SliderBar = GameObject.Find ("Control - Colored Slider");

		//取得Bingo物件
		Bingo = Resources.Load<GameObject> ("JT/" + "checked-Bingo");

		//取得Error物件
		Error = Resources.Load<GameObject> ("JT/" + "checked-Error");

		//載入UFO
		LoadUFO = Resources.LoadAll<GameObject> ("JT/UFO_groupAll");

		BackGround = GameObject.Find ("background");

		WaitValueChange = new WaitUntil (() => g_iTempValue != Level1_Select._arrangement_index);

		WaitUFOReady = new WaitUntil (() => UFOList.All (list => !(list.isMoving)));

		WaitOneSecond = new WaitForSeconds (1f);

		CheckedScale = new Vector3 (140, 140, 0);

		//設定亂數種子
		UnityEngine.Random.InitState (System.Guid.NewGuid ().GetHashCode ());

		LightTime = new WaitForSeconds (0.1f);

		DarkTime = new WaitForSeconds (0.1f);


	}

	int Index;
	int IndexCount;

	IEnumerator GameStart ()
	{
		while (true) {

			yield return new WaitForEndOfFrame ();

			Index = Level1_Select._arrangement_index;
//
			IndexCount = arrangement [Index].Count / 2;


			//關卡設定
			yield return StartCoroutine (LevelManager ());

			//隨機亂數
			yield return StartCoroutine (MakeRandom ());

//			//亮燈
			yield return StartCoroutine (ShowLight ());


			yield return StartCoroutine (ChangePattern ());

//			//答案比對
			yield return StartCoroutine (AnswerCompare ());
//
//			//重置
			yield return StartCoroutine (Reset ());

			//等待下一幀
			yield return null;
		}
	}

	///關卡設定
	IEnumerator LevelManager ()
	{
		

//		DisplaySliderBar ();

		if (!LevelUP) {

			//進入遊戲後初始，只執行一次
			if (!UFOList.Any ()) {
				
				//隨機值
				g_iRandom = UnityEngine.Random.Range (0, 5);


				for (int i = 0; i < IndexCount; i++) {
					UFOList.Add (new Level1_UFO (LoadUFO [g_iRandom]));
					TweenPosition.Begin (UFOList [i].getUFO, 1f, arrangement [Level1_Select._arrangement_index] [i]);
				}


				//取得當前UFO原始圖名稱
				UFO_DefaultLight = UFOList [0].getUFO.GetComponent<UISprite> ().spriteName;
//
//				//取得當前UFO的亮燈圖名稱
				UFO_RedLight = UFO_DefaultLight + "_red";
//
				UFO_GrayLight = UFO_DefaultLight + "_gray";


			} else {//當答錯時執行
				
				var iFlag = 0;

//				UFO_OriginalOrder.Clear ();

				UFOList.ForEach (go1 => {

//					go1.getUFO.GetComponent<UIPlayTween>().Play(true);

					TweenPosition.Begin (go1.getUFO, 0.5f, arrangement [Index] [iFlag++]);

					TweenScale.Begin (go1.getUFO, 0.5f, Vector3.one);

//					UFO_OriginalOrder.Add (go1); 

					go1.getUFO.GetComponent<UISprite> ().spriteName = UFO_DefaultLight;

					//isMoving = true
					(UFOList.Find (go2 => go2.getUFO.Equals (go1.getUFO))).isMoving = true;

				});

//				if (ReRandom.Any (list => list.Equals (Level1_Select._arrangement_index))) {
//
//					//reReRandom
//
//					//test...
//
//				}

			}
		} else {

			//暫存值
			g_iTempValue = Index;

			//下一關圖形
			s_bNextLevel = true;

			//值改變時執行
			yield return WaitValueChange;


			g_iBalance = (arrangement [g_iTempValue].Count - arrangement [Level1_Select._arrangement_index].Count) / 2;
		

			Index = Level1_Select._arrangement_index;



			//			UFO_OriginalOrder.Clear ();

			//extra
			if (g_iBalance > 0) {

				//Destroy幾台
				for (int i = 0; i < g_iBalance; i++) {

					//					UFOList.Remove (UFOList.Find (go2 => go2.getUFO.Equals (UFO_sequence.Last ())));

					UFOList.RemoveAt (UFOList.Count - 1);

					//					UFO_sequence.Remove (UFO_sequence.Last ());

					TweenPosition.Begin (UFO.Last (), 0.5f, Level1_UFO.GeneratePoint [i % 4]);

					TweenAlpha.Begin (UFO.Last (), 0.5f, 0);

					Destroy (UFO.Last (), 1.5f);

					UFO.Remove (UFO.Last ());

					//					CreatUFO.m_s_iPos--;

				}
			}



			//走訪旗標
			int iFlag = 0;


			UFOList.ForEach (go1 => { 
				//設定下個座標
				TweenPosition.Begin (go1.getUFO, 0.5f, arrangement [Index] [iFlag++]);

				//				UFO_OriginalOrder.Add (go1);

				go1.getUFO.GetComponent<UISprite> ().spriteName = UFO_DefaultLight;

				//開始移動
				go1.getUFO.GetComponent<UIPlayTween> ().Play (true);

				//isMoving = true
				(UFOList.Find (go2 => go2.getUFO.Equals (go1.getUFO))).isMoving = true;

				go1.getUFO.transform.parent = UFO_group.transform;

			});


			//lack
			if (g_iBalance < 0) {

				g_iBalance *= -1;

				//少幾台UFO
				for (int i = 0; i < g_iBalance; i++) {
					UFOList.Add (new Level1_UFO (LoadUFO [g_iRandom]));
					TweenPosition.Begin (UFOList.Last ().getUFO, 0.5f, arrangement [Index] [iFlag++]);
				}


			}  






			//重新給暫存值
//			g_iTempValue = Level1_Select._arrangement_index;

//			DisplaySliderBar ();
		}



		yield return null;


//		yield return WaitUFOReady;


//		if (!NeedChangePattern) {
//
//
//			if (class_RotationFix == null) {
//				//				yield return new WaitForSeconds(3);
//				class_RotationFix = UFO_group.gameObject.AddComponent<Level1_RotationFix> ();
//			} else {
//				UFO.ForEach (go => {
//					go.transform.parent = UFO_group.transform;
//
//					if (Level1_RotationFix.children.All (list => list != go))
//						Level1_RotationFix.children.Add (go.transform);
//				});
//			}
//
//
//		}
	}
	//隨機亂數
	IEnumerator MakeRandom ()
	{
		//清空
		UFO_Random.Clear ();
	
		//設定亂數種子
		//UnityEngine.Random.InitState (System.Guid.NewGuid ().GetHashCode ());
		List<Level1_UFO> TempList = UFOList.ToList ();

		var key = UFOList.Count;

		for (int i = 0; i < key; i++) {
			int num = UnityEngine.Random.Range (0, TempList.Count);
			UFO_Random.Add (TempList [num].getUFO);
			TempList [num] = TempList [TempList.Count - 1];
			TempList.RemoveAt (TempList.Count - 1);
		}
	
		//將UFO_Random加回UFO_sequence
//			UFO_sequence.AddRange (UFO_Random);
	
		yield return null;
	}

	IEnumerator ShowLight ()
	{
		//當陣列全部等於false時執行
		yield return WaitUFOReady;
	
		foreach (GameObject arr in UFO_Random) {
	
			arr.GetComponent<UISprite> ().spriteName = UFO_RedLight;
	
			yield return LightTime;
	
			arr.GetComponent<UISprite> ().spriteName = UFO_DefaultLight;
	
			//當走訪至最後時跳出迴圈
			if (arr == UFO_Random.Last ())
				break;
	
			yield return DarkTime;
		}
	}

	IEnumerator ChangePattern ()
	{
		//yield return WaitOneSecond;
	
	
			
		for (int i = 0; i < UFOList.Count; i++) {
			TweenPosition.Begin (UFOList [i].getUFO, 0.5f, arrangement [Index] [i + (arrangement [Index].Count / 2)]);
	
			//				if (i == UFO_Random.Count - 1)
			//					break;
	
			//yield return WaitOneSecond;
		}

	
		//開啟點擊
		UFO_Random.ForEach (go => go.GetComponent<SphereCollider> ().enabled = true);
	
		//開啟點擊
		//UFO_sequence.ForEach (go => go.GetComponent<SphereCollider> ().enabled = true);
	
		yield return null;
	}

	IEnumerator AnswerCompare ()
	{
		//清空
		UFO.Clear ();
	
		while (true) {
			//UFO數量到達時判斷
			if (UFO.Count == UFO_Random.Count) {
	
				//關閉點擊
				UFO_Random.ForEach (go => go.GetComponent<SphereCollider> ().enabled = false);
	
				//答對答錯
				if (UFO.SequenceEqual (UFO_Random))
					LevelUP = true;
				else
					LevelUP = false;
	
				//比對陣列是否一致  答對=>clone = Bingo,反之,答對=>clone = Error
				GameObject clone = (UFO.SequenceEqual (UFO_Random)) ? NGUITools.AddChild (Panel, Bingo) : NGUITools.AddChild (Panel, Error);
	
				//設定大小
				clone.transform.localScale = CheckedScale;
	
				//設定大小tween
				iTween.ScaleFrom (clone, iTween.Hash ("scale", Vector3.zero, "delay", 0.2));
	
				Destroy (clone, 1f);
	
				break;//跳出while迴圈
			}
			yield return null;//等待下一幀
		}
		yield return WaitOneSecond;
	}

	//重置
	IEnumerator Reset ()
	{
		//重置點擊移動開關
		UFOList.ForEach (go => go.m_bToggle = true);
	
		Level1_UFO.s_iClick = 0;
	
		Level1_UFO.s_iReferencePoint = -500;
	
		yield return null;
	}



	void LoadMap (string map)
	{
		for (int x = -3; x <= 3; x++) {
			for (int y = -1; y <= 2; y++) {
				Point.Add (new Vector3 ((200f * x), (150f * y), 100));
			}
		}

		for (int x = -1; x <= 3; x++) {
			for (int y = -2; y <= -2; y++) {
				Point.Add (new Vector3 ((200f * x), (150f * y), 100));
			}
		}
			

		//分隔符
		string[] split_char = { "\n", "\r" };
		//所有字串
		string[] lines = map.Trim ().Split (split_char, StringSplitOptions.RemoveEmptyEntries);

		int p1 = 1;

		var temp = Point.ToList ();
//		string s1 = "Null";

		for (int i = 0; i < lines.Length; i++) {
			//以,#分隔
			string[] parts = lines [i].Split ("," [0], "#" [0]);

			if (parts [1].Contains ("RandomPos_Add")) {

				if (p1 != int.Parse (parts [0])) {

					arrangement.Add (new List<Vector3> ());

					p1 = int.Parse (parts [0]);

					Point.AddRange (temp);
				}

				int RandomNum = UnityEngine.Random.Range (0, Point.Count);
				arrangement [int.Parse (parts [0])].Add (Point [RandomNum]); 
				temp.Add (Point [RandomNum]);
				Point [RandomNum] = Point [Point.Count - 1];
				Point.RemoveAt (Point.Count - 1);	
			



			} else if (parts [1].Contains ("RandomPos_Insert")) {
				Debug.Log ("1");
			} else {

				if (p1 != int.Parse (parts [0])) {

					arrangement.Add (new List<Vector3> ());

					p1 = int.Parse (parts [0]);
				}



				//加入座標
				arrangement [int.Parse (parts [0])].Add (new Vector3 (float.Parse (parts [1]), float.Parse (parts [2]), float.Parse (parts [3])));
			}
		
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{

	//	float dir = 1f;

	//	Collider myCollider;

	RaycastHit hit;

	float Distance;

//	bool bo = true;



	void Start ()
	{
//		myCollider = transform.GetComponent<Collider> ();

		Distance = transform.localScale.x / 4;
	}


	void FixedUpdate ()
	{
		//上
		if (Physics.Raycast (transform.position, transform.up, out hit, Distance)) {

			transform.Rotate (Vector3.forward * Random.Range (0, 90));

//			bo = !bo;
		}

		//下
		if (Physics.Raycast (transform.position, -transform.up, out hit, Distance)) {
			

		}

		//左
		if (Physics.Raycast (transform.position, -transform.right, out hit, Distance)) {

			transform.Rotate (Vector3.forward * Random.Range (0, 90));

//			bo = !bo;

		}

		//右
		if (Physics.Raycast (transform.position, transform.right, out hit, Distance)) {

			transform.Rotate (Vector3.forward * Random.Range (0, 90));

//			bo = !bo;

		}
			
		transform.Rotate (Vector3.forward);

		transform.position += transform.up * Time.deltaTime*0.5f;
	}


	void OnDrawGizmos ()
	{
		Gizmos.DrawRay (transform.position, transform.right * transform.localScale.x / 4);//右
		Gizmos.DrawRay (transform.position, -transform.right * transform.localScale.x / 4);
		Gizmos.DrawRay (transform.position, transform.up * transform.localScale.y / 4);
		Gizmos.DrawRay (transform.position, -transform.up * transform.localScale.y / 4);
	}
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using AnimationOrTween;

[System.Serializable]
public class Level1_UFO
{
	//static
	static public  Transform UFO_group;
	static public  GameObject UFOLightDefault;
	static public  GameObject UFOLight;
	static public  Level1_Hard hard;
	static public  Level1_Normal normal;
	static public  Level1_Easy easy;
	float Delay = 0f;


	//走訪旗標
	public static int s_iPos = 0;

	//物件
	public GameObject GetUFO { get; private set; }

	//點擊移動開關 default = false
	public bool m_bToggle{ get; set; }

	//是否在移動 default = false
	public bool isMoving{ get; set; }


	///UFO生成座標
	public static Vector3[] GeneratePoint = new Vector3[] {
		new Vector3 (800, 500),
		new Vector3 (800, -500),
		new Vector3 (-800, -500),
		new Vector3 (-800, 500)
	};

	//	//走訪旗標
	//	public static int m_s_iPos = 0;
	//
	//	//點擊旗標
	//	public static int m_s_iClick = 0;

	//建構子
	public Level1_UFO (GameObject go)
	{
//		m_bToggle = true;

//		isMoving = true;

//		實例化物件並設定父節點
		this.GetUFO = MonoBehaviour.Instantiate (go, parent: UFO_group) as GameObject;

//		go = MonoBehaviour.Instantiate (go, parent: UFO_group) as GameObject;

//		設定實例化位置
//		go.transform.localPosition = GeneratePoint [s_iPos++ % 4];

		//設定大小為Vector3(1,1,1)
//		go.transform.localScale = Vector3.one;

//		this.GetUFO = go;
		//AddComponent ();

	}

	public void Initmove(float duration, Vector3 pos){
		Initmove(0f,duration,pos);
	}

	public void Initmove(float delay,float duration, Vector3 pos){

		this.isMoving = true;

		this.m_bToggle = true;

		TweenPosition TP = TweenPosition.Begin (this.GetUFO, duration, pos);

		TP.onFinished.Add (new EventDelegate (() => isMoving = false));

		TP.delay = delay;
	}

	public void moveTo (float duration, Vector3 pos)
	{
		Debug.Log (this.GetUFO.name + "\t" + this.m_bToggle + "\t" + "moveTo");

		this.isMoving = true;

		this.m_bToggle = false;

		TweenPosition TP = TweenPosition.Begin (this.GetUFO, duration, pos);

		TP.onFinished.Add (new EventDelegate (() => isMoving = false));

		TP.delay = Delay;
	}

	public void moveBack ()
	{
		Debug.Log (this.GetUFO.name + "\t" + this.m_bToggle + "\t" + "moveBack");

		if (!this.m_bToggle) {
			
			TweenPosition TP = this.GetUFO.GetComponent<TweenPosition> ();

			if (TP != null) {

				isMoving = true;

				TP.onFinished.Add (new EventDelegate (() => isMoving = false));

				TP.PlayReverse ();
			}

		}
		this.m_bToggle = true;
	}


	public void AddListener ()
	{
		//Listen
		UIEventListener.Get (this.GetUFO).onClick = OnClick;
	}

	//點擊事件
	private void OnClick (GameObject obj)
	{
		if (hard)
			Level1_Hard.UFO_OnClick (this);
		if (normal)
			Level1_Normal.UFO_OnClick (this);
		if (easy)
			Level1_Easy.UFO_OnClick (this);
	}

	public void LightOn ()
	{
		//移除原模型
		if (this.GetUFO != null)
			MonoBehaviour.Destroy (this.GetUFO.transform.gameObject);


		//找到當前UFO的發光模型
		if (UFOLight == null) {
			UFOLight = Resources.Load<GameObject> ("JT/UFO_3D(R)/" + this.GetUFO.gameObject.name.Replace ("(Clone)", "") + "R");
			//當來源不存在
			if (UFOLight == null) {
				Debug.LogError ("Missing Red 3D Model");
				return;
			}
		}

		this.GetUFO = this.InstantiateOneUFO (UFOLight, this.GetUFO.transform);
	}


	public void LightOff ()
	{
		//移除原模型
		if (this.GetUFO != null) {
			MonoBehaviour.Destroy (this.GetUFO.transform.gameObject);
		}
		
//		//找到當前UFO的發光模型
		if (UFOLightDefault == null) {
			UFOLightDefault = Resources.Load<GameObject> ("JT/UFO_3D/" + this.GetUFO.gameObject.name.Replace ("R(Clone)", ""));
			//當來源不存在
			if (UFOLightDefault == null) {
				Debug.LogError ("Missing Default 3D Model");
				return;
			}
		}

		// Create a new instance of the game object
		this.GetUFO = this.InstantiateOneUFO (UFOLightDefault, this.GetUFO.transform);

	}

	static public void InstantiateUFOs (int lack, GameObject loadufo, List<Level1_UFO> UFOList, List<List<Vector3>> arrangement, int arrangement_index, int iFlag)
	{
		//設定座標 & 實例化UFO
		for (int i = 0; i < lack; i++) {
			Level1_UFO ufo = new Level1_UFO (loadufo);

			ufo.GetUFO.transform.localPosition = GeneratePoint [s_iPos++ % 4];

			//ufo.isMoving = true;

			if (iFlag == 0)
				ufo.Initmove (0.5f,1f, arrangement [arrangement_index] [i]);
			else
				ufo.Initmove (0.5f, arrangement [arrangement_index] [i + iFlag]);
			

//			ufo.m_bToggle = true;
			
			UFOList.Add (ufo);
		}
	}

	static public void InstantiateUFOs (int lack, GameObject loadufo, List<Level1_UFO> UFOList, List<List<Vector3>> arrangement, int arrangement_index)
	{
		InstantiateUFOs (lack, loadufo, UFOList, arrangement, arrangement_index, 0);
	}


	public GameObject InstantiateOneUFO (GameObject lightufo, Transform trans)
	{
		GameObject go = MonoBehaviour.Instantiate (lightufo, trans.position, trans.rotation, UFO_group) as GameObject;

		go.transform.position = trans.position;

		go.transform.localScale = trans.localScale;

		return go;
	}

	static public void DestroyUFO (int extra, List<Level1_UFO> UFOList, List<Level1_UFO> UFO)
	{
		//Destroy幾台
		for (int i = 0; i < extra; i++) {

			var go = UFOList.Last ();

			go.moveTo (0.5f, GeneratePoint [i % 4]);

			UFOList.Remove (go);

			MonoBehaviour.Destroy (go.GetUFO, 1.5f);

			UFO.Remove (go);
		}
	}
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using AnimationOrTween;

[System.Serializable]
public class Level1_UFO
{
	//static
	static public  Transform UFO_group;
	static public  GameObject UFOLightDefault;
	static public  GameObject UFOLight;


	static public  Level1_Hard hard;
	static public  Level1_Normal normal;
	static public  Level1_Easy easy;

	static public Level1_1 one;

	static public  Level1_Fix fix;


	float Delay = 0f;


	//走訪旗標
	public static int s_iPos = 0;

	//物件
	public GameObject GetUFO { get; private set; }

	//點擊移動開關 default = false
	public bool m_bToggle{ get; set; }

	//是否在移動 default = false
	public bool isMoving{ get; set; }


	///UFO生成座標
	public static Vector3[] GeneratePoint = new Vector3[] {
		new Vector3 (800, 500),
		new Vector3 (800, -500),
		new Vector3 (-800, -500),
		new Vector3 (-800, 500)
	};

	//	//走訪旗標
	//	public static int m_s_iPos = 0;
	//
	//	//點擊旗標
	//	public static int m_s_iClick = 0;

	//建構子
	public Level1_UFO (GameObject go)
	{
//		實例化物件並設定父節點
		this.GetUFO = MonoBehaviour.Instantiate (go, parent: UFO_group) as GameObject;
	}

	static public void InstantiateUFOs (int lack, GameObject loadufo, List<Level1_UFO> UFOList, List<List<Vector3>> arrangement, int arrangement_index, int iFlag)
	{
		//設定座標 & 實例化UFO
		for (int i = 0; i < lack; i++) {
			Level1_UFO ufo = new Level1_UFO (loadufo);

			ufo.GetUFO.transform.localPosition = GeneratePoint [s_iPos++ % 4];

			if (iFlag == 0)
				ufo.Initmove (0.5f, 1f, arrangement [arrangement_index] [i]);
			else
				ufo.Initmove (0.5f, arrangement [arrangement_index] [i + iFlag]);

			UFOList.Add (ufo);
		}
	}

	static public void InstantiateUFOs (int lack, GameObject loadufo, List<Level1_UFO> UFOList, List<List<Vector3>> arrangement, int arrangement_index)
	{
		InstantiateUFOs (lack, loadufo, UFOList, arrangement, arrangement_index, 0);
	}

	static public void DestroyUFO (int extra, List<Level1_UFO> UFOList, List<Level1_UFO> UFO)
	{
		//Destroy幾台
		for (int i = 0; i < extra; i++) {

			var go = UFOList.Last ();

			go.moveTo (0.5f, GeneratePoint [i % 4]);

			UFOList.Remove (go);

			MonoBehaviour.Destroy (go.GetUFO, 1.5f);

			UFO.Remove (go);
		}
	}

	public void Initmove (float duration, Vector3 pos)
	{
		Initmove (0f, duration, pos);
	}

	public void Initmove (float delay, float duration, Vector3 pos)
	{

		this.isMoving = true;

		this.m_bToggle = true;

		TweenPosition TP = TweenPosition.Begin (this.GetUFO, duration, pos);

		TP.onFinished.Add (new EventDelegate (() => isMoving = false));

		TP.delay = delay;
	}

	public void moveTo (float duration, Vector3 pos)
	{
//		Debug.Log (this.GetUFO.name + "\t" + this.m_bToggle + "\t" + "moveTo");

		this.isMoving = true;

		this.m_bToggle = false;

		TweenPosition TP = TweenPosition.Begin (this.GetUFO, duration, pos);

		TP.onFinished.Add (new EventDelegate (() => isMoving = false));

		TP.delay = Delay;
	}

	public void moveBack ()
	{
//		Debug.Log (this.GetUFO.name + "\t" + this.m_bToggle + "\t" + "moveBack");

		if (!this.m_bToggle) {
			
			TweenPosition TP = this.GetUFO.GetComponent<TweenPosition> ();

			if (TP != null) {

				isMoving = true;

				TP.onFinished.Add (new EventDelegate (() => isMoving = false));

				TP.PlayReverse ();
			}

		}
		this.m_bToggle = true;
	}


	public void AddListener ()
	{
		//Listen
		UIEventListener.Get (this.GetUFO).onClick = OnClick;
	}

	//點擊事件
	private void OnClick (GameObject obj)
	{
		if (one)
			Level1_1.UFO_OnClick (this);



//		if (hard)
//			Level1_Hard.UFO_OnClick (this);
//		if (normal)
//			Level1_Normal.UFO_OnClick (this);
//		if (easy)
//			Level1_Easy.UFO_OnClick (this);
	}

	public void LightOn ()
	{
		//移除原模型
		if (this.GetUFO != null)
			MonoBehaviour.Destroy (this.GetUFO.transform.gameObject);

		//找到當前UFO的發光模型
		if (UFOLight == null) {
			UFOLight = Resources.Load<GameObject> ("JT/UFO_3D(R)/" + this.GetUFO.gameObject.name.Replace ("(Clone)", "") + "R");
			//當來源不存在
			if (UFOLight == null) {
				Debug.LogError ("Missing Red 3D Model");
				return;
			}
		}

		this.GetUFO = this.InstantiateOneUFO (UFOLight, this.GetUFO.transform);
	}


	public void LightOff ()
	{
		//移除原模型
		if (this.GetUFO != null) {
			MonoBehaviour.Destroy (this.GetUFO.transform.gameObject);
		}
		
//		//找到當前UFO的發光模型
		if (UFOLightDefault == null) {
			UFOLightDefault = Resources.Load<GameObject> ("JT/UFO_3D/" + this.GetUFO.gameObject.name.Replace ("R(Clone)", ""));
			//當來源不存在
			if (UFOLightDefault == null) {
				Debug.LogError ("Missing Default 3D Model");
				return;
			}
		}

		// Create a new instance of the game object
		this.GetUFO = this.InstantiateOneUFO (UFOLightDefault, this.GetUFO.transform);

	}

	public GameObject InstantiateOneUFO (GameObject lightufo, Transform trans)
	{
		GameObject go = MonoBehaviour.Instantiate (lightufo, trans.position, trans.rotation, UFO_group) as GameObject;

		go.transform.position = trans.position;

		go.transform.localScale = trans.localScale;

		return go;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using AnimationOrTween;

[System.Serializable]
public class Level1_UFO
{
	//UFO建置的parent位置
	static public  Transform UFO_group;
	//Color
	static public  GameObject Original_color;
	static public  GameObject Red_color;
	static public  GameObject Gray_color;

	static public  Level1_Hard hard;
	static public  Level1_Easy easy;

	static public  Level1_1 one;
	static public  Level1_2 two;
	static public  Level1_3 three;
	static public  Level1_4 four;
	static public  Level1_5 five;


	//讓UFO連續從四個頂點新增
	public static int s_iPos = 0;

	//物件
	public GameObject GetUFO { get; private set; }


	//點擊移動開關 default = false
	public bool m_bToggle{ get; set; }

	//是否在移動 default = false
	public bool isMoving{ get; set; }


	///UFO生成座標
	public static Vector3[] GeneratePoint = new Vector3[] {
		new Vector3 (800, 500),
		new Vector3 (800, -500),
		new Vector3 (-800, -500),
		new Vector3 (-800, 500)
	};

	//	//走訪旗標
	//	public static int m_s_iPos = 0;
	//
	//	//點擊旗標
	//	public static int m_s_iClick = 0;

	//建構子
	public Level1_UFO (GameObject go)
	{
//		實例化物件並設定父節點
		if (go != null)
			this.GetUFO = MonoBehaviour.Instantiate (go, parent: UFO_group) as GameObject;
	}

	//從UFOList中新增UFO
	static public List<Level1_UFO> InstantiateUFOs (int lack)
	{
		//新加入UFO,保留原本UFO並加入新UFO
		List<Level1_UFO> TempUFOList = new List<Level1_UFO> ();

		//設定座標 & 實例化UFO
		for (int i = 0; i < lack; i++) {
			
//			Level1_UFO ufo = new Level1_UFO (loadufo);

			Level1_UFO ufo = new Level1_UFO (Level1_DataBase.LoadUFO [1]);

			ufo.GetUFO.transform.localPosition = GeneratePoint [s_iPos++ % 4];

			Level1_DataBase.UFOList.Add (ufo);

//			UFOList.Add (ufo);

			TempUFOList.Add (ufo);

			ufo.AddListener ();
		}

		return TempUFOList;
	}

	//從UFOList、UFO中移除UFO
	static public void DestroyUFO (int extra)
	{
		//Destroy幾台
		for (int i = 0; i < extra; i++) {

			var go = Level1_DataBase.UFOList.Last ();

			go.moveTo (0.5f, GeneratePoint [i % 4]);

			Level1_DataBase.UFOList.Remove (go);

//			UFOList.Remove (go);

			MonoBehaviour.Destroy (go.GetUFO, 1.5f);

			Level1_DataBase.UFO.Remove (go);

//			UFO.Remove (go);
		}
	}

	//	public void Initmove (float duration, Vector3 pos)
	//	{
	//		Initmove (0f, duration, pos);
	//	}

	//	public void Initmove (float delay, float duration, Vector3 pos)
	//	{
	//
	//		this.isMoving = true;
	//
	//		this.m_bToggle = true;
	//
	//		TweenPosition TP = TweenPosition.Begin (this.GetUFO, duration, pos);
	//
	//		TP.onFinished.Add (new EventDelegate (() => isMoving = false));
	//
	//		TP.delay = delay;
	//	}

	//Initmove -> (duration,Pos,true,delay)
	//Initmove -> (duration,Pos,true)
	//moveTo ->(duration,Pos)
	public void moveTo (float duration, Vector3 pos, bool bToggle = false, float delay = 0)
	{
		this.isMoving = true;

		if (bToggle)
			this.m_bToggle = true;

		TweenPosition TP = TweenPosition.Begin (this.GetUFO, duration, pos);

		TP.onFinished.Add (new EventDelegate (() => isMoving = false));

		TP.delay = delay;
	}


	//直接設定UFO位置(目前用於第4關
	public void setPos (Vector3 pos)
	{
		this.GetUFO.transform.localPosition = pos;
		this.m_bToggle = true;
	}



	//	public void moveTo (float duration, Vector3 pos)
	//	{
	////		Debug.Log (this.GetUFO.name + "\t" + this.m_bToggle + "\t" + "moveTo");
	//
	//		this.isMoving = true;
	//
	////		this.m_bToggle = false;
	//
	//		TweenPosition TP = TweenPosition.Begin (this.GetUFO, duration, pos);
	//
	//		TP.onFinished.Add (new EventDelegate (() => isMoving = false));
	//
	//		TP.delay = Delay;
	//	}

	//	public void moveBack ()
	//	{
	////		Debug.Log (this.GetUFO.name + "\t" + this.m_bToggle + "\t" + "moveBack");
	//
	//		if (!this.m_bToggle) {
	//			
	//			TweenPosition TP = this.GetUFO.GetComponent<TweenPosition> ();
	//
	//			if (TP != null) {
	//
	//				isMoving = true;
	//
	//				TP.onFinished.Add (new EventDelegate (() => isMoving = false));
	//
	//				TP.PlayReverse ();
	//			}
	//
	//		}
	//		this.m_bToggle = true;
	//	}

	//Add Listener
	public void AddListener ()
	{
		//Listen
		UIEventListener.Get (this.GetUFO).onClick = OnClick;
	}

	//點擊事件
	private void OnClick (GameObject obj)
	{
		if (one)
			Level1_1.UFO_OnClick (this);
		if (two)
			Level1_2.UFO_OnClick (this);
		if (three)
			Level1_3.UFO_OnClick (this);
		if (four)
			Level1_4.UFO_OnClick (this);
		if (five)
			Level1_4.UFO_OnClick (this);

//		if (hard)
//			Level1_Hard.UFO_OnClick (this);
//		if (normal)
//			Level1_Normal.UFO_OnClick (this);
//		if (easy)
//			Level1_Easy.UFO_OnClick (this);
	}

	//UFO原始顏色
	public void Original (bool Collider = true)
	{
//		var TempRotation = this.GetUFO.transform.GetComponentInChildren<Transform> ().localRotation;

		//移除原模型
		if (this.GetUFO != null) {
			MonoBehaviour.Destroy (this.GetUFO.transform.gameObject);
		}
		
//		//找到當前UFO的發光模型
		if (Original_color == null) {
			Original_color = Resources.Load<GameObject> ("JT/UFO_3D/" + this.GetUFO.gameObject.name.Replace ("R(Clone)", ""));
			//當來源不存在
			if (Original_color == null) {
				Debug.LogError ("Missing Original 3D Model");
				return;
			}
		}

//		this.GetUFO.transform.localRotation = TempRotation;


		// Create a new instance of the game object
		this.GetUFO = this.ReplaceTheUFO (Original_color, this.GetUFO.transform);


		this.m_bToggle = true;
		AddListener ();
		if (Collider)
			this.GetUFO.GetComponent<SphereCollider> ().enabled = true;
	}

	//UFO紅色
	public void Red ()
	{
		//實例化後發現子物件的transform值預設為(0,0,0)，因此必須再移除原模型前先將子物件值保留
		var tmp = this.GetUFO.transform.GetChild (0).localEulerAngles;

		//移除原模型
		if (this.GetUFO != null)
			MonoBehaviour.Destroy (this.GetUFO.transform.gameObject);

		//找到當前UFO的發光模型
		if (Red_color == null) {
			Red_color = Resources.Load<GameObject> ("JT/UFO_3D(R)/" + this.GetUFO.gameObject.name.Replace ("(Clone)", "") + "R");
			//當來源不存在
			if (Red_color == null) {
				Debug.LogError ("Missing Red 3D Model");
				return;
			}
		}
		
		this.GetUFO = ReplaceTheUFO (Red_color, this.GetUFO.transform);//替換UFO
		this.GetUFO.transform.GetChild (0).localEulerAngles = tmp;//實例化後將子物件設定為原來值
	}

	//UFO灰色
	public void Gray ()
	{
		//實例化後發現子物件的transform值預設為(0,0,0)，因此必須再移除原模型前先將子物件值保留
		var tmp = this.GetUFO.transform.GetChild (0).localEulerAngles;

		//移除原模型
		if (this.GetUFO != null)
			MonoBehaviour.Destroy (this.GetUFO.transform.gameObject);

		//找到當前UFO的發光模型
		if (Gray_color == null) {
			Gray_color = Resources.Load<GameObject> ("JT/UFO_3D(G)/" + this.GetUFO.gameObject.name.Replace ("(Clone)", "") + "G");
			//當來源不存在
			if (Gray_color == null) {
				Debug.LogError ("Missing Gray 3D Model");
				return;
			}
		}
			
		this.GetUFO = this.ReplaceTheUFO (Gray_color, this.GetUFO.transform);//替換UFO
		this.GetUFO.transform.GetChild (0).localEulerAngles = tmp;//實例化後將子物件設定為原來值
		this.GetUFO.GetComponent<SphereCollider> ().enabled = true;
		this.m_bToggle = false;
		AddListener ();
	}






	//替換UFO
	public GameObject ReplaceTheUFO (GameObject colorufo, Transform UFO_Transform)
	{
//		GameObject go = MonoBehaviour.Instantiate (colorufo, UFO_Transform.position, UFO_Transform.localRotation, UFO_group) as GameObject;

		GameObject go = MonoBehaviour.Instantiate (colorufo, UFO_group);

		go.transform.position = UFO_Transform.position;

		go.transform.localRotation = UFO_Transform.localRotation;

		go.transform.localScale = UFO_Transform.localScale;

//		go.transform.GetChild(0).rotation = UFO_Transform.localRotation;

//		Debug.Log(UFO_Transform.localRotation);

//		go.transform.GetChild(0).rotation.eulerAngles.Set(0,UFO_Transform.localRotation.y,0);

//		Debug.Log (go.transform.rotation);
//		Debug.Log (go.transform.GetChild (0).rotation);

//		go.GetComponentInChildren<Transform> ().rotation = Quaternion.Euler (new Vector3 (-90, 0, 0));

		return go;
	}
}


*/