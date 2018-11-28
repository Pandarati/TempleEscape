using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BoardManager : MonoBehaviour {

	// Use this for initialization
	[System.Serializable]
	public class Count
	{
		public int min;
		public int max;

		public Count(int minimum, int maximum) {
			min = minimum;
			max = maximum;
		}
	}

	public int cols = 6;
	public int rows = 6;

	public GameObject xtile;
	public GameObject htile;
	public GameObject blank;
	public GameObject borderTile;
	public GameObject exit;
	public GameObject player;
	public GameObject tracker;

	private Transform boardHolder;
	private List<Vector3> gridPositions = new List<Vector3>();

	void InitialiseList() {
		gridPositions.Clear();

		for (int x = 1; x < cols - 1; x++) {
			for (int y = 1; y < rows - 1; y++) {
				gridPositions.Add(new Vector3(x,y,0f));
			}
		}
	}

	void BoardSetup() {
		boardHolder = new GameObject ("Board").transform;
		if (GameManager.public_level == 3) {
			for (int x = -1; x < cols + 1; x++) {
				char prev = 'x';
				for (int y = -1; y < rows + 1; y++) {
					GameObject toInstantiate;
					Debug.Log(prev);
					if (prev == 'h') {
							toInstantiate = xtile;
							prev = 'x';
					} else {
						toInstantiate = htile;
						prev = 'h';
					}

					if(x == -1 || x == cols || y == -1 || y == rows){
						toInstantiate = borderTile;
					}

					if ( x == 0 && y == -1) {
						toInstantiate = blank;
					}

					GameObject instance = Instantiate (toInstantiate, new Vector3 (x, y, 0f), Quaternion.identity) as GameObject;
					instance.transform.SetParent(boardHolder);
				}
			}
		}

		if (GameManager.public_level == 5) {
			for (int x = -1; x < cols + 1; x++) {
				char prev = 'x';
				for (int y = -1; y < rows + 1; y++) {
					GameObject toInstantiate = htile;
					if (prev == 'h') {
							toInstantiate = xtile;
							prev = 'x';
					} else {
						toInstantiate = htile;
						prev = 'h';
					}

					if ((x == 1 && y == 1) || (x == 0 && y == 2)) {
						toInstantiate = xtile;
					}

					if (y == 4 && x == 5) {
						toInstantiate = htile;
					}

					if(x == -1 || x == cols || y == -1 || y == rows){
						toInstantiate = borderTile;
					}

					if ( x == 0 && y == -1) {
						toInstantiate = blank;
					}

					GameObject instance = Instantiate (toInstantiate, new Vector3 (x, y, 0f), Quaternion.identity) as GameObject;
					instance.transform.SetParent(boardHolder);
				}
			}
		}

		if (GameManager.public_level == 1) {
			for (int x = -1; x < cols + 1; x++) {
				char prev = 'x';
				for (int y = -1; y < rows + 1; y++) {
					GameObject toInstantiate;
					if (prev == 'h') {
							toInstantiate = xtile;
							prev = 'x';
					} else {
						toInstantiate = htile;
						prev = 'h';
					}

					if ((x == 0 && y == 0) || (x == 1 && y == 0) || (x == 3 && y == 0) ||
					(x == 4 && y == 0) || (x == 5 && y == 0) || (x == 0 && y == 1) ||
					(x == 2 && y == 1) || (x == 3 && y == 2) || (x == 0 && y == 4) ||
					(x == 4 && y == 4) || (x == 1 && y == 5) || (x == 2 && y == 5)){
						toInstantiate = xtile;
					}

					if ((x == 2 && y == 0) || (x == 1 && y == 1) || (x == 5 && y == 1) ||
					(x == 0 && y == 2) || (x == 2 && y == 2) || (x == 5 && y == 2) ||
					(x == 0 && y == 3) || (x == 3 && y == 3) || (x == 4 && y == 3) ||
					(x == 5 && y == 3) || (x == 5 && y == 4) || (x == 0 && y == 5) ||
					(x == 3 && y == 5) || (x == 4 && y == 5)) {
						toInstantiate = htile;
					}

					if(x == -1 || x == cols || y == -1 || y == rows){
						toInstantiate = borderTile;
					}

					if ( x == 0 && y == -1) {
						toInstantiate = blank;
					}

					GameObject instance = Instantiate (toInstantiate, new Vector3 (x, y, 0f), Quaternion.identity) as GameObject;
					instance.transform.SetParent(boardHolder);
				}
			}
		}

		if (GameManager.public_level == 2) {
			for (int x = -1; x < cols + 1; x++) {
				char prev = 'x';
				for (int y = -1; y < rows + 1; y++) {
					GameObject toInstantiate;
					if (prev == 'h') {
							toInstantiate = xtile;
							prev = 'x';
					} else {
						toInstantiate = htile;
						prev = 'h';
					}

					if ((x == 3 && y == 0) || (x == 4 && y == 0) || (x == 5 && y == 0) ||
					(x == 0 && y == 1) || (x == 2 && y == 1) || (x == 4 && y == 1) ||
					(x == 1 && y == 2) || (x == 3 && y == 2) || (x == 4 && y == 2) ||
					(x == 5 && y == 2) || (x == 0 && y == 3) || (x == 2 && y == 3) ||
					(x == 0 && y == 4) || (x == 3 && y == 4) || (x == 2 && y == 5) ||
					(x == 4 && y == 5)){
						toInstantiate = xtile;
					}

					if ((x == 0 && y == 0) || (x == 1 && y == 0) || (x == 2 && y == 0) ||
					(x == 1 && y == 1) || (x == 3 && y == 1) || (x == 5 && y == 1) ||
					(x == 0 && y == 2) || (x == 1 && y == 3) || (x == 3 && y == 3) ||
					(x == 5 && y == 3) || (x == 1 && y == 4) || (x == 5 && y == 4) ||
					(x == 0 && y == 5) || (x == 1 && y == 5) || (x == 3 && y == 5)) {
						toInstantiate = htile;
					}

					if(x == -1 || x == cols || y == -1 || y == rows){
						toInstantiate = borderTile;
					}

					if ( x == 0 && y == -1) {
						toInstantiate = blank;
					}

					GameObject instance = Instantiate (toInstantiate, new Vector3 (x, y, 0f), Quaternion.identity) as GameObject;
					instance.transform.SetParent(boardHolder);
				}
			}
		}

		if (GameManager.public_level == 4) {
			for (int x = -1; x < cols + 1; x++) {
				for (int y = -1; y < rows + 1; y++) {
					GameObject toInstantiate;

					if ((x == 0 && y == 0) || (x == 2 && y == 0) || (x == 3 && y == 1) ||
					(x == 5 && y == 1) || (x == 0 && y == 2) || (x == 2 && y == 2) ||
					(x == 4 && y == 2) || (x == 1 && y == 3) || (x == 0 && y == 4) ||
					(x == 4 && y == 4) || (x == 1 && y == 5) || (x == 3 && y == 5)) {
						toInstantiate = htile;
					} else {
						toInstantiate = xtile;
					}

					if(x == -1 || x == cols || y == -1 || y == rows){
						toInstantiate = borderTile;
					}

					if ( x == 0 && y == -1) {
						toInstantiate = blank;
					}

					GameObject instance = Instantiate (toInstantiate, new Vector3 (x, y, 0f), Quaternion.identity) as GameObject;
					instance.transform.SetParent(boardHolder);
				}
			}
		}

	}

	Vector3 RandomPosition() {
		int randomIndex = Random.Range(0, gridPositions.Count);
		Vector3 RandomPosition = gridPositions[randomIndex];
		gridPositions.RemoveAt(randomIndex);
		return RandomPosition;
	}

	void LayoutObjectAtRandom(GameObject xTile, int min, int max) {
		int objectCount = Random.Range(min, max + 1);
		for (int i = 0; i < objectCount; i++) {
			Vector3 randomPosition = RandomPosition();
			GameObject tileChoice = xTile;
			Instantiate(tileChoice, randomPosition, Quaternion.identity);
		}
	}

	public void SetupScene(int level) {
		BoardSetup();
		InitialiseList();
		// LayoutObjectAtRandom(xtile, 3, 3);
		// LayoutObjectAtRandom(htile, 3, 3);
		Instantiate (exit, new Vector3 (cols - 1, rows - 1, 0f), Quaternion.identity);
		Instantiate (player, new Vector3 (0f,-0.8f,0f), Quaternion.identity);
		Instantiate (tracker, new Vector3 (-0f,-1f,-2f), Quaternion.identity);

	}

	// public void ResetBoard() {
	//
	// 	List<GameObject> xtiles = new List<GameObject>();
	// 	List<GameObject> htiles = new List<GameObject>();
	//
	// 	xtiles.AddRange(GameObject.FindGameObjectsWithTag("xtile"));
	// 	htiles.AddRange(GameObject.FindGameObjectsWithTag("htile"));
	// 	// GameObject xtile = GameObject.FindWithTag("xtile");;
	// 	// GameObject htile = GameObject.FindWithTag("htile");;
	//
	// 	int xCount = xtiles.Count;
	// 	int hCount = htiles.Count;
	//
	// 	Destroy(GameObject.Find("xtile"));
	// 	Destroy(GameObject.Find("htile"));
	//
	// 	for (int i = 0; i < xCount; i++) {
	// 					Instantiate(xtile, xtiles[i].transform.position, xtiles[i].transform.rotation);
	// 	}
	//
	// 	for (int i = 0; i < hCount; i++) {
	// 					Instantiate(htile, htiles[i].transform.position, htiles[i].transform.rotation);
	// 	}
	//
	// 	GameObject.Find("Player").transform.position = new Vector3(0f, 0.2f, 0f);
	// }
}
