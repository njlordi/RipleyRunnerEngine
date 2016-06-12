using UnityEngine;
using System.Collections;

public class PickUpSpawner : MonoBehaviour {
	public GameObject coinPickupPrefab;
	
	public float laneValue;
	
	// outsource this variable to static method later
	public float pickupSpacing;
	
	// Use this for initialization
	
	void OnEnable () {
		pickupSpacing = 0.04f;
		Random.seed = System.DateTime.Now.Millisecond;
		laneValue = pickupSpacing * Random.Range(-1, 2);
		
		
		for (float i = 0; i < 10; i++) {
			float currentZLocation = 0.45f - (i * 0.1f);
			
			GameObject go = (GameObject) Instantiate (coinPickupPrefab, 
				transform.position, transform.rotation);	
			go.transform.parent = this.transform;
			go.transform.localPosition = new Vector3 (laneValue, 2.0f, currentZLocation);
		}
	}
	
}
