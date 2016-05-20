using UnityEngine;
using System.Collections;

public class PlayerRotation : MonoBehaviour {

	public float turnSpeed;
	public Quaternion targetRotation;
	public float degreesToTurn;
	
	public bool turnInputEnabled;

	void Awake () {
		degreesToTurn = 0.0f;
		turnSpeed = 200.0f;
		targetRotation = Quaternion.identity;
	}
	
	void Start() {
		turnInputEnabled = true;
	}
	
	void Update () {
		
		
		if (Input.GetKey(KeyCode.LeftArrow) && turnInputEnabled) {
			TurnLeft();
		}
		if (Input.GetKey(KeyCode.RightArrow) && turnInputEnabled) {
			TurnRight();
		}
		
		targetRotation = Quaternion.Euler(0.0f, degreesToTurn, 0.0f);
		
		if (transform.rotation == targetRotation) {
			turnInputEnabled = true;
		} else {
			transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
		}
	}
	
	void TurnLeft() {
		turnInputEnabled = false;
		degreesToTurn -= 90.0f;
		
	}
	void TurnRight() {
		turnInputEnabled = false;
		degreesToTurn += 90.0f;
	}
}
