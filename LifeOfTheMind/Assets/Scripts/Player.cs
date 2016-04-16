using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float Speed = 50;
	public float maxSpeed = 10;
	public float velocity = 0;
	public int direction = 0;

	private Rigidbody2D rb;
	private Transform tr;

	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponent<Rigidbody2D>();
		tr = gameObject.GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		//overrideInput();
		if (Time.realtimeSinceStartup % 10 > 5) {
			rb.AddForce (tr.right * Speed);
		} else {
			rb.AddForce (tr.right * -1 * Speed);	
		}

		//Limiting the speed of the player
		if(rb.velocity.x > maxSpeed)
			rb.velocity = new Vector2(maxSpeed, rb.velocity.y);
	}

	void overrideInput()
	{
		//Moving the player
		float h = Input.GetAxis("Horizontal");
		direction = (int)h;
		rb.AddForce(tr.right * h * Speed);
		velocity = rb.velocity.magnitude;
	}
}
