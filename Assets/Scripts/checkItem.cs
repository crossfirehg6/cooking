using UnityEngine;
using System.Collections;

public class checkItem : MonoBehaviour {

	// Use this for initialization
	public Sprite[] list_sprite;
	public Sprite[] list_sprite_2;
	public Sprite[] list_sprite_3;
	public string foodName;
	public type_mouse this_type;
	public string hit_tag;
	public string type_food;
	public int type_food_int;
	public int type_food_index;

	public Sprite[] list_type_food_1;
	public Sprite[] list_type_food_2;
	public Sprite[] list_type_food_3;
	public Sprite[] list_type_food_4;
	public Sprite[] list_type_food_5;
	public Sprite[] list_type_food_6;
	public enum type_mouse
	{
		nguyen_lieu,
		nguyen_lieu_chin,
		nguyen_lieu_chay,
		hoan_thanh
	};
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if(this_type ==type_mouse.hoan_thanh)
		{
			if (other.tag == "character") 
			{

				bool right_f = other.gameObject.GetComponent<characters>().checkFood(foodName);
				if(right_f)
				{
					if(foodName =="cafe" || foodName=="nuoc_cam")
					{
						GameObject cafe = GameObject.Find("do_uong_anim").transform.FindChild(foodName).gameObject;
						cafe.SetActive(true);
					}
					this.transform.parent.gameObject.SetActive(false);

				}
			}
		}
		else if(this_type ==type_mouse.nguyen_lieu)
		{
			 if (other.tag == hit_tag) 
			{
				other.transform.FindChild(foodName).gameObject.SetActive(true);
				other.gameObject.GetComponent<Collider2D>().enabled=false;
				this.transform.parent.gameObject.SetActive(false);
			}
		}
		else if(this_type ==type_mouse.nguyen_lieu_chin)
		{
			if (other.tag == "food") 
			{
				if(other.gameObject.GetComponent<food_disk>().has_food){
				other.gameObject.GetComponent<food_disk>().showCake(type_food,foodName);
				other.gameObject.GetComponent<food_disk>().checkName(type_food,type_food_index,type_food_int);
					other.gameObject.GetComponent<food_disk>().this_type =type_mouse.hoan_thanh;

			
				this.transform.parent.gameObject.SetActive(false);
				}
			}
		}
	}
	public void changeSprite(int index)
	{
		if (this_type == type_mouse.hoan_thanh) {
			this.transform.parent.gameObject.GetComponent<SpriteRenderer> ().sprite = list_sprite [index];
		} else if (this_type == type_mouse.nguyen_lieu) {
			this.transform.parent.gameObject.GetComponent<SpriteRenderer> ().sprite = list_sprite_2 [index];
		}
		else  {
			this.transform.parent.gameObject.GetComponent<SpriteRenderer> ().sprite = list_sprite_3 [index];
		}
	}
	public void changeSprite(Sprite sp)
	{

		this.transform.parent.gameObject.GetComponent<SpriteRenderer> ().sprite = sp;

	}
	public void changeSprite2(int type, int index)
	{
		if (type == 0) 
		{
			this.transform.parent.gameObject.GetComponent<SpriteRenderer> ().sprite = list_sprite [index];
		}
		else if (type ==1) 
		{
			this.transform.parent.gameObject.GetComponent<SpriteRenderer> ().sprite = list_type_food_1 [index];
		}
		else if (type ==2) 
		{
			this.transform.parent.gameObject.GetComponent<SpriteRenderer> ().sprite = list_type_food_1 [index];
		}
		else if (type ==3) 
		{
			this.transform.parent.gameObject.GetComponent<SpriteRenderer> ().sprite = list_type_food_1 [index];
		}
		else if (type ==4) 
		{
			this.transform.parent.gameObject.GetComponent<SpriteRenderer> ().sprite = list_type_food_1 [index];
		}
		else if (type ==5) 
		{
			this.transform.parent.gameObject.GetComponent<SpriteRenderer> ().sprite = list_type_food_1 [index];
		}
		else if (type ==6) 
		{
			this.transform.parent.gameObject.GetComponent<SpriteRenderer> ().sprite = list_type_food_1 [index];
		}
	}
}
