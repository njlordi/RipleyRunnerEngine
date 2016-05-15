using UnityEngine;
using System.Collections;

public class GroundSpawner : MonoBehaviour {
	public GameObject startingGround;
	
	public GameObject straightPiece;
	public GameObject rightTurnPiece;
	public GameObject leftTurnPiece;
	public GameObject tIntersection;
	
	public const int numberOfGroundVariants = 4;
	public GameObject [] groundPool;
	
	public float groundSpeed;
	
	void Start () {
		groundPool = new GameObject[numberOfGroundVariants] {straightPiece, rightTurnPiece, leftTurnPiece, tIntersection};
		groundSpeed = 1.0f;
		startingGround.GetComponent<Ground>().speed = groundSpeed;
	}
	
	void FixedUpdate() {
		//for (int i = 0; i < numberOfGroundVariants; i++) {
			groundPool[0].gameObject.transform.Translate(-Vector3.forward * (Time.deltaTime * groundSpeed));
	//}
	}
}
