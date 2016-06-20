using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	
	public enum MapSpawnDirection {facingZ, facingNegX, facingX};
	public static MapSpawnDirection axisDirection = MapSpawnDirection.facingZ;
	
	public static string[] pieceTagArray = new string[]{"StraightPiece", "LeftTurnPiece", "RightTurnPiece", "StraightPiece"};
	
	public static void DirectionToSpawnShiftLeft() {
		
		if (axisDirection == MapSpawnDirection.facingX) {
			axisDirection = MapSpawnDirection.facingZ;
			pieceTagArray = new string[]{"StraightPiece", "LeftTurnPiece", "RightTurnPiece", "StraightPiece"};
		} else {
			axisDirection = MapSpawnDirection.facingNegX;
			pieceTagArray = new string[]{"StraightPiece", "RightTurnPiece", "RightTurnPiece", "StraightPiece"};
		}
	}
	
	public static void DirectionToSpawnShiftRight() {
		if (axisDirection == MapSpawnDirection.facingNegX) {
			axisDirection = MapSpawnDirection.facingZ;
			pieceTagArray = new string[]{"StraightPiece", "LeftTurnPiece", "RightTurnPiece", "StraightPiece"};
		} else {
			axisDirection = MapSpawnDirection.facingX;
			pieceTagArray = new string[]{"StraightPiece", "LeftTurnPiece", "LeftTurnPiece", "StraightPiece"};
		}
	}
}
