using UnityEngine;
using System.Collections;
using System;
public class LevelControll : MonoBehaviour {

	// Use this for initialization
	public static int this_level=1;
	public static float time_customer_appear;
	public static int level_tv=0;
	public static int level_manocan=0;
	public static int level_table=0;

	public static string level_bep="0_0_0_0_0_0_0_0";

	public static int level_machine=0;
	public static int level_lo=0;
	public static int gau_bong=0;
	public static int mayxeng=0;
	public static int maytinhtien=0;
	public static int chauhoa=0;
	public static string openDiskName;

	public int time_count;
	public int this_level_time;
	public int this_level_time_plus;
	public int this_level_money_require;
	public int this_money_star_1;
	public int this_money_star_2;
	public int this_money_star_3;

	public static bool passThis;
	public static bool gamePause;

	public GameObject machine;
	public GameObject bep;
	public GameObject lo;
	public GameObject manocan;
	public GameObject tivi;
	public GameObject table;

	public static float timeMachine;
	public  float[] timeGas;
	public static float timeLo;

	public Sprite[] listSpMachine;
	public Sprite[] listSpMachine1;
	public Sprite[] listSpBep;
	public Sprite[] listSpLo;
	public static int money_unlock_plate=100;
	GameObject scoress;
	Score scoreClass;
	SaveLoad sv = new SaveLoad ();
	public static int maxLevelOpened=1;
	public static int maxPeople;
	public static int moneyBonus;
	public static float timeCusWait;
	public GameObject[] level_num;


	public GameObject[] level_time;
	void Awake(){
		maxPeople = 1;
		openDiskName = "0";
		timeCusWait = 20;
		#if UNITY_IPHONE
		Environment.SetEnvironmentVariable("MONO_REFLECTION_SERIALIZER", "yes");
		#endif
	
		//this_level = 1;
	//	this_level = 10;
		timeMachine = 7;
		//timeGas = 5;
		timeLo = 7;

		moneyBonus = 0;
		//saveGame ();

		sv.loadFile ();

		if (SaveLoad.savedValue != null) {
			_GM.firstTime=false;
			maxLevelOpened = SaveLoad.savedValue.level;
		//	this_level = SaveLoad.savedValue.level;
			Score.score = SaveLoad.savedValue.total_score;

			level_tv = SaveLoad.savedValue.level_TV;
			level_manocan = SaveLoad.savedValue.level_manocan;
			level_table = SaveLoad.savedValue.level_table;
			level_bep = SaveLoad.savedValue.level_bep;
			level_lo = SaveLoad.savedValue.level_lo;
			level_machine = SaveLoad.savedValue.level_may;
			openDiskName= SaveLoad.savedValue.list_disk_open;
			mayxeng = SaveLoad.savedValue.may_xeng;
			maytinhtien = SaveLoad.savedValue.may_tinh_tien;
			gau_bong = SaveLoad.savedValue.gau_bong;
			chauhoa=SaveLoad.savedValue.chau_hoa;
		
		
		}

//		this_level = 100;
//		maxLevelOpened = 100;
		getLevel ();
		SaveLoad.this_level_value.level = this_level;


	}
	void Start () {
		int soundNum = this_level % 13;
		if (soundNum == 0) {
			soundNum = 13;
		}
		GameObject sound_m = GameObject.Find ("Sounds");
		if (Application.loadedLevel == 1) {
			sound_m.GetComponent<SoundController> ().pauseSpe ("bgSound");
			sound_m.transform.FindChild ("bgSound").gameObject.GetComponent<AudioSource> ().clip = sound_m.transform.FindChild ("bgSound_" + soundNum).gameObject.GetComponent<AudioSource> ().clip;
			sound_m.GetComponent<SoundController> ().playSpe2 ("bgSound");
			GameObject sound1 = GameObject.Find ("Sounds_1");
			if (sound1 != null) {
				Destroy (sound1);
			}
		}

		passThis = false;
		scoress = GameObject.Find ("Scores");
		scoreClass = scoress.GetComponent<Score> ();
		timeCount ();
		addOpenPlateToGM ();
		changeSpriteGas ();
		if (!_GM.firstTime) {

			changeItemLevel ();


			changeLevelManocan ();
			changeLevelTivi ();
			changeLevelTable ();

		} else {
			timeCusWait = 1000000;
			this_level_time = 5000000;
		}
		GameObject buyItems = GameObject.Find ("BuyItems");
		if (buyItems != null) {
			if (maytinhtien == 1) {
				buyItems.transform.FindChild ("maytinhtien").gameObject.SetActive (true);
				buyItems.transform.FindChild ("maytinhtien").transform.FindChild ("maytinhtien").gameObject.SetActive (true);
				buyItems.transform.FindChild ("maytinhtien").transform.FindChild ("btnBuy").gameObject.SetActive (false);

			}
			if (mayxeng == 1) {
			
				buyItems.transform.FindChild ("mayxeng").gameObject.SetActive (true);
				buyItems.transform.FindChild ("mayxeng").transform.FindChild ("mayxeng").gameObject.SetActive (true);
				buyItems.transform.FindChild ("mayxeng").transform.FindChild ("btnBuy").gameObject.SetActive (false);
				timeCusWait = timeCusWait + 5;
			}
			if (chauhoa == 1) {
				buyItems.transform.FindChild ("chauhoa").gameObject.SetActive (true);
				buyItems.transform.FindChild ("chauhoa").transform.FindChild ("chauhoa").gameObject.SetActive (true);
				buyItems.transform.FindChild ("chauhoa").transform.FindChild ("btnBuy").gameObject.SetActive (false);
			}
			if (gau_bong == 1) {
				buyItems.transform.FindChild ("gaubong").gameObject.SetActive (true);
				buyItems.transform.FindChild ("gaubong").transform.FindChild ("gaubong").gameObject.SetActive (true);
				buyItems.transform.FindChild ("gaubong").transform.FindChild ("btnBuy").gameObject.SetActive (false);
			}
		}
		if (Application.loadedLevel == 1) {
			scoreClass.changeSpriteGameObject (level_num [0], level_num [1], this_level);
		}
	}
	
	// Update is called once per frame
	public void nextLevel(){
		this_level++;
		getLevel ();
	}
	void timeCount()
	{
		if(!gamePause)
		{
			time_count++;
			if(scoreClass.money_earned ==this_level_money_require)
			{
				SaveLoad.this_level_value.timess = time_count;
			}
			if (time_count == this_level_time + this_level_time_plus) {
				int numStar=0;

				if(scoreClass.money_earned >=this_level_money_require)
				{
					passThis=true;;
					if(scoreClass.money_earned >=this_money_star_3)
					{
						numStar=3;

					}
					else if(scoreClass.money_earned >=this_money_star_2)
					{
						numStar=2;
					}
					else if(scoreClass.money_earned >=this_money_star_1)
					{
						numStar=1;
					}
					SaveLoad.this_level_value.star = numStar;
					SaveLoad.this_level_value.money = scoreClass.money_earned;
					sv.save_level();
				}
				else
				{
					passThis=false;
				}
				gamePause=true;
				GameObject GM = GameObject.Find("GM");
				if(this_level==9 && maxLevelOpened<10)
				{
					if(passThis)
					{
						GM.GetComponent<_GM>().showOpenItem(true);
						GM.GetComponent<_GM>().showEnd(passThis, numStar);
						GM.GetComponent<_GM>().showBoxItem(false);
					}
				}
				else{
				GM.GetComponent<_GM>().showEnd(passThis, numStar);
				GM.GetComponent<_GM>().showBoxItem(false);
				}

			}
		}
		if (Application.loadedLevel == 1) 
		{
			int time1234 = this_level_time - time_count;
			int abc = time1234 / 60;
			int xxx = time1234 % 60;
			scoreClass.changeSpriteGameObject (level_time [0], level_time [1], abc);
			scoreClass.changeSpriteGameObject (level_time [2], level_time [3], xxx);
		}
		Invoke("timeCount",1);
	}
	void getLevel()
	{
		GameObject child = this.transform.FindChild ("level_"+this_level).gameObject;
		this_level_money_require = child.GetComponent<levelDetail> ().moneyRequire;
		this_level_time = child.GetComponent<levelDetail> ().timeEnd;
		this_level_time_plus = child.GetComponent<levelDetail> ().timePlus;
		time_customer_appear = child.GetComponent<levelDetail> ().timeCusAppear;
		this_money_star_1 = child.GetComponent<levelDetail> ().moneyStar1;
		this_money_star_2 = child.GetComponent<levelDetail> ().moneyStar2;
		this_money_star_3 = child.GetComponent<levelDetail> ().moneyStar3;

	}
	public void changeItemLevel()
	{
		if (maxLevelOpened>=10) {
			machine.transform.FindChild("level_2").gameObject.SetActive(true);
			machine.transform.FindChild("level_1").gameObject.SetActive(false);
		}
		if (maxLevelOpened>=21) {
			lo.SetActive(true);
			lo.transform.FindChild("level_1").gameObject.SetActive(true);
		}
	}
	public void changeSpriteMachine()
	{
		if (level_machine == 1) {
			timeMachine=timeMachine-2;
		}
		if (level_machine == 2) {
			timeMachine=timeMachine-3;
		}
		if (level_machine == 3) {
			timeMachine=timeMachine-4;
		}
		foreach (Transform t in machine.transform) {
			if(t.name =="1")
			{

				t.gameObject.GetComponent<SpriteRenderer>().sprite = listSpMachine[level_machine];
			}
			if(t.name =="2")
			{
				
				t.gameObject.GetComponent<SpriteRenderer>().sprite = listSpMachine1[level_machine];
			}
		}
		machine.transform.FindChild ("updateBar").gameObject.GetComponent<ItemsControl> ().level = level_machine;
	}
	public void changeSpriteGas()
	{
		string[] abc = level_bep.Split ('_');
		for (int i =0; i<abc.Length; i++) {
			GameObject GM = GameObject.Find("GM");
			GameObject gas = GameObject.Find("gas_"+(i+1));
			int thisL = int.Parse(abc[i]);
			gas.GetComponent<SpriteRenderer>().sprite = listSpBep[thisL];
			gas.transform.GetChild(0).gameObject.GetComponent<bep_lo>().this_level = thisL;
			gas.transform.GetChild(0).gameObject.GetComponent<bep_lo>().timeChange = timeGas[thisL];
			gas.transform.GetChild(0).transform.FindChild("updateBar").gameObject.GetComponent<ItemsControl>().level = thisL;
		}


	}
	public void changeSpriteLo()
	{
		if (level_lo == 1) {
			timeLo=timeLo-2;
		}
		if (level_lo == 2) {
			timeLo=timeLo-3;
		}
		if (level_lo == 3) {
			timeLo=timeLo-4;
		}
		foreach (Transform t in lo.transform.FindChild("level_1")) {
			t.gameObject.GetComponent<SpriteRenderer>().sprite = listSpLo[level_lo];
		}
		lo.transform.FindChild ("updateBar").gameObject.GetComponent<ItemsControl> ().level = level_lo;
	}
	public void saveGame()
	{
		SaveLoad sv = new SaveLoad ();
		SaveLoad.savedValue = new savedClass(this_level,Score.score,level_tv,level_manocan,level_table,level_lo,level_machine,"1_2","1_2",gau_bong,mayxeng,maytinhtien,chauhoa);
	
		sv.saveFile ();
		                                   
	}
	void addOpenPlateToGM()
	{
		if (!string.IsNullOrEmpty (openDiskName))
		{
		
			string[] abc = openDiskName.Split ('_');
			GameObject GM = GameObject.Find ("GM");
			for (int i =0; i<abc.Length; i++) {

				GameObject plate = GameObject.Find ("blade_" + abc[i]);
				plate.GetComponent<plate_controll> ().UnLock (false);
		

			}
			GM.GetComponent<_GM> ().showDiskBox (false);
		}
	}
	public void changeLevelManocan()
	{
		foreach (Transform t in manocan.transform) {
			if (t.name == "level_" + level_manocan && level_manocan>0) {
				t.gameObject.SetActive (true);
			} else if (t.name != "updateBar" && t.name !="btnUpgrade") {
				t.gameObject.SetActive (false);
			}
		}
		if (level_manocan == 1) {
			moneyBonus=5;
		}
		if (level_manocan == 2) {
			moneyBonus=10;
		}
		if (level_manocan == 3) {
			moneyBonus=15;
		}
		manocan.transform.FindChild ("updateBar").gameObject.GetComponent<ItemsControl> ().level = level_manocan;
	}
	public void changeLevelTable()
	{
		foreach (Transform t in table.transform) {
			if (t.name == "level_" + level_table) {
				t.gameObject.SetActive (true);
			} else if (t.name != "updateBar" && t.name !="btnUpgrade") {
				t.gameObject.SetActive (false);
			}
		}

		if (level_table == 0) {
			maxPeople=2;
		}
		if (level_table == 1) {
			maxPeople=3;
		}
		if (level_table == 2) {
			maxPeople=4;
		}
		if (level_table == 3) {
			maxPeople=5;
		}
		table.transform.FindChild ("updateBar").gameObject.GetComponent<ItemsControl> ().level = level_table;
	}
	public void changeLevelTivi()
	{
		foreach (Transform t in tivi.transform) {
			if (t.name == "level_" + level_tv && level_tv>0) {
				t.gameObject.SetActive (true);
			} else if (t.name != "updateBar" && t.name !="btnUpgrade") {
				t.gameObject.SetActive (false);
			}
		}

		time_customer_appear -= level_tv * 2;
		
		tivi.transform.FindChild ("updateBar").gameObject.GetComponent<ItemsControl> ().level = level_tv;
	}
	public  void callFunctionSave()
	{
		if (SaveLoad.savedValue != null)
		{
			if (SaveLoad.savedValue.level < this_level) {
				if(passThis){
				SaveLoad.savedValue.level = this_level;
				}

			}
		}
		else
		{
			if(passThis){
			SaveLoad.savedValue = new savedClass();
			SaveLoad.savedValue.level = this_level;
			}
			else{
				SaveLoad.savedValue = new savedClass();
				SaveLoad.savedValue.level =1;
			}
		}
		  SaveLoad.savedValue.level_TV=level_tv;
		  SaveLoad.savedValue.level_manocan = level_manocan;
		  SaveLoad.savedValue.level_table = level_table;
		  SaveLoad.savedValue.level_bep=level_bep;
		  SaveLoad.savedValue.level_lo=level_lo;
		  SaveLoad.savedValue.level_may = level_machine;
		 SaveLoad.savedValue.list_disk_open = openDiskName;
		SaveLoad.savedValue.total_score =Score.score;
		SaveLoad.savedValue.chau_hoa =chauhoa;
		SaveLoad.savedValue.may_xeng =mayxeng;
		SaveLoad.savedValue.may_tinh_tien =maytinhtien;
		SaveLoad.savedValue.gau_bong =gau_bong;
			sv.saveFile ();
	
	}

}
