using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
public class Score : MonoBehaviour {

	// Use this for initialization
	public static int score=1000000;
	public  int money_earned;
	public static int bonus;

	public Sprite[] listSprite;
	public GameObject num1;
	public GameObject num2; 
	public GameObject num3;
	public GameObject num4;
	public GameObject num5;
	public GameObject num6;
	public GameObject num7;

	public GameObject[] bars;
	private int[] money_star= new int[4];
//	void Awake(){
//		Environment.SetEnvironmentVariable("MONO_REFLECTION_SERIALIZER", "yes");
//	}
	void Start () {
		changeSprite();
		GameObject le_vel = GameObject.Find ("Levels");
		money_star [0] = le_vel.GetComponent<LevelControll> ().this_level_money_require;
		money_star [1] = le_vel.GetComponent<LevelControll> ().this_money_star_1;
		money_star [2] = le_vel.GetComponent<LevelControll> ().this_money_star_2;
		money_star [3] = le_vel.GetComponent<LevelControll> ().this_money_star_3;
		changeMoneyBar ();
	}
	
	// Update is called once per frame

	public void updateScore(int num, bool val){
		score += num;
		if (score < 0) 
		{
			score=0;
		}
		changeSprite ();
		if (val) {
			money_earned += num;
			changeMoneyBar ();
		}
	}
	public void changeMoneyBar(){
			bars [1].gameObject.SetActive (false);
			bars [2].gameObject.SetActive (false);
			bars [3].gameObject.SetActive (false);
			float rate1 = (float)money_earned / money_star [0];
			float rate2 = (float)money_earned / money_star [1];
			float rate3 = (float)money_earned / money_star [2];
			float rate4 = (float)money_earned / money_star [3];
	
			if(rate1>1)
			{
				rate1=1;
				bars [1].gameObject.SetActive (true);
				
			}
			if(rate2>1)
			{
				rate2=1;
				bars [2].gameObject.SetActive (true);
			}
			if(rate3>1)
			{
				rate3=1;
				bars [3].gameObject.SetActive (true);
			}
			if(rate4>1)
			{
				rate4=1;
			}
			bars [0].transform.localScale = new Vector3 (rate1, 1, 1);
			bars [1].transform.localScale = new Vector3 (rate2, 1, 1);
			bars [2].transform.localScale = new Vector3 (rate3, 1, 1);
			bars [3].transform.localScale = new Vector3 (rate4, 1, 1);

	}
	public void changeSprite()
	{
			num2.SetActive(false);
			num3.SetActive(false);
			num4.SetActive(false);
			num5.SetActive(false);
			num6.SetActive(false);
			num7.SetActive(false);
			
	//	Levels lv = new Levels(Score.numFish,Score.score,DateTime.Now,btnSound.musicPause,btnSound.musicstop);
//		SaveLoad.savedScore = lv;

		if (score < 0) 
		{
			score=0;
		}
		else if(score<10)
		{
			int index1 = score;
			num1.GetComponent<SpriteRenderer>().sprite = listSprite[index1];

		}
		else if(score<100)
		{
			int index1 = score/10;
			int index2 = score%10;
			num2.SetActive(true);
			num1.GetComponent<SpriteRenderer>().sprite = listSprite[index1];
			num2.GetComponent<SpriteRenderer>().sprite = listSprite[index2];


		}
		else if(score<1000)
		{
			int index1 = score/100;
			int index2 = (score%100)/10;
			int index3 = (score%100)%10;
			num2.SetActive(true);
			num3.SetActive(true);

			num1.GetComponent<SpriteRenderer>().sprite = listSprite[index1];
			num2.GetComponent<SpriteRenderer>().sprite = listSprite[index2];
			num3.GetComponent<SpriteRenderer>().sprite = listSprite[index3];
		}
		else if(score<10000)
		{
			int index1 = score/1000;
			int index2 = (score%1000)/100;
			int index3 = ((score%1000)%100)/10;
			int index4 = ((score%1000)%100)%10;
				num2.SetActive(true);
				num3.SetActive(true);
				num4.SetActive(true);
			num1.GetComponent<SpriteRenderer>().sprite = listSprite[index1];
			num2.GetComponent<SpriteRenderer>().sprite = listSprite[index2];
			num3.GetComponent<SpriteRenderer>().sprite = listSprite[index3];
			num4.GetComponent<SpriteRenderer>().sprite = listSprite[index4];
		}
		else if(score<100000)
		{		
			int index1 = score/10000;
			int index2 = (score%10000)/1000;
			int index3 = ((score%10000)%1000)/100;
			int index4 = (((score%10000)%1000)%100)/10;
			int index5 = (((score%10000)%1000)%100)%10;
				num2.SetActive(true);
				num3.SetActive(true);
				num4.SetActive(true);
				num5.SetActive(true);

			num1.GetComponent<SpriteRenderer>().sprite = listSprite[index1];
			num2.GetComponent<SpriteRenderer>().sprite = listSprite[index2];
			num3.GetComponent<SpriteRenderer>().sprite = listSprite[index3];
			num4.GetComponent<SpriteRenderer>().sprite = listSprite[index4];
			num5.GetComponent<SpriteRenderer>().sprite = listSprite[index5];
		}
		else if(score<1000000)
		{
			int index1 = score/100000;
			int index2 = (score%100000)/10000;
			int index3 = ((score%100000)%10000)/1000;
			int index4 = (((score%100000)%10000)%1000)/100;
			int index5 = ((((score%100000)%10000)%1000)%100)/10;
			int index6 = ((((score%100000)%10000)%1000)%100)%10;
				num2.SetActive(true);
				num3.SetActive(true);
				num4.SetActive(true);
				num5.SetActive(true);
				num6.SetActive(true);
			num1.GetComponent<SpriteRenderer>().sprite = listSprite[index1];
			num2.GetComponent<SpriteRenderer>().sprite = listSprite[index2];
			num3.GetComponent<SpriteRenderer>().sprite = listSprite[index3];
			num4.GetComponent<SpriteRenderer>().sprite = listSprite[index4];
			num5.GetComponent<SpriteRenderer>().sprite = listSprite[index5];
			num6.GetComponent<SpriteRenderer>().sprite = listSprite[index6];
		}
		else if(score<10000000)
		{
			int index1 = score/1000000;
			int index2 = (score%1000000)/100000;
			int index3 = ((score%1000000)%100000)/10000;
			int index4 = (((score%1000000)%100000)%10000)/1000;
			int index5 = ((((score%1000000)%100000)%10000)%1000)/100;
			int index6 = ((((score%1000000)%100000)%10000)%1000)%100/10;
			int index7 = (((((score%1000000)%100000)%10000)%1000)%100)%10;
				num2.SetActive(true);
				num3.SetActive(true);
				num4.SetActive(true);
				num5.SetActive(true);
				num6.SetActive(true);
				num7.SetActive(true);
			num1.GetComponent<SpriteRenderer>().sprite = listSprite[index1];
			num2.GetComponent<SpriteRenderer>().sprite = listSprite[index2];
			num3.GetComponent<SpriteRenderer>().sprite = listSprite[index3];
			num4.GetComponent<SpriteRenderer>().sprite = listSprite[index4];
			num5.GetComponent<SpriteRenderer>().sprite = listSprite[index5];
			num6.GetComponent<SpriteRenderer>().sprite = listSprite[index6];
			num7.GetComponent<SpriteRenderer>().sprite = listSprite[index7];
				
		}
	}

	public void changeSpriteGameObject(GameObject num_1,GameObject num_2, int val)
	{
		//num_1.SetActive(false);
		if (val < 0) 
		{
			val=0;
		}
		else if(val<10)
		{
			int index1 = val;
			num_2.GetComponent<SpriteRenderer>().sprite = listSprite[index1];
			
		}
		else if(val<100)
		{
			int index1 = val/10;
			int index2 = val%10;
			num_1.SetActive(true);
			num_1.GetComponent<SpriteRenderer>().sprite = listSprite[index1];
			num_2.GetComponent<SpriteRenderer>().sprite = listSprite[index2];
			
			
		}
	}
}
