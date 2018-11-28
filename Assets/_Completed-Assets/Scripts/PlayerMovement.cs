using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	  // private Dice dice;
    // public GameObject diceObj;
    // public float speed;
    // public int i = 0;
    // public Transform[] wayPoint;
    // public int targetWaypoint;
		//
    // bool asd = true;
		//
		//
    // // Use this for initialization
    // void Start () {
		//
    //     dice = diceObj.GetComponent<Dice>();
    // }
		//
    // // Update is called once per frame
    // void Update () {
		//
    //     Vector3 target = wayPoint[i].position;
    //     float maxDist = speed * Time.deltaTime;
		//
    //     if(transform.position == target){
    //         i++;
    //     }
		//
    //     if(i == wayPoint.Length){
    //         i = 0;
    //     }
		//
		//
    //     if(true){
		// 			transform.position = Vector3.MoveTowards(transform.position, target, maxDist);
		// 		}
		//
    //     transform.LookAt(target);
    //     Debug.Log(dice.steps);
    // }

		float playerSpeed = 5.0f;
     void Start ()
     {
         transform.position = new Vector3 (-3, 3, -2);
     }
     void Update ()
     {
			 if (Input.GetKeyDown(KeyCode.LeftArrow))
			 {
					 Vector3.Lerp(transform.position, transform.position += new Vector3(-2,0,0) , playerSpeed);
			 }
			 if (Input.GetKeyDown(KeyCode.RightArrow))
			 {
					 transform.position += new Vector3(2,0,0);
			 }
     }
}
