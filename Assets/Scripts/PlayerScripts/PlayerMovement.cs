using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	public float runSpeed;
	public float turnSpeed;
	float degreesToTurn;
	
	Quaternion targetRotation;
	public bool turnInputEnabled;
	bool PlayerCurrentlyCentering;
	
	void Awake () {
		degreesToTurn = 0.0f;
		targetRotation = Quaternion.identity;
	}
	
	void Start() {
		PlayerCurrentlyCentering = false;
		turnInputEnabled = true;
		GroundPiece.MoveLeft();
	}
	
	void Update () {
		turnSpeed = runSpeed * 5.0f;
		
		this.transform.Translate(Vector3.forward * Time.deltaTime * runSpeed);
		
		targetRotation = Quaternion.Euler(0.0f, degreesToTurn, 0.0f);
		
		if (this.transform.rotation == targetRotation) {
			turnInputEnabled = true;
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
		if (PlayerCurrentlyCentering) {
			StopCoroutine("CenterPlayer");
			Debug.Log("Cancelling CenterPlayer coroutine.");
			PlayerCurrentlyCentering = false;
		}
	}
	
	/// <summary>
	/// This coroutine centers the player on the current piece.
	/// It is called from TurnTrigger.cs which passes the 
	/// current piece's transform.position.
	/// </summary>
	public IEnumerator CenterPlayer(Vector3 centerVector) {
		PlayerCurrentlyCentering = true;
		
		if (GameManager.axisDirection == GameManager.MapSpawnDirection.facingZ) {
			Debug.Log("Lerping player towards target X value");
			while (this.transform.position.x < (centerVector.x - 0.1f) 
				|| this.transform.position.x > (centerVector.x + 0.1f)) {
				Debug.Log("Lerp Frames to X");
				this.transform.position = Vector3.Lerp(this.transform.position, new Vector3(centerVector.x, this.transform.position.y, this.transform.position.z), Time.deltaTime * (runSpeed / 5.0f));
				yield return null;
			}
		} else {
			Debug.Log("Lerping player towards target Z value");
			while (this.transform.position.z < (centerVector.z - 0.1f) 
				|| this.transform.position.z > (centerVector.z + 0.1f)) {
				Debug.Log("Lerp Frames to X");
				this.transform.position = Vector3.Lerp(this.transform.position, new Vector3(this.transform.position.x, this.transform.position.y, centerVector.z), Time.deltaTime * (runSpeed / 5.0f));
				yield return null;
			}
		}
		
		PlayerCurrentlyCentering = false;
		Debug.Log("Player centering completed.");
	}
	
}
