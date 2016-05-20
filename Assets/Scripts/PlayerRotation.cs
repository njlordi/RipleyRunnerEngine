using UnityEngine;
using System.Collections;

public class PlayerRotation : MonoBehaviour {
	
	public string directionToTurn;
	public float turnSpeed;
	public float currentYRotation;
	
	public Quaternion targetRotation;
	public float degreesToTurn;
	
	public bool keyInputEnabled;
	public bool flagForDegreeChange;

	// Use this for initialization
	void Awake () {
		degreesToTurn = 0.0f;
		turnSpeed = 200.0f;
		targetRotation = Quaternion.identity;
	}
	
	void Start() {
		flagForDegreeChange = true;
		keyInputEnabled = true;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		currentYRotation = gameObject.transform.rotation.eulerAngles.y;
		
		if (Input.GetKey(KeyCode.LeftArrow) && keyInputEnabled) {
			directionToTurn = "left";
			keyInputEnabled = false;
			flagForDegreeChange = true;
		}
		if (Input.GetKey(KeyCode.RightArrow) && keyInputEnabled) {
			directionToTurn = "right";
			keyInputEnabled = false;
			flagForDegreeChange = true;
		}
		
		switch(directionToTurn){

		case "left":
			TurnLeft();
			break;			
		case "right":
			TurnRight();
			break;
		default:
			break;
			
		}
		targetRotation = Quaternion.Euler(0.0f, degreesToTurn, 0.0f);
		transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
		
		if (transform.rotation == targetRotation) {
			keyInputEnabled = true;
		}
	}
	
	void TurnLeft() {
		if (flagForDegreeChange) {
			degreesToTurn -= 90.0f;
			flagForDegreeChange = false;
		}
		//targetRotation = Quaternion.Euler(0.0f, degreesToTurn, 0.0f);
	}
	void TurnRight() {
		if (flagForDegreeChange) {
			degreesToTurn += 90.0f;
			flagForDegreeChange = false;
		}
		//targetRotation = Quaternion.Euler(0.0f, degreesToTurn, 0.0f);
	}
}
