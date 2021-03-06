﻿using UnityEngine;
using System.Collections;

public class HideAndroidButtons : MonoBehaviour
{
	#if UNITY_ANDROID && !UNITY_EDITOR
	const int SYSTEM_UI_FLAG_IMMERSIVE_STICKY = 4096;
	const int SYSTEM_UI_FLAG_HIDE_NAVIGATION = 2;
	const int SYSTEM_UI_FLAG_FULLSCREEN = 4;
	
	AndroidJavaObject decorView;
	
	void Start()
	{
		AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		AndroidJavaObject activity = jc.GetStatic<AndroidJavaObject>("currentActivity");
		AndroidJavaObject window = activity.Call<AndroidJavaObject>("getWindow");
		decorView = window.Call<AndroidJavaObject>("getDecorView");
		
		TurnImmersiveModeOn();
		GameObject hide_android_navigator = GameObject.Find("hide_android_navigator").gameObject;
		DontDestroyOnLoad (hide_android_navigator);
	}
	void OnApplicationFocus(bool focusStatus) {
		if(focusStatus){
			TurnImmersiveModeOn();
		}
	}
	void TurnImmersiveModeOn()
	{
		decorView.Call("setSystemUiVisibility", SYSTEM_UI_FLAG_FULLSCREEN | SYSTEM_UI_FLAG_HIDE_NAVIGATION | SYSTEM_UI_FLAG_IMMERSIVE_STICKY);
	}
	void OnDestroy()
	{
		decorView.Dispose();
	}
	
	#endif
}