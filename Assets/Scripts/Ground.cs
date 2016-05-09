using UnityEngine;
using System.Collections;

public class Ground : MonoBehaviour {
	public Vector3 StartingPoint;
	public float speed;
	
	void OnEnable () {
		StartingPoint = transform.position;
	}
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(-Vector3.forward * (Time.deltaTime * speed));
	}
	
	void OnDisable() {
		transform.position = StartingPoint;
	}
}
