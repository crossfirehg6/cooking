using UnityEngine;
using System.Collections;

public class food_disk : FoodsControll {

	// Use this for initialization
	public bool has_food;
	public int so_nguyen_lieu_da_nhan;
	public bool had_meat;
	public string[] list_type_food;
	public bool moving;
	void Start () {
		base.Start ();
		hideElement ();
		oldPos = this.transform.localPosition;
		so_nguyen_lieu_da_nhan = -1;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void showCake(string loai_banh,string thanh_phan)
	{
	//	Debug.Log (this.transform.parent.gameObject.name);
		if (!had_meat) 
		{
			type_food = loai_banh;
			
			foreach (Transform t in this.transform.GetChild(0)) {
				if (t.name == loai_banh) {
					t.gameObject.SetActive (true);
				} else {
					t.gameObject.SetActive (false);
				}

			}

			if (!string.IsNullOrEmpty (thanh_phan)) {
				if (!this.transform.GetChild (0).FindChild (loai_banh).FindChild (thanh_phan).gameObject.activeSelf) {

					this.transform.GetChild (0).FindChild (loai_banh).FindChild (thanh_phan).gameObject.SetActive (true);
					so_nguyen_lieu_da_nhan++;
					if (so_nguyen_lieu_da_nhan != num_type_index) {
						this_type = checkItem.type_mouse.nguyen_lieu;
					}
				}
			}
		}
	}
	public void showCake2(string thanh_phan)
	{
		//	Debug.Log (this.transform.parent.gameObject.name);
		foreach (Transform t in this.transform.GetChild(0)) {
			if(t.name == type_food)
			{
				t.gameObject.SetActive(true);
			}
			else
			{
				t.gameObject.SetActive(false);
			}
			
		}
		if (!string.IsNullOrEmpty (thanh_phan))
		{

			if (!this.transform.GetChild (0).FindChild (type_food).FindChild (thanh_phan).gameObject.activeSelf) 
			{
				this.transform.GetChild (0).FindChild (type_food).FindChild (thanh_phan).gameObject.SetActive (true);
				so_nguyen_lieu_da_nhan++;
				if (so_nguyen_lieu_da_nhan != num_type_index) {
					this_type = checkItem.type_mouse.nguyen_lieu;
				}
			}
			for(int i =0;i<list_type_food.Length;i++)
			{
				foreach(Transform t in this.transform.GetChild(0).FindChild(list_type_food[i]))
				{
					if(t.name == thanh_phan)
					{
						if(!t.gameObject.activeSelf)
						{
							t.gameObject.SetActive(true);
						}
					}
				}
			}
		}
	}
	public override void getType()
	{
		this_type = checkItem.type_mouse.nguyen_lieu;
	}
	public void hideElement()
	{
		Transform cake = this.transform.FindChild ("cakes");
		if (cake != null) 
		{
			foreach (Transform t in cake.transform) {
				t.gameObject.SetActive (false);
				foreach(Transform t1 in t)
				{
					if(t1.name !="banh_mi")
					{
						t1.gameObject.SetActive(false);
					}
				}
			}
		}
	}
	public void checkName(string oldName,int index,int num_food_type)
	{
		if (index >= num_type_index) {
			num_type_index =index;
			foodName = oldName + "_" + index;
			type_food_int = num_food_type;
		}
		else
		{
			foodName = oldName+"_"+num_type_index;
		}
		if (so_nguyen_lieu_da_nhan == num_type_index) {
			this_type = checkItem.type_mouse.hoan_thanh;
		}
		if (type_food == "type_3") {
			this_type = checkItem.type_mouse.hoan_thanh;
		}
	}
	public string getTypeFood(){
		return type_food;
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		base.OnTriggerEnter2D (other);
	}
	public override void moveback()
	{
		this.transform.localScale = oldScale;
		this.transform.localPosition = oldPos;

		this.transform.parent.gameObject.GetComponent<plate_controll> ().hasFood = false;

		has_food = false;
		had_meat = false;
		moving = false;
		type_food = null;
		so_nguyen_lieu_da_nhan = -1;
		num_type_index = 0;
		foodName = null;
		hideElement ();

	}
	void OnMouseDown()
	{
		base.OnMouseDown ();
		moving = true;
	}
	void OnMouseUp()
	{
		moving = false;
		base.OnMouseUp ();
	}
}

