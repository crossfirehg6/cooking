using UnityEngine;
using System.Collections;
using System.Linq;
public class MenuControll : MonoBehaviour {

	// Use this for initialization
	public GameObject[] listbtnpage;
	void Awake () {
		SaveLoad sv = new SaveLoad ();
		sv.loadFileLevel ();
	

	}
	void Start(){
		showPageNum ();
	}
	// Update is called once per frame
	public void showPageNum()
	{
		foreach (Transform t in this.transform) {
			if(t.name ==nextBackControll.recentPage.ToString())
			{
				t.gameObject.SetActive(true);
			}
			else if(t.name !="ButtonMenu")
			{
				t.gameObject.SetActive(false);
			}
		}
		GameObject abc = this.transform.FindChild("ButtonMenu").FindChild("listPageNum").gameObject;

		int xxx = menuButtons.maxLv / 10;
		if (xxx == 0) {
			 this.transform.FindChild ("ButtonMenu").FindChild ("btnGo").gameObject.SetActive (false);
			 this.transform.FindChild ("ButtonMenu").FindChild ("btnPre").gameObject.SetActive (false);
		}
		else 
		{
			 this.transform.FindChild ("ButtonMenu").FindChild ("btnGo").gameObject.SetActive (true);
			this.transform.FindChild ("ButtonMenu").FindChild ("btnPre").gameObject.SetActive (true);
		}
		for (int i=0; i<= xxx; i++) {
			if(i<=9){
			listbtnpage[i].SetActive(true);
			}
		}

		float posx = 8.8f - xxx;
		if (posx < 1) {
			posx =0;
		}
		abc.transform.localPosition = new Vector3 (posx, 0, 0);
		foreach (GameObject t in listbtnpage) {
			if(t.name =="btnNum_"+nextBackControll.recentPage)
			{
				t.transform.FindChild("bg").gameObject.SetActive(true);
			}
			else
			{
				t.transform.FindChild("bg").gameObject.SetActive(false);
			}
		}
	}
}
