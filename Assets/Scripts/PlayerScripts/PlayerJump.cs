using UnityEngine;
using System.Collections;

public class PlayerJump : MonoBehaviour
{
    Rigidbody rb;
    public float jumpHeight;
	public bool jumpInput;

	public float rayLength;
	Vector3 rayDirection;

    RaycastHit rh;

    void Start() {
        rb = GetComponent<Rigidbody>();
        jumpHeight = 8;
		rayLength = 1.5f;
    }
		
    void Update() {
		rayDirection = this.transform.TransformDirection(Vector3.down);

		Debug.DrawRay(this.transform.position, rayDirection, Color.red);

        if (IsGrounded())
            Debug.Log("Touching the ground");

		if (Input.GetKeyDown(KeyCode.Space) && jumpInput) {
			rb.velocity = new Vector3(0, jumpHeight, 0);
        }
    }

    public bool IsGrounded() {
		if (Physics.Raycast (this.transform.position, rayDirection, out rh, rayLength)) {
			
			if (rh.collider.tag == "StraightPiece") {
				jumpInput = true;
				return true;
			}
		}
			
		jumpInput = false;
		return false;
	}
}
