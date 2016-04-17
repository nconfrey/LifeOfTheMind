using UnityEngine;
using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;

/*
 * Dynamically generates the world upon game startup.
 * Manages all game objects.
 */

public class WorldManager : MonoBehaviour {

	public GameObject[] terrainSlices;

	private Transform worldHolder;
	private List <Vector3> slicePositions = new List<Vector3>();

	//Create a list with all the positions of terrain slices
	void initializeSlices()
	{
		slicePositions.Clear();
		//these constants are based on the scale of the slices
		List<Vector3> firstQuad = new List<Vector3>();
		firstQuad.Add(new Vector2(11.0f,27.0f));
		firstQuad.Add(new Vector2(25.5f,18.0f));
		firstQuad.Add(new Vector2(34f,3.4f));

		//First Quad
		for(int i = 0; i < 3; i++)
		{
			slicePositions.Add(firstQuad[i]);
		}
		//Second Quad
		for(int i = 0; i < 3; i++)
		{
			Vector2 n = new Vector2(firstQuad[i].x, firstQuad[i].y * -1);
			slicePositions.Add(n);
		}
		//Third Quad
		for(int i = 0; i < 3; i++)
		{
			slicePositions.Add(firstQuad[i] * -1);
		}

		//Fourth Quad
		for(int i = 0; i < 3; i++)
		{
			Vector2 n = new Vector2(firstQuad[i].x * -1, firstQuad[i].y);
			slicePositions.Add(n);
		}
		//print (slicePositions.Count);
		//print ("Done creating slice locations");
	}

	public void worldSetup()
	{
		initializeSlices ();
		worldHolder = new GameObject ("world").transform;
		//print ("Created our gameobject transform");
		for(int j = 1; j < 12; j++)
		{
			//Choose a random terrain and prepare to instantiate it.
			GameObject toInstantiate = terrainSlices[Random.Range (0,terrainSlices.Length)];
			//Instantiate the GameObject instance using the prefab chosen for toInstantiate at the right location.
			float x = slicePositions[j].x;
			float y = slicePositions [j].y;
			GameObject instance =
				Instantiate (toInstantiate, new Vector3 (x, y, 0), new Quaternion(0,0,0,0)) as GameObject;
			instance.GetComponent<Transform> ().Rotate (new Vector3 (0, 0, -30 * j));

			//Set the parent of our newly instantiated object instance to boardHolder, this is just organizational to avoid cluttering hierarchy.
			instance.transform.SetParent (worldHolder);
		}
	}
}
