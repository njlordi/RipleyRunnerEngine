using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
    public bool isTimePaused;

	public enum MapSpawnDirection {facingZ, facingNegX, facingX};
	public static MapSpawnDirection axisDirection = MapSpawnDirection.facingZ;
	
	public static string[] pieceTagArray = new string[]{"StraightPiece", "LeftTurnPiece", "RightTurnPiece", "StraightPiece", "IntersectionPiece"};
	
	public static void DirectionToSpawnShiftLeft() {
		
		if (axisDirection == MapSpawnDirection.facingX) {
			axisDirection = MapSpawnDirection.facingZ;
			pieceTagArray = new string[]{"StraightPiece", "LeftTurnPiece", "RightTurnPiece", "StraightPiece", "IntersectionPiece"};
		} else {
			axisDirection = MapSpawnDirection.facingNegX;
			pieceTagArray = new string[]{"StraightPiece", "RightTurnPiece", "RightTurnPiece", "StraightPiece", "IntersectionPiece"};
		}
	}
	
	public static void DirectionToSpawnShiftRight() {
		if (axisDirection == MapSpawnDirection.facingNegX) {
			axisDirection = MapSpawnDirection.facingZ;
			pieceTagArray = new string[]{"StraightPiece", "LeftTurnPiece", "RightTurnPiece", "StraightPiece", "IntersectionPiece"};
		} else {
			axisDirection = MapSpawnDirection.facingX;
			pieceTagArray = new string[]{"StraightPiece", "LeftTurnPiece", "LeftTurnPiece", "StraightPiece", "IntersectionPiece"};
		}
	}

    public void TimeBasedPause()
    {
        if (!isTimePaused)
        {
            Time.timeScale = 0;
            isTimePaused = true;
        }
        else
        {
            Time.timeScale = 1;
            isTimePaused = false;
        }
    }
}
