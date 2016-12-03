using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float moveSpeed = 2.5f;
	public float rotationSpeed = 10f;

	Transform trans;
	Transform cameraTrans;

	Vector3 moveDir;

	bool isWalking = false;

	void Start () {
		trans = transform;
		cameraTrans = GameObject.FindGameObjectWithTag ("CameraRotation").transform;
	}
	
	void FixedUpdate () {

		CheckWalking ();

		if (isWalking) {
			MoveCharacter ();
			RotateCharacter ();
		}
	}

	void MoveCharacter () {
		moveDir = Time.fixedDeltaTime * cameraTrans.forward * Input.GetAxis ("Vertical") * moveSpeed;
		moveDir += Time.fixedDeltaTime * cameraTrans.right * Input.GetAxis ("Horizontal") * moveSpeed;
		moveDir.y = 0f;

		trans.position += moveDir;

		moveDir = moveDir.normalized;
	}

	void RotateCharacter () {
		float moveAmount = Mathf.Abs (Input.GetAxis ("Horizontal")) + Mathf.Abs (Input.GetAxis ("Vertical"));
		Quaternion moveRot = Quaternion.LookRotation (moveDir);
		trans.rotation = Quaternion.Lerp (trans.rotation, moveRot, Time.fixedDeltaTime * rotationSpeed * moveAmount);
	}

	void CheckWalking () {
		if (Mathf.Abs (Input.GetAxis ("Horizontal")) + Mathf.Abs (Input.GetAxis ("Vertical")) > 0f) {
			isWalking = true;
		} else {
			isWalking = false;
		}
	}
}
