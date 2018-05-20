using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DIrectionalAudioListenerVolume : MonoBehaviour {

    public Transform playerCamera;

    AudioSource audioSource;

    float hardZone = 0.1f;
    float softZone = 0.6f;

	void Start () {
        audioSource = GetComponent<AudioSource>();
	}
	
	void Update () {
        Vector3 dir = (transform.position - playerCamera.transform.position).normalized;
        Vector3 viewDirection = playerCamera.forward;

        Debug.DrawRay(playerCamera.position, dir * 3f, Color.green);
        Debug.DrawRay(playerCamera.position, viewDirection * 3f, Color.red);

        float dot = Vector3.Dot(dir, viewDirection);
		//Debug.LogError("Dot: " + dot);
        if(dot > 1f - hardZone) {
            audioSource.volume = 1f;
        } else if(dot > 1f - softZone) {
            //Debug.LogError(Mathf.InverseLerp(1f - softZone, 1f - hardZone, dot));
            audioSource.volume = Mathf.InverseLerp(1f - softZone, 1f - hardZone, dot);
        } else {
			audioSource.volume = 0f;
        }

	}
}
