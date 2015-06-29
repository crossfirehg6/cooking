using UnityEngine;
using System.Collections;

public class cocaControll : FoodsControll {

	// Use this for initialization
	public int levelOpen;
	void Start () {
		checkOpen ();
		base.Start ();

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnMouseDown()
	{
		this.GetComponent<SpriteRenderer>().sortingLayerName = "mouses";

	}
	void OnMouseUp()
	{
		this.GetComponent<SpriteRenderer>().sortingLayerName = "Default";
		base.OnMouseUp ();
	}
	public override void getType(){
		this_type = checkItem.type_mouse.hoan_thanh;
	
	}
	public override void moveback ()
	{
		this.transform.localPosition = oldPos;
	}
	void checkOpen()
	{
		if (LevelControll.maxLevelOpened < levelOpen) {
			this.transform.parent.localScale = new Vector3 (0, 0, 0);
		} else {
			this.transform.parent.localScale = new Vector3 (0.85f, 0.85f, 0.85f);
		}
	}
}
