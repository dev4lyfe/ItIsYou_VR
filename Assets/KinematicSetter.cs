using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinematicSetter : MonoBehaviour {

	// Use this for initialization
	void OnEnable () {
		SetKinematic (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetKinematic(bool on)
	{
		foreach (Rigidbody x in GetComponentsInChildren<Rigidbody>()) {
			x.gameObject.GetComponent<Collider> ().enabled = on;
		}
	}
}
