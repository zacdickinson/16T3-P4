using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour {

	Light myLight;
	public float minIntensity = 0f;
	public float maxIntensity = 1f;

	void Start () {
		myLight = GetComponent<Light> ();
	}
	
	void FixedUpdate () {
		myLight.intensity = Random.Range (minIntensity, maxIntensity);
	}
}
