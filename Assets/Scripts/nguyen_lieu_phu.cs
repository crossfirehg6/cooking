using UnityEngine;
using System.Collections;

public class nguyen_lieu_phu : FoodsControll {

	// Use this for initialization
	public int level_open;
	private Vector3 old_parent_scale;
	private GameObject food_set;
	void Start () {
		base.Start ();

		old_parent_scale = this.transform.parent.localScale;
		checkOpen ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public override void getType(){
		this_type = checkItem.type_mouse.nguyen_lieu_chin;
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		
		if (other.tag == "food") 
		{
			if(this_type ==checkItem.type_mouse.nguyen_lieu_chin && check_suit_type(other.gameObject))
			{
				if(other.gameObject.GetComponent<food_disk>().has_food && !other.gameObject.GetComponent<food_disk>().moving){
					food_set = other.gameObject;
					//other.gameObject.GetComponent<food_disk>().this_type =checkItem.type_mouse.hoan_thanh;

				}
			}
		}
		base.OnTriggerEnter2D (other);
	}
	void OnMouseUp()
	{
		if (food_set != null) {
			food_set.gameObject.GetComponent<food_disk>().showCake2(foodName);
			type_food = food_set.gameObject.GetComponent<food_disk>().getTypeFood();

			food_set.gameObject.GetComponent<food_disk>().checkName(type_food,num_type_index,type_food_int);
			food_set=null;
			if(sounds !=null)
			{
				if(type_food !="type_3"){
				sounds.GetComponent<SoundController>().playSpe2("rau");
				}
				else
				{
					sounds.GetComponent<SoundController>().playSpe2("tuong_ot");
				}
			}
		}
		base.OnMouseUp ();
	}
	public override void moveback()
	{
		this.transform.localScale = oldScale;
		this.transform.localPosition = oldPos;

	}
	public void checkOpen()
	{

		if (LevelControll.maxLevelOpened < level_open) {
			this.transform.parent.localScale = new Vector3 (0, 0, 0);
		} else {
			this.transform.parent.localScale = old_parent_scale;
		}
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
