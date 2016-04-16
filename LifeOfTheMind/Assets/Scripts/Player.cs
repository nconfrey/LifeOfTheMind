using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float Speed = 50;
	public float maxSpeed = 10;
	public float velocity = 0;

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
		//Moving the player
		float h = Input.GetAxis("Horizontal");
		rb.AddForce(tr.right * h * Speed);
		velocity = rb.velocity.magnitude;


		//Limiting the speed of the player
		if(rb.velocity.x > maxSpeed)
			rb.velocity = new Vector2(maxSpeed, rb.velocity.y);
	}
}
