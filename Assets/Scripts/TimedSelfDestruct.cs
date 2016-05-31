using UnityEngine;
using System.Collections;

public class TimedSelfDestruct : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Destroy(gameObject, 2.0f);
	}

}
