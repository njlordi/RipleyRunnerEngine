using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FramesPerSecondScript : MonoBehaviour {

    public Text fpsText;
    public float nextTime;
    public int frames;

	void Start () {
        fpsText = GetComponent<Text>();
        nextTime = 1.0f;
        frames = 0;
        fpsText.text = "FPS: " + 0.ToString();
	}
	
	void Update () {
        ++frames;
        if (Time.time > nextTime) {
            fpsText.text = "FPS: " + frames.ToString();
            frames = 0;
            nextTime = Time.time + 1;
        }
    }
}
