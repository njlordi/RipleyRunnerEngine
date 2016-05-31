using UnityEngine;
using System.Collections;

public class GroundLogic : MonoBehaviour {
	
	// rotation flag, (ground probably should not rotate more than once)
	public bool hasRotated; 
	
	// Use this for initialization
	void Start () {
		hasRotated = false;
	}
	
	void Update () {
		if (!hasRotated)
			checkIfAtPointOfOrigin();
	}
	
	public bool checkIfAtPointOfOrigin() {
		if (transform.position.z <= 0) {
			Debug.Log("Just hit point of origin!");
			if (GetComponent<GroundPiece>().gp == GroundPiece.GroundPieces.right)
				GroundPiece.RotateToTurnRight();	
			hasRotated = true;	
			return true;
		} else {
			return false;
		}
	}
}
