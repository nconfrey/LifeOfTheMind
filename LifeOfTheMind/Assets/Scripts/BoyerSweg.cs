using UnityEngine;
using System.Collections;

public class BoyerSweg : MonoBehaviour {

	private BoxCollider2D boxCollider;      
	private Rigidbody2D rb;                           
	private Transform tr;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		tr = GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		//print ("yoo");
		rb.AddForce (tr.right * 10);
	}
}
