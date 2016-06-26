using UnityEngine;
using System.Collections;

public class TimedSelfDestruct : MonoBehaviour {
	public bool isDestructable;
	void Start () {
		if (isDestructable)
			Destroy(gameObject, 2.0f);
	}

}
