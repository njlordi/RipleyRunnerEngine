using UnityEngine;
using System.Collections;

public class TimedSelfDestruct : MonoBehaviour {

	void Start () {
		Destroy(gameObject, 2.0f);
	}

}
