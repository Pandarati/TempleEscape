using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class collisionScript : MonoBehaviour {

	public static bool keyEnabled;
	public static bool hitExit;
	public static bool success;

	// Use this for initialization
	void Start () {
		keyEnabled = true;
		hitExit = false;
		success = false;
	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("exit");

				if (col.gameObject.tag == "PickUp") {
					hitExit = true;
					Movement.inputEnabled = false;
				} else if (col.gameObject.tag == "Player"){
					//level won and load next one
					SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
				}
    }
}
