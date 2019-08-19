using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public float autoLoadNextLevelAfter;
	public static int currentLevelIndex;


	void Start(){

		if (autoLoadNextLevelAfter <= 0) {
			Debug.Log ("autoLoadNextLevelAfter Disabled. Please put a positive value in seconds");
		} else {
			Invoke ("LoadNextLevel", autoLoadNextLevelAfter);
		}
	}

	//this function is used to load a level
	public void LoadLevel (string name){

		SceneManager.LoadScene (name);
		//below code gets the build index of the new scene
		Scene currentScene = SceneManager.GetActiveScene ();
		currentLevelIndex = currentScene.buildIndex;

	}

	public void LoadNextLevel(){
		
		Scene scene = SceneManager.GetActiveScene ();

		Debug.Log ("current scene index : "+scene.buildIndex);
		//add 1 to it
		SceneManager.LoadScene(scene.buildIndex+1);

		//below code gets the build index of the new scene
		Scene currentScene = SceneManager.GetActiveScene ();
		currentLevelIndex = currentScene.buildIndex;


	}

	public void LoadCurrentLevel(){

		SceneManager.LoadScene (currentLevelIndex);
	}



	public void QuitGame (){

		Debug.Log ("QuitGame was called ");
		Application.Quit ();
	}

	public void Back(){

		Scene scene = SceneManager.GetActiveScene ();

		Debug.Log ("current scene index : "+scene.buildIndex);
		//add 1 to it
		SceneManager.LoadScene(scene.buildIndex-1);

	}
}
