using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
public class GM_Guide : MonoBehaviour {

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
	
	public int[] rand_curr= new int[3]{-1,-1,-1};
	private int reRand_currIndex;
	public GameObject mainCamera;
	public GameObject[] listObjectHide;
	public Sprite[] list_sprite_num_updates;
	GameObject Menu_board; 
	public GameObject btnBackAll;
	public GameObject manden;
	public GameObject sounds;
	void Start () {
		
		//	GameObject chao_0 = GameObject.Find ("Gases").transform.FindChild ("gas_1").FindChild ("chao").gameObject;
		
		
		//	list_chao.Add (chao_0);
		next_box = 0;
		Invoke ("timeCount",LevelControll.time_customer_appear);
		showUpgrade (false);
		showBoxItem (true);
		Menu_board = GameObject.Find ("Menu_board");
		createCharacter ();
		sounds = GameObject.Find ("Sounds");
		
	}
	
	void timeCount()
	{
		
		if (next_box<=LevelControll.maxPeople-1) {
			createCharacter();
		}
		
		if (!LevelControll.gamePause) {
			Invoke ("timeCount", LevelControll.time_customer_appear);
			
		}
		
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
			iTween.ScaleTo(pass,new Vector3(1,1,1),1);
			sounds.GetComponent<SoundController>().playSpe("level_complete");
		} else {
			GameObject fail = Menu_board.transform.FindChild ("level_end").transform.FindChild ("fail").gameObject;
			fail.gameObject.SetActive (true);
			iTween.ScaleTo(fail,new Vector3(1,1,1),1);
			sounds.GetComponent<SoundController>().playSpe("level_fail");
		}
		manden.SetActive (true);
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
	}
	public void showMainCam(bool val){
		mainCamera.SetActive (val);
		if (val) {
			GameObject came2 = GameObject.Find ("list_cam");
			foreach (Transform t in came2.transform) {
				t.gameObject.SetActive (false);
				
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
	
}

