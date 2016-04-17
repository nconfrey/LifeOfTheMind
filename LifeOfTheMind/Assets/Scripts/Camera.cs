using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		float arg = Input.GetAxis("Vertical");
		if(arg == 1)
		{
			transform.RotateAround (new Vector3 (0, 0, 0), new Vector3 (0, 0, 1), 1);
			//rb.AddTorque(50);
		}
		else if(arg == -1)
		{
			transform.RotateAround (new Vector3 (0, 0, 0), new Vector3 (0, 0, 1), -1);
		}
	}
}
