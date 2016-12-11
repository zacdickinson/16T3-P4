using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCollisionCheck : MonoBehaviour {

	public Transform minDolly;
	public Transform maxDolly;
	float distance;
	Transform trans;

	void Awake () {
		distance = Vector3.Distance (minDolly.position, maxDolly.position);
		trans = transform;
	}
	
	void FixedUpdate () {
		RaycastHit rayHit;
		if (Physics.Raycast (minDolly.position, maxDolly.position - minDolly.position, out rayHit, distance)) {
			trans.position = rayHit.point;
		} else {
			trans.position = maxDolly.position;
		}
	}
}
