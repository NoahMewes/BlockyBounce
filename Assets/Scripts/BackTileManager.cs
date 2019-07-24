using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BackTileManager : MonoBehaviour {

	public GameObject[] tilePrefabs;

	private Transform playerTransform; //Players Transform
	private float spawnX = -90.0f; //What X position the tiles should start spawning
	private float tileLength = 12.5f; //How long each tile is
	private int amnTilesONScreen = 10; //How many tiles can spawn ahead of player
	private float safeZone = 100.0f; //How long behind the player a tile must be before it is deleted
	private int lastPrefabIndex = 0; //Index in array where tile is 
	public int z;

	private List<GameObject> activeTiles;//A list where active tiles are placed


	void Start () {
		activeTiles = new List<GameObject>(); 
		playerTransform = GameObject.FindGameObjectWithTag ("Player").transform;//Sets playerTransform to the players transform
		for (int i = 0; i < amnTilesONScreen; i++) { //Spawns tiles until the cap is reached
				SpawnTile ();
		}
	}

	// Update is called once per frame
	void Update () {
		if (playerTransform.position.x - safeZone > (spawnX - amnTilesONScreen * tileLength)) { //if the players position - safezone is greater than tile spawn point - total length of all tiles ahead of player
			SpawnTile (); //Spawns random tile ahead
			DeleteTile ();//Deletes tile that is furtheset back
		}
	}

	private void SpawnTile(int prefabIndex = -1){
		GameObject go;
		if (prefabIndex == -1) {//Spawns random tile
			go = Instantiate (tilePrefabs [RandomPrefabIndex ()]) as GameObject;
		} else {//Spawns a tile we assign 
			go = Instantiate (tilePrefabs [prefabIndex]) as GameObject;
		}
		go.transform.SetParent (transform);
		go.transform.position = new Vector3(spawnX, 0.0f, z) ;//Places New tile at the spawn point
		spawnX += tileLength;//Moves spawn point forwards
		activeTiles.Add (go);//Adds newest tile to list
	}
	private void DeleteTile(){
		Destroy (activeTiles [0]);//Deletes furthest behind tile 
		activeTiles.RemoveAt (0);//Removes deleted tile from list of active tiles
	}
	private int RandomPrefabIndex(){ //Returns a random prefab index
		if (tilePrefabs.Length <= 1) { //If there is only one tile prefab in the array
			return 0;
		}
		int randomIndex = lastPrefabIndex; //Creates randomIndex and sets it to the index of the last prefab
		while (randomIndex == lastPrefabIndex) { //Runs until the random generator gives us a different index so we don't get two of the same object in a row
			randomIndex = Random.Range (0, tilePrefabs.Length);
		}
		lastPrefabIndex = randomIndex; //Sets the last index into the random index we just got
		return randomIndex;
	}
}
