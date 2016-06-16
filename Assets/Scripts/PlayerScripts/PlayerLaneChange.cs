// Written by Nick L.
// Code for strafing in the RipleyRunner Engine
using UnityEngine;
using System.Collections;

public class PlayerLaneChange : MonoBehaviour
{
	public float strafeDestinationModifier;
	public float strafeSpeed;
	public float strafeFixedFrame;
	
	public bool movementFlag;
	
    // rename these next two?
	public bool strafeLeftFlag;
	public bool strafeRightFlag;
	
	public bool inputEnabled;
	
	public enum StrafeLocation { left, center, right };
	public StrafeLocation currentStrafeLocation;
	public float strafeAmount;
	public float strafeCenter = 0;
	
	float strafeResponsivenessLevel;
	
	
    // Use this for initialization
    void Awake()
    {
	    strafeAmount = 4.0f;
	    strafeSpeed = 10.0f;
	    strafeDestinationModifier = 0.0f;
	    strafeResponsivenessLevel = 0.5f;
    }

    void Start()
	{
		movementFlag = false;
		strafeLeftFlag = false;
		strafeRightFlag = false;
		
		currentStrafeLocation = StrafeLocation.center;
		strafeDestinationModifier = 0.0f;
		inputEnabled = true;
	}
	
    // Update is called once per frame
	void Update()
	{
	    // fixed frame variable for movement
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
			
		Vector3 tempVector = transform.localPosition;
		tempVector.x = Mathf.Lerp(tempVector.x, strafeDestinationModifier, strafeFixedFrame);
		transform.localPosition = tempVector;
		
		if (transform.localPosition.x >= strafeAmount - strafeResponsivenessLevel) {
			currentStrafeLocation = StrafeLocation.right;
			inputEnabled = true;
		}
		if (transform.localPosition.x <= -(strafeAmount - strafeResponsivenessLevel)) {
			currentStrafeLocation = StrafeLocation.left;
			inputEnabled = true;
		}
		if (transform.localPosition.x < strafeResponsivenessLevel 
			&& transform.localPosition.x > -strafeResponsivenessLevel) {
			currentStrafeLocation = StrafeLocation.center;
			inputEnabled = true;
			}
	}
	
	public void SlideToLeftLane()
	{
		strafeDestinationModifier = -strafeAmount;
	}
	
	public void SlideToRightLane()
	{
		strafeDestinationModifier = strafeAmount;
	}
	
	public void SlideToCenterLane() 
	{
		strafeDestinationModifier = strafeCenter;
	}
}