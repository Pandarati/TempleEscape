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

	public int cols = 8;
	public int rows = 8;

	public GameObject xtile;
	public GameObject htile;
	public GameObject borderTile;
	public GameObject exit;
	public GameObject player;

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
		for (int x = -1; x < cols + 1; x++) {
			for (int y = -1; y < rows + 1; y++) {
				GameObject toInstantiate = htile;

				if(x == -1 || x == cols || y == -1 || y == rows){
					toInstantiate = borderTile;
				}

				GameObject instance = Instantiate (toInstantiate, new Vector3 (x, y, 0f), Quaternion.identity) as GameObject;
				instance.transform.SetParent(boardHolder);
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
		LayoutObjectAtRandom(xtile, 3, 3);
		LayoutObjectAtRandom(htile, 3, 3);
		Instantiate (exit, new Vector3 (cols - 1, rows - 1, 0f), Quaternion.identity);
		Instantiate (player, new Vector3 (0f,0.2f,0f), Quaternion.identity);

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
