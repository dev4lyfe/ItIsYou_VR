using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPaper : MonoBehaviour {

    Vector3 endPosition;
    Quaternion endRotation;

    bool active = false;

    float minFallSpeed = 0.4f;
    float maxFallSpeed = 0.5f;
    float fallSpeed;

    float minRotateSpeed = 0.1f;
    float maxRotateSpeed = 0.2f;
    float rotateSpeed;

    Vector3 rotationVelocity;

	void Start () {
        endPosition = transform.position;
        endRotation = transform.rotation;

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
            if(Vector3.Distance(transform.position, endPosition) < 0.1f) {
                active = false;
            } else if(Vector3.Distance(transform.position, endPosition) < 0.11f) {
                transform.position += Vector3.down * fallSpeed * Time.deltaTime;


                //transform.rotation = Quaternion.Lerp(transform.rotation, endRotation, Time.deltaTime*3f);
                GetComponent<Rigidbody>().useGravity = true;
                //transform.Rotate(
                //    rotationVelocity.x * rotateSpeed * Time.deltaTime,
                //    rotationVelocity.y * rotateSpeed * Time.deltaTime,
                //    rotationVelocity.z * rotateSpeed * Time.deltaTime
                //);
            } else {
				transform.position += Vector3.down * fallSpeed * Time.deltaTime;
				transform.Rotate(
					rotationVelocity.x * rotateSpeed * Time.deltaTime, 
					rotationVelocity.y * rotateSpeed * Time.deltaTime, 
					rotationVelocity.z * rotateSpeed * Time.deltaTime
				);
            }
        }
	}

	//private void OnDrawGizmos()
	//{
 //       Gizmos.color = Color.red;
 //       Gizmos.DrawWireSphere(transform.position + Vector3.up * 10f, 0.5f);
	//}
}
