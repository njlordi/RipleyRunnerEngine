using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PickUpCountDisplay : MonoBehaviour {
	Text NumberOfPickUps;
	// Use this for initialization
	void Start () {
		NumberOfPickUps = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		NumberOfPickUps.text = PlayerStats.pickUpsCollected.ToString();
	}
}
