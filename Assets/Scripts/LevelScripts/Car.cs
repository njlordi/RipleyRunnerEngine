using UnityEngine;
using System.Collections;

public class Car : MonoBehaviour
{
	// scale of 1-5 (1 = will not happen) (5 = guaranteed) ...maybe move to centralized class?
	float chanceToExist;
	public bool isExistent;

	public float carSpeed;
	public float delayInCarMovement;
	Renderer carRenderer;
	Vector3 carOrigin;
	float timeMarker;

	void Awake ()
	{
		carRenderer = GetComponent<Renderer> ();
	}

	void OnEnable ()
	{
		rollForExistence ();

		chanceToExist = 3;
		carOrigin = this.transform.localPosition;
		delayInCarMovement = Random.Range (1.0f, 2.0f);
		timeMarker = Time.time;

		if (isExistent) {
			carSpeed = Random.Range (20.0f, 60.0f);
			carRenderer.enabled = true;
		} else {
			carSpeed = 0;
			carRenderer.enabled = false;
		}
	}

	// Update is called once per frame
	void Update ()
	{
		if (Time.time >= (timeMarker + delayInCarMovement))
			this.transform.Translate (Vector3.forward * Time.deltaTime * carSpeed);
	}

	void OnDisable ()
	{
		this.transform.localPosition = carOrigin;
	}

	void rollForExistence ()
	{
		if (Random.Range (1, 5) < chanceToExist) {
			isExistent = true;
		} else {
			isExistent = false;
		}
			
	}
}
