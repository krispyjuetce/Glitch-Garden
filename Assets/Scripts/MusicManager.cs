using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

	public AudioClip[] levelMusicChangeArray;
	private AudioSource audioSource;
	// Use this for initialization
	void Start () {

		audioSource = GetComponent<AudioSource> ();
	}

	void Awake () {
		DontDestroyOnLoad (gameObject);
		Debug.Log ("Dont Destroy: "+name);
	}
	
	void OnLevelWasLoaded(int level){
        Debug.Log("The level loaded is: " + level);
		AudioClip thisLevelMusic = levelMusicChangeArray [level];
		//Debug.Log ("Playing : "+thisLevelMusic);

		if (thisLevelMusic) {
            //audioSource.clip = thisLevelMusic;
            Debug.Log("Playing : " + thisLevelMusic);
            audioSource.clip = thisLevelMusic;
			audioSource.loop = true;
			audioSource.volume = PlayerPrefsManager.GetMasterVolume ();
			audioSource.Play();
		}
	}

	public void ChangeVolume(float volume){
		audioSource.volume = volume;
	}
}
