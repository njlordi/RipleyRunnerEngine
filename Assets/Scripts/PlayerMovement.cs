using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	public float runSpeed;
	public float turnSpeed;
	Quaternion targetRotation;
	float degreesToTurn;
	public bool turnInputEnabled;
	
	void Awake () {
		degreesToTurn = 0.0f;
		turnSpeed = 200.0f;
		targetRotation = Quaternion.identity;
	}
	
	void Start() {
		turnInputEnabled = true;
		GroundPiece.MoveLeft();
	}
	
	void Update () {
		turnSpeed = runSpeed * 5.0f;
		
		gameObject.transform.Translate(Vector3.forward * Time.deltaTime * runSpeed);
		
		targetRotation = Quaternion.Euler(0.0f, degreesToTurn, 0.0f);
		
		if (transform.rotation == targetRotation) {
			turnInputEnabled = true; //remove?
		} else {
			transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
		}
	}
	
	public void TurnLeft() {
		turnInputEnabled = false;
		degreesToTurn -= 90.0f;
	}
	public void TurnRight() {
		turnInputEnabled = false;
		degreesToTurn += 90.0f;
	}
}
