using UnityEngine;
using System.Collections;

public class confirmButtonControll : MonoBehaviour {

	// Use this for initialization
	public GameObject parrentOb;
	public bool isPlate;
	public int moneyRequire;
	void OnMouseDown()
	{
		if (this.name == "btnConfirm")
		{
			if (isPlate) {
				if (parrentOb != null) {


					parrentOb.GetComponent<plate_controll> ().checkMoney();
					parrentOb = null;
					
					this.transform.parent.gameObject.SetActive (false);
				}
			} else {
				if (parrentOb != null) {
					parrentOb.GetComponent<ItemsControl> ().changeLevelItem ();
					parrentOb = null;

					this.transform.parent.gameObject.SetActive (false);
					if(_GM.firstTime)
					{
						GameObject GM = GameObject.Find("GM");
						GM.GetComponent<_GM>().guideSteps(14);
					}
				}
			}
		}
		if (this.name == "btnConfirm2")
		{
			if(parrentOb.name =="updateBar")
			{	if(Score.score >=moneyRequire)
				{
					parrentOb.SetActive(true);
					parrentOb.transform.parent.FindChild("btnUpgrade").gameObject.SetActive(true);
					parrentOb.GetComponent<ItemsControl> ().changeLevelItem ();
					this.transform.parent.parent.FindChild(parrentOb.transform.parent.name).FindChild("btnBuy").gameObject.SetActive(false);
					parrentOb.SetActive(false);
					GameObject Menu_board = GameObject.Find("Menu_board");
					Menu_board.transform.FindChild("thongbao").FindChild("yes").gameObject.SetActive(true);
				}
				else
				{
					GameObject Menu_board = GameObject.Find("Menu_board");
					Menu_board.transform.FindChild("thongbao").FindChild("no").gameObject.SetActive(true);

				}
			}
			else
			{
				if(Score.score >=moneyRequire)
				{
					GameObject sc = GameObject.Find ("Scores");
					sc.GetComponent<Score> ().updateScore (-moneyRequire,false);
					GameObject sounds = GameObject.Find("Sounds");
					sounds.GetComponent<SoundController> ().playSpe ("thanh_cong");
					if(parrentOb.name =="gaubong")
					{
						LevelControll.gau_bong=1;
					}
					if(parrentOb.name =="mayxeng")
					{
						LevelControll.mayxeng=1;

					}
					if(parrentOb.name =="maytinhtien")
					{
						LevelControll.maytinhtien=1;
					}
					if(parrentOb.name =="chauhoa")
					{
						LevelControll.chauhoa=1;
					}
					parrentOb.SetActive(true);
					this.transform.parent.parent.FindChild(parrentOb.name).FindChild("btnBuy").gameObject.SetActive(false);
					GameObject Menu_board = GameObject.Find("Menu_board");
					Menu_board.transform.FindChild("thongbao").FindChild("yes").gameObject.SetActive(true);
				}
				else
				{
					GameObject Menu_board = GameObject.Find("Menu_board");
					Menu_board.transform.FindChild("thongbao").FindChild("no").gameObject.SetActive(true);
				}
			}
			parrentOb = null;
			
			this.transform.parent.gameObject.SetActive (false);
		}
		else if (this.name == "btnDiscard3")
		{
			this.transform.parent.gameObject.SetActive (false);
		}
		else if (this.name == "btnDiscard2")
		{
		
			parrentOb = null;
			
			this.transform.parent.gameObject.SetActive (false);
		}

	}


}
