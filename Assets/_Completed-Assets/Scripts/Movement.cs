using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	float playerSpeed = 5.0f;
	public GameObject player;

	 void Start ()
	 {
			 transform.position = player.transform.position;
	 }
	 void Update ()
	 {
		 if (Input.GetKeyDown(KeyCode.LeftArrow))
		 {
				 Vector3.Lerp(transform.position, transform.position += new Vector3(-1,0,0) , playerSpeed);
		 }
		 if (Input.GetKeyDown(KeyCode.RightArrow))
		 {
				 transform.position += new Vector3(1,0,0);
		 }
		 if (Input.GetKeyDown(KeyCode.UpArrow))
		 {
				 transform.position += new Vector3(0,1,0);
		 }
		 if (Input.GetKeyDown(KeyCode.DownArrow))
		 {
				 transform.position += new Vector3(0,-1,0);
		 }
	 }
}
