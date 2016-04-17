using UnityEngine;
using System.Collections;

public class Sky : MonoBehaviour {

	public Sprite background_night;
	public Sprite background_day;
	private SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer>();
		spriteRenderer.sprite = background_day; 

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			Sprite currentSprite = spriteRenderer.sprite;
			if (currentSprite == background_day) {
				spriteRenderer.sprite = background_night;
			} else {
				spriteRenderer.sprite = background_day;
			}
		}
	}
}
