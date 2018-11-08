using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Gameplan: Have a script file that handles certain type of collisions for
each type of symbol!

Right now this will handle the: "#" symbol!

*/

public class TileCollideDetection : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Debug.Log("I started!");
	}

	// Update is called once per frame
	void Update () {


	}

	void OnTriggerEnter2D(Collider2D other)
     {
				 //Detects when the Sprite goes over a tile
         if (other.gameObject.name == "UFO")
         {
             Debug.Log("Stepped on Tile: #");
         }
     }

		 void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider == true)
        {
					Debug.Log("2nd Detection detected!");
				//	collision.collider.enabled = false;
            Debug.Log("PIzza hut!");
        }
    }

}
