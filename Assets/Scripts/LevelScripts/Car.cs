using UnityEngine;
using System.Collections;

public class Car : MonoBehaviour {
	
	public float carSpeed;
	public float delayInCarMovement;
	Vector3 carOrigin;
	float timeMarker;

	// scale of 1-5 (1 = will not happen) (5 = guaranteed)
	float chanceToExist;

	void OnEnable () {
		chanceToExist = 2;
		carOrigin = this.transform.localPosition;
        delayInCarMovement = Random.Range(1.0f, 2.0f);
		timeMarker = Time.time;

		if (Random.Range (1, 5) < chanceToExist) {
			carSpeed = Random.Range (20.0f, 60.0f);
		} else {
			carSpeed = 0;
		}
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
