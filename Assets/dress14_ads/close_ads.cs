using UnityEngine;
using System.Collections;

public class close_ads : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown()
	{
		GameObject www=GameObject.Find("www");

		www.SetActive (false);
	}
}
