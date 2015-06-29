using UnityEngine;
using System.Collections;

public class SoundController : MonoBehaviour {

	// Use this for initialization
	public static bool soundOff;
	public static bool bgOff;
	public static bool effectOff;
	void Awake(){
		if (!soundOff) {
			turnOnSound ();
		} else {
			turnOffSound();
		}

		if (effectOff) {
			turnOffEffect();
		}
		if (bgOff) {
			turnOffBg();
		}
	}
	public void playSoundInTimes(string obName,int times,float delay,float beginDelay)
	{
		StartCoroutine( playSoundTimes(obName,times,delay,beginDelay));
	}
	IEnumerator playSoundTimes(string obName,int times, float delay,float beginDelay)
	{
		yield return new WaitForSeconds (beginDelay);
		playSpe (obName);
		for (int i = 0; i<times; i++)
		{
			yield return new WaitForSeconds(delay);
			playSpe (obName);
		}

	}
	public  void playSpe(string obName)
	{

		if (!soundOff) 
		{
			foreach (Transform t in this.transform) 
			{
				if (t.name == obName)
				{
					if(t.gameObject.GetComponent<AudioSource>() !=null)
					{
						if(!t.gameObject.GetComponent<AudioSource>().isPlaying)
						{

							//t.gameObject.GetComponent<AudioSource>().volume=1;
							t.gameObject.GetComponent<AudioSource>().Play();
						}
					}
				}
			}
		}
	}

	public  void playSpe1(string obName)
	{
		
		if (!soundOff) 
		{

					if(this.transform.FindChild(obName).gameObject.GetComponent<AudioSource>() !=null)
					{
						if(!this.transform.FindChild(obName).gameObject.GetComponent<AudioSource>().isPlaying)
							{
								
								//t.gameObject.GetComponent<AudioSource>().volume=1;
								this.transform.FindChild(obName).gameObject.GetComponent<AudioSource>().Play();
							}
					}
				

		}
	}
	public  void playSpe2(string obName)
	{
		
		if (!effectOff) 
		{
			foreach (Transform t in this.transform) 
			{
				if (t.name == obName)
				{
					if(t.gameObject.GetComponent<AudioSource>() !=null)
					{
						if(!t.gameObject.GetComponent<AudioSource>().isPlaying)
						{
							
							//t.gameObject.GetComponent<AudioSource>().volume=1;
							t.gameObject.GetComponent<AudioSource>().Play();
						}
					}
				}
			}
		}
	}
	public  void pauseSpe(string obName)
	{
		if (!soundOff) 
		{
			foreach (Transform t in this.transform) 
			{
				if (t.name == obName)
				{
					if(t.gameObject.GetComponent<AudioSource>() !=null)
					{
						if(t.gameObject.GetComponent<AudioSource>().isPlaying)
						{
							t.gameObject.GetComponent<AudioSource>().Stop();
						}
					}
				}
			}
		}
	}
	void pauseAll(){
		foreach (Transform t in this.transform) 
		{
			if(t.gameObject.GetComponent<AudioSource>() !=null)
			{
				if(t.gameObject.GetComponent<AudioSource>().isPlaying)
				{
					t.gameObject.GetComponent<AudioSource>().Stop();
				}
			}
		}
	}
	void pauseAllButBg(){
		foreach (Transform t in this.transform) {
			if (t.name != "bgSound") {
				if (t.gameObject.GetComponent<AudioSource> () != null) {
					if (t.gameObject.GetComponent<AudioSource> ().isPlaying) {
						t.gameObject.GetComponent<AudioSource> ().Stop ();
					}
				}
			}
		}
	}
	public void turnOffSound()
	{
		AudioListener.pause = true;
		soundOff = true;
		changeVolAll (0);
		pauseAll ();
	}
	public void turnOnSound()
	{
		AudioListener.pause = false;
		soundOff = false;
		changeVolAll (1);
		playSpe ("bgSound");
	}
	public void turnOffBg(){
		bgOff = true;
		changeVol ("bgSound", 0);
		pauseSpe ("bgSound");
	}
	public void turnOnBg(){
		bgOff = false;

		changeVol ("bgSound", 1);
		playSpe ("bgSound");
	}
	public void turnOffEffect(){
		effectOff = true;
		changeVolAllButBg (0);
		pauseAllButBg ();

	}
	public void turnOnEffect(){
		effectOff = false;
		changeVolAllButBg (1);
	}
	public  void changeVol(string obName,float vol)
	{
		
		foreach (Transform t in this.transform) 
		{
			if (t.name == obName)
			{
				if(t.gameObject.GetComponent<AudioSource>() !=null)
				{
				t.gameObject.GetComponent<AudioSource>().volume =vol;
				}
			}
		}
	}
	public  void changeVolAll(float vol)
	{
		
		foreach (Transform t in this.transform) 
		{
			if(t.gameObject.GetComponent<AudioSource>() !=null)
			{
				t.gameObject.GetComponent<AudioSource>().volume =vol;
			}
		}
	}
	public  void changeVolAllButBg(float vol)
	{
		
		foreach (Transform t in this.transform) 
		{
			if (t.name != "bgSound") {
			if(t.gameObject.GetComponent<AudioSource>() !=null)
			{
				t.gameObject.GetComponent<AudioSource>().volume =vol;
			}
			}
		}
	}

}
