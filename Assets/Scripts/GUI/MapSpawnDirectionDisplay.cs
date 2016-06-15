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
		if (GameManager.axisDirection == GameManager.MapSpawnDirection.facingZ) {
			directionText.text = "Map is generating towards Z";
		} else if (GameManager.axisDirection == GameManager.MapSpawnDirection.facingX) {
			directionText.text = "Map is generating towards X";
		} else if (GameManager.axisDirection == GameManager.MapSpawnDirection.facingNegX) {
			directionText.text = "Map is generating away from X";
		}
	}
}
