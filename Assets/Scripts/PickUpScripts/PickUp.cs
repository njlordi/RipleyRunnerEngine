using UnityEngine;
using System.Collections;

public class PickUp : MonoBehaviour {
	public float rotationSpeed;
	public PlayerSounds playerSounds;
	
	void OnEnable() {
		
	}
	
	// Use this for initialization
	void Start () {
		rotationSpeed = 250.0f;
		
		// this code is bad, but will be good with pooling! add it asap!
		playerSounds = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerSounds>();
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed);
	}
	
	void OnTriggerEnter(Collider other) {
		playerSounds.PlayPickUpNoise();
		PlayerStats.pickUpsCollected++;
		
		// (remove later with pooling)
		gameObject.SetActive(false);
		
		/* Save this for object pooling later...
		gameObject.SetActive(false);
		*/
	}
	
	void OnDisable() {
		// (remove later with pooling)
		gameObject.SetActive(false);
	}
}
