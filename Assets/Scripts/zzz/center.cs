using UnityEngine;
using System.Collections;

public class center : MonoBehaviour {

	public float width;
	public float height;
	public float scale;
	void Start () {

	}

	void Update () {
		this.width = Camera.main.ViewportToWorldPoint(new Vector2(0,0)).x;
		this.width = Mathf.Abs (this.width*2)-(1.33f*2);
		this.scale = this.width / 5f;

		this.transform.localScale = new Vector2 (this.scale,1);
	}
}
