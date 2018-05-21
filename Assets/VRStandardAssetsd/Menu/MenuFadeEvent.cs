using System;
using System.Collections;
using UnityEngine;
using VRStandardAssets.Utils;
using UnityEngine.Events;

public class MenuFadeEvent : MonoBehaviour
{

    public UnityEvent OnButtonSelected;
    public UnityEvent OnFadeComplete;
	public UnityEvent OnFadeInBetweenEvent;
	public UnityEvent OnFadeInStartEvent;

    [SerializeField] private VRInteractiveItem m_InteractiveItem;       // The interactive item for where the user should click to load the level.

    private bool m_GazeOver;                                            // Whether the user is looking at the VRInteractiveItem currently.

	float gazeTime = 0f;
	float gazeTimeToActivate = 2.5f;


    private void OnEnable()
    {
        m_InteractiveItem.OnOver += HandleOver;
        m_InteractiveItem.OnOut += HandleOut;
        //m_SelectionRadial.OnSelectionComplete += HandleSelectionComplete;
    }


    private void OnDisable()
    {
        m_InteractiveItem.OnOver -= HandleOver;
        m_InteractiveItem.OnOut -= HandleOut;
        //m_SelectionRadial.OnSelectionComplete -= HandleSelectionComplete;
    }


    private void HandleOver()
    {
        // When the user looks at the rendering of the scene, show the radial.
        SelectionRadial.instance.Show(gameObject, gazeTimeToActivate);

		gazeTime = 0f;

        m_GazeOver = true;
    }

    private void HandleOut()
    {
        // When the user looks away from the rendering of the scene, hide the radial.
		SelectionRadial.instance.Hide(gameObject);

        m_GazeOver = false;
    }

	private void Update()
	{
        if(m_GazeOver) {
            if(gazeTime < gazeTimeToActivate) {
                gazeTime += Time.unscaledDeltaTime;
                if(gazeTime >= gazeTimeToActivate) {
                    StartCoroutine(ActivateButton());
                }
            }
        }
	}

	//private void HandleSelectionComplete()
    //{
    //    // If the user is looking at the rendering of the scene when the radial's selection finishes, activate the button.
    //    if (m_GazeOver)
    //        StartCoroutine(ActivateButton());
    //}

    bool isFading = false;

    private IEnumerator ActivateButton()
    {
        // If the camera is already fading, ignore.
        if (isFading)
            yield break;
        
		isFading = true;

        // If anything is subscribed to the OnButtonSelected event, call it.
        if (OnButtonSelected != null)
            OnButtonSelected.Invoke();

		HandleOut ();

        // Wait for the camera to fade out.
		GhettoVRFade.StartFadeInOut (0.75f, 1f, .75f, OnFadeInBetweenEvent, OnFadeInStartEvent, OnFadeComplete);

		yield return new WaitForSeconds(0.75f + 1f + .75f);

        // If anything is subscribed to the OnButtonSelected event, call it.
        if (OnFadeComplete != null)
            OnFadeComplete.Invoke();

        isFading = false;
    }
}
