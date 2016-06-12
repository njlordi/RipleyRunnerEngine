// Written by Nick L.
// Code for strafing in the RipleyRunner Engine
using UnityEngine;
using System.Collections;

public class PlayerLaneChange : MonoBehaviour
{
	public float strafeAmount;
	public float strafeSpeed;
	public float strafeFixedFrame;
	
	public bool movementFlag;
	
    // rename these next two
	public bool strafeLeftFlag;
	public bool strafeRightFlag;
	
	public bool inputEnabled;
	
	public enum StrafeLocation { left, center, right };
	public StrafeLocation currentStrafeLocation;
	
    // Use this for initialization
	void Start()
	{
		movementFlag = false;
		
		strafeAmount = 0.0f;
		
		strafeLeftFlag = false;
		strafeRightFlag = false;
		
		currentStrafeLocation = StrafeLocation.center;
		inputEnabled = true;
		strafeAmount = 0.0f;
		strafeSpeed = 5.0f;
	}
	
    // Update is called once per frame
	void Update()
	{
	    // steady movement variable
		strafeFixedFrame = strafeSpeed * Time.deltaTime;

		if (Input.GetKey(KeyCode.A) && inputEnabled == true)
		{
			inputEnabled = false;
			if (currentStrafeLocation == StrafeLocation.center)
				SlideToLeftLane();
			else if (currentStrafeLocation != StrafeLocation.left)
				SlideToCenterLane();
		}
		if (Input.GetKey(KeyCode.D) && inputEnabled == true)
		{
			inputEnabled = false;
			if (currentStrafeLocation == StrafeLocation.center)
				SlideToRightLane();
			else if (currentStrafeLocation != StrafeLocation.right)
				SlideToCenterLane();
		}
		
		if (strafeLeftFlag)
			SlideToLeftLane();
			
        if (strafeRightFlag)
			SlideToRightLane();
			
		// not sure which is better... MoveTowards or Lerp... :/
		Vector3 tempVector = transform.localPosition;
		tempVector.x = Mathf.Lerp(tempVector.x, strafeAmount, strafeFixedFrame);
		transform.localPosition = tempVector;
		
		if (transform.localPosition.x >= 3.7f) {
			currentStrafeLocation = StrafeLocation.right;
			inputEnabled = true;
		}
		if (transform.localPosition.x <= -3.7f) {
			currentStrafeLocation = StrafeLocation.left;
			inputEnabled = true;
		}
		if (transform.localPosition.x < 0.1f 
			&& transform.localPosition.x > -0.1f) {
			currentStrafeLocation = StrafeLocation.center;
			inputEnabled = true;
			}
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