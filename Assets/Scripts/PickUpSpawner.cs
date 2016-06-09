using UnityEngine;
using System.Collections;

public class PickUpSpawner : MonoBehaviour {
	public GameObject coinPickupPrefab;
	
	public float laneValue;
	// Use this for initialization
	
	void OnEnable () {
		laneValue = 0.0f;
		
		
		for (float i = 0; i < 10; i++) {
			float currentZLocation = 0.45f - (i * 0.1f);
			
			GameObject go = (GameObject) Instantiate (coinPickupPrefab, transform.position, transform.rotation);	
			go.transform.parent = this.transform;
			go.transform.localPosition = new Vector3 (laneValue, 2.0f, currentZLocation);
		}
	}
	
}
