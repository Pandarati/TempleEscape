using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;

	public  BoardManager bMngr;
	private int level = 1;

	void Awake() {
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy(gameObject);
		}

		DontDestroyOnLoad(gameObject);
		bMngr = GetComponent<BoardManager>();
		InitGame();
	}

	void InitGame() {
		bMngr.SetupScene(level);
	}

	// Update is called once per frame
	void Update () {

	}
}
