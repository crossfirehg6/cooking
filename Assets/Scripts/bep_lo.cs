using UnityEngine;
using System.Collections;

public class bep_lo : MonoBehaviour {

	// Use this for initialization
	public bool hadFood;
	public int level_open;
	private Vector3 oldScale;
	public int this_level;
	public float timeChange;
	void Start () {
		oldScale = this.transform.localScale ;
		checkOpen ();
	}
	
	// Update is called once per frame

	public void checkOpen()
	{

		if (LevelControll.maxLevelOpened < level_open) {
			this.transform.localScale =Vector3.zero;
		}
		else
		{
			this.transform.localScale =oldScale;
			GameObject GM = GameObject.Find("GM");

			if(this.name =="chao")
			{
				GM.GetComponent<_GM>().add_chao(this.gameObject);
			}
			else if(this.name =="vi_nuong")
			{
				GM.GetComponent<_GM>().add_vi_nuong(this.gameObject);
			}
			else 
			{
				GM.GetComponent<_GM>().add_lo(this.gameObject);
			}
		}
	}
}
