using UnityEngine;
using System.Collections;
using System;

public class Camera : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		float arg = Input.GetAxis("Vertical");
		float velocity = Muse.GetVelocityLeftRight();
		if (velocity != 0f) {	// Muse Input
			// Adjust velocity
			velocity = (float)(Math.Sign (velocity) * Math.Log (Math.Abs (velocity)) / 2);
			transform.RotateAround (new Vector3 (0, 0, 0), new Vector3 (0, 0, 1), velocity);
		} else { 				// Keyboard Input
			if(arg == 1)
				//if head is right or up button pressed
			{
				transform.RotateAround (new Vector3 (0, 0, 0), new Vector3 (0, 0, 1), 1);
			}
			else if(arg == -1)
				//if head is left or down button pressed
			{
				transform.RotateAround (new Vector3 (0, 0, 0), new Vector3 (0, 0, 1), -1);
			}
		}
	}
}