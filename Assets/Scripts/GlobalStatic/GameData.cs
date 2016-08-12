using UnityEngine;
using System.Collections;

public class GameData : MonoBehaviour
{
	public static int pickUpsCollected = 0;
	public static int runSpeed = 75;
    public static float distanceRan = 0;

    // Should these be the same variable? We will see...
    public static float leftOriginCarSpeed;
    public static float rightOriginCarSpeed;

	// For viewing player's speed in the inspector (debugging)
	public int runSpeedInspector;

	void Start() {
		runSpeedInspector = runSpeed;
	}

	void Update () {
        distanceRan += Time.deltaTime * runSpeed;

		if (runSpeedInspector != runSpeed) {
			runSpeed = runSpeedInspector;
		} else {
			runSpeedInspector = runSpeed;
		}
	}

    public static void SetNextCarSpeeds()
    {
        leftOriginCarSpeed = Random.Range(30.0f, 60.0f);
        rightOriginCarSpeed = Random.Range(30.0f, 60.0f);
    }
}
