using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;

	public BoardManager bMngr;
	private int level = 1;
	public static int public_level;
	private Text levelText;
	public static List<GameObject> activeTiles;

	void Awake() {
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy(gameObject);
		}

		DontDestroyOnLoad(gameObject);
		activeTiles = new List<GameObject>();
		bMngr = GetComponent<BoardManager>();
		InitGame();
	}

	// [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
	// static public void CallbackInitialization()
	// {
	// 		//register the callback to be called everytime the scene is loaded
	// 		SceneManager.sceneLoaded += OnSceneLoaded;
	// }

	//This is called each time a scene is loaded.
	static private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
	{
			instance.level++;
			instance.InitGame();
	}

	void InitGame() {
		public_level = level;

		//Get a reference to our text LevelText's text component by finding it by name and calling GetComponent.
		levelText = GameObject.Find("LevelText").GetComponent<Text>();

		//Set the text of levelText to the string "Day" and append the current level number.
		levelText.text = "Level " + level;

		activeTiles.Clear();

		bMngr.SetupScene(level);
	}

	// Update is called once per frame
	void Update () {

	}

	private void restartLevel() {
		 SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
		 ColliderScript.restart = false;
	}
}
