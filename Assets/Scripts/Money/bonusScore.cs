using UnityEngine;
using System.Collections;

public class bonusScore : MonoBehaviour {

	// Use this for initialization
	public  int score;

	public Sprite[] listSprite;
	public GameObject num1;
	public GameObject num2; 
	public GameObject num3;
	public GameObject num4;
	public GameObject num5;
	public GameObject num6;
	public GameObject num7;
	
	//	void Awake(){
	//		Environment.SetEnvironmentVariable("MONO_REFLECTION_SERIALIZER", "yes");
	//	}
	void Start () {
		changeSprite();
		Debug.Log (this.name);

	}
	
	// Update is called once per frame

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
		
		
		if(score<10)
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

}
