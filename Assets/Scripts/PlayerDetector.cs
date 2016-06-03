using UnityEngine;
using System.Collections;

public class PlayerDetector : MonoBehaviour {
	
	public string currentPieceTag;
	public int randArrayIndex;
	GameObject go;
	GameObject go2;
	float destroyDelayInSeconds;
	
	void Awake() {
		// Get tag from parent
		currentPieceTag = transform.parent.gameObject.tag;
		
		destroyDelayInSeconds = 0.5f;
	}
	
	void OnTriggerEnter() {
		spawnNext();
	}
	
	void OnTriggerExit() {
		destroyParent();
	}

	void destroyParent() {
		Debug.Log("Destroying...");
		Destroy(transform.parent.gameObject, destroyDelayInSeconds);
	}
	
	void spawnNext() {
		string[] pieceTagArray = new string[]{"StraightPiece", "LeftTurnPiece", "RightTurnPiece", "tIntersectionPiece"};
		randArrayIndex = Random.Range(0, 4);
		string pieceSelection = pieceTagArray[randArrayIndex];
		
		switch(currentPieceTag) {
		case "StraightPiece":	
			go = (GameObject)Instantiate(Resources.Load(pieceSelection), 
				transform.parent.position + transform.parent.forward * 100.0f, 
				transform.parent.rotation);
			break;
			
		case "LeftTurnPiece":
			go = (GameObject)Instantiate(Resources.Load(pieceSelection), 
				transform.parent.position - transform.parent.right * 100.0f, 
				transform.parent.rotation * Quaternion.AngleAxis(-90f, Vector3.up));
				
			break;
			
		case "RightTurnPiece":
			go = (GameObject)Instantiate(Resources.Load(pieceSelection), 
				transform.parent.position + transform.parent.right * 100.0f, 
				transform.parent.rotation * Quaternion.AngleAxis(90f, Vector3.up));
				
			break;
			
		case "tIntersectionPiece":
			go = (GameObject)Instantiate(Resources.Load(pieceSelection), 
				transform.parent.position - transform.parent.right * 100.0f, 
				transform.parent.rotation * Quaternion.AngleAxis(-90f, Vector3.up));
			
			go2 = (GameObject)Instantiate(Resources.Load(pieceSelection), 
				transform.parent.position + transform.parent.right * 100.0f, 
				transform.parent.rotation * Quaternion.AngleAxis(90f, Vector3.up));
			
			break;
			
		default:
			break;
		}
	}
}
