using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	float playerSpeed = 5.0f;
	public GameObject player;
	public static KeyCode move;
	public static KeyCode prev_move;
	public static List<KeyCode> steps;
	private bool badmove;

	 void Start ()
	 {
			 transform.position = player.transform.position;

			 steps = new List<KeyCode>();
			 badmove = false;
	 }

	 void Update()
    {
        if (Input.anyKeyDown)
        {
					if (Input.GetKeyDown(KeyCode.LeftArrow)) {
						 move = KeyCode.LeftArrow;
						 Debug.Log(move);
						 Vector3.Lerp(transform.position, transform.position += new Vector3(-1,0,0) , playerSpeed);
				 }else if (Input.GetKeyDown(KeyCode.RightArrow)){
						 move = KeyCode.RightArrow;
						 transform.position += new Vector3(1,0,0);
				 }else if (Input.GetKeyDown(KeyCode.UpArrow)){
						 move = KeyCode.UpArrow;
						 transform.position += new Vector3(0,1,0);
				 } else if (Input.GetKeyDown(KeyCode.DownArrow)){
						 move = KeyCode.DownArrow;
						 transform.position += new Vector3(0,-1,0);
				 }

				 if ((prev_move == KeyCode.LeftArrow &&  move == KeyCode.RightArrow) ||
				 (move == KeyCode.LeftArrow &&  prev_move == KeyCode.RightArrow) ||
				 (prev_move == KeyCode.UpArrow &&  move == KeyCode.DownArrow) ||
				 (move == KeyCode.UpArrow &&  prev_move == KeyCode.DownArrow)) {
					 steps.RemoveAt(steps.Count - 1);
					 if (steps.Count > 0){
						 prev_move = steps[steps.Count - 1];
					 }
					 move = KeyCode.None;
					 // if (steps.Count == 1){
						//  steps.Clear();
					 // }
					 // Debug.Log(prev_move);
					 // Debug.Log(steps.Count);
				 } else {
					 // if (steps.Count == 0) {
						//  steps.Add(move);
						//  steps.Add(move);
					 // } else {
						//  steps.Add(move);
					 // }
					 steps.Add(move);
					 prev_move = move;
					 // Debug.Log(prev_move);
					 // Debug.Log(move);
				 }

        }
    }
}
