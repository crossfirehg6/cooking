using UnityEngine;
using System.Collections;

public class btnMusic : MonoBehaviour {

	// Use this for initialization
	public Sprite offSprite;
	GameObject soundss;
	Sprite oldSprite;
	void Start () {
		soundss = GameObject.Find ("Sounds");
		oldSprite = this.GetComponent<SpriteRenderer> ().sprite;
		if (this.name == "btnMusic") {
			if(SoundController.bgOff)
			{
				soundss.GetComponent<SoundController>().turnOffBg();
				this.GetComponent<SpriteRenderer> ().sprite = offSprite;
			}

		}
		else if (this.name == "btnSound") {
			if(SoundController.effectOff)
			{
				soundss.GetComponent<SoundController>().turnOffEffect();
				this.GetComponent<SpriteRenderer> ().sprite = offSprite;
			}

		}


	}
	
	// Update is called once per frame
	void OnMouseDown()
	{
		if (this.name == "btnMusic") {
			if(SoundController.bgOff)
			{
				soundss.GetComponent<SoundController>().turnOnBg();
				this.GetComponent<SpriteRenderer> ().sprite = oldSprite;
			}
			else
			{
				soundss.GetComponent<SoundController>().turnOffBg();
				this.GetComponent<SpriteRenderer> ().sprite = offSprite;
			}
		}
		else if (this.name == "btnSound") {
			if(SoundController.effectOff)
			{
				soundss.GetComponent<SoundController>().turnOnEffect();
				this.GetComponent<SpriteRenderer> ().sprite = oldSprite;
			}
			else
			{
				soundss.GetComponent<SoundController>().turnOffEffect();
				this.GetComponent<SpriteRenderer> ().sprite = offSprite;
			}
		}
	}
}
