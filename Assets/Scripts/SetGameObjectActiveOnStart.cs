using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetGameObjectActiveOnStart : MonoBehaviour {

	public bool active = false;

	[Header("If null will use itself")]
	public GameObject target;

	void Start () {
		if (target == null)
			gameObject.SetActive (active);
		else
			target.SetActive (active);
	}
}
