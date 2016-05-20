using UnityEngine;
using System.Collections;

public class GroundPiece : MonoBehaviour {
	
	public Vector3 startingPoint;
	
	public enum GroundPieces {start, straight, right, left, cross};
	public GroundPieces gp;
	
	public static float speed = 20;
	// for flagging
	//public bool hasRotated = false;
	
	void OnEnable () {
		startingPoint = new Vector3 (0, 1.0f, 40.0f);
	}	
	
	// Update is called once per frame
	void FixedUpdate () {
		
		// main movement of platform
		transform.position -= new Vector3 (0, 0, Time.deltaTime * speed);
		
		
		if (transform.position.z <= -100.0f) {
			if (gp == GroundPieces.start) {
				Destroy(gameObject);
			} else {
				gameObject.SetActive(false);
			}
		}
	}
}