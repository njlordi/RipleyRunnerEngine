using UnityEngine;
using System.Collections;

public class PlayerStrafe : MonoBehaviour
{
    public float runSpeed;

    public float strafeAmount;
    public float strafeSpeed;
    public float strafeFixedFrame;
    public float strafeDistanceFromOrigin;

    // rename these next two
    public bool strafeLeftFlag;
    public bool strafeRightFlag;

    public bool inputEnabled;

    public enum StrafeLocation { left, center, right };
    public StrafeLocation currentStrafeLocation;

    // Use this for initialization
    void Start()
    {
        strafeLeftFlag = false;
        strafeRightFlag = false;

        currentStrafeLocation = StrafeLocation.center;
        inputEnabled = true;
        strafeAmount = 8.0f;
        strafeSpeed = 20.0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        gameObject.transform.Translate(Vector3.forward * Time.deltaTime * runSpeed);

	    if (Input.GetKey(KeyCode.A) && inputEnabled == true 
		    && currentStrafeLocation != StrafeLocation.left)
        {
            strafeDistanceFromOrigin = 0;
            strafeLeftFlag = true;

        }
	    if (Input.GetKey(KeyCode.D) && inputEnabled == true 
		    && currentStrafeLocation != StrafeLocation.right)
        {
            strafeDistanceFromOrigin = 0;
            strafeRightFlag = true;
        }

        if (strafeLeftFlag == true)
        {
            StrafeLeft();
        }
        if (strafeRightFlag == true)
        {
	        StrafeRight();        
        }
    }

    public void StrafeLeft()
    {
        inputEnabled = false;
	    
	    if (strafeDistanceFromOrigin >= strafeAmount)
	    {
		    if (currentStrafeLocation == StrafeLocation.center)
			    currentStrafeLocation = StrafeLocation.left;
		    else
			    currentStrafeLocation = StrafeLocation.center;
		    
		    strafeLeftFlag = false;
		    inputEnabled = true;
	    }

        // steady movement variable
        strafeFixedFrame = Time.fixedDeltaTime * strafeSpeed;

        transform.position -= transform.right * strafeFixedFrame;
        strafeDistanceFromOrigin += strafeFixedFrame;
    }

    public void StrafeRight()
    {
	    inputEnabled = false;
	    
	    if (strafeDistanceFromOrigin >= strafeAmount)
	    {
		    if (currentStrafeLocation == StrafeLocation.center)
			    currentStrafeLocation = StrafeLocation.right;
		    else
			    currentStrafeLocation = StrafeLocation.center;
		    
		    strafeRightFlag = false;
		    inputEnabled = true;
	    }

        // steady movement variable
        strafeFixedFrame = Time.fixedDeltaTime * strafeSpeed;

        transform.position += transform.right * strafeFixedFrame;
        strafeDistanceFromOrigin += strafeFixedFrame;  
    }
}