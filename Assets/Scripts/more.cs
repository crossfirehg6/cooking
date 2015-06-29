using UnityEngine;
using System.Collections;

public class more : MonoBehaviour {
	public string URL;
	// Use this for initialization
	void Start () {
		URL="http://redirect.app4girl.com/com.app4girl.aliciainjuredkitty";
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnMouseDown(){
		#if UNITY_ANDROID
		Application.OpenURL (URL+"&device=UNITY_ANDROID");
		#endif
		
		#if UNITY_EDITOR 
		Application.OpenURL (URL+"&device=UNITY_EDITOR");
		#endif
		#if UNITY_EDITOR_WIN
		Application.OpenURL (URL+"&device=UNITY_EDITOR_WIN");
		#endif
		
		#if UNITY_IPHONE
		Application.OpenURL (URL+"&device=UNITY_IPHONE");
		#endif
		
		#if		UNITY_WP8
		Application.OpenURL (URL+"&device=UNITY_WP8");
		#endif
		
		#if		UNITY_EDITOR_WIN
		Application.OpenURL (URL+"&device=UNITY_EDITOR_WIN");
		#endif
		
		#if		UNITY_EDITOR_OSX
		Application.OpenURL (URL+"&device=UNITY_EDITOR_OSX");
		#endif
		
		#if		UNITY_STANDALONE_OSX
		Application.OpenURL (URL+"&device=UNITY_STANDALONE_OSX");
		#endif
		
		#if		UNITY_DASHBOARD_WIDGET
		Application.OpenURL (URL+"&device=UNITY_DASHBOARD_WIDGET");
		#endif
		
		#if		UNITY_STANDALONE_WIN
		Application.OpenURL (URL+"&device=UNITY_STANDALONE_WIN");
		#endif
		
		#if		UNITY_STANDALONE_LINUX
		Application.OpenURL (URL+"&device=UNITY_STANDALONE_LINUX");
		#endif
		#if		UNITY_STANDALONE
		Application.OpenURL (URL+"&device=UNITY_STANDALONE");
		#endif
		#if		UNITY_WEBPLAYER
		Application.OpenURL (URL+"&device=UNITY_WEBPLAYER");
		#endif
		#if		UNITY_WII
		Application.OpenURL (URL+"&device=UNITY_WII");
		#endif
		#if		UNITY_PS3
		Application.OpenURL (URL+"&device=UNITY_PS3");
		#endif
		#if		UNITY_XBOX360
		Application.OpenURL (URL+"&device=UNITY_XBOX360");
		#endif
		#if		UNITY_FLASH
		Application.OpenURL (URL+"&device=UNITY_FLASH");
		#endif
		#if		UNITY_BLACKBERRY
		Application.OpenURL (URL+"&device=UNITY_BLACKBERRY");
		#endif
		#if		UNITY_METRO
		Application.OpenURL (URL+"&device=UNITY_METRO");
		#endif
		#if		UNITY_WINRT
		Application.OpenURL (URL+"&device=UNITY_WINRT");
		#endif
		
		
	}
}
