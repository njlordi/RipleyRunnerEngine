using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MapSpawnDirectionDisplay : MonoBehaviour {
	Text directionText;
	// Use this for initialization
	void Start () {
		directionText = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		if (LevelManager.axisDirection == LevelManager.MapSpawnDirection.facingZ) {
			directionText.text = "Map is generating towards Z";
		} else if (LevelManager.axisDirection == LevelManager.MapSpawnDirection.facingX) {
			directionText.text = "Map is generating towards X";
		} else if (LevelManager.axisDirection == LevelManager.MapSpawnDirection.facingNegX) {
			directionText.text = "Map is generating away from X";
		}
	}
}
