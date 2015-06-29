using UnityEngine;
using System.Collections;

public class ItemsControl : MonoBehaviour {

	// Use this for initialization

	public int level;
	public int[] requireMoney;
	public bool type_1;
	public Sprite[] lisTextUpdate;
	public GameObject upgreadBoard;
	public int maxlevel;
	public GameObject[] listBoxObject;
	GameObject sounds;
	void Start () {
		// hien thi thanh bar level
		if(this.transform.parent.name =="table")
		{
			level = LevelControll.level_table;

		}
		else if(this.transform.parent.name =="tivi")
		{
			level = LevelControll.level_tv;

		}
		else if(this.transform.parent.name =="manocan")
		{
			level = LevelControll.level_manocan;
		}
		else if(this.transform.parent.name =="lonuong")
		{
			level = LevelControll.level_lo;
		}
		else if(this.transform.parent.name =="machine")
		{
			level = LevelControll.level_machine;
		}
		else if(this.transform.parent.name =="chao" || this.transform.parent.name =="vi_nuong")
		{
			level = this.transform.parent.gameObject.GetComponent<bep_lo>().this_level;
		}
		for (int i=1; i<=level; i++) {
			GameObject t = this.transform.FindChild("level_"+i).gameObject;
			if(t !=null)
			{
				t.gameObject.SetActive(true);
			}
		}
		this.gameObject.SetActive (false);
		//changeLevelItem ();
		sounds = GameObject.Find("Sounds");
	}

	void showThis()
	{
		this.transform.FindChild ("level_" + (level - 1)).gameObject.SetActive (false);
		this.transform.FindChild ("level_" + level).gameObject.SetActive (true);
	}
	void OnMouseDown()
	{
		if (level < maxlevel) {
			int index = level;
			if (index < 0) {
				index = 0;
			}
			changeSpriteForNums(index);
			upgreadBoard.transform.FindChild ("text").gameObject.GetComponent<SpriteRenderer> ().sprite = lisTextUpdate [index];
			upgreadBoard.SetActive (true);
			upgreadBoard.transform.FindChild ("btnConfirm").gameObject.GetComponent<confirmButtonControll> ().parrentOb = this.gameObject;
		}
		if (_GM.firstTime) {
			GameObject GM = GameObject.Find ("GM");
			GM.GetComponent<_GM> ().guideSteps(13);
		}
		turnOffBox (false);
	}

	public void changeLevelItem()
	{
		LevelControll levelcontroll = GameObject.Find("Levels").GetComponent<LevelControll>();
		if (type_1) 
		{

				if(this.transform.parent.name =="manocan")
				{
					if(checkMoney())
					{
						LevelControll.level_manocan++;
						levelcontroll.changeLevelManocan();
						if(LevelControll.level_manocan>1){
						this.transform.parent.FindChild("thongbao").gameObject.SetActive(true);
						this.transform.parent.FindChild("thongbao").FindChild("yes").gameObject.SetActive(true);
						this.transform.parent.FindChild("thongbao").FindChild("yes").GetChild(0).gameObject.GetComponent<Collider2D>().enabled =true;
						}
					}
					else
					{
						if(LevelControll.level_manocan>=1){
						this.transform.parent.FindChild("thongbao").gameObject.SetActive(true);
						this.transform.parent.FindChild("thongbao").FindChild("no").gameObject.SetActive(true);
						this.transform.parent.FindChild("thongbao").FindChild("no").GetChild(0).gameObject.GetComponent<Collider2D>().enabled =true;
						}
					}
				}
				else if(this.transform.parent.name =="table")
				{
					if(checkMoney())
					{
						LevelControll.level_table++;
						levelcontroll.changeLevelTable();	
					this.transform.parent.FindChild("thongbao").gameObject.SetActive(true);
					this.transform.parent.FindChild("thongbao").FindChild("yes").gameObject.SetActive(true);
					this.transform.parent.FindChild("thongbao").FindChild("yes").GetChild(0).gameObject.GetComponent<Collider2D>().enabled =true;
					}
					
					else
					{
						
							this.transform.parent.FindChild("thongbao").gameObject.SetActive(true);
							this.transform.parent.FindChild("thongbao").FindChild("no").gameObject.SetActive(true);
							this.transform.parent.FindChild("thongbao").FindChild("no").GetChild(0).gameObject.GetComponent<Collider2D>().enabled =true;
						
					}
				
			}
			else if(this.transform.parent.name =="tivi")
				{
					if(checkMoney())
					{
						LevelControll.level_tv++;
						levelcontroll.changeLevelTivi();
						if(LevelControll.level_tv>1){
						this.transform.parent.FindChild("thongbao").gameObject.SetActive(true);
						this.transform.parent.FindChild("thongbao").FindChild("yes").gameObject.SetActive(true);
						this.transform.parent.FindChild("thongbao").FindChild("yes").GetChild(0).gameObject.GetComponent<Collider2D>().enabled =true;
							}
						}
						else
						{
							if(LevelControll.level_tv>=1){
									this.transform.parent.FindChild("thongbao").gameObject.SetActive(true);
									this.transform.parent.FindChild("thongbao").FindChild("no").gameObject.SetActive(true);
						this.transform.parent.FindChild("thongbao").FindChild("no").GetChild(0).gameObject.GetComponent<Collider2D>().enabled =true;
							}
						}
			}
			

		}
		else
		{

			if(this.transform.parent.name =="machines")
			{
				if(checkMoney())
				{
				LevelControll.level_machine++;
				levelcontroll.changeSpriteMachine();


				}

			}
			else if(this.transform.parent.name =="lonuong")
			{	
				if(checkMoney())
				{
					LevelControll.level_lo++;
					levelcontroll.changeSpriteLo();

				}

			}
			else if(this.transform.parent.parent.parent.name =="Gases")
			{
				if(checkMoney()){
					string[] abc = LevelControll.level_bep.Split('_');
					string[] thisPaArr = this.transform.parent.parent.name.Split('_');
					int parInt = int.Parse(thisPaArr[1]);
					int parVal = int.Parse(abc[parInt-1]);
					parVal++;
					abc[parInt-1] = parVal.ToString();
					LevelControll.level_bep=abc[0];
					for(int i=1;i<abc.Length;i++)
					{
						LevelControll.level_bep +="_"+abc[i];
					}
					levelcontroll.changeSpriteGas();
				
				}

			}
			
		}

		changeBar ();
	//	turnOffBox (true);
	}
	bool checkMoney()
	{
		if (level < maxlevel) {
			if (Score.score >= requireMoney [level]) {
			
				GameObject sc = GameObject.Find ("Scores");
				sc.GetComponent<Score> ().updateScore (-requireMoney [level],false);
				sounds.GetComponent<SoundController> ().playSpe ("thanh_cong");
				if(this.transform.parent.name !="tivi" && this.transform.parent.name !="manocan"  ){
				
				this.transform.parent.FindChild("thongbao").gameObject.SetActive(true);
				this.transform.parent.FindChild("thongbao").FindChild("yes").gameObject.SetActive(true);
				this.transform.parent.FindChild("thongbao").FindChild("yes").GetChild(0).gameObject.GetComponent<Collider2D>().enabled =true;
					Debug.Log(1111);
				}

				return true;
			}
		}
		sounds.GetComponent<SoundController> ().playSpe ("thieu_tien");
		if (this.transform.parent.name != "tivi" && this.transform.parent.name != "manocan") {
			Debug.Log(2222);
			this.transform.parent.FindChild ("thongbao").gameObject.SetActive (true);
			this.transform.parent.FindChild ("thongbao").FindChild ("no").gameObject.SetActive (true);
			this.transform.parent.FindChild ("thongbao").FindChild ("no").GetChild(0).gameObject.GetComponent<Collider2D> ().enabled = true;
		}
		return false;
	}
	void changeBar()
	{
		for (int i=0; i<=level; i++) {
			Transform t = this.transform.FindChild("level_"+i);
			if(t !=null)
			{
				t.gameObject.SetActive(true);
			}
		}
	}
	public void turnOffBox(bool val)
	{
		this.GetComponent<BoxCollider2D> ().enabled = val;
		foreach (GameObject t in listBoxObject) {
			if(t.GetComponent<BoxCollider2D>() !=null)
			{
				t.GetComponent<BoxCollider2D>().enabled =val;
			}
		}
	}
	void changeSpriteForNums(int index)
	{
		int num = requireMoney [index];

		GameObject num1 = upgreadBoard.transform.FindChild ("num").FindChild ("num1").gameObject;
		GameObject num2 = upgreadBoard.transform.FindChild ("num").FindChild ("num2").gameObject;
		GameObject num3 = upgreadBoard.transform.FindChild ("num").FindChild ("num3").gameObject;
		GameObject GM = GameObject.Find ("GM");
		GM.GetComponent<_GM> ().changeSprite (num, num1, num2, num3, null, null, null, null);

	}
}
