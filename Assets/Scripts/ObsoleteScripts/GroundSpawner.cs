﻿using UnityEngine;
using System.Collections;

public class GroundSpawner : MonoBehaviour {
	public GameObject startingGround;
	
	public GameObject straightPiece;
	public GameObject rightTurnPiece;
	public GameObject leftTurnPiece;
	public GameObject tIntersection;
	
	public const int numberOfGroundVariants = 4;
	public GameObject [] groundPool;
	
	public float groundSpeed;
	
	void Start () {
		groundPool = new GameObject[numberOfGroundVariants] {straightPiece, rightTurnPiece, leftTurnPiece, tIntersection};
		groundSpeed = 40f;
	}
}
