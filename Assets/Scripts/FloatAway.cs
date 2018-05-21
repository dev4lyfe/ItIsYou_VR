using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRStandardAssets.Utils;

public class FloatAway : MonoBehaviour {

	public Vector3 floatDir;
	public float floatSpeed = 0.1f;
	public bool isActive = false;
	public List<AudioClip> sounds = new List<AudioClip>(7); 
	AudioSource soundSource;

	


	// Use this for initialization
	void Awake () {
			
			floatDir = new Vector3(Random.Range(-1f,1f), 1.0f, Random.Range(-1f,1f));

			soundSource = gameObject.GetComponent<AudioSource>();

			VRInteractiveItem tempItem = gameObject.AddComponent<VRInteractiveItem>();
			VRInteractiveItemEvent tempEvent = gameObject.AddComponent<VRInteractiveItemEvent>();

			tempEvent.m_InteractiveItem = tempItem;
			tempEvent.FixOverEvents();

			tempEvent.OnTimedOver.AddListener(StartFloat);

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
		soundSource.Play();

	}

	void StartFloat(){
		isActive = true;
	}
}
