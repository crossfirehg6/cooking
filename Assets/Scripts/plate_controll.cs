using UnityEngine;
using System.Collections;

public class plate_controll : MonoBehaviour {

	// Use this for initialization
	public bool unlock;
	public bool hasFood;
	public GameObject noticeBoard;
	public Sprite[] list_txt;
	void Start () {
		showFood ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnMouseDown()
	{
		showBoard ();
		this.transform.localScale = this.transform.localScale + new Vector3 (0.4f, 0.4f, 0);
	}
	void OnMouseUp(){
		backLocalScale ();
	}
	public void UnLock( bool val)
	{
		if (val) {
			GameObject Scores = GameObject.Find ("Scores");
			Scores.GetComponent<Score> ().updateScore (-LevelControll.money_unlock_plate, false);
		
			string[] abc = this.name.Split ('_');
			LevelControll.openDiskName = LevelControll.openDiskName + "_" + abc [1];

			//backLocalScale();
		}
		unlock = true;
		this.transform.FindChild ("lock").gameObject.SetActive (false);
		this.GetComponent<Collider2D> ().enabled = false;
		GameObject GM = GameObject.Find ("GM");
		GM.GetComponent<_GM> ().add_unlock_plate (this.gameObject);
		showFood ();
	

	}
	public void showBoard(){
		noticeBoard.SetActive(true);
		noticeBoard.transform.FindChild ("text").gameObject.GetComponent<SpriteRenderer> ().sprite = list_txt [0];
		
		noticeBoard.transform.FindChild ("btnConfirm").gameObject.GetComponent<confirmButtonControll> ().parrentOb = this.gameObject;
		noticeBoard.transform.FindChild ("btnDiscard2").gameObject.GetComponent<confirmButtonControll> ().parrentOb = this.gameObject;
		changeSpriteForNums(noticeBoard);
	}
	void showFood()
	{
		//this.transform.localScale = new Vector3 (0.4f,0.4f,0) + this.transform.localScale;
		this.transform.FindChild("food").gameObject.SetActive(unlock);

	}
	public void checkMoney()
	{

		if (Score.score >= LevelControll.money_unlock_plate) {
			showThongbao();
			UnLock(true);
		}
		else
		{
			noticeBoard.transform.parent.FindChild("thongbao").gameObject.SetActive(true);
			noticeBoard.transform.parent.FindChild("thongbao").FindChild("no").gameObject.SetActive(true);
		}
	}
	public void showThongbao(){
		noticeBoard.transform.parent.FindChild("thongbao").gameObject.SetActive(true);
		noticeBoard.transform.parent.FindChild("thongbao").FindChild("yes").gameObject.SetActive(true);
	}
	public void backLocalScale()
	{
		this.transform.localScale = this.transform.localScale - new Vector3 (0.4f, 0.4f, 0);
	}

	void changeSpriteForNums(GameObject upgreadBoard)
	{
		int num = LevelControll.money_unlock_plate ;
		GameObject num1 = upgreadBoard.transform.FindChild ("num").FindChild ("num1").gameObject;
		GameObject num2 = upgreadBoard.transform.FindChild ("num").FindChild ("num2").gameObject;
		GameObject num3 = upgreadBoard.transform.FindChild ("num").FindChild ("num3").gameObject;
		//GameObject num4 = upgreadBoard.transform.FindChild ("num").FindChild ("num4").gameObject;
		GameObject GM = GameObject.Find ("GM");
		GM.GetComponent<_GM> ().changeSprite (num, num1, num2, num3, null, null, null, null);

	}
}
