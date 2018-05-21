using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonRigidPlankManager : MonoBehaviour {

	public List<AudioClip> sounds = new List<AudioClip>(11); 
	FloatAway[] planks;

	// Use this for initialization
	void Start () {

		for(int i =0; i<planks.Length;i++){
			int index = Random.Range(0, sounds.Count);

			planks[i].GetComponent<AudioSource>().clip = sounds[index];

		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
