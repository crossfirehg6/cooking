using UnityEngine;
using System.Collections;

public class time_timdo : MonoBehaviour {
	
	public static int time_life;
	//so hnag
	public Sprite[] newSprite;
	public static bool stoptime;
	public static bool starttime0j=false;
	public GameObject num1;
	public GameObject num2;
	public GameObject num3;
	//private SpriteRenderer thayso;
	public static bool xxx;
	// Use this for initialization

	void Start () {
		time_life = 180;
		stoptime = false;
		//thayso = this.GetComponent<SpriteRenderer> ();
		changeSprite ();

		InvokeRepeating ("countTime", 1, 1);

	}
	
	// Update is called once per frame
	void Update () 
	{
		
		
	}
	void countTime()
	{
		if (!stoptime && time_life>0) {
			time_life--;
			if(time_life %10==0)
			{
				GameObject s2 = GameObject.Find ("Sounds");
				if (s2 == null) {
					int rands= Random.Range(1,9);
					s2.GetComponent<SoundController>().playSpe("meo_"+rands);

				}
			}
		changeSprite ();
		}
		else
		{
			stoptime =true;
			gameFinished();
		}
	}
	
	public void changeSprite()
	{

		num2.SetActive(false);
		if(time_life<10)
		{
			int index1 = time_life;
			num1.GetComponent<SpriteRenderer>().sprite = newSprite[index1];
			num2.SetActive(false);
			num3.SetActive(false);

		}
		else if(time_life<100)
		{
			int index1 = time_life/10;
			int index2 = time_life%10;
			num2.SetActive(true);
			num1.GetComponent<SpriteRenderer>().sprite = newSprite[index1];
			num2.GetComponent<SpriteRenderer>().sprite = newSprite[index2];
			num3.SetActive(false);
		}
		
		else if(time_life<1000)
		{
			int index1 = time_life/100;
			int index2 = (time_life%100)/10;
			int index3 = (time_life%100)%10;
			num2.SetActive(true);
			num3.SetActive(true);		
			num1.GetComponent<SpriteRenderer>().sprite = newSprite[index1];
			num2.GetComponent<SpriteRenderer>().sprite = newSprite[index2];
			num3.GetComponent<SpriteRenderer>().sprite = newSprite[index3];
		}

	}
	public void gameFinished(){
		GameObject s2 = GameObject.Find ("Sounds");
		if (s2 == null) {
			Destroy(s2);
		}
		Application.LoadLevel (6);
	}
}
