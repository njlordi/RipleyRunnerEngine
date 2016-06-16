using UnityEngine;
using System.Collections;

public class RRE_ObjectPooler : MonoBehaviour {
	public GameObject [] StraightPiecePool;
	public GameObject [] RightTurnPiecePool;
	public GameObject [] LeftTurnPiecePool;

	// Use this for initialization
	void Start () {
		StraightPiecePool = new GameObject[] {
			(GameObject)Resources.Load("StraightPiece"), 
			(GameObject)Resources.Load("StraightPiece"), 
			(GameObject)Resources.Load("StraightPiece")
		};
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
