using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	
	public float runSpeed;
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.Translate(Vector3.forward * Time.deltaTime * runSpeed);
	}
}
