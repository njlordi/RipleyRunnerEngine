using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	
	public enum MapSpawnDirection {facingZ, facingNegX, facingX, tBranch};
	public static MapSpawnDirection axisDirection;
	
	public static string[] pieceTagArray = new string[]{"StraightPiece", "LeftTurnPiece", "RightTurnPiece", "StraightPiece"};
	
	// Update is called every frame, if the MonoBehaviour is enabled.
	void Start()
	{
		// Game starts building towards Z
		axisDirection = MapSpawnDirection.facingZ;
	}
	
	public static void DirectionToSpawnShiftLeft() {
		
		if (axisDirection == MapSpawnDirection.facingX) {
			axisDirection = MapSpawnDirection.facingZ;
			pieceTagArray = new string[]{"StraightPiece", "LeftTurnPiece", "RightTurnPiece", "StraightPiece"};
		} else {
			axisDirection = MapSpawnDirection.facingNegX;
			pieceTagArray = new string[]{"StraightPiece", "StraightPiece", "RightTurnPiece", "StraightPiece"};
		}
	}
	
	public static void DirectionToSpawnShiftRight() {
		if (axisDirection == MapSpawnDirection.facingNegX) {
			axisDirection = MapSpawnDirection.facingZ;
			pieceTagArray = new string[]{"StraightPiece", "LeftTurnPiece", "RightTurnPiece", "StraightPiece"};
		} else {
			axisDirection = MapSpawnDirection.facingX;
			pieceTagArray = new string[]{"StraightPiece", "StraightPiece", "LeftTurnPiece", "StraightPiece"};
		}
	}
}
