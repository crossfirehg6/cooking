using UnityEngine;
using System.Collections;

public class quangcao : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnMouseDown()
	{
		if (this.name == "available-on_0") {
			Application.OpenURL("https://play.google.com/store/apps/details?id=com.dress14.babydinocare&hl=vi");		
		}
		if (this.name == "available-on_1") {
			//Application.OpenURL("https://itunes.apple.com/us/artist/tuyen-hoang/id631944333");		
		}
		if (this.name == "available-on_2") {
			//Application.OpenURL("https://play.google.com/store/search?q=dress14&c=apps&docType=1&sp=CAFiCQoHZHJlc3MxNHoCGACKAQIIAQ%3D%3D&hl=vi");		
		}
		if (this.name == "available-on_3") {
			//Application.OpenURL("https://play.google.com/store/search?q=dress14&c=apps&docType=1&sp=CAFiCQoHZHJlc3MxNHoCGACKAQIIAQ%3D%3D&hl=vi");		
		}
	}
}
