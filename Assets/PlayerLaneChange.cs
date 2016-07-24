// Written by Nick L.
// Code for strafing in the RipleyRunner Engine
using UnityEngine;
using System.Collections;

public class PlayerLaneChange : MonoBehaviour {
	public float strafeDestinationModifier;
	public float strafeSpeed;
	public float strafeFixedFrame;

	public bool inputEnabled;

	// bool to display if the player us exactly in the lane
	public bool isSnappedToLane;

	public enum StrafeLocation { left, center, right };
	public StrafeLocation currentStrafeLocation;
	public float strafeAmount;
	public float strafeCenter = 0;

	float strafeResponsivenessLevel;

	// Use this for initialization
	void Awake() {
		strafeAmount = 4.0f;
		strafeSpeed = 10.0f;
		strafeDestinationModifier = 0.0f;
		strafeResponsivenessLevel = 0.3f;
	}

	void Start() {	
		currentStrafeLocation = StrafeLocation.center;
		strafeDestinationModifier = 0.0f;
		inputEnabled = true;
	}

	// Update is called once per frame
	void Update() {
		// fixed frame variable for movement
		strafeFixedFrame = strafeSpeed * Time.deltaTime;

		if (Input.GetKey(KeyCode.A) && inputEnabled == true) {
			StrafeLeft();
		}
		if (Input.GetKey(KeyCode.D) && inputEnabled == true) {
			StrafeRight();
		}

		Vector3 tempVector = transform.localPosition;

		if (transform.localPosition.x != strafeDestinationModifier) {
			isSnappedToLane = false;
			tempVector.x = Mathf.Lerp (tempVector.x, strafeDestinationModifier, strafeFixedFrame);
			transform.localPosition = tempVector;
		} else {
			isSnappedToLane = true;
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