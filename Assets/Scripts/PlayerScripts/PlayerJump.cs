using UnityEngine;
using System.Collections;

public class PlayerJump : MonoBehaviour
{
    Rigidbody rb;
    //public float jumpSpeed;
    public float jumpHeight;

    Vector3 down;
    RaycastHit rh;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jumpHeight = 8;
    }

    // Update is called once per frame
    void Update()
    {

        down = this.transform.TransformDirection(Vector3.down);

        Debug.DrawLine(this.transform.position, down);

        if (IsGrounded())
            Debug.Log("Touching the ground");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector3(0, jumpHeight, 0);
        }
    }

    public bool IsGrounded()
    {
        if (Physics.Raycast(this.transform.position, down, out rh, 0.1f))
        {
            return true;
        }
        else
            return false;
    }
}
