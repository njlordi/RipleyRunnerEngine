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
		targetRotation = Quaternion.identity;
	}
	
	void Start() {
		turnInputEnabled = true;
		GroundPiece.MoveLeft();
	}
	
	void Update () {
		turnSpeed = runSpeed * 5.0f;
		
		this.transform.Translate(Vector3.forward * Time.deltaTime * runSpeed);
		
		targetRotation = Quaternion.Euler(0.0f, degreesToTurn, 0.0f);
		
		if (this.transform.rotation == targetRotation) {
			turnInputEnabled = true; //remove?
		} else {
			this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
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
	/// This coroutine centers the player on the current piece.
	/// It is called from TurnTrigger.cs which passes the current piece
	/// (it's parent's) transform.position.
	/// </summary>
	public IEnumerator CenterPlayer(Vector3 centerVector) {
		
		if (GameManager.axisDirection == GameManager.MapSpawnDirection.facingZ)
		{
			Debug.Log("Lerping player towards target X value");
			while (this.transform.position.x < (centerVector.x - 0.1f) 
				|| this.transform.position.x > (centerVector.x + 0.1f))  
			{
				Debug.Log("Lerp Frames to X");
				this.transform.position = Vector3.Lerp(this.transform.position, new Vector3(centerVector.x, this.transform.position.y, this.transform.position.z), Time.deltaTime * (runSpeed / 12.0f));
				yield return null;
			}
		}
		else
		{
			Debug.Log("Lerping player towards target Z value");
			while (this.transform.position.z < (centerVector.z - 0.1f) 
				|| this.transform.position.z > (centerVector.z + 0.1f)) {
				Debug.Log("Lerp Frames to X");
				this.transform.position = Vector3.Lerp(this.transform.position, new Vector3(this.transform.position.x, this.transform.position.y, centerVector.z), Time.deltaTime * (runSpeed / 12.0f));
				yield return null;
			}
		}
		Debug.Log("Player centering completed.");
	}
	
}
