using UnityEngine;
using System.Collections;

public class PlayerData : MonoBehaviour
{

	public static int pickUpsCollected = 0;
	public static int runSpeed = 75;
    public static float distanceRan = 0;

	// For viewing player's speed in the inspector (debugging)
	public int runSpeedInspector;

	void Start() {
		runSpeedInspector = runSpeed;
	}

	void Update ()
	{
        distanceRan += Time.deltaTime * runSpeed;

		if (runSpeedInspector != runSpeed) {
			runSpeed = runSpeedInspector;
		} else {
			runSpeedInspector = runSpeed;
		}
	}
}
