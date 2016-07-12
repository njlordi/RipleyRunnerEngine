using UnityEngine;
using System.Collections;

/// <summary>
/// Places pieces adjacent to passed GameObject
/// (Uses object pooling)
/// </summary>
public class PiecePlacer : MonoBehaviour {
	
	public GameObject StraightPiece;
	public GameObject LeftTurnPiece;
	public GameObject RightTurnPiece;
    public GameObject IntersectionPiece;

    public int universalPoolSize;
	public GameObject [] StraightPiecePool;
	public GameObject [] LeftTurnPiecePool;
	public GameObject [] RightTurnPiecePool;
    public GameObject [] IntersectionPiecePool;

	// does what it says, this is used to test intersection pieces in the game world
	public bool onlyIntersectionPieces;

    void Awake() {

		universalPoolSize = 4;
		
		StraightPiecePool = new GameObject[universalPoolSize];
		LeftTurnPiecePool = new GameObject[universalPoolSize];
		RightTurnPiecePool = new GameObject[universalPoolSize];
        IntersectionPiecePool = new GameObject[universalPoolSize];

		for (int i = 0; i < universalPoolSize; i++) {
            StraightPiecePool[i] = (GameObject)Instantiate(StraightPiece);
            StraightPiecePool[i].SetActive(false);
			LeftTurnPiecePool[i] = (GameObject)Instantiate(LeftTurnPiece);
			LeftTurnPiecePool[i].SetActive(false);
			RightTurnPiecePool[i] = (GameObject)Instantiate(RightTurnPiece);
			RightTurnPiecePool[i].SetActive(false);
            IntersectionPiecePool[i] = (GameObject)Instantiate(IntersectionPiece);
            IntersectionPiecePool[i].SetActive(false);
        }
	}
	
	// make this static later??? that would be best
	public void PlaceRandomPiece(GameObject previousPiece) {
		if (previousPiece.tag == "StraightPiece") {
			PlacePieceStraightAhead(previousPiece, GetValidRandomPiece());
		} else if (previousPiece.tag == "LeftTurnPiece") {
			GameManager.DirectionToSpawnShiftLeft();
			PlacePieceOnTheLeft(previousPiece, GetValidRandomPiece());
		} else if (previousPiece.tag == "RightTurnPiece") {
			GameManager.DirectionToSpawnShiftRight();
			PlacePieceOnTheRight(previousPiece, GetValidRandomPiece());
		}
	}
	
    /// <summary>
    /// Returns a random piece based on which direction the level is building towards.
    /// (TYPE OF PIECE IS DETERMINED BY GAMEMANAGER.CS)
    /// </summary>
	GameObject GetValidRandomPiece(){

		int randArrayIndex;

		if (onlyIntersectionPieces) {
			randArrayIndex = 4;
		} else {
		 	randArrayIndex = Random.Range(0, 5);
		}

		string pieceSelection = GameManager.pieceTagArray[randArrayIndex];
		
		switch(pieceSelection) {
		case "StraightPiece":
			return GetPooledStraightPiece();
			
		case "LeftTurnPiece":
			return GetPooledLeftTurnPiece();
			
		case "RightTurnPiece":
			return GetPooledRightTurnPiece();

		case "IntersectionPiece":
			return GetPooledIntersectionPiece();
		default:
			return null;
		}
	}
	
	/// <summary>
	/// Place a piece that would fit at the end of a straight piece.
	/// </summary>
	public void PlacePieceStraightAhead(GameObject previousPiece, GameObject nextPiece) {
		nextPiece.transform.position = previousPiece.transform.position + previousPiece.transform.forward * 100.0f; 
		nextPiece.transform.rotation = previousPiece.transform.rotation;
		nextPiece.SetActive(true);
	}
	
	/// <summary>
	/// Place a piece that would fit at the end of a left-turn piece.
	/// </summary>
	public void PlacePieceOnTheLeft(GameObject previousPiece, GameObject nextPiece) {
		nextPiece.transform.position = previousPiece.transform.position - previousPiece.transform.right * 100.0f; 
		nextPiece.transform.rotation = previousPiece.transform.rotation
			* Quaternion.AngleAxis(-90f, Vector3.up);
		nextPiece.SetActive(true);
	}
	
	/// <summary>
	/// Place a piece that would fit at the end of a right-turn piece.
	/// </summary>
	public void PlacePieceOnTheRight(GameObject previousPiece, GameObject nextPiece) {
		nextPiece.transform.position = previousPiece.transform.position + previousPiece.transform.right * 100.0f; 
		nextPiece.transform.rotation = previousPiece.transform.rotation
			* Quaternion.AngleAxis(90f, Vector3.up);
		nextPiece.SetActive(true);
	}
	
	/// <summary>
	/// Fetches a Straight-Piece from the pool.
	/// </summary>
	public GameObject GetPooledStraightPiece() {
		for (int i = 0; i < StraightPiecePool.Length; i++) {
			if(!StraightPiecePool[i].activeInHierarchy) {
				return StraightPiecePool[i];
			}
		}
		return null;
	}
	/// <summary>
	/// Fetches a Left-Turn-Piece from the pool.
	/// </summary>
	public GameObject GetPooledLeftTurnPiece() {
		for (int i = 0; i < LeftTurnPiecePool.Length; i++) {
			if(!LeftTurnPiecePool[i].activeInHierarchy) {
				return LeftTurnPiecePool[i];
			}
		}
		return null;
	}
	/// <summary>
	/// Fetches a Right-Turn-Piece from the pool.
	/// </summary>
	public GameObject GetPooledRightTurnPiece() {
		for (int i = 0; i < RightTurnPiecePool.Length; i++) {
			if(!RightTurnPiecePool[i].activeInHierarchy) {
				return RightTurnPiecePool[i];
			}
		}
		return null;
	}

	public GameObject GetPooledIntersectionPiece() {
		for (int i = 0; i <  IntersectionPiecePool.Length; i++) {
			if(! IntersectionPiecePool[i].activeInHierarchy) {
				return  IntersectionPiecePool[i];
			}
		}
		return null;
	}
}
