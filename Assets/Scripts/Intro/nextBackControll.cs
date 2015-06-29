using UnityEngine;
using System.Collections;

public class nextBackControll : MonoBehaviour {

	// Use this for initialization
	public static int recentPage=1;
	public int val;
	public static int maxPage;

	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnMouseDown()
	{
		maxPage = (menuButtons.maxLv / 10)+1;
		recentPage += val;
		if (recentPage > maxPage) {
			recentPage=maxPage;
		}
		if (recentPage < 1) {
			recentPage=1;
		}
		this.transform.parent.parent.gameObject.GetComponent<MenuControll> ().showPageNum ();
//		foreach (Transform t in this.transform.parent.parent) {
//			if(t.gameObject != this.transform.parent.gameObject)
//			{
//				if(t.name == recentPage.ToString())
//				{
//					t.gameObject.SetActive(true);
//				}
//				else
//				{
//					t.gameObject.SetActive(false);
//				}
//			}
//		}
	}
}
