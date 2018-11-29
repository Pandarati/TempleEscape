using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;

	public BoardManager bMngr;
	public gameBoardScript dfaMngr;
	private int level = 1;
	public static int public_level;
	private Text levelText;
	private Canvas canvas;
	public static List<GameObject> activeTiles;
	public static GameObject panel;
	public bool replay;
	private int score;

	void Awake() {
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy(gameObject);
		}

		replay = false;
		score = 0;

		DontDestroyOnLoad(gameObject);
		activeTiles = new List<GameObject>();
		bMngr = GetComponent<BoardManager>();
		dfaMngr = GetComponent<gameBoardScript>();
		InitGame();
	}

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
	static public void CallbackInitialization()
	{
			//register the callback to be called everytime the scene is loaded
			SceneManager.sceneLoaded += OnSceneLoaded;
	}

	//This is called each time a scene is loaded.
	static private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
	{
			if (instance.replay) {
				instance.InitGame();
			}else {
				instance.level++;
				instance.score += 100;
				if (instance.level > 5) {
					instance.level = 1;
					instance.score = 0;
				}
				instance.InitGame();
			}
	}

	void InitGame() {
		public_level = level;

		//Get a reference to our text LevelText's text component by finding it by name and calling GetComponent.
		levelText = GameObject.Find("LevelText").GetComponent<Text>();
		//Set the text of levelText to the string "Day" and append the current level number.
		levelText.text = "Level: " + level + "  Score: " + score;

		activeTiles.Clear();

		dfaMngr.initialize();

		bMngr.SetupScene(level);
	}

	void levelFailed() {
		replay = true;
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
		restart.restarting = false;
	}

	// Update is called once per frame
	void Update () {
		if (restart.restarting == true){
			levelFailed();
		}
	}
}
