using UnityEngine;
using System.Collections;

public class GroundPiece : MonoBehaviour {
	
	public Vector3 startingPoint;
	
	public enum GroundPieces {start, straight, right, left, cross};
	public GroundPieces gp;
	
	public static float speed = 20;
	public float turnAngle;
	public float turnSpeed;
	// for flagging
	//public bool hasRotated = false;

	void Awake() {
		// this number depends on type of piece(right/left)
		switch (gp) {
		case GroundPieces.right:
			turnAngle = 360f;
			break;
		case GroundPieces.left:
			turnAngle = 180f;
			break;
		default:
			break;
		}
	}
	
	void OnEnable () {
		startingPoint = new Vector3 (0, 1.0f, 40.0f);
	}	
	
	// Update is called once per frame
	void FixedUpdate () {
		
		// main movement of platform
		transform.position -= new Vector3 (0, 0, Time.deltaTime * speed);
		
		turnSpeed = speed * Mathf.PI;
		
		if (gp != GroundPieces.straight) {
			RotatePiece();
		}
		
		if (transform.position.z <= -100.0f) {
			if (gp == GroundPieces.start) {
				Destroy(gameObject);
			} else {
				gameObject.SetActive(false);
			}
		}
	}
	
	void RotatePiece() {
		Debug.Log("RotatePiece Called...");
		
		// once the ground is out of bounds and not rotated to 270 degrees, start rotating
		// replace this code with Mathf.clamp?
		
		switch(gp) {
		case GroundPieces.right:
		if (transform.position.z <= 15 && turnAngle >= 270f) {
			turnAngle -= Time.deltaTime * turnSpeed;
			transform.rotation = Quaternion.Euler(0.0f, turnAngle, 0.0f);
		/* if the ground is out of bounds and has reached it's rotation goal set precise angle of 270 
		(this may not be necessary) */	
		} else if (transform.position.z <= 15) {
			transform.rotation = Quaternion.Euler(0.0f, 270f, 0.0f);
		}
			break;
		case GroundPieces.left:
			if (transform.position.z <= 15 && turnAngle <= 270f) {
				turnAngle += Time.deltaTime * turnSpeed;
				transform.rotation = Quaternion.Euler(0.0f, turnAngle, 0.0f);
		/* if the ground is out of bounds and has reached it's rotation goal set precise angle of 270 
		(this may not be necessary) */	
			} else if (transform.position.z <= 15) {
				transform.rotation = Quaternion.Euler(0.0f, 270f, 0.0f);
			}
			break;
		default:
			break;
		}
	}
}