using UnityEngine;
using System.Collections;

/// <summary>
/// This script is attached to a box collider. 
/// The box collider is a child of the game piece 
/// that the player is walking on.
/// </summary>
public class PlayerDetector : MonoBehaviour {

	float disableDelayInSeconds;
	float slowDisableDelayInSeconds;

	PiecePlacer piecePlacerReference;
	PlayerMovement playerMovementReference;
	
	void Awake() {
		disableDelayInSeconds = 0.5f;
		slowDisableDelayInSeconds = 4.0f;
		piecePlacerReference = GameObject.FindGameObjectWithTag("GameManager")
			.GetComponent<PiecePlacer>();
		playerMovementReference = GameObject.FindGameObjectWithTag("PlayerGeneralLocation").GetComponent<PlayerMovement>();
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player")
			SpawnNext();
	}
	
	void OnTriggerExit(Collider other) {
		if (other.tag == "Player" 
			&& (this.transform.parent.tag == "RightTurnPiece" || this.transform.parent.tag == "LeftTurnPiece")) {
			playerMovementReference.KillCenterPlayerCoroutine();
			Debug.Log ("Player-centering coroutine stopped from PlayerDetector.cs"); 
		}
		StartCoroutine("DisableParent");
	}
	
	void SpawnNext() {
		if (piecePlacerReference != null)
			piecePlacerReference.PlaceRandomPiece(transform.parent.gameObject);
	}

	/// <summary>
	/// Disables the piece the player is leaving. 
	/// Uses a delay and uses a greater delay for extra slow movement.
	/// </summary>
	IEnumerator DisableParent() {

		if (PlayerData.runSpeed <= 20) {
			yield return new WaitForSeconds (slowDisableDelayInSeconds);
			transform.parent.gameObject.SetActive (false);
		} else {
			yield return new WaitForSeconds (disableDelayInSeconds);
			transform.parent.gameObject.SetActive (false);
		}
	}
}
