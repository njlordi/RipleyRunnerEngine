using UnityEngine;
using System.Collections;

public class PickUp : MonoBehaviour {
	
	public float rotationSpeed;
	public AudioClip coinNoise;
	// Use this for initialization
	void Start () {
		rotationSpeed = 250.0f;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed);
	}
	
	void OnTriggerEnter(Collider other) {
		AudioSource.PlayClipAtPoint(coinNoise, other.transform.position);
		gameObject.SetActive(false);
	}
}
