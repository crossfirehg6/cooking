using UnityEngine;
using System.Collections;

public class marginTopLeft : MonoBehaviour {
	public float marginTop=80f;
	public float marginLeft=80f;
	float itemWidth=0;
	float itemHeight=0;
	// Use this for initialization
	void Start () {
		gameObject.transform.position = new Vector3 (Camera.main.ViewportToWorldPoint(new Vector2(0,1)).x+itemWidth+marginLeft, Camera.main.ViewportToWorldPoint(new Vector2(0,1)).y-marginTop,this.transform.position.z);

	}
	// Update is called once per frame
	void Update () {
	//	gameObject.transform.position = new Vector3 (Camera.main.ViewportToWorldPoint(new Vector2(0,1)).x+itemWidth+marginLeft, Camera.main.ViewportToWorldPoint(new Vector2(0,1)).y-marginTop,this.transform.position.z);

		}
}
