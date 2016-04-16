using UnityEngine;
using System.Collections;

public class Planet : MonoBehaviour {

	public Rigidbody2D rb;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		float arg = Input.GetAxis("Vertical");
		if(arg == 1)
		{
			transform.Rotate(Vector3.forward);
			//rb.AddTorque(50);
		}
		else if(arg == -1)
		{
			transform.Rotate(Vector3.forward * -1);
		}
		
	
	}
}
