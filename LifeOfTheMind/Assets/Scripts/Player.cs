using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float Speed = 10;
	public float maxSpeed = 10;
	public float velocity = 0;
	public int direction = 0;
	public bool moving = false;

	private Rigidbody2D rb;
	private Transform tr;
	private Animator animator;

	// Use this for initialization
	void Start () 
	{
		rb = gameObject.GetComponent<Rigidbody2D>();
		tr = gameObject.GetComponent<Transform>();
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		//overrideInput();
		if (Time.realtimeSinceStartup % 15 > 10) {
			rb.AddForce (tr.right * Speed);
			animator.SetInteger("Direction",-1);
		} else if (Time.realtimeSinceStartup % 15 > 5) {
			rb.AddForce (tr.right * -1 * Speed);
			animator.SetInteger("Direction",1);
		} else {
			//no force
		}
		velocity = rb.velocity.magnitude;
		print (velocity);
		if (velocity > 0.01f)
			animator.SetBool ("Moving", true);
		else
			animator.SetBool ("Moving", false);



		//Limiting the speed of the player
		if(rb.velocity.x > maxSpeed)
			rb.velocity = new Vector2(maxSpeed, rb.velocity.y);
		if (rb.velocity.y > maxSpeed)
			rb.velocity = new Vector2 (rb.velocity.x, maxSpeed);
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
