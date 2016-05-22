using UnityEngine;
using System.Collections;

public class GroundPiece : MonoBehaviour {
	
	public Vector3 startingPoint;
	
	public enum GroundPieces {start, straight, right, left, cross};
	public GroundPieces gp;
	
	// these variables are used to control speed and direction
	public static float xSpeed;
	public static float zSpeed;
	
	void OnEnable () {
		startingPoint = new Vector3 (0, 1.0f, 40.0f);
		//moveRight();
	}	
	
	void Update () {
		
		// main movement of platform
		transform.position += new Vector3 (Time.deltaTime * xSpeed, 0, Time.deltaTime * zSpeed);
	}
	
	/* The following functions correspond to top down view, where compass looks like:
	           ^
	         < + Z
	           x
	*/
	public static void moveLeft () {
		xSpeed = 0;
		zSpeed = -20;
	}
	
	public static void moveRight () {
		xSpeed = 0;
		zSpeed = 20;
	}
	
	public static void moveUp () {
		xSpeed = -20;
		zSpeed = 0;
	}
	
	public static void moveDown () {
		xSpeed = 20;
		zSpeed = 0;
	}
}