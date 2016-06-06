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
			directionText.text = "facing Z";
		} else if (GameManager.axisDirection == GameManager.MapSpawnDirection.facingX) {
			directionText.text = "facing X";
		} else if (GameManager.axisDirection == GameManager.MapSpawnDirection.facingNegX) {
			directionText.text = "facing Neg X";
		}
	}
}
