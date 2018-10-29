using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed;

	private Rigidbody2D rb2d;

	void Start(){
		rb2d = GetComponent<Rigidbody2D>();
		screenCenter = Camera.main.ViewportToWorldPoint(new Vector3(0.5, 0.5, rb.position.y));
	}

	void FixedUpdate(){
		// float moveHorizontal = Input.GetAxis("Horizontal");
// 		float moveVertical = Input.GetAxis("Vertical");
// 		Vector2 movement = new Vector2(moveHorizontal, moveVertical);
// 		rb2d.AddForce(movement*speed);
		
		Vector3 direction = ( screenCenter - rb.position );
		float distance = Vector3.Distance( screenCenter, rb.position ) ;

		if(distance > Mathf.Epsilon)
			rb.MovePosition(rb.position + speed * direction / distance * Time.deltaTime);
	}

}
