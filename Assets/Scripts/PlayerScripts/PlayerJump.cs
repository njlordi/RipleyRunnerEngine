using UnityEngine;
using System.Collections;

public class PlayerJump : MonoBehaviour {
	Rigidbody rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			rb.velocity = new Vector3 (0, 10, 0);
		}
	}
}
