using UnityEngine;
using System.Collections;

public class thit_nau : FoodsControll {

	// Use this for initialization
	public Sprite new_sprite;
	public Sprite old_Sprite;
	public float time_change;
	public int  num_burned;
	public Color oldColor;
	public bool chosen;
	public string[] list_type_this;
	private GameObject food_set;

	public GameObject soundOfThis;
	public GameObject soundOfThis_1;
	public GameObject soundOfThis_2;
	private int this_time;
	private bool pauseBurn;
	private float timeBurned;
	public Sprite old_Sprite_Khoi;
	void Start () {
		base.Start ();
		old_Sprite = this.GetComponent<SpriteRenderer> ().sprite;
		oldColor = this.GetComponent<SpriteRenderer> ().color;
		sounds = GameObject.Find("Sounds");
		timeBurned = 15;



	}
	
	// Update is called once per frame
	public void begin(){
		if (this.transform.parent.name == "chao" || this.transform.parent.name == "vi_nuong") {
			GameObject khoi =	GameObject.Find("khoi_den_1");
			if(old_Sprite_Khoi ==null){
			old_Sprite_Khoi = khoi.gameObject.GetComponent<SpriteRenderer>().sprite;
			}
		}
		if (_GM.firstTime) {
			if(_GM.numCus ==0){
			timeBurned = 10000000;
			}

		} else {
			timeBurned = 15;
		}
		this.GetComponent<Collider2D> ().enabled = false;
		pauseBurn = false;
		//Invoke ("changeSprite1",time_change);
		this_time = 0;
		thisTimeCount ();

		if (soundOfThis != null) {
			if(sounds ==null)
			{
				sounds = GameObject.Find("Sounds");
			}
			if(sounds !=null){
			
			sounds.GetComponent<SoundController>().playSpe2(soundOfThis.name);
			}
		}
		if (this.transform.parent.name == "chao" || this.transform.parent.name == "vi_nuong") {
			GameObject khoi =	this.transform.FindChild("khoi").GetChild(0).gameObject;
		
			khoi.GetComponent<SpriteRenderer>().sprite=old_Sprite_Khoi;
		}
	}
	public void getTimeChange(){
		time_change = this.transform.parent.gameObject.GetComponent<bep_lo> ().timeChange;
	}

	public void OnMouseDown(){
		base.OnMouseDown ();
		chosen = true;
	}
	void OnMouseUp(){
		if (food_set != null) {
			if(_GM.firstTime){
			if(_GM.numCus==0)
			{
				GameObject GM = GameObject.Find("GM");
				GM.GetComponent<_GM>().guideSteps(6);
			}
			}
			food_set.gameObject.GetComponent<food_disk>().showCake(type_food,foodName);
			food_set.gameObject.GetComponent<food_disk>().checkName(type_food,num_type_index,type_food_int);
			food_set.gameObject.GetComponent<food_disk>().had_meat =true;
			returnBegin();
			if(sounds !=null)
			{
				sounds.GetComponent<SoundController>().playSpe("thit");
			}
		}
		chosen = false;
		base.OnMouseUp ();
	}
	void thisTimeCount(){
		if (!LevelControll.gamePause) {
			this_time++;
		}
		if (this_time == time_change) {
			changeSprite1();

		}
		if (this_time == time_change + timeBurned) {
			if (!chosen)
			{
				changeSprite2();
			}
		}

		if (!pauseBurn) 
		{
			Invoke ("thisTimeCount", 1);
		}

	}
	void changeSprite1()
	{
		//yield return new WaitForSeconds (time_change);
		sounds.GetComponent<SoundController> ().playSpe (soundOfThis_1.name);
		this.GetComponent<SpriteRenderer> ().sprite = new_sprite;
		num_burned = 1;
		this.GetComponent<Collider2D> ().enabled = true;
		this_type=checkItem.type_mouse.nguyen_lieu_chin;
		GameObject GM = GameObject.Find ("GM");
		GM.GetComponent<_GM> ().showStarCook (this.transform.position);

		if(_GM.firstTime)
		{
			if(_GM.numCus==0)
			{
			//	GameObject GM = GameObject.Find("GM");
				GM.GetComponent<_GM>().guideSteps(5);

			}
		}
		//yield return new WaitForSeconds (15);

	}
	void changeSprite2()
	{
		sounds.GetComponent<SoundController> ().playSpe (soundOfThis_2.name);
			this.GetComponent<SpriteRenderer> ().color = Color.gray;
			num_burned = 2;
			this_type = checkItem.type_mouse.nguyen_lieu_chay;

		if (LevelControll.gau_bong == 1) {
			returnBegin ();
		}
		else
		{
			GameObject GM = GameObject.Find("GM");
			if(GM.GetComponent<_GM>().numchay==0){
			StartCoroutine(GM.GetComponent<_GM>().nhapnhaythungrac(true));
			}
			GM.GetComponent<_GM>().numchay++;
			GM.GetComponent<_GM>().showStarCook2(this.transform.position);
			if (this.transform.parent.name == "chao" || this.transform.parent.name == "vi_nuong") {
				GameObject khoi =	this.transform.FindChild("khoi").GetChild(0).gameObject;
				GameObject khoi_den = GameObject.Find("khoi_den");
				khoi.GetComponent<SpriteRenderer>().sprite = khoi_den.GetComponent<SpriteRenderer>().sprite;
			}
		}
		if (!_GM.chaylandau) {
			_GM.chaylandau=true;
			GameObject GM = GameObject.Find("GM");

			GM.GetComponent<_GM>().guideSteps(20);

		}

	}
	public void returnBegin()
	{
		this.transform.localPosition = oldPos;
		this.GetComponent<SpriteRenderer> ().sprite = old_Sprite;
		this_type=checkItem.type_mouse.nguyen_lieu;
		this.transform.parent.gameObject.GetComponent<bep_lo> ().hadFood = false;
		this.GetComponent<SpriteRenderer> ().color = oldColor;
		this.GetComponent<Collider2D> ().enabled = false;
		chosen = false;
		food_set = null;
		this_time = 0;
		pauseBurn = true;
		this.gameObject.SetActive (false);


	}
	public override void getType(){
		this_type = checkItem.type_mouse.nguyen_lieu_chin;
	}
	void OnTriggerEnter2D(Collider2D other)
	{

		if (other.tag == "food") 
		{
			if(this_type ==checkItem.type_mouse.nguyen_lieu_chin)
			{

				if(other.gameObject.GetComponent<food_disk>().has_food && !other.gameObject.GetComponent<food_disk>().had_meat && !other.gameObject.GetComponent<food_disk>().moving){
					if(check_suit_type(other.gameObject))
					{
						food_set = other.gameObject;
					}
				}
			}
		}
		base.OnTriggerEnter2D (other);
	}
	void OnTriggerExit2D(Collider2D other){
		if (other.gameObject == food_set) {
			food_set=null;
		}
	}
	public override void moveback()
	{
		this.transform.localScale = oldScale;
		this.transform.localPosition = oldPos;
		returnBegin ();
	}
	bool check_suit_type(GameObject other)
	{
		for(int i =0;i<other.gameObject.GetComponent<food_disk>().list_type_food.Length;i++)
		{	
			if(other.gameObject.GetComponent<food_disk>().list_type_food[i] == type_food)
			{
				return true;
			}
		}
		return false;
	}
}
