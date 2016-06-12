using UnityEngine;
using System.Collections;

public class PickUpRotation : MonoBehaviour {
	
	public float rotationSpeed;
	// Use this for initialization
	void Start () {
		rotationSpeed = 250.0f;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed);
	}
	
	void OnTriggerEnter() {
		gameObject.SetActive(false);
	}
}
