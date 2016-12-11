using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	[SerializeField] private float moveSpeed = 4f;
	[SerializeField] private float rotationSpeed = 5.5f;

	Transform trans;
	Transform cameraTrans;

	Vector3 moveDir;

	bool isWalking = false;
	Animator myAnim;

	[SerializeField] private bool canMove = true;
	bool inBattle = false;

	void Start () {
		myAnim = GetComponent<Animator> ();
		trans = transform;
		cameraTrans = GameObject.FindGameObjectWithTag ("CameraRotation").transform;
	}
	
	void FixedUpdate () {

		CheckWalking ();

		if (isWalking && canMove) {
			MoveCharacter ();
			RotateCharacter ();
		}

		myAnim.SetBool ("isWalking", isWalking && canMove);
	}

	void MoveCharacter () {
		moveDir = cameraTrans.forward * Input.GetAxis ("Vertical");
		moveDir += cameraTrans.right * Input.GetAxis ("Horizontal");
		moveDir.y = 0f;
		moveDir = moveDir.normalized * Time.fixedDeltaTime * moveSpeed;

		trans.position += moveDir;

		moveDir = moveDir.normalized;
	}

	void RotateCharacter () {
		Quaternion moveRot = Quaternion.LookRotation (moveDir);
		trans.rotation = Quaternion.Lerp (trans.rotation, moveRot, Time.fixedDeltaTime * rotationSpeed);
	}

	void CheckWalking () {
		if (Mathf.Abs (Input.GetAxis ("Horizontal")) + Mathf.Abs (Input.GetAxis ("Vertical")) > 0.4f) {
			isWalking = true;
		} else {
			isWalking = false;
		}
	}

	void OnEnable () {
		
		BattleManager.OnStart += OnBattleStart;
		BattleManager.OnWon += OnBattleEnd;
	}


	void OnDisable () {

		BattleManager.OnStart -= OnBattleStart;
		BattleManager.OnWon -= OnBattleEnd;
	}

	void OnBattleStart () {
		
		inBattle = true;
		canMove = false;
	}

	void OnBattleEnd () {
		
		inBattle = false;
		canMove = true;
	}
}
