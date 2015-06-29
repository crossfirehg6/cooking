using UnityEngine;
using System.Collections;

public class ButtonControll : MonoBehaviour {

	// Use this for initialization
	public int level_open;
	public GameObject[] controlledObject;
	GameObject Soundss;
	void Start () {
		if (level_open > LevelControll.this_level) {
			this.gameObject.SetActive(false);
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnMouseDown()
	{
		GameObject GM = GameObject.Find("GM");
		Soundss = GameObject.Find("Sounds");
		Soundss.GetComponent<SoundController> ().playSpe2 ("soundbutton");
		if (this.name == "btnPlay") {
		
			if(Soundss !=null){
			DontDestroyOnLoad(Soundss);
			Soundss.name ="Sounds_1";
			}
			Application.LoadLevel (2);

		}
		if ( this.name == "btnReplay") {
			GameObject	lv = GameObject.Find ("Levels");
			lv.GetComponent<LevelControll>().callFunctionSave();
		
			DontDestroyOnLoad(Soundss);
			Soundss.name ="Sounds_1";
			Application.LoadLevel (1);
			LevelControll.gamePause=false;

		}
		else if(this.name =="btnUpdate")
		{

			GM.GetComponent<_GM>().showUpgrade(true);
			if(_GM.firstTime){
			GM.GetComponent<_GM>().guideSteps(11);
			}
			iTween.ScaleTo(this.transform.parent.gameObject,Vector3.zero,1);
			StartCoroutine(GM.GetComponent<_GM>().nhapnhayUpdate(this.transform.GetChild(0).gameObject,false));
			_GM.numLevelPass=0;

		}
		else if(this.name =="btnNext")
		{
			GameObject	lv = GameObject.Find ("Levels");
			lv.GetComponent<LevelControll>().callFunctionSave();
			Application.LoadLevel (2);
		}
		else if(this.name =="btnAbort")
		{
			Application.LoadLevel(0);
		}
		else if(this.name =="btnReturn")
		{
			Soundss = GameObject.Find("Sounds");
			Soundss.name ="Sounds_1";
			Application.LoadLevel(0);

		}
		else if(this.name =="btnResign")
		{
			controlledObject[0].SetActive(true);
			this.transform.parent.gameObject.SetActive(false);
		}
		else if(this.name =="reYes")
		{

			Application.LoadLevel(0);
		}
		else if(this.name =="reNo")
		{
			controlledObject[0].SetActive(true);
			this.transform.parent.gameObject.SetActive(false);
		}
		else if(this.name =="btnSound")
		{
			
		}
		else if(this.name =="btnMusic")
		{
			
		}
		else if(this.name =="btnClose1")
		{
			this.transform.parent.gameObject.SetActive(false);	
		}
		else if(this.name =="btnClose2")
		{
			if(_GM.firstTime)
			{
				GM.GetComponent<_GM>().guideSteps(0);
			}
			this.transform.parent.parent.parent.FindChild("updateBar").gameObject.GetComponent<Collider2D>().enabled=true;
			this.transform.parent.parent.parent.FindChild("updateBar").gameObject.GetComponent<ItemsControl>().turnOffBox(true);

			this.transform.parent.gameObject.SetActive(false);	
		}
		else if(this.name =="btnCloseOpenItem")
		{

				GM.GetComponent<_GM>().showOpenItem(false);

		}

		else if(this.name =="btnBack")
		{
	
			GM.GetComponent<_GM>().showMainCam(true);
			GM.GetComponent<_GM>().showUpgrade(true);
			if(_GM.firstTime)
			{
				GM.GetComponent<_GM>().guideSteps(15);
			}
			GameObject[] list1 = GameObject.FindGameObjectsWithTag("updateBar");
			foreach(GameObject o in list1)
			{
				o.gameObject.SetActive(false);
			}

		}
		else if(this.name =="btnBackAll")
		{
			GM.GetComponent<_GM>().showMainCam(true);
			GM.GetComponent<_GM>().showUpgrade(false);
			if(_GM.firstTime)
			{
				GM.GetComponent<_GM>().guideSteps(0);
				_GM.firstTime=false;
			}
			GameObject Menu_board = GameObject.Find ("Menu_board");
			foreach(Transform t in Menu_board.transform.FindChild("level_end"))
			{
				if(t.gameObject.activeSelf)
				{
					iTween.ScaleTo(t.gameObject,Vector3.one,1);
				}
			}
			GM.GetComponent<_GM>().manden.SetActive(true);

		}
		else if(this.name =="btnClose")
		{
			iTween.MoveTo(controlledObject[0],new Vector3(0,17,0) ,3);
			StartCoroutine(changePause(false,3));
			GM.GetComponent<_GM>().manden.SetActive(false);

		}
		else if(this.name =="btnClose22")
		{
			iTween.MoveTo(controlledObject[0],new Vector3(0,17,0) ,3);
			StartCoroutine(changePause(false,3));
			controlledObject[1].SetActive(false);
			
		}
		else if(this.name =="btnOption")
		{
			iTween.MoveTo(controlledObject[0],Vector3.zero,3);
			StartCoroutine(changePause(true,0));
			GM.GetComponent<_GM>().manden.SetActive(true);
		}
		else if(this.name =="btnOption2")
		{
			iTween.MoveTo(controlledObject[0],Vector3.zero,3);
			StartCoroutine(changePause(true,0));
//			GM.GetComponent<_GM>().manden.SetActive(true);
			controlledObject[1].SetActive(true);
		}
		else if(this.name =="btnDiscard")
		{
			this.transform.parent.FindChild("btnConfirm").gameObject.GetComponent<Collider2D>().enabled =true;
			foreach(GameObject o in controlledObject){
			o.GetComponent<Collider2D>().enabled = true;
			}
			this.transform.parent.gameObject.SetActive(false);
		}
		else if(this.name =="btnDiscard2")
		{
			this.transform.parent.gameObject.SetActive(false);

		}
		else if(this.name =="btnUpgrade")
		{

			GM.GetComponent<_GM>().showCameraUpgrade(this.transform.parent.name);
			GM.GetComponent<_GM>().showOb(false);
			foreach(GameObject abc in controlledObject)
			{
				abc.SetActive(true);
			}
			GM.GetComponent<_GM>().showUpgrade(false);
			GM.GetComponent<_GM>().showMainCam(false);
			if(_GM.firstTime)
			{
				GM.GetComponent<_GM>().guideSteps(12);
			}
		}

	}
	IEnumerator changePause(bool val, int timess)
	{
		yield return new WaitForSeconds (timess);
		LevelControll.gamePause=val;
	}
}
