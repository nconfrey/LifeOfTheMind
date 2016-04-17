using UnityEngine;
using System.Collections.Generic;

/*
 * Top level class for all game logic
 */

public class GameManager : MonoBehaviour {

	public WorldManager worldScript;
	public GameObject[] villagers;

	//This class can be accessed by any other class
	public static GameManager instance = null;
	//Store a reference to set up our board
	private WorldManager boardScript;

	public GameObject prefabBoyer;
	public GameObject camera;

	private List<Villager> villagerList;

	public PlanetGravity planet;

	private Transform cameraLens;

	//Awake is always called before any Start functions
	void Awake()
	{
		//We want this to be the only controller in the game
		//Check if instance already exists
		if (instance == null)
			instance = this;
		else if (instance != this)
		//THERE CAN ONLY BE ONE...
			Destroy(gameObject);    

		//Sets this to not be destroyed when reloading scene
		DontDestroyOnLoad(gameObject);

		//Get a component reference to the attached BoardManager script
		boardScript = GetComponent<WorldManager>();

		cameraLens = camera.GetComponent<Transform> ();

		//Setup villager list
		villagerList = new List<Villager> ();
		//this automatically adds itself to be the first in our new list
		//and now automatically instantiates itself
		createNewVillager(5,50);

		//Uncomment this when we are ready to generate worlds
		boardScript.worldSetup();
	}

	public void createNewVillager(int xLoc, int yLoc)
	{
		print ("Going to add a villager");
		Villager dude = new Villager(villagers[(int)Random.Range(0,3)]);
		Instantiate (dude.prefab, new Vector3 (xLoc, yLoc, -1), Quaternion.identity);
		villagerList.Add (dude);
	}

	public void spawnBoyer(int x, int y)
	{
		Instantiate (prefabBoyer, new Vector3 (x, y, -1), Quaternion.identity);

	}

	void moveVillagers()
	{
		//For now, just keep all villagers moving left
		//I'm sure we'll come up with more logic here soon...
		for (int n = 0; n < villagerList.Count; n++) {
			villagerList [n].MoveLeft ();
		}
	}

	void Update()
	{
		moveVillagers ();

		if (Input.GetKeyDown ("space")) {
			createNewVillager ((int)cameraLens.position.x, (int)cameraLens.position.y);
		}
		if (Input.GetKeyDown ("b")) {
			spawnBoyer ((int)cameraLens.position.x, (int)cameraLens.position.y);
		}
	}
}
