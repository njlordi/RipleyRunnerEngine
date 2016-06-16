using UnityEngine;
using System.Collections;

/// <summary>
/// Places pieces adjacent to passed Transform
/// (Uses object pooling)
/// </summary>
public class PiecePlacer : MonoBehaviour {
	public GameObject [] StraightPiecePool;
	
	public GameObject [] LeftTurnPiecePool;
	
	public GameObject [] RightTurnPiecePool;
	
	void Awake() {
		
		StraightPiecePool = new GameObject[] 
		{
			(GameObject)Resources.Load("StraightPiece"), 
			(GameObject)Resources.Load("StraightPiece"), 
			(GameObject)Resources.Load("StraightPiece")
		};
		LeftTurnPiecePool = new GameObject[] 
		{
			(GameObject)Resources.Load("LeftTurnPiece"), 
			(GameObject)Resources.Load("LeftTurnPiece"), 
			(GameObject)Resources.Load("LeftTurnPiece")
		};
		RightTurnPiecePool = new GameObject[] 
		{
			(GameObject)Resources.Load("RightTurnPiece"), 
			(GameObject)Resources.Load("RightTurnPiece"), 
			(GameObject)Resources.Load("RightTurnPiece")
		};
	}
	
	public void PlaceNextPiece(Transform pieceToAttachTo) {
		
	}
}
