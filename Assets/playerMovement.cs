using UnityEngine;

public class playerMovement : MonoBehaviour
{
    // void Update()
    // {
    //     var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
    //     var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;
		//
    //     transform.Rotate(0, x, 0);
    //     transform.Translate(0, 0, z);
    // }

		public float speed;

		void Update(){
     if(Input.GetKey(KeyCode.UpArrow)){
         move(Vector2.up * Time.deltaTime);
     }else if(Input.GetKey(KeyCode.DownArrow)){
         move (Vector2.down * Time.deltaTime);
     } else if (Input.GetKey(KeyCode.LeftArrow)) {
			 	 move (Vector2.left * Time.deltaTime);
		 } else if (Input.GetKey(KeyCode.RightArrow)){
			 	 move (Vector2.right * Time.deltaTime);
		 }
 }

 void move(Vector2 direction)
 {
		 transform.Translate (direction * speed);
 }
}
