using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Events;

public class GhettoVRFade : MonoBehaviour {

	static GhettoVRFade instance;

	Material material;

	void Awake() {
		if (instance == null) {
			instance = this;
		} else {
			Debug.LogError ("Instance of GhettoFaceVR already exists in scene. Disabling", this);
			this.enabled = false;
		}
	}

	void Start () {
		material = GetComponent<Renderer> ().material;
		SetFade (0f);
	}
	
	void Update () {
		
	}

	/// <summary>
	/// Sets the fade 0f-1f
	/// </summary>
	/// <param name="percentage">Percentage.</param>
	public static void SetFade(float percentage) {
		SetAlpha (instance.material, percentage);
	}

	bool fading = false;

	public static void StartFadeInOut(float fadeInTime, float fadeInBetweenTime, float fadeOutTime, UnityEvent fadeInBetweenEvent = null, UnityEvent fadeInStartEvent = null, UnityEvent fadeInDoneEvent = null) {
		instance.StartCoroutine (instance.FadeInOut (fadeInTime, fadeInBetweenTime, fadeOutTime, fadeInBetweenEvent, fadeInStartEvent, fadeInDoneEvent));
	}

	public IEnumerator FadeInOut(float fadeInTime,  float fadeInBetweenTime, float fadeOutTime, UnityEvent fadeInBetweenEvent = null, UnityEvent fadeInStartEvent = null, UnityEvent fadeInDoneEvent = null) {
		for (float t = 0; t < 1f; t += Time.unscaledDeltaTime / fadeInTime) {
			SetAlpha (instance.material, t);
			yield return null;
		}

		if (fadeInBetweenEvent != null)
			fadeInBetweenEvent.Invoke ();
		
		yield return new WaitForSeconds(fadeInBetweenTime);

		if (fadeInStartEvent != null)
			fadeInStartEvent.Invoke ();

		for (float t = 1f; t > 0f; t -= Time.unscaledDeltaTime / fadeOutTime) {
			SetAlpha (instance.material, t);
			yield return null;
		}
		SetAlpha (instance.material, 0f);

		if (fadeInDoneEvent != null)
			fadeInDoneEvent.Invoke ();
	}

	static void SetAlpha(Material mat, float alpha) {
		Color color = mat.color;
		color.a = alpha;
		mat.color = color;
	}
}
