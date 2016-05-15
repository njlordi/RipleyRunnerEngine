using UnityEngine;
using System.Collections;

public class Ground : MonoBehaviour {
	public Vector3 startingPoint;
	public float speed;
	
	void Start() {
	}
	
	void OnEnable () {
		startingPoint = new Vector3(0, 1.0f, 20.0f);
	}	
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.Translate(-Vector3.forward * (Time.deltaTime * speed));
		if (transform.position.z <= -20.0f) {
			Destroy(gameObject);
		}
	}
}
