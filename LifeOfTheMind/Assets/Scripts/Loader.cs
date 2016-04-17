using UnityEngine;
using System.Collections;

/*
 * This class just creates our game manager and sound manager on game openning.
 */
public class Loader : MonoBehaviour { 
	public GameObject gameManager;          //GameManager prefab to instantiate.
	public GameObject soundManager;         //SoundManager prefab to instantiate.


	void Awake ()
	{
		//Check if a GameManager has already been assigned to static variable GameManager.instance or if it's still null
		if (GameManager.instance == null)

			//Instantiate gameManager prefab
			Instantiate(gameManager);
		//Uncomment this when we are ready to do sound
		/*
		//Check if a SoundManager has already been assigned to static variable GameManager.instance or if it's still null
		if (SoundManager.instance == null)

			//Instantiate SoundManager prefab
			Instantiate(soundManager);
		*/
	}
}
