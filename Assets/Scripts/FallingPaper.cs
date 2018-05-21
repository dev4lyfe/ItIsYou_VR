using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRStandardAssets.Utils;

public class FallingPaper : MonoBehaviour {

    float endYPosition;

    bool active = false;

    float minFallSpeed = 0.4f;
    float maxFallSpeed = 0.5f;
    float fallSpeed;

    float minRotateSpeed = 0.1f;
    float maxRotateSpeed = 0.2f;
    float rotateSpeed;

    Vector3 rotationVelocity;

    VRInteractiveItem vRInteractiveItem;

    static FallingPaper currentViewedPaper = null;

	void Start () {
        endYPosition = transform.position.y;

        transform.position += Vector3.up * 10f;
        foreach(Renderer rend in GetComponentsInChildren<Renderer>()) {
            rend.enabled = false;
        }
        Activate();
	}
	
	public void Activate () {
        foreach (Renderer rend in GetComponentsInChildren<Renderer>())
        {
            rend.enabled = true;
        }
        active = true;
        rotationVelocity = Random.onUnitSphere;
        rotateSpeed = Random.Range(minRotateSpeed, maxRotateSpeed) * 360f;
        fallSpeed = Random.Range(minFallSpeed, maxFallSpeed);
	}

	private void Update()
	{
        if(active) {
			if(vRInteractiveItem.IsOver) {
				if(currentViewedPaper == null) {
					currentViewedPaper = this;
                } else {
                    Fall();
                }
				if(currentViewedPaper == this) {
                    Vector3 targetPosition = Camera.main.transform.position + Camera.main.transform.forward * 1.5f;
                    Quaternion targetRotation = Quaternion.LookRotation(Camera.main.transform.forward * -1f);

                    transform.position = Vector3.Slerp(transform.position, targetPosition, Time.deltaTime * 2f);
                    transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 2f);
				}
            } else {
                if (currentViewedPaper == this)
                    currentViewedPaper = null;
                Fall();
            }
        }
	}

    void Fall() {
        float yDifference = Mathf.Abs(transform.position.y - endYPosition);
        if (yDifference < 0.1f)
        {
            active = false;
        }
        else if (yDifference < 0.16f)
        {
            transform.position += Vector3.down * fallSpeed * Time.deltaTime;

            GetComponent<Rigidbody>().useGravity = true;
            //transform.Rotate(
            //    rotationVelocity.x * rotateSpeed * Time.deltaTime,
            //    rotationVelocity.y * rotateSpeed * Time.deltaTime,
            //    rotationVelocity.z * rotateSpeed * Time.deltaTime
            //);
        }
        else
        {
            transform.position += Vector3.down * fallSpeed * Time.deltaTime;
            transform.Rotate(
                rotationVelocity.x * rotateSpeed * Time.deltaTime,
                rotationVelocity.y * rotateSpeed * Time.deltaTime,
                rotationVelocity.z * rotateSpeed * Time.deltaTime
            );
        }
    }
}
