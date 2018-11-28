using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class restart : MonoBehaviour {

	public static bool restarting;

	// Use this for initialization
	void Start () {
		restarting = false;
	}

	// Update is called once per frame
	void Update () {

	}

	public void restartgame() {
		restarting = true;
	}
}
