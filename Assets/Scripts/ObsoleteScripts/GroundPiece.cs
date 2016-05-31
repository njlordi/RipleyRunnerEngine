using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GroundPiece : MonoBehaviour {
	
	public enum GroundPieces {start, straight, right, left, cross};
	public GroundPieces gp;
	
	// these variables are used to control speed and direction
	public static float xSpeed;
	public static float zSpeed;
	
	public static List<System.Action> directionFunctions = new List<System.Action>();
	public static int directionFunctionsIter;

	
	void Awake(){
		directionFunctionsIter = 0;
		directionFunctions.Add(MoveLeft);
		directionFunctions.Add(MoveUp);
		directionFunctions.Add(MoveRight);
		directionFunctions.Add(MoveDown);
	}
	
	void FixedUpdate () {
		// main movement of platform
		transform.position += new Vector3 (Time.deltaTime * xSpeed, 0, Time.deltaTime * zSpeed);
	}
	
	public static void RotateToTurnLeft(){
		if (directionFunctionsIter != 0) {
			directionFunctionsIter--;
		} else {
			directionFunctionsIter = 3;
		}
		directionFunctions[directionFunctionsIter]();
		
	}
	
	public static void RotateToTurnRight(){
		if (directionFunctionsIter != 3) {
			directionFunctionsIter++;
		} else {
			directionFunctionsIter = 0;
		}
		directionFunctions[directionFunctionsIter]();
	}
	
		/* The following functions correspond to top down view, where compass looks like:
	           ^
	         < + Z
	           x
	*/
	public static void MoveLeft () {
		xSpeed = 0;
		zSpeed = -20;
	}
	
	public static void MoveRight () {
		xSpeed = 0;
		zSpeed = 20;
	}
	
	public static void MoveUp () {
		xSpeed = -20;
		zSpeed = 0;
	}
	
	public static void MoveDown () {
		xSpeed = 20;
		zSpeed = 0;
	}
}