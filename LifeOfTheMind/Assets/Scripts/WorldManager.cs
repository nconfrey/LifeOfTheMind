using UnityEngine;
using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;

/*
 * Dynamically generates the world upon game startup.
 * Manages all game objects.
 */

public class WorldManager : MonoBehaviour {

	public GameObject[] villagers;
	public GameObject[] terrainSlices;

	private Transform worldHolder;
	private List <Vector3> slicePositions = new List<Vector3>;

	//Create a list with all the positions of terrain slices
	void initializeSlices()
	{
		slicePositions.Clear();
		//these constants are based on the scale of the slices
		List<Vector3> firstQuad = new List<Vector3>;
		firstQuad.Add(new Vector2(11,27));
		firstQuad.Add(new Vector2(25.5,18));
		firstQuad.Add(new Vector2(34,3.4));

		//First Quad
		for(int i = 0; i < 3; i++)
		{
			slicePositions.Add(firstQuad[i]);
		}
		//Second Quad
		for(int i = 0; i < 3; i++)
		{
			slicePositions.Add(firstQuad[i] * -1);
		}
		//Third Quad
		for(int i = 0; i < 3; i++)
		{
			Vector2 n = new Vector2(firstQuad[i].x, firstQuad[i].y *1);
			slicePositions.Add(n);
		}
		//Fourth Quad
		for(int i = 0; i < 3; i++)
		{
			Vector2 n = new Vector2(firstQuad[i].x * -1, firstQuad[i].y);
			slicePositions.Add(n);
		}
	}

	void worldSetup()
	{
		worldHolder = new GameObject ("world").transform;
		for(int j = 1; j <= 12; j++)
		{
			//Choose a random terrain and prepare to instantiate it.
			GameObject toInstantiate = terrainSlices[Random.Range (0,terrainSlices.Length)];
			//Instantiate the GameObject instance using the prefab chosen for toInstantiate at the right location.
			GameObject instance =
				Instantiate (toInstantiate, new Vector3 (x, y, 30 * j), Quaternion.identity) as GameObject;

			//Set the parent of our newly instantiated object instance to boardHolder, this is just organizational to avoid cluttering hierarchy.
			instance.transform.SetParent (worldHolder);
		}
	}

	void addVillager(int xLoc, int yLoc)
	{
		GameObject villagerChoice = villagers[Random.Range(0, villagers.Length())];
		Instantiate (villagerChoice, new Vector3 (xLoc, yLoc, 0), Quaternion.identity);
	}
}
