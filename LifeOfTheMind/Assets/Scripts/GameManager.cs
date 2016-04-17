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
	private List<Villager> villagerList;

	public PlanetGravity planet;

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

		//Setup villager list
		villagerList = new List<Villager> ();
		//this automatically adds itself to be the first in our new list
		//and now automatically instantiates itself
		createNewVillager(5,50);
		//boardScript.addVillager (5,50);

		//Uncomment this when we are ready to generate worlds
		boardScript.worldSetup();
	}

	public void createNewVillager(int xLoc, int yLoc)
	{
		print ("Going to add a villager");
		Villager dude = new Villager(villagers[0]);
		Instantiate (dude.prefab, new Vector3 (xLoc, yLoc, -1), Quaternion.identity);
		villagerList.Add (dude);
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
			createNewVillager (5, 50);
		}
	}
}
