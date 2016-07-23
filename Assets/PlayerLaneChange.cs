using UnityEngine;
using System.Collections;

public class PlayerLaneChange : MonoBehaviour
{
	public bool isAllowedInput;

	public float strafeSpeed;
	public float strafeAmount;
	public float localPosX;

	public enum laneLocation {left, center, right};
	public laneLocation playerCurrentLane;

	void Start () {
		this.playerCurrentLane = laneLocation.center;
		isAllowedInput = true;
		strafeSpeed = 20.0f;
		strafeAmount = 4.0f;
	}

	void Update () {
		localPosX = this.transform.localPosition.x;

		if (Input.GetKey (KeyCode.A) && isAllowedInput == true) {
			isAllowedInput = false;

			switch(this.playerCurrentLane) {

			case laneLocation.right:
				StartCoroutine (StrafeToCenter(-1));
				break;
			case laneLocation.center:
				StartCoroutine ("StrafeToLeftLane");
				break;
			default:
				isAllowedInput = true;
				break;	
			}
		}

		if (Input.GetKey (KeyCode.D) && isAllowedInput == true) {
			isAllowedInput = false;

			switch(this.playerCurrentLane) {

			case laneLocation.left:
				StartCoroutine (StrafeToCenter(1));
				break;
			case laneLocation.center:
				StartCoroutine ("StrafeToRightLane");
				break;
			default:
				isAllowedInput = true;
				break;	
			}
		}
	}

	IEnumerator StrafeToLeftLane () {
		while (localPosX > -strafeAmount) {
			transform.Translate (Vector3.right * -(Time.deltaTime * strafeSpeed));
			yield return null;
		}
		this.playerCurrentLane = laneLocation.left;
		isAllowedInput = true;
	}

	IEnumerator StrafeToCenter (int directionModifier) {
		while (true) {
			transform.Translate (Vector3.right * (directionModifier * (Time.deltaTime * strafeSpeed)));
			yield return null;
			if (this.playerCurrentLane == laneLocation.left && localPosX >= 0) {
				break;
			}
			if (this.playerCurrentLane == laneLocation.right && localPosX <= 0) {
				break;
			}

		}
		this.playerCurrentLane = laneLocation.center;
		isAllowedInput = true;
	}

	IEnumerator StrafeToRightLane () {
		while (localPosX < strafeAmount) {
			transform.Translate (Vector3.right * (Time.deltaTime * strafeSpeed));
			yield return null;
		}
		this.playerCurrentLane = laneLocation.right;
		isAllowedInput = true;
	}
}
