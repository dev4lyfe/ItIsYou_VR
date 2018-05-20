using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{
	public Transform camTransform;

	public float shakeDuration;

	public float shakeAmount = 0.7f;

	public float decreaseFactor = 1.0f;

	Vector3 originalPos;

	void Awake()
	{
		if (camTransform == null) {
			camTransform = GetComponent<Transform> ();
		}
	}

	public void Shake()
	{
		shakeDuration = .1f;
	}

	void OnEnable(){
		originalPos = camTransform.localPosition;
	}

	void Update()
	{
		if (shakeDuration > 0) {
			camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;
			shakeDuration -= Time.deltaTime * decreaseFactor;
		} else {
			shakeDuration = 0f;
			camTransform.localPosition = originalPos;
		}
	}
}