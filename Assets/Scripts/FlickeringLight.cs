using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Light))]
public class FlickeringLight : MonoBehaviour {
	Light lt;
	float originalRange;	[Space(10)]

	[Header("Light customization")]
	[Space(10)]
	[SerializeField]
	[Tooltip("The color of your light.")]
	Color lightColor = Color.yellow;

	[SerializeField]
	[Tooltip("The min intensity of your light.")]
	float minIntensity = 8f;
	[SerializeField]
	[Tooltip("The max intensity of your light.")]
	float maxIntensity = 3f;
	[SerializeField]
	[Tooltip("The minimal range of your light (radius).")]
	float minRange = 79f;
	[SerializeField]
	[Tooltip("The maximum range of your light (radius).")]
	float maxRange = 100f;

	void FixedUpdate() {
		lt.intensity = Random.Range(minIntensity, maxIntensity);
		lt.range =  Random.Range(minRange, maxRange);
		lt.color = lightColor;
	}


	Vector3 StartingPosition;
	Vector3 NextPosition;
	Vector3 LastPosition;
	float translationTimer;
	float translationTime = 7f;
	float lerpVal;
	bool bIsTranslating;

	float flameOffset = .001f;

	void Start() {
		lt = GetComponent<Light>();
		StartingPosition = transform.position;
	}
	void Update() {
		if (bIsTranslating) {
			lerpVal += Time.deltaTime * translationTime;
			transform.position = Vector3.Lerp (LastPosition, NextPosition, lerpVal);
			if (lerpVal > 1) {
				lerpVal = 0;
				bIsTranslating = false;
			}
		} else {
			//pick new point
			Vector3 newVec = new Vector3(Random.Range(-flameOffset,flameOffset),  Random.Range(-flameOffset,flameOffset), Random.Range(-flameOffset,flameOffset));
			LastPosition = transform.position;
			NextPosition = StartingPosition + newVec;
			bIsTranslating = true;
			translationTime = Random.Range (18, 27);
		}
	}
}
