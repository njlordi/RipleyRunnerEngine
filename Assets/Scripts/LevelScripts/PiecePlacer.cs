using UnityEngine;
using System.Collections;

/// <summary>
/// Places pieces adjacent to passed Transform
/// (Uses object pooling)
/// </summary>
public class PiecePlacer : MonoBehaviour {
	
	public GameObject StraightPiece;
	public GameObject LeftTurnPiece;
	public GameObject RightTurnPiece;
	
	public GameObject [] StraightPiecePool;
	public GameObject [] LeftTurnPiecePool;
	public GameObject [] RightTurnPiecePool;
	
	void Awake() {
		StraightPiecePool = new GameObject[] 
		{
			(GameObject)Instantiate(StraightPiece), 
			(GameObject)Instantiate(StraightPiece), 
			(GameObject)Instantiate(StraightPiece)
		};
		LeftTurnPiecePool = new GameObject[] 
		{
			(GameObject)Instantiate(LeftTurnPiece), 
			(GameObject)Instantiate(LeftTurnPiece), 
			(GameObject)Instantiate(LeftTurnPiece)
		};
		RightTurnPiecePool = new GameObject[] 
		{
			(GameObject)Instantiate(RightTurnPiece), 
			(GameObject)Instantiate(RightTurnPiece), 
			(GameObject)Instantiate(RightTurnPiece)
		};
		
		// Disable each piece in each pool
		foreach (GameObject go in StraightPiecePool)
			go.SetActive(false);
		foreach (GameObject go in LeftTurnPiecePool)
			go.SetActive(false);
		foreach (GameObject go in RightTurnPiecePool)
			go.SetActive(false);
	}
	
	public void PlaceRandomPiece(GameObject previousPiece) {
		PlaceStraightPiece(previousPiece);
	}
	
	public void PlaceStraightPiece(GameObject previousPiece) {
		GameObject nextPiece = GetPooledStraightPiece();
		Debug.Log("Enabling and placing straight piece.");
		nextPiece.SetActive(true);
		nextPiece.transform.position = previousPiece.transform.forward
			+ (previousPiece.transform.forward* 100.0f); 
		nextPiece.transform.rotation = previousPiece.transform.rotation;
	}
	
	public GameObject GetPooledStraightPiece() {
		for (int i = 0; i < StraightPiecePool.Length; i++)
		{
			if(!StraightPiecePool[i].activeInHierarchy) {
				return StraightPiecePool[i];
			}
		}
		return null;
	}
	public GameObject GetPooledLeftTurnPiece() {
		for (int i = 0; i < LeftTurnPiecePool.Length; i++)
		{
			if(!LeftTurnPiecePool[i].activeInHierarchy) {
				return LeftTurnPiecePool[i];
			}
		}
		return null;
	}
	public GameObject GetPooledRightTurnPiece() {
		for (int i = 0; i < RightTurnPiecePool.Length; i++)
		{
			if(!RightTurnPiecePool[i].activeInHierarchy) {
				return RightTurnPiecePool[i];
			}
		}
		return null;
	}
}
