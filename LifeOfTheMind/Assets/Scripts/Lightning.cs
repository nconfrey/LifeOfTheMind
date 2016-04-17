using UnityEngine;
using System.Collections;

public class Lightning : MonoBehaviour {

	private Vector3 hidingPlace = new Vector3(-200,150,1);
	private bool moving = false;
	public float moveTime = 0.1f;           //Time it will take object to move, in seconds.
	private BoxCollider2D boxCollider;      //The BoxCollider2D component attached to this object.
	private Rigidbody2D rb2D;               //The Rigidbody2D component attached to this object.
	private float inverseMoveTime;          //Used to make movement more efficient.

	// Use this for initialization
	void Start () {
		//Get a component reference to this object's BoxCollider2D
		boxCollider = GetComponent <BoxCollider2D> ();

		//Get a component reference to this object's Rigidbody2D
		rb2D = GetComponent <Rigidbody2D> ();

		//By storing the reciprocal of the move time we can use it by multiplying instead of dividing, this is more efficient.
		inverseMoveTime = 1f / moveTime;
	
	}

	public void smite(Vector3 start, Vector3 end)
	{
		moving = true;
		StartCoroutine (SmoothMovement (start, end));
	}

	//Co-routine for moving units from one space to next, takes a parameter end to specify where to move to.
	protected IEnumerator SmoothMovement (Vector3 start, Vector3 end)
	{
		transform.position = start;
		//Calculate the remaining distance to move based on the square magnitude of the difference between current position and end parameter. 
		//Square magnitude is used instead of magnitude because it's computationally cheaper.
		float sqrRemainingDistance = (transform.position - end).sqrMagnitude;

		//While that distance is greater than a very small amount (Epsilon, almost zero):
		while(sqrRemainingDistance > float.Epsilon)
		{
			//Find a new position proportionally closer to the end, based on the moveTime
			Vector3 newPostion = Vector3.MoveTowards(rb2D.position, end, inverseMoveTime * Time.deltaTime);

			//Call MovePosition on attached Rigidbody2D and move it to the calculated position.
			rb2D.MovePosition (newPostion);

			//Recalculate the remaining distance after moving.
			sqrRemainingDistance = (transform.position - end).sqrMagnitude;

			//Return and loop until sqrRemainingDistance is close enough to zero to end the function
			yield return null;
		}
	}



	// Update is called once per frame
	void Update () {
		if (moving) {
			
			moving = false;
		}
	}
}
