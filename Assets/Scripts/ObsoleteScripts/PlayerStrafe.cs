// Written by Nick L.
// Code for strafing in the RipleyRunner Engine
using UnityEngine;
using System.Collections;

public class PlayerStrafe : MonoBehaviour
{
    public float runSpeed;

    public float strafeAmount;
    public float strafeSpeed;
	public float strafeFixedFrame;
	public float myDeltaTime;
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
	    // for debugging, erase later
	    myDeltaTime = Time.fixedDeltaTime;
	    
	    // steady movement variable
	    strafeFixedFrame = strafeSpeed * Time.fixedDeltaTime;
	    
	    gameObject.transform.Translate(Vector3.forward * Time.fixedDeltaTime * runSpeed);

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
	    // disable keyboard input while strafing
	    inputEnabled = false;
	    
        // move the player to it's relative left
        transform.position -= transform.right * strafeFixedFrame;
	    
	    // keep track of how much movement has happened so far
	    strafeDistanceFromOrigin += strafeFixedFrame;
	    
	    // change enum for left\center\right lanes accordingly
	    if (strafeDistanceFromOrigin >= strafeAmount)
	    {
		    if (currentStrafeLocation == StrafeLocation.center)
			    currentStrafeLocation = StrafeLocation.left;
		    else
			    currentStrafeLocation = StrafeLocation.center;
		    
		    // disable movement in this direction
		    strafeLeftFlag = false;
		    // movement has finished... enable joyboard input
		    inputEnabled = true;
	    }
    }

    public void StrafeRight()
	{
		// disable keyboard input while strafing
	    inputEnabled = false;
		
        // move the player to it's relative right
		transform.position += transform.right * strafeFixedFrame;
		
		// keep track of how much movement has happened so far
		strafeDistanceFromOrigin += strafeFixedFrame;  
		
		
		// change enum for left\center\right lanes accordingly
	    if (strafeDistanceFromOrigin >= strafeAmount)
	    {
		    if (currentStrafeLocation == StrafeLocation.center)
			    currentStrafeLocation = StrafeLocation.right;
		    else
			    currentStrafeLocation = StrafeLocation.center;
		    
		    // disable movement in this direction
		    strafeRightFlag = false;
		    // movement has finished... enable joyboard input
		    inputEnabled = true;
	    }
    }
}