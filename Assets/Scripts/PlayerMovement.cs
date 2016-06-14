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
		turnSpeed = runSpeed * 6.0f;
		
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
	
	public void KillCenterPlayerCoroutine() {
		StopAllCoroutines();
	}
	
	/// <summary>
	/// This coroutine centers the player on the current piece so it's not 
	/// </summary>
	/// <param name="centerVector"></param>
	/// <returns></returns>
	public IEnumerator CenterPlayer(Vector3 centerVector) {
		
		if (GameManager.axisDirection == GameManager.MapSpawnDirection.facingZ)
		{
			Debug.Log("Lerping player towards target X value");
			while (transform.position.x < (centerVector.x - 0.1f) 
				|| transform.position.x > (centerVector.x + 0.1f))  
			{
				Debug.Log("Lerp Frames to X");
				transform.position = Vector3.Lerp(transform.position, new Vector3(centerVector.x, this.transform.position.y, this.transform.position.z), Time.deltaTime * (runSpeed / 12.0f));
				yield return null;
			}
		}
		else
		{
			Debug.Log("Lerping player towards target Z value");
			while (transform.position.x < (centerVector.z - 0.1f) 
				|| transform.position.x > (centerVector.z + 0.1f)) {
				Debug.Log("Lerp Frames to X");
				transform.position = Vector3.Lerp(transform.position, new Vector3(this.transform.position.x, this.transform.position.y, centerVector.z), Time.deltaTime * (runSpeed / 12.0f));
				yield return null;
			}
		}
		Debug.Log("Player centering completed.");
	}
	
}
