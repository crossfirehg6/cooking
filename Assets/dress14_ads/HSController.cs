using UnityEngine;
using System.Collections;

public class HSController : MonoBehaviour {

	private string secretKey = "mySecretKey"; // Edit this value and make sure it's the same as the one stored on the server
	public string getURL = "http://www.app4girl.com/unity.php";
	public string link;
	public string url;
	public string newURL;
	void Start()
	{
		#if UNITY_ANDROID
		newURL = getURL+"?device=UNITY_ANDROID";
		#endif
		#if UNITY_EDITOR 
		newURL = getURL+"?device=UNITY_EDITOR";
		#endif
		#if UNITY_EDITOR_WIN
		newURL = getURL+"?device=UNITY_EDITOR_WIN";
		#endif
		#if UNITY_IPHONE
		newURL = getURL+"?device=UNITY_IPHONE";
		#endif
		#if		UNITY_WP8
		newURL = getURL+"?device=UNITY_WP8";
		#endif
		StartCoroutine(GetScores());
	}

	void OnMouseDown(){
		Application.OpenURL (link);
	}
	// Get the scores from the MySQL DB to display in a GUIText.
	// remember to use StartCoroutine when calling this function!
	IEnumerator GetScores()
	{

		WWW hs_get = new WWW(newURL);

		Debug.Log("newURL"+newURL);
		yield return hs_get;
		
		if (hs_get.error != null)
		{
			print("There was an error getting the high score: " + hs_get.error);
		}
		else
		{

			string getText = hs_get.text.ToString();
			string[] split = getText.Split('|');
			url		= split[0].Trim();
			link 	= split[1].Trim();
			WWW www = new WWW(url);
			yield return www; 

				Sprite sprite = new Sprite();
//				WaitForSeconds(1f);
				sprite = Sprite.Create(www.texture,new Rect(0, 0, 400, 250),new Vector2(0, 0),50.0f);
				gameObject.GetComponent<SpriteRenderer>().sprite = sprite;

				gameObject.AddComponent<BoxCollider2D>();
				if(gameObject.GetComponent<SpriteRenderer>().sprite.name!=null){
					gameObject.transform.FindChild("close").gameObject.SetActive(true);
					iTween.MoveFrom(GameObject.Find("www"), new Vector3(GameObject.Find("www").transform.position.x,-15f,0f),1f);
				}


		}
	}

}
