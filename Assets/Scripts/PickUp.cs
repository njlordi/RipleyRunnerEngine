using UnityEngine;
using System.Collections;

public class PickUp : MonoBehaviour {
	public float rotationSpeed;
	public PlayerSounds playerSounds;
	
	// Use this for initialization
	void Start () {
		rotationSpeed = 250.0f;
		playerSounds = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerSounds>();
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed);
	}
	
	void OnTriggerEnter(Collider other) {
		playerSounds.PlayPickUpNoise();
		gameObject.SetActive(false);
	}
}
