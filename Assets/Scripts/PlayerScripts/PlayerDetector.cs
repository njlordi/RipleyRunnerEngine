using UnityEngine;
using System.Collections;

public class PlayerDetector : MonoBehaviour {
	
	public string currentPieceTag;
	GameObject go;
	GameObject go2;
	float destroyDelayInSeconds;
	
	public int randArrayIndex;
	string pieceSelection;
	
	void Awake() {
		// Get tag from parent
		currentPieceTag = transform.parent.gameObject.tag;
		
		randArrayIndex = 0;
		pieceSelection = GameManager.pieceTagArray[randArrayIndex];
		
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
			destroyParent();
		}
	}

	void destroyParent() {
		Debug.Log("Destroying...");
		Destroy(transform.parent.gameObject, destroyDelayInSeconds);
	}
	
	void spawnNext() {
		randArrayIndex = Random.Range(0, 4);
		pieceSelection = GameManager.pieceTagArray[randArrayIndex];
		
		switch(currentPieceTag) {
				
		case "StraightPiece":	// YOU WALKED ONTO A STRAIGHT PIECE SO.....
			go = (GameObject)Instantiate(Resources.Load(pieceSelection), 
				transform.parent.position + transform.parent.forward * 100.0f, 
				transform.parent.rotation);
			break;
			
		case "LeftTurnPiece":   // YOU WALKED ONTO A LEFT ANGLE PIECE SO.....
			GameManager.DirectionToSpawnShiftLeft();
			pieceSelection = GameManager.pieceTagArray[randArrayIndex];
			go = (GameObject)Instantiate(Resources.Load(pieceSelection), 
				transform.parent.position - transform.parent.right * 100.0f, 
				transform.parent.rotation * Quaternion.AngleAxis(-90f, Vector3.up));
			break;
			
		case "RightTurnPiece":  // YOU WALKED ONTO A RIGHT ANGLE PIECE SO.....
			GameManager.DirectionToSpawnShiftRight();
			pieceSelection = GameManager.pieceTagArray[randArrayIndex];
			go = (GameObject)Instantiate(Resources.Load(pieceSelection), 
				transform.parent.position + transform.parent.right * 100.0f, 
				transform.parent.rotation * Quaternion.AngleAxis(90f, Vector3.up));
			break;
			
		case "tIntersectionPiece": // focus on this later!
			go = (GameObject)Instantiate(Resources.Load(pieceSelection), 
				transform.parent.position - transform.parent.right * 100.0f, 
				transform.parent.rotation * Quaternion.AngleAxis(-90f, Vector3.up));
			
			go2 = (GameObject)Instantiate(Resources.Load(pieceSelection), 
				transform.parent.position + transform.parent.right * 100.0f, 
				transform.parent.rotation * Quaternion.AngleAxis(90f, Vector3.up));
			
			//GameManager.axisDirection = GameManager.MapSpawnDirection.tBranch;
			break;
			
		default:
			break;
		}
	}
}
