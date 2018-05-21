using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatAway : MonoBehaviour {

	public Vector3 floatDir;
	public float floatSpeed = 0.1f;
	public bool isActive = false;


	// Use this for initialization
	void Start () {
			
			floatDir = new Vector3(Random.Range(-1f,1f), 1.0f, Random.Range(-1f,1f));
			Debug.DrawRay(transform.position, floatDir);

	}
	
	// Update is called once per frame
	void Update () {

		if(isActive){

			Float();
		}

	}

	void Float(){

		transform.Translate(floatDir * floatSpeed, Space.World);
		transform.Rotate(Random.Range(0,100)*Time.deltaTime,Random.Range(0,100)*Time.deltaTime,Random.Range(0,100)*Time.deltaTime, Space.World);

	}

	public void StartFloat(){
		isActive = true;
	}
}
