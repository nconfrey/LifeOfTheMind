using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		float arg = Input.GetAxis("Vertical");
		print ("about to access muse");
		if(Muse.acc_x > 0 || arg == 1)
		//if head is right or up button pressed
		{
			transform.RotateAround (new Vector3 (0, 0, 0), new Vector3 (0, 0, 1), 1);
			//rb.AddTorque(50);
		}
		else if(Muse.acc_x < 0 || arg == -1)
		//if head is left or down button pressed
		{
			transform.RotateAround (new Vector3 (0, 0, 0), new Vector3 (0, 0, 1), -1);
		}
	}
}
