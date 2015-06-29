using UnityEngine;
using System.Collections;

public class nguyen_lieu : MonoBehaviour {

	// Use this for initialization
	public bool this_click;
	public int numIndex;
	public string foodName;
	public string hit_tag;
	private Vector3 oldPos;
	public int level_open;
	public int index_list_tag; // chon vat dung de dat len
	private Vector3 oldScale;
	public string[] list_type_food;
	public GameObject sounds;
	public GameObject soundOfThis;
	void Start () {
		oldPos = this.transform.localPosition;
		oldScale = this.transform.localScale;
		checkOpen();
		sounds = GameObject.Find("Sounds");
		if (_GM.firstTime) {
			this.GetComponent<Collider2D>().enabled=false;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnMouseDown()
	{
		GameObject GM = GameObject.Find("GM");
		sounds.GetComponent<SoundController> ().playSpe2 (soundOfThis.name);
		this.transform.localScale = new Vector3 (0.3f, 0.3f, 0) + this.transform.localScale;
		int indexPos = 0;
		if (index_list_tag ==1) 
		{	
			if(_GM.firstTime)
			{
				if(_GM.numCus==0)
				{
					GM.GetComponent<_GM>().guideSteps(3);
				}
			}
		
			indexPos = GM.GetComponent<_GM>().getNextPlate();
			if(GM.GetComponent<_GM>().list_plates.Count >indexPos)
			{
				GameObject p_food = GM.GetComponent<_GM>().list_plates[indexPos].transform.FindChild("food").gameObject;
				p_food.GetComponent<food_disk>().showCake(foodName,"");
				p_food.GetComponent<food_disk>().has_food =true;
				p_food.GetComponent<food_disk>().list_type_food = list_type_food;
				GM.GetComponent<_GM>().list_plates[indexPos].GetComponent<plate_controll>().hasFood=true;

			}
		}
		else if (index_list_tag ==2) 
		{
			if(_GM.firstTime)
			{
				if(_GM.numCus==0)
				{
					GM.GetComponent<_GM>().guideSteps(4);
				}
			}
			indexPos = GM.GetComponent<_GM>().getNextChao();
			if(GM.GetComponent<_GM>().list_chao.Count >indexPos)
			{
				GameObject chao = 	GM.GetComponent<_GM>().list_chao[indexPos];
				chao.transform.FindChild(foodName).gameObject.SetActive(true);

			//	chao.transform.FindChild(foodName).gameObject.GetComponent<thit_nau>().time_change =LevelControll.timeGas;
				chao.transform.FindChild(foodName).gameObject.GetComponent<thit_nau>().getTimeChange();
				chao.transform.FindChild(foodName).gameObject.GetComponent<thit_nau>().begin();
				//this.transform.localScale = new Vector3(0,0,0);
				
				GM.GetComponent<_GM>().list_chao[indexPos].GetComponent<bep_lo>().hadFood=true;
				
			}
		}
		else if (index_list_tag ==3) 
		{
			indexPos = GM.GetComponent<_GM>().getNextViNuong();
			if(GM.GetComponent<_GM>().list_vi_nuong.Count >indexPos)
			{
				GameObject vi_nuong = 	GM.GetComponent<_GM>().list_vi_nuong[indexPos];
				vi_nuong.transform.FindChild(foodName).gameObject.SetActive(true);
				
				vi_nuong.transform.FindChild(foodName).gameObject.GetComponent<thit_nau>().getTimeChange();
				vi_nuong.transform.FindChild(foodName).gameObject.GetComponent<thit_nau>().begin();
				//this.transform.localScale = new Vector3(0,0,0);
				
				GM.GetComponent<_GM>().list_vi_nuong[indexPos].GetComponent<bep_lo>().hadFood=true;
				
			}
		}
		else if (index_list_tag ==4) 
		{
			indexPos = GM.GetComponent<_GM>().getNextLo();
			if(GM.GetComponent<_GM>().list_lo.Count >indexPos)
			{
				GameObject lo = GM.GetComponent<_GM>().list_lo[indexPos];
				lo.transform.FindChild(foodName).gameObject.SetActive(true);
				lo.transform.FindChild("o_nuong").gameObject.SetActive(true);
				lo.transform.FindChild(foodName).gameObject.GetComponent<thit_nau>().time_change =LevelControll.timeLo;
				lo.transform.FindChild(foodName).gameObject.GetComponent<thit_nau>().begin();
				//this.transform.localScale = new Vector3(0,0,0);
				
				GM.GetComponent<_GM>().list_lo[indexPos].GetComponent<bep_lo>().hadFood=true;
				
			}
		}

	}
	public void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == hit_tag) 
		{
		//	this.transform.localPosition =oldPos;
			other.transform.FindChild(foodName).gameObject.SetActive(true);
			other.gameObject.GetComponent<Collider2D>().enabled=false;
			other.transform.FindChild(foodName).gameObject.GetComponent<thit_nau>().time_change =5;
			other.transform.FindChild(foodName).gameObject.GetComponent<thit_nau>().begin();
			this.transform.localScale = new Vector3(0,0,0);
		}
		
	}
	void OnMouseUp(){
		this.transform.localScale =oldScale;
	}
	public void checkOpen()
	{

		if (LevelControll.maxLevelOpened+1 < level_open) {
			this.transform.localScale =Vector3.zero;
		}
		else
		{
			this.transform.localScale =oldScale;
		}
	}


}
