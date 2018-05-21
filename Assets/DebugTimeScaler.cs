using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugTimeScaler : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	bool changedTimeScale = false;

	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Q)) {
			Time.timeScale = 2f;
			changedTimeScale = true;
		} else if (Input.GetKey (KeyCode.W)) {
			Time.timeScale = 3f;
			changedTimeScale = true;
		} else if (Input.GetKey (KeyCode.E)) {
			Time.timeScale = 10f;
			changedTimeScale = true;
		} else if(changedTimeScale) {
			changedTimeScale = false;
			Time.timeScale = 1f;
		}
	}
}
