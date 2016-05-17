using UnityEngine;
using System.Collections;

public class TurnPiece : MonoBehaviour {

	public bool isStartingGround;
	public Vector3 startingPoint;
	public float speed;
	public float turnAngle;
	public float turnSpeed;
	
	void Start() {
		turnAngle = 360f;
	}
	
	void OnEnable () {
		startingPoint = new Vector3 (0, 1.0f, 40.0f);
	}	
	
	// Update is called once per frame
	void FixedUpdate () {
		
		// main movement of platform
		transform.position -= new Vector3 (0, 0, Time.deltaTime * speed);
		
		turnSpeed = speed * Mathf.PI;
		
		// once the ground is out of bounds and not rotated to 270 degrees, start rotating
		// replace this code with Mathf.clamp?
		if (transform.position.z <= 15 && turnAngle >= 270f) {
			turnAngle -= Time.deltaTime * turnSpeed;
			transform.rotation = Quaternion.Euler(0.0f, turnAngle, 0.0f);
		/* if the ground is out of bounds and has reached it's rotation goal set precise angle of 270 
		(this may not be necessary) */	
		} else if (transform.position.z <= 15) {
			transform.rotation = Quaternion.Euler(0.0f, 270f, 0.0f);
		}
		
		if (transform.position.z <= -100.0f) {
			if (isStartingGround) {
				Destroy(gameObject);
			} else {
				gameObject.SetActive(false);
			}
		}
	}
}