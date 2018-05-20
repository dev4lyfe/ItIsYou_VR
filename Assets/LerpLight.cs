using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpLight : MonoBehaviour {

	public float startIntensity;
	public float endInstenity;
	public float lerpDuration;
	float lerpVal;
	public Light lightToModify;


	bool isLerping;

	public void StartLerp()
	{
		
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (isLerping) {
			lerpVal += Time.deltaTime;
			lightToModify.intensity = lerpVal/lerpDuration;
		}
	}
}
