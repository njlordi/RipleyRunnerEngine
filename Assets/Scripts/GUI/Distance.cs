using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Distance : MonoBehaviour {
    Text distanceText;
    int wholeNumberDistance;

	// Use this for initialization
	void Start () {
        distanceText = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        wholeNumberDistance = (int)PlayerData.distanceRan; 
        distanceText.text = "Score: \n" + wholeNumberDistance.ToString();
	}
}
