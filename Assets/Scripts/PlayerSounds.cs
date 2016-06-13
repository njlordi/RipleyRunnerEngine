using UnityEngine;
using System.Collections;

public class PlayerSounds : MonoBehaviour {
	AudioSource audioSource;
	
	void Start() {
		audioSource = GetComponent<AudioSource>();
	}
	
	public void PlayPickUpNoise() {
		audioSource.Play();
	}
}
