using UnityEngine;
using System.Collections;

public class FoodsControll : MonoBehaviour {

	// Use this for initialization
	public bool finished;
	public string foodName;
	public bool isFood;
	public int numIndex;
	public checkItem.type_mouse this_type;
	public string type_food;
	public int type_food_int;
	public int num_type_index;

	public Vector3 oldPos;
	public Vector3 oldScale;

	private GameObject character;
	public GameObject sounds;
	public void Start () {
		getType ();
		getName ();
		oldPos = this.transform.localPosition;
		oldScale = this.transform.localScale;
		sounds = GameObject.Find("Sounds");
		this.GetComponent<Collider2D> ().enabled = false;
	}
	
	// Update is called once per frame

	public virtual void getType(){
		this_type = checkItem.type_mouse.hoan_thanh;
		if (!_GM.firstTime) {
			StartCoroutine (runningMachine (LevelControll.timeMachine));
		}
	}
	public virtual void getName(){
		if(string.IsNullOrEmpty(foodName))
		foodName = this.name;
	}


	public void OnMouseDown(){
		this.transform.localScale = new Vector3 (0.3f, 0.3f, 0) + this.transform.localScale;

	}
	public void OnTriggerEnter2D(Collider2D other)
	{
		if(this_type ==checkItem.type_mouse.hoan_thanh)
		{
			if (other.tag == "character") 
			{
				character=other.gameObject;
			}
		}
		if (other.tag == "thung_rac")
		{
			sounds.GetComponent<SoundController>().playSpe2("rac");
			if(this_type == checkItem.type_mouse.nguyen_lieu_chay)
			{
				GameObject GM = GameObject.Find("GM");
			//	StartCoroutine(GM.GetComponent<_GM>().nhapnhaythungrac(false));
				GM.GetComponent<_GM>().numchay--;
			}
			moveback();
		}
	}
	public virtual void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject == character) {
			character= null;
		}
	}
	public virtual void OnMouseUp()
	{
		if (character != null) {
			if(this_type ==checkItem.type_mouse.hoan_thanh)
			{
					bool right_f = character.GetComponent<characters>().checkFood(foodName);
					if(right_f)
					{
						
						sounds.GetComponent<SoundController>().playSpe2("giao_do");
						this.transform.localScale =new Vector3(0,0,0);
						moveback();
					}
					else
					{
					sounds.GetComponent<SoundController>().playSpe2("sai_do");
					}
			}
		}
		this.transform.localPosition = oldPos;
		this.transform.localScale = oldScale;

	}
	public virtual void moveback()
	{
		character = null;
		this.transform.FindChild ("coc").transform.GetChild (0).gameObject.SetActive (false);
		this.transform.FindChild ("nuoc").localScale = new Vector3 (0,0,0);
		this.GetComponent<Collider2D> ().enabled = false;
		this.transform.localScale = oldScale;
		this.transform.localPosition = oldPos;
		this.GetComponent<lb_drag> ().cannotMove = true;
		//this.GetComponent<lb_drag> ().enabled = false;
		StartCoroutine(runningMachine (LevelControll.timeMachine));

	}
	public IEnumerator runningMachine(float timeWait)
	{
		this.transform.FindChild ("nuoc").gameObject.SetActive (true);
		iTween.ScaleTo (this.transform.FindChild("nuoc").gameObject,new Vector3(1,1,1),1);
		yield return new WaitForSeconds (1);
		this.transform.FindChild ("coc").transform.GetChild (0).gameObject.SetActive (true);
		this.GetComponent<Collider2D> ().enabled = false;
		yield return new WaitForSeconds(timeWait);
		iTween.ScaleTo (this.transform.FindChild("nuoc").gameObject,new Vector3(0,0,0),1);
		this.GetComponent<Collider2D> ().enabled = true;
		this.GetComponent<lb_drag> ().cannotMove = false;
		GameObject GM = GameObject.Find ("GM");
		GM.GetComponent<_GM> ().showStarCook (this.transform.position);

	}
}
