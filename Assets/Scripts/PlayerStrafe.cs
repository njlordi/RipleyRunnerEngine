using UnityEngine;
using System.Collections;

public class PlayerStrafe : MonoBehaviour {
	public float runSpeed;
	
	public float strafeAmount;
	public float strafeSpeed;
	public float strafeFixedFrame;
	public float strafeDistanceFromOrigin;
	
	public bool inputEnabled;
	
	// Use this for initialization
	void Start () {
		inputEnabled = true;
		strafeAmount = 8.0f;
		strafeSpeed = 20.0f;
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.Translate(Vector3.forward * Time.deltaTime * runSpeed);
		
		if (Input.GetKey(KeyCode.D) && inputEnabled == true) {
			StartCoroutine("moveRight");	
		}
	}
	
	IEnumerator moveRight() {
		Debug.Log("D Key pressed");
		inputEnabled = false;
		strafeDistanceFromOrigin = 0;

		while (strafeDistanceFromOrigin < strafeAmount) {
			strafeFixedFrame = Time.deltaTime * strafeSpeed;
			transform.position += transform.right * strafeFixedFrame;
			strafeDistanceFromOrigin += strafeFixedFrame;
			yield return null;
		}
		
		inputEnabled = true;
	}
}
