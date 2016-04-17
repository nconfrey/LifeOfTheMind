using UnityEngine;
using System;
using System.Collections;

/*
 * Simple Timer Code for Load Screen
 */

public class LoadLevel : MonoBehaviour {

	public float delayTime = 5; 

	IEnumerator Start (){
	
		yield return new WaitForSeconds (delayTime);

		Application.LoadLevel(Application.loadedLevel + 1);
	}
}
