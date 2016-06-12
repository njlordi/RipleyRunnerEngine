// Written by Nick L.
// Code for strafing in the RipleyRunner Engine
using UnityEngine;
using System.Collections;

public class PlayerLaneChange : MonoBehaviour
{
	
	public float strafeAmount;
	public float strafeSpeed;
	public float strafeFixedFrame;
	//public float myDeltaTime;
	//public float strafeDistanceFromOrigin;
	
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
		strafeAmount = 0.0f;
		strafeSpeed = 10.0f;
	}
	
    // Update is called once per frame
	void Update()
	{
	    // steady movement variable
		strafeFixedFrame = strafeSpeed * Time.deltaTime;

		if (Input.GetKey(KeyCode.A) && inputEnabled == true)
		{
			strafeRightFlag = false;
			strafeLeftFlag = true;
		}
		if (Input.GetKey(KeyCode.D) && inputEnabled == true)
		{
			strafeLeftFlag = false;
			strafeRightFlag = true;
		}
		
		if (strafeLeftFlag)
			//SlideToLeftLane();
			SlideToCenterLane();
			
        if (strafeRightFlag)
			SlideToRightLane();
			
		// not sure which is better... MoveTowards or Lerp... :/
		transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(strafeAmount, 0, 0), strafeFixedFrame);	
	}
	
	public void SlideToLeftLane()
	{
		strafeAmount = -4.0f;
	}
	
	public void SlideToRightLane()
	{
		strafeAmount = 4.0f;
	}
	
	public void SlideToCenterLane() 
	{
		strafeAmount = 0.0f;
	}
	
}