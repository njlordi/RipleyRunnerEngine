using UnityEngine;
using System.Collections;

public class DisableZone : MonoBehaviour {
	/* OBSOLETE CODE
	[Header ("Drag and Drop GroundSpawner Here:")]
	public GameObject GroundSpawnerObject;
	*/
	
	void OnTriggerEnter (Collider objectToDisable) {
		Debug.Log("Touched " + objectToDisable.gameObject);
		objectToDisable.gameObject.SetActive(false);
		/* OBSOLETE CODE
		if (objectToDisable.tag == "Ground") {
			GroundSpawnerObject.SendMessage("SpawnGround");
		}
		*/
	}
}
