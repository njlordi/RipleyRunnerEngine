using UnityEngine;
using System.Collections;

/// <summary>
/// This script is attached to a box collider. 
/// The box collider is a child of the game piece 
/// that the player is walking on.
/// </summary>
public class PlayerDetector : MonoBehaviour {
	float destroyDelayInSeconds;
	PiecePlacer piecePlacerReference;
	PlayerMovement playerMovementReference;
	
	void Awake() {
		destroyDelayInSeconds = 0.5f;
		piecePlacerReference = GameObject.FindGameObjectWithTag("GameManager")
			.GetComponent<PiecePlacer>();
		playerMovementReference = GameObject.FindGameObjectWithTag("PlayerGeneralLocation").GetComponent<PlayerMovement>();
	}
	
	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player")
			SpawnNext();
	}
	
	void OnTriggerExit(Collider other) {
		if (other.tag == "Player") {
			playerMovementReference.KillCenterPlayerCoroutine();
			StartCoroutine("DisableParent");
		}
	}
	
	void SpawnNext() {
		if (piecePlacerReference != null)
			piecePlacerReference.PlaceRandomPiece(transform.parent.gameObject);
	}
	
	IEnumerator DisableParent() {
		// This should be made relative to player runSpeed later on...
		yield return new WaitForSeconds(destroyDelayInSeconds);
		transform.parent.gameObject.SetActive(false);
	}
}
