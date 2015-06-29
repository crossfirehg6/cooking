using UnityEngine;
using System.Collections;

public class GM_2 : MonoBehaviour {

	// Use this for initialization
	void Awake () {

		GameObject sound1 = GameObject.Find ("Sounds_1");
		if (sound1 != null) {
			GameObject Soundss = GameObject.Find("Sounds");
			Soundss.SetActive(false);
			Destroy(Soundss);
			sound1.name ="Sounds";
		}
			sound1 = GameObject.Find("Sounds");
			sound1.GetComponent<SoundController> ().playSpe ("bgSound");

	}


}
