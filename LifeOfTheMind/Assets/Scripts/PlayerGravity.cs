using UnityEngine;
using System.Collections;

public class PlayerGravity : MonoBehaviour {

	public PlanetGravity attractor;
	private Transform myTransform;

	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
		GetComponent<Rigidbody2D>().gravityScale = 0;
		myTransform = transform;
	
	}
	
	// Update is called once per frame
	void Update () {
		attractor.Attract (myTransform);
	}
}
