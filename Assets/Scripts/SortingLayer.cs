using UnityEngine;
using System.Collections;

public class SortingLayer : MonoBehaviour {

	// Use this for initialization

	void Start () 
	{
		if (this.transform.parent.name == "tim_lon" || this.name =="tim_lon") 
		{
			GetComponent<ParticleSystem>().GetComponent<Renderer>().sortingLayerName = "Default";
			GetComponent<ParticleSystem>().GetComponent<Renderer>().sortingOrder =1;
				} else {
			GetComponent<ParticleSystem>().GetComponent<Renderer>().sortingLayerName = "top";
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
