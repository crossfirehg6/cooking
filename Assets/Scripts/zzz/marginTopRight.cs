using UnityEngine;
using System.Collections;

public class marginTopRight : MonoBehaviour {
	public float marginTop=80;
	public float marginRight=80;
	// Use this for initialization
	void Start () {
		gameObject.transform.position = new Vector3 (Camera.main.ViewportToWorldPoint(new Vector2(1,1)).x-marginRight, Camera.main.ViewportToWorldPoint(new Vector2(1,1)).y-marginTop,this.transform.position.z);
	}
	// Update is called once per frame
	void Update () {
		gameObject.transform.position = new Vector3 (Camera.main.ViewportToWorldPoint(new Vector2(1,1)).x-marginRight, Camera.main.ViewportToWorldPoint(new Vector2(1,1)).y-marginTop,this.transform.position.z);
	}
}
