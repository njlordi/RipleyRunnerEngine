using UnityEngine;
using System.Collections;

public class Car : MonoBehaviour {
	public float carSpeed;
	public float delayInCarMovement;
	Vector3 carOrigin;
	float timeMarker;
	// Use this for initialization

	void OnEnable () {
		carOrigin = this.transform.localPosition;
		carSpeed = Random.Range(18.0f, 60.0f);
        delayInCarMovement = Random.Range(1.0f, 2.0f);
		timeMarker = Time.time;
	}

	// Update is called once per frame
	void Update () {
		if (Time.time >= (timeMarker + delayInCarMovement))
			this.transform.Translate (Vector3.forward * Time.deltaTime * carSpeed);
	}
		
	void OnDisable() {
		this.transform.localPosition = carOrigin;
	}
}
