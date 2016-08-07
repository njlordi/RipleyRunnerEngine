using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
	
	float turnSpeed;
	public float turnSpeedModifier;
	float degreesToTurn;
	
	Quaternion targetRotation;
	bool PlayerCurrentlyCentering;

	/* Possibly obsolete when using KillCenterPlayerCoroutine()
       or perhaps KillCenterPlayerCoroutine() should be scrapped?*/
	float playerCenteringPrecision;

	// for debugging only... delete later?
	public float OffCenterAmount;

	void Awake ()
	{
		degreesToTurn = 0.0f;
		targetRotation = Quaternion.identity;
	}

	void Start ()
	{
		playerCenteringPrecision = 0;
		PlayerCurrentlyCentering = false;
		turnSpeedModifier = 2.4f; // ... math research?
		GroundPiece.MoveLeft ();
	}

	void Update ()
	{
		turnSpeed = PlayerData.runSpeed * turnSpeedModifier;
		
		this.transform.Translate (Vector3.forward * Time.deltaTime * PlayerData.runSpeed);
		
		targetRotation = Quaternion.Euler (0.0f, degreesToTurn, 0.0f);
		
		if (this.transform.rotation == targetRotation) {
		} else {
			this.transform.rotation = Quaternion.RotateTowards (this.transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
		}
	}

	public void TurnLeft ()
	{
		degreesToTurn -= 90.0f;
	}

	public void TurnRight ()
	{
		degreesToTurn += 90.0f;
	}

	public void KillCenterPlayerCoroutine ()
	{
		if (PlayerCurrentlyCentering) {
			StopCoroutine ("CenterPlayer");
			PlayerCurrentlyCentering = false;
		}
	}

	/// <summary>
	/// This coroutine centers the player on the current piece.
	/// It is called from TurnTrigger.cs which passes the 
	/// current piece's transform.position.
	/// </summary>
	public IEnumerator CenterPlayer (Vector3 centerVector)
	{
		PlayerCurrentlyCentering = true;

		
		if (LevelManager.axisDirection == LevelManager.MapSpawnDirection.facingZ) {
			OffCenterAmount = centerVector.x - this.transform.position.x;

			while (this.transform.position.x < (centerVector.x - playerCenteringPrecision)
			       || this.transform.position.x > (centerVector.x + playerCenteringPrecision)) {
				this.transform.position = Vector3.Lerp (this.transform.position, 
					new Vector3 (centerVector.x, this.transform.position.y, this.transform.position.z), 
					Time.deltaTime * (PlayerData.runSpeed / 3.0f));
				yield return null;
			}
		} else {
			OffCenterAmount = centerVector.z - this.transform.position.z;

			while (this.transform.position.z < (centerVector.z - playerCenteringPrecision)
			       || this.transform.position.z > (centerVector.z + playerCenteringPrecision)) {
				this.transform.position = Vector3.Lerp (this.transform.position, 
					new Vector3 (this.transform.position.x, this.transform.position.y, centerVector.z), 
					Time.deltaTime * (PlayerData.runSpeed / 3.0f));
				yield return null;
			}
		}
		
		PlayerCurrentlyCentering = false;
		Debug.Log ("Player centering completed.");
	}
	
}
