using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColliderScript : MonoBehaviour {

	public Color original;
	public static bool restart;
	private BoardManager mngr;

	// Use this for initialization
	void Start () {
			original = GetComponent<Renderer>().material.color;
			restart = false;
	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D collision){
				if (gameObject.tag == "xtile"){
					Debug.Log("Stepped on *");
        }

        if (gameObject.tag == "htile"){
					Debug.Log("Stepped on #");
        }
				Debug.Log(Movement.prev_move);
				Debug.Log(Movement.move);
				Debug.Log(Movement.steps.Count);
				if (GetComponent<Renderer>().material.color == Color.cyan){
					if (Movement.move == Movement.prev_move){
						// mngr = GetComponent<BoardManager>();
						// mngr.ResetBoard();
						SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
						// restart = true;
					}
				} else {
					GetComponent<Renderer>().material.color = Color.cyan;
				}
    }

		void OnTriggerExit2D(Collider2D collision){
					if (GetComponent<Renderer>().material.color == Color.cyan){
						if (Movement.move == KeyCode.None) {
							GetComponent<Renderer>().material.color = original;
						}
					}
	  }
}
