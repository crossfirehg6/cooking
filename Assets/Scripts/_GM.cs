using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
public class _GM : MonoBehaviour {

	// Use this for initialization
	public static  int next_box; // diem dung cua nhan vat
	public static int level_food=1;
	public List<GameObject> list_plates = new List<GameObject>();
	public List<GameObject> list_chao = new List<GameObject>();
	public List<GameObject> list_lo = new List<GameObject>();
	public List<GameObject> list_vi_nuong = new List<GameObject>();
	public static int next_plate;
	
	public int[] list_Ob_check = new int[6];
	public GameObject[] customer_prefabs;
	public GameObject[] lst_Check;
	public GameObject Customers;

	public GameObject machines;
	public GameObject losuoi;


	private int time_count;

	public static bool passLevel;
	public int levelGame;
	public int timeToEnd;
	public int timePlus;

	public int[] rand_curr;
	private int reRand_currIndex;
	public GameObject mainCamera;
	public GameObject[] listObjectHide;
	public Sprite[] list_sprite_num_updates;
	public Sprite[] list_sprite_num_bonus;
	GameObject Menu_board; 
	public GameObject btnBackAll;
	public GameObject manden;
	public GameObject sounds;
	public GameObject guides;
	public static bool firstTime=true;
	public static int numCus;
	public GameObject cafeLevel1;
	public static int happyNum;
	private int timeWaitPause;
	public GameObject thung_rac;
	public GameObject star_cook;
	public GameObject star_cook_1;
	public int numchay;
	public static int numLevelPass;
	public static bool chaylandau;
	void Start () {

	//	GameObject chao_0 = GameObject.Find ("Gases").transform.FindChild ("gas_1").FindChild ("chao").gameObject;


	//	list_chao.Add (chao_0);
		next_box = 0;
		timeCount ();
		showUpgrade (false);
		showBoxItem (true);
		Menu_board = GameObject.Find ("Menu_board");
		createCharacter ();
		sounds = GameObject.Find ("Sounds");
		if (thung_rac != null) {
			iTween.FadeTo (thung_rac, 0, 0);
			thung_rac.transform.localScale = new Vector3 (1, 1, 1);
		}
		if (Application.loadedLevel == 1) {
			numLevelPass++;
		}
		if (firstTime) {
			if (cafeLevel1 != null) {
				cafeLevel1.GetComponent<Collider2D> ().enabled = false;
				cafeLevel1.transform.FindChild ("nuoc").gameObject.SetActive (false);
				cafeLevel1.transform.FindChild ("coc").GetChild(0).gameObject.SetActive (false);
			}
		}
	}

	public void timeCount()
	{


			if (next_box <= LevelControll.maxPeople - 1 && timeWaitPause >= LevelControll.time_customer_appear) {
				createCharacter ();
				timeWaitPause = 0;
			}

			if (!LevelControll.gamePause) {
				timeWaitPause++;
			}
			Invoke ("timeCount", 1);
		 


	}
	 public int getNextPlate(){
		for (int i=0; i<list_plates.Count; i++) {
				if(!list_plates[i].GetComponent<plate_controll>().hasFood)
				{
					return i;
				}
			}
		return list_plates.Count;
	}
	public int getNextChao(){
		for (int i=0; i<list_chao.Count; i++) {
			if(!list_chao[i].GetComponent<bep_lo>().hadFood)
			{
				return i;
			}
		}
		return list_plates.Count;
	}
	public int getNextLo(){
		for (int i=0; i<list_lo.Count; i++) {
			if(!list_lo[i].GetComponent<bep_lo>().hadFood)
			{
				return i;
			}
		}
		return list_plates.Count;
	}
	public int getNextViNuong(){
		for (int i=0; i<list_vi_nuong.Count; i++) {
			if(!list_vi_nuong[i].GetComponent<bep_lo>().hadFood)
			{
				return i;
			}
		}
		return list_plates.Count;
	}
	public void createCharacter()
	{
		int rand_no = Random.Range (0,customer_prefabs.Length);
		if (firstTime) {
			if(numCus==0)
			{
				rand_no=3;
			}
		}
		while (checkExitChar(rand_no)) 
		{
			rand_no = Random.Range (0,customer_prefabs.Length);
			checkExitChar(rand_no);
		}
		rand_curr[reRand_currIndex] = rand_no;

		GameObject cus = Instantiate (customer_prefabs[rand_no],new Vector3(-13,0,0),Quaternion.identity) as GameObject;
		cus.transform.parent = Customers.transform;
		cus.GetComponent<characters>().check_box = lst_Check[next_box];
		cus.GetComponent<characters> ().indexBoxCheck = next_box;
		cus.GetComponent<characters> ().this_num_index = rand_no;
		list_Ob_check [next_box] = 1;
		getNext ();

		reRand_currIndex++;
		if (reRand_currIndex >= rand_curr.Length) {
			reRand_currIndex=0;
		}
	}
	bool checkExitChar(int rand_no){
		for (int i=0; i<rand_curr.Length; i++) {
			if(rand_no == rand_curr[i])
			{
				return true;
			}
		}
		return false;
	}
	public void removeElementArrayCharacter(int num){
		for (int i=0; i<rand_curr.Length; i++) {
			if(num == rand_curr[i])
			{
				rand_curr[i] =-1;
			}
		}
	}
	public void add_unlock_plate(GameObject ob)
	{
		list_plates.Add (ob);
		var list = list_plates.OrderBy (s=>s.name).ToList();
		list_plates = list;

	}
	public void add_chao(GameObject ob)
	{
		list_chao.Add (ob);
		var list = list_chao.OrderBy (s=>s.transform.parent.name).ToList();
		list_chao = list;
	}
	public void add_lo(GameObject ob)
	{
		list_lo.Add (ob);
		var list = list_lo.OrderBy (s=>s.name).ToList();
		list_lo = list;
	}
	public void add_vi_nuong(GameObject ob)
	{
		list_vi_nuong.Add (ob);
		var list = list_vi_nuong.OrderBy (s=>s.transform.parent.name).ToList();
		list_vi_nuong = list;
	}
	public void getNext()
	{
		for(int i = 0;i<lst_Check.Length;i++)
		{
			next_box=3;
			if(list_Ob_check[i]==0)
			{
				next_box =i;
				return ;
			}
		}
	}
	public void changeListval(int indexBoxCheck)
	{
		list_Ob_check [indexBoxCheck] = 0;
		getNext ();
	}

	public void showEnd(bool val, int numStar){
		sounds.GetComponent<SoundController> ().pauseSpe ("bgSound");
		resetLevel ();
		if (val) {
			GameObject pass = Menu_board.transform.FindChild ("level_end").transform.FindChild ("pass").gameObject;
			pass.gameObject.SetActive (true);
			if(numLevelPass>=3)
			{
				GameObject btnUpdate2 = pass.transform.FindChild("btnUpdate").GetChild(0).gameObject;
				StartCoroutine(nhapnhayUpdate(btnUpdate2,true));

				//numLevelPass=0;
			}
			for(int i=0;i<=numStar;i++)
			{
				Transform t = pass.transform.FindChild("star_"+i);
				if(i==numStar){
					if(t !=null)
					{

						t.gameObject.SetActive(true);
					}
				}
				else
				{
					if(t !=null)
					{
						
						t.gameObject.SetActive(false);
					}
				}

			}
			if(numStar==1)
			{
				pass.transform.FindChild("bonus").gameObject.SetActive(true);
				GameObject num1 = pass.transform.FindChild("bonus").FindChild("1").gameObject;
				GameObject num2 = pass.transform.FindChild("bonus").FindChild("2").gameObject;
				changeSprite2(20,num1,num2);
				
				GameObject scores = GameObject.Find ("Scores");
				scores.GetComponent<Score> ().updateScore (20, false);
			}
			if(numStar==2)
			{
				pass.transform.FindChild("bonus").gameObject.SetActive(true);
				GameObject num1 = pass.transform.FindChild("bonus").FindChild("1").gameObject;
				GameObject num2 = pass.transform.FindChild("bonus").FindChild("2").gameObject;
				changeSprite2(30,num1,num2);
				GameObject scores = GameObject.Find ("Scores");
				scores.GetComponent<Score> ().updateScore (30, false);
			}
			if(numStar==3)
			{
				pass.transform.FindChild("bonus").gameObject.SetActive(true);
				GameObject num1 = pass.transform.FindChild("bonus").FindChild("1").gameObject;
				GameObject num2 = pass.transform.FindChild("bonus").FindChild("2").gameObject;
				changeSprite2(50,num1,num2);
				GameObject scores = GameObject.Find ("Scores");
				scores.GetComponent<Score> ().updateScore (50, false);
			}
			iTween.ScaleTo(pass,new Vector3(1,1,1),1);
			sounds.GetComponent<SoundController>().playSpe("level_complete");


		} else {
			GameObject fail = Menu_board.transform.FindChild ("level_end").transform.FindChild ("fail").gameObject;
			fail.gameObject.SetActive (true);
			iTween.ScaleTo(fail,new Vector3(1,1,1),1);
			sounds.GetComponent<SoundController>().playSpe("level_fail");
			if(numLevelPass>=3)
			{
				GameObject btnUpdate2 = fail.transform.FindChild("btnUpdate").GetChild(0).gameObject;
				StartCoroutine(nhapnhayUpdate(btnUpdate2,true));
			
				//numLevelPass=0;
			}
		}
		manden.SetActive (true);
		if (firstTime) {
			guideSteps (10);
		}
	}

	public void showBoxItem(bool val) // bat/tat box collider khi qua level
	{

		if (!val)
		{
			foreach (Transform t in Customers.transform) {
				Destroy (t.gameObject);
			}

		}
		Customers.SetActive(val);
		GameObject nguyenlieu = GameObject.Find ("Nguyen_lieu");
		foreach (Transform t in nguyenlieu.transform) {
			if(t.gameObject.GetComponent<Collider2D>() !=null)
			{
				t.gameObject.GetComponent<Collider2D>().enabled=val;
			}
		}
		foreach (Transform t in machines.transform) {
			if(t.name !="updateBar")
			{
				foreach(Transform t1 in t)
				{
					foreach(Transform t2 in t1)
					{
						if(t2.gameObject.GetComponent<Collider2D>() !=null)
						{
							t2.gameObject.GetComponent<Collider2D>().enabled =val;

						}
					}
				}
			}
		}
	
	}
	public void showUpgrade(bool val) // hien thi nut update
	{
		GameObject itemUpdate = GameObject.Find ("ItemUpdate");

		btnBackAll.SetActive (val);
		foreach (Transform t in itemUpdate.transform) {
			foreach(Transform t1 in t )
			{
				if(t1.name =="btnUpgrade")
				{
					t1.gameObject.GetComponent<SpriteRenderer>().enabled =val;
					t1.gameObject.GetComponent<Collider2D>().enabled =val;
				}
				
			}
		}
		showDiskBox (val);
		manden.SetActive (false);
		GameObject buyItems = GameObject.Find ("BuyItems");
		if (buyItems != null)
		{
			foreach (Transform t in buyItems.transform) {
				if (t.name != "board") {
					t.gameObject.SetActive (val);
					t.transform.FindChild ("btnBuy").gameObject.GetComponent<btnBuying> ().showBtnUpgrade ();
				}
			}
		}
	}
	public void showDiskBox(bool val){
		GameObject plates = GameObject.Find ("Plates").transform.FindChild ("level_1").gameObject;
		foreach (Transform t in plates.transform) {
			if(t.gameObject.GetComponent<Collider2D>() !=null)
			{
				t.gameObject.GetComponent<Collider2D>().enabled =val;
			}	
		}
	}
	public void showCameraUpgrade(string cameraName){
		//mainCamera.SetActive (false);
		btnBackAll.SetActive (true);
		GameObject came2 = GameObject.Find ("list_cam").transform.FindChild (cameraName).gameObject;
		came2.SetActive (true);
		GameObject itemUpdate = GameObject.Find ("ItemUpdate");
		

		foreach (Transform t in itemUpdate.transform) {

				if(t.name !=cameraName)
				{
					t.gameObject.SetActive(false);
				}
		}
	}
	public void showMainCam(bool val){
		mainCamera.SetActive (val);
		if (val) {
			GameObject came2 = GameObject.Find ("list_cam");
			foreach (Transform t in came2.transform) {
				t.gameObject.SetActive (false);

			}
			GameObject itemUpdate = GameObject.Find ("ItemUpdate");
			foreach (Transform t in itemUpdate.transform) {
				
				if(t.name !="btnBackAll")
				{
					t.gameObject.SetActive(val);
				}
			}
		}
		showOb (val);

	}
	public void showOb(bool val)
	{

		foreach (GameObject o in listObjectHide) {
			
			if(val)
			{
				o.transform.localScale=new Vector3(0.7f,0.7f,1);
			}
			else
			{
				o.transform.localScale=new Vector3(0f,0f,1);
			}
		}
	}
	public void resetLevel()
	{
		foreach (GameObject o in list_chao) {
			foreach(Transform t in o.transform)
			{
				if(t.name !="updateBar" && t.name !="thongbao")
				{
					t.gameObject.GetComponent<thit_nau>().returnBegin();
				}
			}
		}
		foreach (GameObject o in list_lo) {
			foreach(Transform t in o.transform)
			{
				if(t.name !="o_nuong")
				{
					t.gameObject.GetComponent<thit_nau>().returnBegin();
				}
			}
		}
		foreach (GameObject o in list_plates) {
			o.transform.FindChild("food").gameObject.GetComponent<food_disk>().moveback();
		}
		foreach (GameObject o in list_vi_nuong) {
			foreach(Transform t in o.transform)
			{
				if(t.name !="updateBar")
				{
					t.gameObject.GetComponent<thit_nau>().returnBegin();
				}
			}
		}
		GameObject pass = Menu_board.transform.FindChild ("level_end").transform.FindChild ("pass").gameObject;
		//pass.gameObject.SetActive (true);
		for(int i=0;i<=3;i++)
		{
			Transform t = pass.transform.FindChild("star_"+i);
			if(t !=null)
			{
				t.gameObject.SetActive(false);
			}
		}
	}
	public IEnumerator showGuide(int num, float timess)
	{
		yield return new WaitForSeconds (timess);
		if (num == 2) {
			guideSteps(2);
		}
		if (num == 9) {
			guideSteps(9);
		}

		foreach (Transform t in guides.transform) {
			if(t.name == num.ToString())
			{
				t.gameObject.SetActive(true);
			}
			else
			{
				t.gameObject.SetActive(false);
			}
		}
	}
	public void guideSteps(int step)
	{
		if (step == 1) {
			StartCoroutine(showGuide(1,0));
			StartCoroutine(showGuide(2,5));
			GameObject nguyenlieu = GameObject.Find("Nguyen_lieu");
			if(nguyenlieu !=null)
			{
				nguyenlieu.transform.FindChild("thit_lon").gameObject.GetComponent<Collider2D>().enabled=false;
			}
		}
		else if (step == 2) {
			GameObject nguyenlieu = GameObject.Find("Nguyen_lieu");
			if(nguyenlieu !=null)
			{
				nguyenlieu.transform.FindChild("dia_1").gameObject.GetComponent<Collider2D>().enabled=true;
			}


		}
		else if (step == 3) {
			StartCoroutine(showGuide(3,0));
			GameObject nguyenlieu = GameObject.Find("Nguyen_lieu");
			if(nguyenlieu !=null)
			{
				nguyenlieu.transform.FindChild("thit_lon").gameObject.GetComponent<Collider2D>().enabled=true;
			}
		}
		else if (step == 4) {
			StartCoroutine(showGuide(4,0));

		}
		else if (step == 5) {
			StartCoroutine(showGuide(5,0));
			
		}
		else if (step == 6) {
			StartCoroutine(showGuide(6,0));

		}
		else if (step == 7) {
			StartCoroutine(showGuide(7,0));
			
		}
		else if (step == 8) {
			StartCoroutine(showGuide(8,0));

			if(cafeLevel1 !=null)
			{
				StartCoroutine(cafeLevel1.GetComponent<FoodsControll>().runningMachine(LevelControll.timeMachine));
				cafeLevel1.transform.FindChild("nuoc").gameObject.SetActive(true);
				cafeLevel1.GetComponent<Collider2D>().enabled=false;
			}
			StartCoroutine(showGuide(9,LevelControll.timeMachine));
		}
		else if (step == 9) {
			if(cafeLevel1 !=null)
			{
				cafeLevel1.GetComponent<Collider2D>().enabled=true;
			}

		}
		else if (step == 10) {
			StartCoroutine(showGuide(10,0));
			GameObject pass = Menu_board.transform.FindChild ("level_end").transform.FindChild ("pass").gameObject;
			pass.transform.FindChild("btnNext").gameObject.GetComponent<Collider2D>().enabled=false;
			pass.transform.FindChild("btnReplay").gameObject.GetComponent<Collider2D>().enabled=false;

			
		}
		else if (step == 11) {
			StartCoroutine(showGuide(11,0));
			
		}
		else if (step == 12) {
			StartCoroutine(showGuide(12,0));
			
		}
		else if (step == 13) {
			StartCoroutine(showGuide(13,0));
			GameObject UpgradeScene = GameObject.Find("UpgradeScene");
			UpgradeScene.transform.FindChild("machine").FindChild("btnDiscard").gameObject.GetComponent<Collider2D>().enabled=false;
			StartCoroutine(showGuide(0,5));
		}
		else if (step == 14) {
			StartCoroutine(showGuide(14,0));
			
		}
		else if (step == 16) {
			StartCoroutine(showGuide(16,3));
			StartCoroutine(showGuide(0,8));
		}
		else if (step == 17) {
			StartCoroutine(showGuide(0,0));
			guideSteps(16);
		}
		else if (step == 20) {
			StartCoroutine(showGuide(20,0));
			StartCoroutine(showGuide(0,5));
		}
		else if (step == 15) {
			StartCoroutine(showGuide(15,0));
			GameObject pass = Menu_board.transform.FindChild ("level_end").transform.FindChild ("pass").gameObject;
			pass.transform.FindChild("btnNext").gameObject.GetComponent<Collider2D>().enabled=true;
			pass.transform.FindChild("btnReplay").gameObject.GetComponent<Collider2D>().enabled=true;
		

			
		}
		else if (step == 0) {
			StartCoroutine(showGuide(0,0));
			
		}
	}
	public void changeSprite(int moneyRequire, GameObject num1, GameObject num2,GameObject num3,GameObject num4,GameObject num5,GameObject num6,GameObject num7)
	{
		if (num2 != null) {
			num2.SetActive(false);
		}
		if (num3 != null) {
			num3.SetActive(false);
		}
		if (num4 != null) {
			num4.SetActive(false);
		}
		if (num5 != null) {
			num5.SetActive(false);
		}
		if (num6 != null) {
			num6.SetActive(false);
		}
		if (num7 != null) {
			num7.SetActive(false);
		}
		int score = moneyRequire;
		if (score < 0) 
		{
			score=0;
		}
		else if(score<10)
		{
			int index1 = score;
			num1.GetComponent<SpriteRenderer>().sprite = list_sprite_num_updates[index1];
			
		}
		else if(score<100)
		{
			int index1 = score/10;
			int index2 = score%10;
			num2.SetActive(true);
			num1.GetComponent<SpriteRenderer>().sprite = list_sprite_num_updates[index1];
			num2.GetComponent<SpriteRenderer>().sprite = list_sprite_num_updates[index2];
			
			
		}
		else if(score<1000)
		{
			int index1 = score/100;
			int index2 = (score%100)/10;
			int index3 = (score%100)%10;
			num2.SetActive(true);
			num3.SetActive(true);
			
			num1.GetComponent<SpriteRenderer>().sprite = list_sprite_num_updates[index1];
			num2.GetComponent<SpriteRenderer>().sprite = list_sprite_num_updates[index2];
			num3.GetComponent<SpriteRenderer>().sprite = list_sprite_num_updates[index3];
		}
		else if(score<10000)
		{
			int index1 = score/1000;
			int index2 = (score%1000)/100;
			int index3 = ((score%1000)%100)/10;
			int index4 = ((score%1000)%100)%10;
			num2.SetActive(true);
			num3.SetActive(true);
			num4.SetActive(true);
			num1.GetComponent<SpriteRenderer>().sprite = list_sprite_num_updates[index1];
			num2.GetComponent<SpriteRenderer>().sprite = list_sprite_num_updates[index2];
			num3.GetComponent<SpriteRenderer>().sprite = list_sprite_num_updates[index3];
			num4.GetComponent<SpriteRenderer>().sprite = list_sprite_num_updates[index4];
		}
		else if(score<100000)
		{		
			int index1 = score/10000;
			int index2 = (score%10000)/1000;
			int index3 = ((score%10000)%1000)/100;
			int index4 = (((score%10000)%1000)%100)/10;
			int index5 = (((score%10000)%1000)%100)%10;
			num2.SetActive(true);
			num3.SetActive(true);
			num4.SetActive(true);
			num5.SetActive(true);
			
			num1.GetComponent<SpriteRenderer>().sprite = list_sprite_num_updates[index1];
			num2.GetComponent<SpriteRenderer>().sprite = list_sprite_num_updates[index2];
			num3.GetComponent<SpriteRenderer>().sprite = list_sprite_num_updates[index3];
			num4.GetComponent<SpriteRenderer>().sprite = list_sprite_num_updates[index4];
			num5.GetComponent<SpriteRenderer>().sprite = list_sprite_num_updates[index5];
		}
		else if(score<1000000)
		{
			int index1 = score/100000;
			int index2 = (score%100000)/10000;
			int index3 = ((score%100000)%10000)/1000;
			int index4 = (((score%100000)%10000)%1000)/100;
			int index5 = ((((score%100000)%10000)%1000)%100)/10;
			int index6 = ((((score%100000)%10000)%1000)%100)%10;
			num2.SetActive(true);
			num3.SetActive(true);
			num4.SetActive(true);
			num5.SetActive(true);
			num6.SetActive(true);
			num1.GetComponent<SpriteRenderer>().sprite = list_sprite_num_updates[index1];
			num2.GetComponent<SpriteRenderer>().sprite = list_sprite_num_updates[index2];
			num3.GetComponent<SpriteRenderer>().sprite = list_sprite_num_updates[index3];
			num4.GetComponent<SpriteRenderer>().sprite = list_sprite_num_updates[index4];
			num5.GetComponent<SpriteRenderer>().sprite = list_sprite_num_updates[index5];
			num6.GetComponent<SpriteRenderer>().sprite = list_sprite_num_updates[index6];
		}
		else if(score<10000000)
		{
			int index1 = score/1000000;
			int index2 = (score%1000000)/100000;
			int index3 = ((score%1000000)%100000)/10000;
			int index4 = (((score%1000000)%100000)%10000)/1000;
			int index5 = ((((score%1000000)%100000)%10000)%1000)/100;
			int index6 = ((((score%1000000)%100000)%10000)%1000)%100/10;
			int index7 = (((((score%1000000)%100000)%10000)%1000)%100)%10;
			num2.SetActive(true);
			num3.SetActive(true);
			num4.SetActive(true);
			num5.SetActive(true);
			num6.SetActive(true);
			num7.SetActive(true);
			num1.GetComponent<SpriteRenderer>().sprite = list_sprite_num_updates[index1];
			num2.GetComponent<SpriteRenderer>().sprite = list_sprite_num_updates[index2];
			num3.GetComponent<SpriteRenderer>().sprite = list_sprite_num_updates[index3];
			num4.GetComponent<SpriteRenderer>().sprite = list_sprite_num_updates[index4];
			num5.GetComponent<SpriteRenderer>().sprite = list_sprite_num_updates[index5];
			num6.GetComponent<SpriteRenderer>().sprite = list_sprite_num_updates[index6];
			num7.GetComponent<SpriteRenderer>().sprite = list_sprite_num_updates[index7];
			
		}
	}
	public void changeSprite2(int moneyRequire, GameObject num1, GameObject num2)
	{
		if (num2 != null) {
			num2.SetActive(false);
		}
		int score = moneyRequire;
		if (score < 0) 
		{
			score=0;
		}
		else if(score<10)
		{
			int index1 = score;
			num1.GetComponent<SpriteRenderer>().sprite = list_sprite_num_bonus[index1];
			
		}
		else if(score<100)
		{
			int index1 = score/10;
			int index2 = score%10;
			num2.SetActive(true);
			num1.GetComponent<SpriteRenderer>().sprite = list_sprite_num_bonus[index1];
			num2.GetComponent<SpriteRenderer>().sprite = list_sprite_num_bonus[index2];

		}
	}
	public IEnumerator nhapnhaythungrac(bool val)
	{
		yield return new WaitForSeconds (0);
		if (val) {
			iTween.FadeTo (thung_rac, 1, 1);
			yield return new WaitForSeconds (1);
			iTween.FadeTo (thung_rac, 0, 1);
			//yield return new WaitForSeconds (1);
		} 
		else {
			iTween.FadeTo (thung_rac, 0, 0);
		}
		yield return new WaitForSeconds (1);
		if (numchay > 0) {
			StartCoroutine (nhapnhaythungrac (true));
		}
	}
	public void showStarCook(Vector3 pos)
	{
		if (star_cook != null) {
			if(!LevelControll.gamePause){
			GameObject abc=	Instantiate(star_cook,pos,Quaternion.identity) as GameObject;
			iTween.FadeTo(abc,0,2);
			Destroy(abc,1);
			}
		}
	}
	public void showStarCook2(Vector3 pos)
	{
		if (star_cook_1 != null) {
			if(!LevelControll.gamePause){
			GameObject abc=	Instantiate(star_cook_1,pos,Quaternion.identity) as GameObject;
			iTween.FadeTo(abc,0,2);
			Destroy(abc,1);
			}
		}
	}
	public IEnumerator nhapnhayUpdate(GameObject ob,bool val)
	{
		yield return new WaitForSeconds (0);
		if (val) {
			ob.transform.localScale=Vector3.one;
			iTween.FadeTo (ob, 1, 1);
			yield return new WaitForSeconds (1);
			iTween.FadeTo (ob, 0, 1);
			//yield return new WaitForSeconds (1);
			yield return new WaitForSeconds (1);
			if(numLevelPass>=3){
			StartCoroutine (nhapnhayUpdate (ob,true));
			}
		} 
		else {
			iTween.FadeTo (ob, 0, 0);
			ob.transform.localScale=Vector3.zero;
		}


			

	}
	public void showOpenItem(bool val)
	{
		if (val) {
			GameObject NewItems = Menu_board.transform.FindChild ("NewItems").gameObject;
			NewItems.SetActive (true);

			if (LevelControll.this_level == 9) {
				NewItems.transform.FindChild ("txt").gameObject.SetActive (true);
				NewItems.transform.FindChild ("txt1").gameObject.SetActive (true);
			} else {
				NewItems.transform.FindChild ("txt1").gameObject.SetActive (true);
				NewItems.transform.FindChild ("txt").gameObject.SetActive (false);
			}
			GameObject pass = Menu_board.transform.FindChild ("level_end").gameObject;
			pass.transform.localScale= Vector3.zero;
		} else {
			GameObject NewItems = Menu_board.transform.FindChild ("NewItems").gameObject;
			NewItems.SetActive (false);
			GameObject pass = Menu_board.transform.FindChild ("level_end").gameObject;
			pass.transform.localScale= new Vector3 (0.8f,0.8f,0.8f);
		}
	}
}

