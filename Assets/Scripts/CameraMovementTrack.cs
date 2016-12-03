using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementTrack : MonoBehaviour {

	public float heightOffset = 1.96f;
	public float followDamping = 1f;

	Transform playerTransform;
	Transform trans;

	void Awake () {
		trans = transform;
		playerTransform = GameObject.FindGameObjectWithTag ("Player").transform;
	}

	void FixedUpdate () {
		trans.position = Vector3.Lerp (trans.position, playerTransform.position + (Vector3.up * heightOffset), Time.fixedDeltaTime * followDamping);
	}
}
