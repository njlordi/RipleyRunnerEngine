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
	
	public int universalPoolSize;
	
	public GameObject [] StraightPiecePool;
	public GameObject [] LeftTurnPiecePool;
	public GameObject [] RightTurnPiecePool;
	
	void Awake() {

		universalPoolSize = 4;
		
		StraightPiecePool = new GameObject[universalPoolSize];
		LeftTurnPiecePool = new GameObject[universalPoolSize];
		RightTurnPiecePool = new GameObject[universalPoolSize];
		
		for (int i = 0; i < universalPoolSize; i++) {
			StraightPiecePool[i] = (GameObject)Instantiate(StraightPiece);
			StraightPiecePool[i].SetActive(false);
			LeftTurnPiecePool[i] = (GameObject)Instantiate(LeftTurnPiece);
			LeftTurnPiecePool[i].SetActive(false);
			RightTurnPiecePool[i] = (GameObject)Instantiate(RightTurnPiece);
			RightTurnPiecePool[i].SetActive(false);
		}
	}
	
	// make this static later??? that would be best
	public void PlaceRandomPiece(GameObject previousPiece) {
		if (previousPiece.tag == "StraightPiece") {
			PlacePieceStraightAhead(previousPiece, GetRandomPiece());
		} else if (previousPiece.tag == "LeftTurnPiece") {
			GameManager.DirectionToSpawnShiftLeft();
			PlacePieceOnTheLeft(previousPiece, GetRandomPiece());
		} else if (previousPiece.tag == "RightTurnPiece") {
			GameManager.DirectionToSpawnShiftRight();
			PlacePieceOnTheRight(previousPiece, GetRandomPiece());
		}
	}
	
	GameObject GetRandomPiece(){
		int randArrayIndex = Random.Range(0, 4);
		string pieceSelection = GameManager.pieceTagArray[randArrayIndex];
		GameObject randomPieceToPlace;
		
		switch(pieceSelection) {
		case "StraightPiece":
			return GetPooledStraightPiece();
			break;
			
		case "LeftTurnPiece":
			return GetPooledLeftTurnPiece();
			break;
			
		case "RightTurnPiece":
			return GetPooledRightTurnPiece();
			break;
		default:
			return null;
			break;
		}
	}
	
	/// <summary>
	/// Place a piece that would fit at the end of a straight piece.
	/// </summary>
	/// <param name="previousPiece">Straight-Piece that triggered this piece to be placed</param>
	/// <param name="nextPiece">Piece to be placed and enabled</param>
	public void PlacePieceStraightAhead(GameObject previousPiece, GameObject nextPiece) {
		nextPiece.transform.position = previousPiece.transform.position + previousPiece.transform.forward * 100.0f; 
		nextPiece.transform.rotation = previousPiece.transform.rotation;
		nextPiece.SetActive(true);
	}
	
	/// <summary>
	/// Place a piece that would fit at the end of a left-turn piece.
	/// </summary>
	/// <param name="previousPiece">Left-Turn-Piece that triggered this piece to be placed</param>
	/// <param name="nextPiece">Piece to be placed and enabled</param>
	public void PlacePieceOnTheLeft(GameObject previousPiece, GameObject nextPiece) {
		nextPiece.transform.position = previousPiece.transform.position - previousPiece.transform.right * 100.0f; 
		nextPiece.transform.rotation = previousPiece.transform.rotation
			* Quaternion.AngleAxis(-90f, Vector3.up);
		nextPiece.SetActive(true);
	}
	
	/// <summary>
	/// Place a piece that would fit at the end of a right-turn piece.
	/// </summary>
	/// <param name="previousPiece">Right-Turn-Piece that triggered this piece to be placed</param>
	/// <param name="nextPiece">Piece to be placed and enabled</param>
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
		Debug.Log("Getting straight piece.");
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
}
