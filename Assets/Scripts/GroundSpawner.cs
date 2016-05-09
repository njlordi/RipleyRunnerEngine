using UnityEngine;
using System.Collections;

public class GroundSpawner : MonoBehaviour {
	
	public GameObject [] groundVariants; 
	public float groundSpeed;
	
	void Start () {
		groundSpeed = 4.0f;
		if (groundVariants != null){
			Debug.Log("Setting speed for each ground in array");
			foreach (GameObject go in groundVariants) {
				go.GetComponent<Ground>().speed = groundSpeed;
				Debug.Log(go.transform.position.z);
			}
		}
	}
		
	void Update () {
		foreach (GameObject go in groundVariants) {
				// disable ground piece when it reaches a certain z coordinate (IE not visable anymore!)
			if (go.transform.position.z <= -10) {
				go.SetActive(false);
			}
			//go.GetComponent<Ground>().speed = groundSpeed;
			Debug.Log(go.transform.position.z);
		}
	}
}
