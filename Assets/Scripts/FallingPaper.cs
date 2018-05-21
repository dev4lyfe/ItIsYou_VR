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

	[SerializeField]
	Collider rigidBodyCollider;

	[SerializeField]
	Collider lookCollider;

    static FallingPaper currentViewedPaper = null;

	[SerializeField]
	Vector3 fallingSpeed;

	void Start () {
        endYPosition = transform.position.y;
		vRInteractiveItem = GetComponent<VRInteractiveItem> ();

        transform.position += Vector3.up * 10f;
        foreach(Renderer rend in GetComponentsInChildren<Renderer>()) {
            rend.enabled = false;
        }
        Activate();
        GetComponent<Rigidbody>().isKinematic = true;
		lookCollider.enabled = true;
		rigidBodyCollider.enabled = false;
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

	float closeToFaceTime = 0f;

	private void Update()
	{
        if(active) {
			if(vRInteractiveItem.IsOver && closeToFaceTime < 2f) {
				if(currentViewedPaper == null && Mathf.Abs(transform.position.y - endYPosition) < 3f) {
					currentViewedPaper = this;
				} else if(currentViewedPaper != this) {
                    Fall();
                }
				if(currentViewedPaper == this) {
                    Vector3 targetPosition = Camera.main.transform.position + Camera.main.transform.forward * .35f;
                    Quaternion targetRotation = Quaternion.LookRotation(Camera.main.transform.forward);

					if (Vector3.Distance (transform.position, targetPosition) < 0.11f)
						closeToFaceTime += Time.deltaTime;

					fallingSpeed = Vector3.zero;

                    transform.position = Vector3.Slerp(transform.position, targetPosition, Time.deltaTime * 1f);
                    transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 1f);
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
			Vector3 targetFallingSpeed = Vector3.down * fallSpeed;
			fallingSpeed = Vector3.Lerp (fallingSpeed, targetFallingSpeed, Time.deltaTime * 1.5f);
			transform.position += fallingSpeed * Time.deltaTime;

			if (GetComponent<Rigidbody> ().useGravity == false) {
				GetComponent<Rigidbody> ().useGravity = true;
				GetComponent<Rigidbody> ().isKinematic = false;
				lookCollider.enabled = false;
				rigidBodyCollider.enabled = true;
			}
            //transform.Rotate(
            //    rotationVelocity.x * rotateSpeed * Time.deltaTime,
            //    rotationVelocity.y * rotateSpeed * Time.deltaTime,
            //    rotationVelocity.z * rotateSpeed * Time.deltaTime
            //);
        }
        else
        {
			Vector3 targetFallingSpeed = Vector3.down * fallSpeed;
			fallingSpeed = Vector3.Lerp (fallingSpeed, targetFallingSpeed, Time.deltaTime * 1.5f);
			transform.position += fallingSpeed * Time.deltaTime;

            transform.Rotate(
                rotationVelocity.x * rotateSpeed * Time.deltaTime,
                rotationVelocity.y * rotateSpeed * Time.deltaTime,
                rotationVelocity.z * rotateSpeed * Time.deltaTime
            );
        }
    }
}
