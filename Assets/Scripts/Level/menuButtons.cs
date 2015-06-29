using UnityEngine;
using System.Collections;
using System.Linq;
public class menuButtons : MonoBehaviour {

	// Use this for initialization
	public GameObject[] txtName;
	public GameObject[] minutes;
	public GameObject[] seconds;
	public GameObject[] scores_this_level; // chu hien thi
	public GameObject[] stars;
	public Sprite[] listSpriteTxtName;
	public Sprite[] listSpriteTxtHours;
	public Sprite[] listSpriteTxtScore;

	public int this_score;
	public int this_second;
	public static int maxLv=0;
	int thisNumberName;
	int numStar;
	void Start () {
		showName ();
		loadContent ();
	}
	void loadContent(){

		if (SaveLoad.list_level_save.Count > 0)
		{

			if(SaveLoad.savedValue !=null){
			maxLv = SaveLoad.savedValue.level;
			}
			maxLv = SaveLoad.list_level_save.Max(s=>s.level);
			//maxLv = model1.

			var model = SaveLoad.list_level_save.SingleOrDefault (s => s.level == thisNumberName);
			if (model != null) {

				this_score = model.money;
				this_second = model.timess;
				numStar = model.star;

			}
		}
		if (SaveLoad.savedValue != null) {
			if (thisNumberName > maxLv+1) {
				this.gameObject.SetActive (false);
			}
		}
		else
		{
			if(thisNumberName !=1)
			{
				this.gameObject.SetActive (false);
			}
		}
		if (this_score > 0) {
			this.transform.FindChild ("bg_1").gameObject.SetActive(false);
			this.transform.FindChild ("bg").gameObject.SetActive(true);
			this.transform.FindChild ("topBar").FindChild("bgBtn").gameObject.SetActive(false);
			showScore();
			showMinutes();
			showStar();
		}
		else
		{
			showUnfinishLevel();

		}
	}
	
	// Update is called once per frame

	void showUnfinishLevel(){
		this.transform.FindChild ("bg_1").gameObject.SetActive(true);
		this.transform.FindChild ("bg").gameObject.SetActive(false);
		this.transform.FindChild ("topBar").FindChild("bgBtn").gameObject.SetActive(true);
	}
	void showStar()
	{

			stars[numStar].SetActive(true);
			stars[numStar].transform.parent.gameObject.SetActive(true);

	}
	void showName()
	{
		string[] abc = this.name.Split ('_');
		int num1 = int.Parse (abc[1]);
		thisNumberName = num1;
		int a = num1 / 10;
		int b = num1 % 10;
		txtName [0].GetComponent<SpriteRenderer> ().sprite = listSpriteTxtName [a];
		txtName [1].GetComponent<SpriteRenderer> ().sprite = listSpriteTxtName [b];
		if (a == 0) {
			txtName[1].SetActive(false);
			txtName [0].GetComponent<SpriteRenderer> ().sprite = listSpriteTxtName [b];
		}
	}
	void showMinutes()
	{
		int mi = this_score / 60;
		int se = this_second % 60;

		int m1 = mi / 10;
		int m2 = mi % 10;

		int s1 = se / 10;
		int s2 = se % 10;

		minutes[1].GetComponent<SpriteRenderer> ().sprite = listSpriteTxtHours [m1];
		minutes[2].GetComponent<SpriteRenderer> ().sprite = listSpriteTxtHours [m2];

		seconds[0].GetComponent<SpriteRenderer> ().sprite = listSpriteTxtHours [s1];
		seconds[1].GetComponent<SpriteRenderer> ().sprite = listSpriteTxtHours [s2];
		if (m1 == 0) {
			minutes[0].SetActive(false);
			minutes[1].SetActive(false);
		}
	}
	void showScore()
	{
		scores_this_level[1].SetActive(false);
		scores_this_level[2].SetActive(false);
		scores_this_level[3].SetActive(false);
		scores_this_level[4].SetActive(false);
		if(this_score<10)
		{
			int index1 = this_score;
			scores_this_level[0].GetComponent<SpriteRenderer>().sprite = listSpriteTxtScore[index1];
			
		}
		else if(this_score<100)
		{
			int index1 = this_score/10;
			int index2 = this_score%10;
			scores_this_level[1].SetActive(true);
			scores_this_level[0].GetComponent<SpriteRenderer>().sprite = listSpriteTxtScore[index1];
			scores_this_level[1].GetComponent<SpriteRenderer>().sprite = listSpriteTxtScore[index2];

		}
		else if(this_score<1000)
		{
			int index1 = this_score/100;
			int index2 = (this_score%100)/10;
			int index3 = (this_score%100)%10;
			scores_this_level[1].SetActive(true);
			scores_this_level[2].SetActive(true);
			
			scores_this_level[0].GetComponent<SpriteRenderer>().sprite = listSpriteTxtScore[index1];
			scores_this_level[1].GetComponent<SpriteRenderer>().sprite = listSpriteTxtScore[index2];
			scores_this_level[2].GetComponent<SpriteRenderer>().sprite = listSpriteTxtScore[index3];
		}
		else if(this_score<10000)
		{
			int index1 = this_score/1000;
			int index2 = (this_score%1000)/100;
			int index3 = ((this_score%1000)%100)/10;
			int index4 = ((this_score%1000)%100)%10;
			scores_this_level[1].SetActive(true);
			scores_this_level[2].SetActive(true);
			scores_this_level[3].SetActive(true);
			scores_this_level[0].GetComponent<SpriteRenderer>().sprite = listSpriteTxtScore[index1];
			scores_this_level[1].GetComponent<SpriteRenderer>().sprite = listSpriteTxtScore[index2];
			scores_this_level[2].GetComponent<SpriteRenderer>().sprite = listSpriteTxtScore[index3];
			scores_this_level[3].GetComponent<SpriteRenderer>().sprite = listSpriteTxtScore[index4];
		}
		else if(this_score<100000)
		{		
			int index1 = this_score/10000;
			int index2 = (this_score%10000)/1000;
			int index3 = ((this_score%10000)%1000)/100;
			int index4 = (((this_score%10000)%1000)%100)/10;
			int index5 = (((this_score%10000)%1000)%100)%10;
			scores_this_level[1].SetActive(true);
			scores_this_level[2].SetActive(true);
			scores_this_level[3].SetActive(true);
			scores_this_level[4].SetActive(true);
			
			scores_this_level[0].GetComponent<SpriteRenderer>().sprite = listSpriteTxtScore[index1];
			scores_this_level[1].GetComponent<SpriteRenderer>().sprite = listSpriteTxtScore[index2];
			scores_this_level[2].GetComponent<SpriteRenderer>().sprite = listSpriteTxtScore[index3];
			scores_this_level[3].GetComponent<SpriteRenderer>().sprite = listSpriteTxtScore[index4];
			scores_this_level[4].GetComponent<SpriteRenderer>().sprite = listSpriteTxtScore[index5];
		}

	}
	void OnMouseDown()
	{
		LevelControll.this_level = thisNumberName;
		LevelControll.gamePause = false;
		GameObject Soundss = GameObject.Find("Sounds");
		Soundss.GetComponent<SoundController> ().pauseSpe ("soundbutton");
		if(Soundss !=null){
			Destroy(Soundss);

		}
		Application.LoadLevel (1);
	}
}
