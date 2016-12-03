using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotationTrack : MonoBehaviour {

	Transform trans;

	void Awake () {
		trans = transform;
	}

	void Update () {
		trans.rotation = Quaternion.Euler(trans.parent.rotation.eulerAngles.y * Vector3.up);
	}
}
