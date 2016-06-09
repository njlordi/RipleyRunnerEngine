using UnityEngine;
using System.Collections;

public class PickUpRotation : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(Vector3.up * Time.deltaTime * 100.0f);
	}
	
	void OnTriggerEnter() {
		gameObject.SetActive(false);
	}
}
