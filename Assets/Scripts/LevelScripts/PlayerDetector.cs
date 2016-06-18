using UnityEngine;
using System.Collections;

public class PlayerDetector : MonoBehaviour {
	float destroyDelayInSeconds;
	
	void Awake() {
		destroyDelayInSeconds = 0.5f;
	}
	
	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player")
			spawnNext();
	}
	
	void OnTriggerExit(Collider other) {
		if (other.tag == "Player") {
			Debug.Log ("Stopping centering coroutine in PlayerMovement script.");
			other.GetComponentInParent<PlayerMovement>().KillCenterPlayerCoroutine();
			StartCoroutine("DisableParent");
		}
	}
	
	void spawnNext() {
		// BAD CODE... REWRITE
		GameObject.FindGameObjectWithTag("GameManager")
				.GetComponent<PiecePlacer>().PlaceRandomPiece(transform.parent.gameObject);

	}
	
	IEnumerator DisableParent() {
		// This should be made relative to player runSpeed later on...
		yield return new WaitForSeconds(destroyDelayInSeconds);
		Debug.Log("Disabling piece...");
		transform.parent.gameObject.SetActive(false);
	}
}
