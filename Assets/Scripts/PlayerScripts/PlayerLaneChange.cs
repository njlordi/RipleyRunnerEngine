// Written by Nick L.
// Code for strafing in the RipleyRunner Engine
using UnityEngine;
using System.Collections;

public class PlayerLaneChange : MonoBehaviour {

	// Prevents movement before input is received from the user
	public bool isActivatedForMovement;

	public float strafeDestinationModifier;
	public float strafeSpeed;
	public float strafeFixedFrame;

	public bool inputEnabled;

	public enum StrafeLocation { left, center, right };
	public StrafeLocation currentStrafeLocation;
	public float strafeAmount;
	public float strafeCenter = 0;

	float strafeResponsivenessLevel;

	void Awake() {
		isActivatedForMovement = false;

		strafeAmount = 4.0f;
		strafeSpeed = 10.0f;
		strafeDestinationModifier = 0.0f;
		strafeResponsivenessLevel = 0.05f;
	}

	void Start() {	
		currentStrafeLocation = StrafeLocation.center;
		strafeDestinationModifier = 0;
		inputEnabled = true;
	}
		
	void Update() {
		// fixed frame variable for movement
		strafeFixedFrame = strafeSpeed * Time.deltaTime;

		if (Input.GetKey(KeyCode.A) && inputEnabled == true) {
			isActivatedForMovement = true;
			StrafeLeft();
		}
		if (Input.GetKey(KeyCode.D) && inputEnabled == true) {
			isActivatedForMovement = true;
			StrafeRight();
		}

		Vector3 tempVector = transform.localPosition;

		if (isActivatedForMovement) {
			tempVector.x = Mathf.Lerp (tempVector.x, strafeDestinationModifier, strafeFixedFrame);
			transform.localPosition = tempVector;
		}

		SetEnumToCorrectLane();
	}

	/// <summary>
	/// Determines what lane the player is currently in 
	/// and sets StrafeLocation to that enum value.
	/// </summary>
	void SetEnumToCorrectLane() {
		if (transform.localPosition.x >= strafeAmount - strafeResponsivenessLevel) {
			currentStrafeLocation = StrafeLocation.right;
			inputEnabled = true;
		}
		if (transform.localPosition.x <= -(strafeAmount - strafeResponsivenessLevel)) {
			currentStrafeLocation = StrafeLocation.left;
			inputEnabled = true;
		}
		if (transform.localPosition.x < strafeResponsivenessLevel 
			&& transform.localPosition.x > -strafeResponsivenessLevel) {
			currentStrafeLocation = StrafeLocation.center;
			inputEnabled = true;
		}
	}

	public void StrafeLeft() {
		inputEnabled = false;
		if (currentStrafeLocation == StrafeLocation.center)
			strafeDestinationModifier = -strafeAmount;
		else if (currentStrafeLocation != StrafeLocation.left)
			GoToCenterLane();
	}

	public void StrafeRight() {
		inputEnabled = false;
		if (currentStrafeLocation == StrafeLocation.center)
			strafeDestinationModifier = strafeAmount;
		else if (currentStrafeLocation != StrafeLocation.right)
			GoToCenterLane();

	}

	public void GoToCenterLane() {
		strafeDestinationModifier = strafeCenter;
	}
}