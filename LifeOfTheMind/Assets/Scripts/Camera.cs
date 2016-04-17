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
		float speed = (float)Math.Log(Math.Abs(velocity));
		if(velocity > 0.0 || arg == 1)
		//if head is right or up button pressed
		{
			transform.RotateAround (new Vector3 (0, 0, 0), new Vector3 (0, 0, 1), speed);
		}
		else if(velocity < 0.0 || arg == -1)
		//if head is left or down button pressed
		{
			transform.RotateAround (new Vector3 (0, 0, 0), new Vector3 (0, 0, 1), -1f * speed);
		}
	}
}