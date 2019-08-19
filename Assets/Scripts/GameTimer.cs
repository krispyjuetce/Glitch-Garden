using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {
	[Tooltip("How many seconds do you want the level to last")]
	public float levelSeconds = 10f;

	private Slider slider;
	private AudioSource audioSource;
	private bool isEndOfLevel = false;
	private LevelManager levelManager;
	private GameObject winLabel;

	// Use this for initialization
	void Start () {
		slider = GetComponent<Slider> ();
		audioSource = GetComponent<AudioSource> ();
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
		winLabel = GameObject.Find ("You Win");
		winLabel.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		slider.value = (Time.timeSinceLevelLoad / levelSeconds);

		if (Time.timeSinceLevelLoad >= levelSeconds&& !isEndOfLevel) {
			HandleWinCondition ();
		}
	}

	void HandleWinCondition ()
	{
		DestroyAllTaggedObjects ();
		audioSource.Play ();
		winLabel.SetActive (true);
		Invoke ("LoadNextLevel", audioSource.clip.length);
		print ("Level End");
		isEndOfLevel = true;
	}

	//destroys all objects destroyOnWin
	void DestroyAllTaggedObjects(){
		GameObject[] taggedObjectArray = GameObject.FindGameObjectsWithTag("destroyOnWin");
		foreach (GameObject taggedObject in taggedObjectArray) {
			Destroy (taggedObject);
		}
	}

	void LoadNextLevel(){
		levelManager.LoadNextLevel();
	}
}
