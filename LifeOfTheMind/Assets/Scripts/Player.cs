using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;

public class Player : MonoBehaviour {

	public float Speed = 0.5f;
	public float maxSpeed = 1;
	public float velocity = 0;
	public int direction = 0;
	public bool moving = false;

	private Rigidbody2D rb;
	private Transform tr;
	private Animator animator;
	private float randomSeed;
	private float lastTime;
	private bool lastDirection;

	// Use this for initialization
	void Start () 
	{
		rb = gameObject.GetComponent<Rigidbody2D>();
		tr = gameObject.GetComponent<Transform>();
		animator = GetComponent<Animator>();
		randomSeed = Random.value;
		lastTime = Time.realtimeSinceStartup;
		lastDirection = true;
		print("I have been assigned" + randomSeed);
	}

	void randomWalk()
	{
		if (lastDirection) {
			rb.AddForce (tr.right * Speed);
			animator.SetInteger ("Direction", -1);
		} else {
			rb.AddForce (tr.right * -1 * Speed);
			animator.SetInteger ("Direction", 1);
		}
	}

	// Update is called once per frame
	void Update () 
	{
		//overrideInput();
//		if (Time.realtimeSinceStartup % 15 > 10) {
//			rb.AddForce (tr.right * Speed);
//			animator.SetInteger("Direction",-1);
//		} else if (Time.realtimeSinceStartup % 15 > 5) {
//			rb.AddForce (tr.right * -1 * Speed);
//			animator.SetInteger("Direction",1);
//		} else {
//			//no force
//		}
		//random change in direction
		if (Time.realtimeSinceStartup > lastTime) {
			lastTime += Random.Range (0, 3);
			lastDirection = !lastDirection;
		}
		randomWalk();
		velocity = rb.velocity.magnitude;
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
