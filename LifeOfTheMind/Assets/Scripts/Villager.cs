using UnityEngine;
using System.Collections;

public class Villager : MonoBehaviour {

	private BoxCollider2D boxCollider;      
	private Rigidbody2D rb;               
	private float inverseMoveTime;          //Used to make movement more efficient.
	private Animator animator;              
	private Transform tr;					//This holds all location information
	public float moveTime = 0.1f;           //Time it will take object to move, in seconds.
	public GameObject prefab;
	public float Speed = 10f;

	public Villager(GameObject ani)
	{
		print ("New creation of villager");
		prefab = ani;
	}
	//Called on a new villager spawn
	void Start () 
	{
		print ("Called start method");
		boxCollider = prefab.GetComponent <BoxCollider2D> ();
		rb = GetComponent <Rigidbody2D> ();
		tr = GetComponent <Transform> ();
		if (rb == null) {
			print ("This is where the bad happens");

		}
		animator = prefab.GetComponent<Animator> ();
		inverseMoveTime = 1f / moveTime;
	}

	public void MoveLeft()
	{
		//if (rb == null)
		//	print ("ugh");
		//rb.AddForce (Vector2.right * Speed);
		//animator.SetInteger("Direction",-1);
	}

	public void MoveRight()
	{
		rb.AddForce (tr.right * -1 * Speed);
		animator.SetInteger("Direction",1);
	}
}
