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
		strafeSpeed = 8.0f;
		strafeAmount = 4.0f;
	}

	void Update () {
		localPosX = this.transform.localPosition.x;

		if (Input.GetKey (KeyCode.A) && isAllowedInput == true) {
			isAllowedInput = false;

			switch(this.playerCurrentLane) {

			case laneLocation.right:
				StartCoroutine ("StrafeToCenter");
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
				StartCoroutine ("StrafeToCenter");
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
		while (this.transform.localPosition.x > -strafeAmount) {
			transform.Translate (Vector3.right * -(Time.deltaTime * strafeSpeed));
			yield return null;
		}
		this.playerCurrentLane = laneLocation.left;
		isAllowedInput = true;
	}

	IEnumerator StrafeToCenter () {
		float tempX;

		while (!Mathf.Approximately(this.transform.localPosition.x, 0)) {

			tempX = Mathf.Lerp (this.transform.localPosition.x, 0, Time.deltaTime * strafeSpeed);
			this.transform.position = new Vector3 (tempX, this.transform.position.y, this.transform.position.z);
			yield return null;
		}
		this.playerCurrentLane = laneLocation.center;
		isAllowedInput = true;
	}

	IEnumerator StrafeToRightLane () {
		while (this.transform.localPosition.x < strafeAmount) {
			transform.Translate (Vector3.right * (Time.deltaTime * strafeSpeed));
			yield return null;
		}
		this.playerCurrentLane = laneLocation.right;
		isAllowedInput = true;
	}
}
