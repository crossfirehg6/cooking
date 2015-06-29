using UnityEngine;
using System.Collections;

public class btnBuying : MonoBehaviour {

	// Use this for initialization
	public int moneyRequire;
	public GameObject parentControll;
	public Sprite txt;
	public GameObject btnUpgrade;
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnMouseDown()
	{
		GameObject board = this.transform.parent.parent.FindChild ("board").gameObject;
		changeSpriteForNums (board);
		board.transform.FindChild ("text").gameObject.GetComponent<SpriteRenderer> ().sprite = txt;

		board.SetActive (true);
		GameObject btnConfirm = board.transform.FindChild ("btnConfirm2").gameObject;
		btnConfirm.GetComponent<confirmButtonControll> ().parrentOb = parentControll;
		btnConfirm.GetComponent<confirmButtonControll> ().moneyRequire = moneyRequire;

	}
	public void showBtnUpgrade(){
		if (this.transform.parent.name == "tivi") {
			if(LevelControll.level_tv>0)
			{
				btnUpgrade.SetActive(true);
				this.transform.parent.gameObject.SetActive(false);
			}
			else
			{
				btnUpgrade.SetActive(false);
			}

		}
		if (this.transform.parent.name == "manocan") {
			if(LevelControll.level_manocan>0)
			{
				btnUpgrade.SetActive(true);
				this.transform.parent.gameObject.SetActive(false);
			}
			else
			{
				btnUpgrade.SetActive(false);
			}
		}
	}
	void changeSpriteForNums(GameObject upgreadBoard)
	{
		int num = moneyRequire ;
		GameObject num1 = upgreadBoard.transform.FindChild ("num").FindChild ("num1").gameObject;
		GameObject num2 = upgreadBoard.transform.FindChild ("num").FindChild ("num2").gameObject;
		GameObject num3 = upgreadBoard.transform.FindChild ("num").FindChild ("num3").gameObject;
		GameObject num4 = upgreadBoard.transform.FindChild ("num").FindChild ("num4").gameObject;
		GameObject GM = GameObject.Find ("GM");
		GM.GetComponent<_GM> ().changeSprite (num, num1, num2, num3, num4, null, null, null);

	}
}
