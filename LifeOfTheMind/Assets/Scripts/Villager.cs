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
		prefab = ani;
	}
	//Called on a new villager spawn
	void Start () 
	{
		boxCollider = prefab.GetComponent <BoxCollider2D> ();
		rb = prefab.GetComponent <Rigidbody2D> ();
		animator = prefab.GetComponent<Animator> ();
		inverseMoveTime = 1f / moveTime;
	}

	public void MoveLeft()
	{
		//rb.AddForce (tr.right * Speed);
		//animator.SetInteger("Direction",-1);
	}

	public void MoveRight()
	{
		//rb.AddForce (tr.right * -1 * Speed);
		//animator.SetInteger("Direction",1);
	}
}
