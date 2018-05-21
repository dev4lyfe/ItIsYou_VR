using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GramophonePivotRotation : MonoBehaviour {

	public float maxedSpeed = 10f;
	public float startSpeed = 1f;
	public float timeTillMaxedSpeed = 0.5f;
	private bool roateActive = false;


	public void StartRotation(){
		roateActive = true;
	}

	public void EndRotation(){
		roateActive = false;
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (roateActive) {
			transform.Rotate (Vector3.right, (Mathf.LerpAngle (startSpeed, maxedSpeed, timeTillMaxedSpeed * Time.deltaTime)));
		}

	}

}
