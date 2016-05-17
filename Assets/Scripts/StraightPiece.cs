using UnityEngine;
using System.Collections;

public class StraightPiece : MonoBehaviour {
	public bool isStartingGround;
	public Vector3 startingPoint;
	public float speed;
	
	void Start() {
	}
	
	void OnEnable () {
		startingPoint = new Vector3(0, 1.0f, 40.0f);
	}	
	
	void FixedUpdate () {
		
		// main movement of platform
		transform.position -= new Vector3 (0, 0, Time.deltaTime * speed);
		
		if (transform.position.z <= -100.0f) {
			if (isStartingGround) {
				Destroy(gameObject);
			} else {
				gameObject.SetActive(false);
			}
		}
	}
}
