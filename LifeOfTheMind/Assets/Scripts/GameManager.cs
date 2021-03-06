﻿using UnityEngine;
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
	public Lightning lightningMover;

	public GameObject prefabBoyer;
	public GameObject camera;
	public GameObject lightning;

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
		//boardScript.worldSetup();
	}

	public void createNewVillager(int xLoc, int yLoc)
	{
		//print ("Going to add a villager");
		Villager dude = new Villager(villagers[(int)Random.Range(0,3)]);
		GameObject inst = Instantiate (dude.prefab, new Vector3 (xLoc, yLoc, -1), Quaternion.identity) as GameObject;
		villagerList.Add (dude);
	}

	public void spawnBoyer(int x, int y)
	{
		GameObject inst = Instantiate (prefabBoyer, new Vector3 (x, y, -1), Quaternion.identity) as GameObject;

	}

	public void smite()
	{
		lightningMover.smite (new Vector3 ((int)cameraLens.position.x, (int)cameraLens.position.y, -1), 
			new Vector3 ((int)cameraLens.position.x, (int)cameraLens.position.y - 40, -1));
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

		if (Input.GetKeyDown ("space") || (Muse.blinks >= 2)) {
			if (Muse.mood == "studious") {
				spawnBoyer ((int)cameraLens.position.x, (int)cameraLens.position.y);
			} else {
				createNewVillager ((int)cameraLens.position.x, (int)cameraLens.position.y);
			}
		}

		if (Input.GetKeyDown ("s")) {
			smite ();
		}
	}
}
