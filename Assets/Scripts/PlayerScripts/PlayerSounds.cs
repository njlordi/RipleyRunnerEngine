using UnityEngine;
using System.Collections;

public class PlayerSounds : MonoBehaviour {
	AudioSource audioSource;
	public bool MutePlayerAudio;
	
	void Start() {
		audioSource = GetComponent<AudioSource>();
	}
	
	public void PlayPickUpNoise() {
		if (!MutePlayerAudio)
			audioSource.Play();
	}
}
