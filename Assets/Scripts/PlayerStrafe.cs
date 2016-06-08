using UnityEngine;
using System.Collections;

public class PlayerStrafe : MonoBehaviour {
	public float runSpeed;
	
	public float strafeAmount;
	public float strafeSpeed;
	public float strafeFixedFrame;
	public float strafeDistanceFromOrigin;
	
	// rename these next two
	public bool strafeLeftFlag;
	public bool strafeRightFlag;
	
	public bool inputEnabled;
	
	public enum StrafeLocation {left, center, right};
	public StrafeLocation currentStrafeLocation;
	
	// Use this for initialization
	void Start () {
		currentStrafeLocation = StrafeLocation.center;
		inputEnabled = true;
		strafeAmount = 8.0f;
		strafeSpeed = 20.0f;
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.Translate(Vector3.forward * Time.deltaTime * runSpeed);
		
		if (Input.GetKey(KeyCode.A) && inputEnabled == true) {
			StartCoroutine("strafeLeft");
		}
		if (Input.GetKey(KeyCode.D) && inputEnabled == true) {
			StartCoroutine("strafeRight");	
		}
		
		if (playerStrafingFlag == true) {
			
			playerStrafingFlag = false;
		}
	}
	
	// DITCH THE COROUTINES
	
	IEnumerator strafeLeft() {
		Debug.Log("A Key pressed");
		inputEnabled = false;
		strafeDistanceFromOrigin = 0;
		
		while (strafeDistanceFromOrigin < strafeAmount) {
			strafeFixedFrame = Time.deltaTime * strafeSpeed;
			transform.position -= transform.right * strafeFixedFrame;
			strafeDistanceFromOrigin += strafeFixedFrame;
			yield return null;
		}
		if (currentStrafeLocation == StrafeLocation.center)
			currentStrafeLocation = StrafeLocation.left;
		else
			currentStrafeLocation = StrafeLocation.center;
		inputEnabled = true;
	}
	IEnumerator strafeRight() {
		Debug.Log("D Key pressed");
		inputEnabled = false;
		strafeDistanceFromOrigin = 0;
		
		while (strafeDistanceFromOrigin < strafeAmount) {
			strafeFixedFrame = Time.deltaTime * strafeSpeed;
			transform.position += transform.right * strafeFixedFrame;
			strafeDistanceFromOrigin += strafeFixedFrame;
			yield return null;
		}
		if (currentStrafeLocation == StrafeLocation.center)
			currentStrafeLocation = StrafeLocation.right;
		else
			currentStrafeLocation = StrafeLocation.center;
		inputEnabled = true;
	}
}
