using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class Movement : MonoBehaviour {

	float playerSpeed = 5.0f;
	public GameObject player;
	private GameObject main_player;
	public static KeyCode move;
	public static KeyCode prev_move;
	public static List<KeyCode> steps;
	public static List<char> characters;
	private bool badmove;
	public static bool inputEnabled;
	private Vector3 start;
	private bool accept;
	private char[] char_array;
	private string input;
	public GameObject panel;
	public static bool restart;

	 void Start ()
	 {
		 	 panel =  GameObject.FindWithTag("Finish");
 			 panel.SetActive(false);
			 transform.position = player.transform.position;
			 main_player =  GameObject.FindWithTag("Player");
			 steps = new List<KeyCode>();
			 badmove = false;
			 inputEnabled = true;
			 accept = false;
			 char_array = new char[40];
			 characters = new List<char>();
			 restart = false;

	 }

	 void Update()
    {
        if (Input.anyKeyDown)
        {
					if (inputEnabled){
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

					 if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow) ||
					 Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow)) {
						 if ((prev_move == KeyCode.LeftArrow &&  move == KeyCode.RightArrow) ||
						 (move == KeyCode.LeftArrow &&  prev_move == KeyCode.RightArrow) ||
						 (prev_move == KeyCode.UpArrow &&  move == KeyCode.DownArrow) ||
						 (move == KeyCode.UpArrow &&  prev_move == KeyCode.DownArrow)) {
							 if (inputEnabled != false) {
								 steps.RemoveAt(steps.Count - 1);
								 characters.RemoveAt(characters.Count - 1);
								 if (steps.Count > 0){
									 prev_move = steps[steps.Count - 1];
								 }
								 move = KeyCode.None;
							 }
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
							 if (inputEnabled != false) {
								 steps.Add(move);
								 prev_move = move;
							 }
							 // Debug.Log(prev_move);
							 // Debug.Log(move);
						 }
					 }
					}
        }

				if (inputEnabled == false) {
					inputEnabled = true;
					characters.RemoveAt(characters.Count - 1);
					char_array = characters.ToArray();
					Debug.Log(characters.Count);
					input = new string(char_array);

					accept = gameBoardScript.mainDFA.executeSteps(gameBoardScript.mainDFA, gameBoardScript.mainDFA.start.name, input, 0);
					if(!accept){
						StartCoroutine(blowup());
					}
					movePlayer();
				}
    }

		void movePlayer() {
			StartCoroutine(movemain());
		}

		IEnumerator movemain()
	   {
	 		for (int i = 0; i < steps.Count; i++)
	 		{
	 			if (steps[i] == KeyCode.LeftArrow) {
	 				Vector3.Lerp(main_player.transform.position, main_player.transform.position += new Vector3(-1,0,0) , playerSpeed);
	 			} else if (steps[i] == KeyCode.RightArrow) {
	 				main_player.transform.position += new Vector3(1,0,0);
	 			} else if (steps[i] == KeyCode.UpArrow){
	 				main_player.transform.position += new Vector3(0,1,0);
	 			} else if (steps[i] == KeyCode.DownArrow){
	 				main_player.transform.position += new Vector3(0,-1,0);
	 			}
	 			 yield return new WaitForSeconds(1);
	 		}
	   }

		 IEnumerator blowup()
 	   {
			 // UnityEngine.Random rnd = new UnityEngine.Random();

			 yield return new WaitForSeconds( Random.Range( 2, 7));
			 StopAllCoroutines();
			 panel.SetActive(true);
 	   }


		//  void GameOver() {
	 	// 	// GameObject instantiate = panel;
	 	// 	// instantiate.transform.SetParent(canvas.transform, false);
	 	// }

}
