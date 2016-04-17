using UnityEngine;
using System;
using System.Collections;

/*
 * Simple Timer Code for Splash Screen
 */

public class SplashScreen : MonoBehaviour {

	void Start (){
	
	}

	void Update(){
		if (Input.GetKeyDown ("space")) {
			Application.LoadLevel (Application.loadedLevel + 1);
		}
	}
}
