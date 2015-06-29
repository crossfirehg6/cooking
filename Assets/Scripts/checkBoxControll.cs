using UnityEngine;
using System.Collections;

public class checkBoxControll : MonoBehaviour {

	// Use this for initialization
	public int money;
	public GameObject prefabScore;
	public GameObject sounds;
	void Start () {
		sounds = GameObject.Find ("Sounds");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void showMoney(bool val,int money)
	{
		this.money += money;
		if (LevelControll.maytinhtien == 0) {

			this.GetComponent<SpriteRenderer> ().enabled = val;
			sounds.GetComponent<SoundController> ().playSpe ("tra_tien");
		

		}
		else 
		{
			if(this.money>0){
			thutien();
			}
		}
	}
	void OnMouseDown()
	{
		if (this.money > 0) {
			thutien();
			if(_GM.firstTime)
			{
				if(_GM.numCus==0)
				{
					GameObject GM = GameObject.Find("GM");
					GM.GetComponent<_GM>().guideSteps(0);
					LevelControll.maxPeople=1;
					_GM.numCus=1;
				//	GM.GetComponent<_GM>().createCharacter();
				}
			}
		}
	}
	void thutien()
	{
		GameObject scores = GameObject.Find ("Scores");
		scores.GetComponent<Score> ().updateScore (money, true);
		GameObject abc = Instantiate (prefabScore, this.transform.position, Quaternion.identity) as GameObject;
		abc.GetComponent<bonusScore> ().score = money;
		abc.GetComponent<bonusScore> ().changeSprite ();
		iTween.MoveTo (abc, abc.transform.position + new Vector3 (0, 4, 0), 2);
		Destroy (abc, 2);
	
		this.money = 0;
		showMoney (false, 0);
		sounds.GetComponent<SoundController>().playSpe("thu_tien");
	}
}
