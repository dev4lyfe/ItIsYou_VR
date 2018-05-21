using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class VRChecker : MonoBehaviour {

	public GameObject mouseController;

	// Use this for initialization
	void Start () {

		if(!XRDevice.isPresent){

			mouseController.SetActive(true);

		}
	}
	// Update is called once per frame
	void Update () {
		
	}
}
