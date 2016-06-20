using UnityEngine;
using System.Collections;

public class TurnTrigger : MonoBehaviour {
	
	void OnTriggerEnter(Collider other) {
		if (other.transform.parent.tag == "PlayerGeneralLocation"
		&& this.transform.parent.tag == "LeftTurnPiece") {
			other.GetComponentInParent<PlayerMovement>().TurnLeft();
		}
		if (other.transform.parent.tag == "PlayerGeneralLocation"
		&& this.transform.parent.tag == "RightTurnPiece") {
			other.GetComponentInParent<PlayerMovement>().TurnRight();
		}
	}
	
	void OnTriggerExit(Collider other) {
		if (other.tag == "Player") {
			other.GetComponentInParent<PlayerMovement>()
				.StartCoroutine("CenterPlayer", transform.parent.position);
		}
	}
}
