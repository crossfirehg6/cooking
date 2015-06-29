using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class characters : MonoBehaviour {

	// Use this for initialization
	public Sprite[] mat;
	public Sprite[] than;
	public Sprite[] ao;
	public Sprite[] moi;
	public Sprite[] kinh;
	public Sprite[] toc;

	public string[] requestItems =new string[2];
	public Sprite[] item_Level1;
	public string[] listItemsName;

	private int[] numIdex=new int[2];
	public GameObject do_an_1;
	public GameObject do_an_2;
	public GameObject bg_think;

	public bool order_food;
	public bool get_food;
	public bool exit_game;

	private int numtime;
	public GameObject check_box;
	public int indexBoxCheck;
	private int numRequest; // so luong do an muon yeu cau

	public List<GameObject> list_by_level = new List<GameObject>();
	public int totalmoney;
	public float y_val;
	private bool ungry;
	public int this_num_index;
	private int timeWaiting;
	private GameObject sounds;
	public string[] list_sound;
	void Start () {
		changeSprite ();
		y_val = Random.Range(0.08f,0.1f);
		InvokeRepeating ("changeYVal",0.01f,1);
		sounds = GameObject.Find ("Sounds");
	}
	
	// Update is called once per frame
	void Update () {
		if(!LevelControll.gamePause)
		{
			if (!order_food) 
			{
				this.transform.Translate(new Vector3(1,y_val,0) * 4*Time.deltaTime);
				//changeYVal();
			}
			if (exit_game) 
			{
			//	this.transform.Translate(Vector3.right * 4*Time.deltaTime);
				this.transform.Translate(new Vector3(1,y_val,0) * 4*Time.deltaTime);
				if(this.transform.position.x>20)
				{
					GameObject Gm = GameObject.Find("GM");
					//Gm.GetComponent<_GM>().createCharacter();
					Gm.GetComponent<_GM>().changeListval(indexBoxCheck);
					Destroy(this.gameObject);
					Gm.GetComponent<_GM>().removeElementArrayCharacter(this_num_index);
				}
			}
		}
	}
	void changeYVal(){
		y_val *= -1;
	}
	void OnTriggerStay2D(Collider2D other)
	{
		if (other.gameObject == check_box) 
		{
			float distance =Mathf.Abs(this.transform.position.x - other.transform.position.x);

			if(distance<=0.15f)
			{
				if(!order_food)
				{
					Invoke("timeWait",1);
					this.transform.position = new Vector3(other.transform.position.x,this.transform.position.y,0);
					order_food=true;
					createItem(LevelControll.this_level);
					changeSpriteLayer(40);
				}
			}
		}
	}
	// thay doi hinh dang nhan vat
	public void changeSprite()
	{
		if (mat.Length > 0) {
			GameObject mat_c = this.transform.FindChild("mat").gameObject;
			int rand = Random.Range(0,mat.Length);
			mat_c.GetComponent<SpriteRenderer>().sprite = mat[rand];
		}
		if (than.Length > 0) {
			GameObject than_c = this.transform.FindChild("than").gameObject;
			int rand = Random.Range(0,than.Length);
			than_c.GetComponent<SpriteRenderer>().sprite = than[rand];
		}
		if (ao.Length > 0) {
			GameObject ao_c = this.transform.FindChild("ao").gameObject;
			int rand = Random.Range(0,ao.Length);
			ao_c.GetComponent<SpriteRenderer>().sprite = ao[rand];
		}
		if (moi.Length > 0) {
			GameObject moi_c = this.transform.FindChild("moi").gameObject;
			int rand = Random.Range(0,moi.Length);
			moi_c.GetComponent<SpriteRenderer>().sprite = moi[rand];
		}
		if (kinh.Length > 0) {
			GameObject kinh_c = this.transform.FindChild("kinh").gameObject;
			int rand = Random.Range(0,kinh.Length);
			kinh_c.GetComponent<SpriteRenderer>().sprite = kinh[rand];
		}
		if (toc.Length > 0) {
			GameObject toc_c = this.transform.FindChild("toc").gameObject;
			int rand = Random.Range(0,toc.Length);
			toc_c.GetComponent<SpriteRenderer>().sprite = toc[rand];
		}
	}
	// lua chon do an
	public void createItem(int level)
	{
			list_by_level.Clear ();
			list_by_level = getListFood (level);
			int rand_num = Random.Range(0,10);
			if (_GM.firstTime) {
				if(_GM.numCus<2)
				{
					rand_num=1;
				}
			}
			 if(rand_num<8)
			{
				//random do an hoac do uong
				

				do_an_1.SetActive(true);
				do_an_2.SetActive(false);

				int rand_2 = Random.Range(0,list_by_level.Count);
				if (_GM.firstTime) {
					GameObject gm = GameObject.Find("GM");
					if(_GM.numCus==0)
					{
						rand_2=1;
						gm.GetComponent<_GM>().guideSteps(1);
						LevelControll.maxPeople=0;
					}
					if(_GM.numCus==1)
					{
						rand_2=0;
						gm.GetComponent<_GM>().guideSteps(8);
					}
				}
				requestItems[0] = list_by_level[rand_2].GetComponent<food_cost>().foodName; // lay ten thuc an
				do_an_1.GetComponent<SpriteRenderer>().sprite = list_by_level[rand_2].GetComponent<SpriteRenderer>().sprite; // thay doi sprite
				totalmoney =  list_by_level[rand_2].GetComponent<food_cost>().cost + LevelControll.moneyBonus;
				numRequest=1;  

			}
			else
			{


				//random do uong
				do_an_1.SetActive(true);
				do_an_2.SetActive(true);

				int rand_2 = Random.Range(0,list_by_level.Count);
				int rand_3 = Random.Range(0,list_by_level.Count);
				while(rand_3 ==rand_2)
				{
					rand_3 = Random.Range(0,list_by_level.Count);
				}
				requestItems[0] = list_by_level[rand_2].GetComponent<food_cost>().foodName;
				requestItems[1] = list_by_level[rand_3].GetComponent<food_cost>().foodName;
				do_an_1.GetComponent<SpriteRenderer>().sprite = list_by_level[rand_2].GetComponent<SpriteRenderer>().sprite;

				do_an_2.GetComponent<SpriteRenderer>().sprite = list_by_level[rand_3].GetComponent<SpriteRenderer>().sprite;
				totalmoney =  list_by_level[rand_2].GetComponent<food_cost>().cost + list_by_level[rand_3].GetComponent<food_cost>().cost + LevelControll.moneyBonus*2;
				numRequest=2;
			}
		bg_think.SetActive (true);

	}
	// hien thi do an da chon

	public bool checkFood(string foodname)
	{
		for (int i=0; i<requestItems.Length; i++) 
		{
			if(!string.IsNullOrEmpty(requestItems[i]))
			{
				if(requestItems[i]==foodname)
				{
					hideRequest(i+1);
					if(timeWaiting<=5){
					int rd = Random.Range(0,2);
					sounds.GetComponent<SoundController>().playSpe2(list_sound[rd]);
					}
					return true;
				}
			}
		}
		return false;
	}
	void hideRequest(int num)
	{
		if (num == 1) 
		{
			do_an_1.SetActive(false);
			requestItems[0] =null;
		}
		else if(num==2)
		{
			do_an_2.SetActive(false);
			requestItems[1] =null;
		}
		numRequest--;
		if (numRequest == 0)
		{
			_GM.happyNum++;
			if(_GM.happyNum==4)
			{
				if(LevelControll.chauhoa==1)
				{
					GameObject scores = GameObject.Find ("Scores");
					scores.GetComponent<Score> ().updateScore (20, true);
				}
				_GM.happyNum=0;
			}
			check_box.GetComponent<checkBoxControll>().showMoney(true,totalmoney);
			changeSpriteLayer(-20);
			exit_game=true;
			bg_think.SetActive (false);
			if(_GM.firstTime)
			{
				if(_GM.numCus==0)
				{
					GameObject GM = GameObject.Find("GM");
					GM.GetComponent<_GM>().guideSteps(7);

				}
				if(_GM.numCus==1)
				{
					GameObject GM = GameObject.Find("GM");
					//GM.GetComponent<_GM>().guideSteps(0);
					GM.GetComponent<_GM>().guideSteps(17);
					_GM.numCus=2;
					LevelControll.timeCusWait =15;
					GameObject Level = GameObject.Find("Levels");
					Level.GetComponent<LevelControll>().time_count=0;
					Level.GetComponent<LevelControll>().this_level_time=100;
				}
			}

		}

	}
	List<GameObject> getListFood(int level)
	{
		GameObject ListFoods = GameObject.Find ("List_Foods");
		GameObject[] listFood = ListFoods.GetComponent<List_Food> ().listFoods;
		List<GameObject> list1 = new List<GameObject>();
		foreach (GameObject ob in listFood) {
			if(ob.GetComponent<food_cost>().level <= level)
			{
				list1.Add(ob);
			}
		}
		return list1;
	}
	void changeSpriteLayer(int val)
	{
		foreach (Transform t in this.transform) {
			if(t.gameObject.GetComponent<SpriteRenderer>() !=null)
			{
				t.gameObject.GetComponent<SpriteRenderer>().sortingOrder +=val;
			}
		}
	}
	void runoutofTime()
	{
		if (!exit_game)
		{
			_GM.happyNum=0;
			exit_game = true;
			requestItems [1] = null;
			requestItems [0] = null;
			do_an_1.SetActive (false);
			do_an_2.SetActive (false);
			bg_think.SetActive (false);
			ungry = true;
			sounds.GetComponent<SoundController> ().playSpe2 ("bo_di");
			changeSpriteLayer (-20);
		}
	}
	void timeWait()
	{
		timeWaiting++;
		if (timeWaiting > LevelControll.timeCusWait) {
			runoutofTime ();
		} else 
		{
			Invoke ("timeWait", 1);
		}
		scaleThinkBar ();
	}
	void scaleThinkBar()
	{
		GameObject bgt = bg_think.transform.FindChild ("1").gameObject;
		float timeExist = LevelControll.timeCusWait - timeWaiting;
		if (timeWaiting < 0) {
			timeExist=0;
		}
		float val = (float)timeExist / (float)LevelControll.timeCusWait;
		bgt.transform.localScale = new Vector3 (1,val,1);
	}
}
