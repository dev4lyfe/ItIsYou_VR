using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractivePlank : MonoBehaviour {

	Vector3 rotateAroundPoint;
	[SerializeField]
	float direction = 1f;
	float speed;

	public bool bIsRotating;
	// Use this for initialization
	void Start () {
		rotateAroundPoint = GameObject.FindGameObjectWithTag ("CenterOfRoom").transform.position;
		speed = Random.Range (.1f, 1f);
	}
	
	// Update is called once per frame
	void Update () {
		if (bIsRotating)
			transform.RotateAround (rotateAroundPoint, Vector3.up, Time.deltaTime * speed * direction);
	}
}
