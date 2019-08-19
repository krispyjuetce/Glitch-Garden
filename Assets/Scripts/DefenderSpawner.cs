using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour {

	public Camera myCamera;

	private GameObject parent;
	private StarsDisplay starDisplay;

	void Start () {
		parent = GameObject.Find ("Defenders");

		if (!parent) {
			parent = new GameObject("Defenders");
		}

		starDisplay = FindObjectOfType<StarsDisplay>();
	}


	void OnMouseDown(){
		Vector2 pos = SnapToGrid (CalculateWorldPointOfMouseClick ());
		GameObject defender = Button.selectedDefender;
		int defenderCost = defender.GetComponent<Defender> ().starCost;
		if (starDisplay.UseStars (defenderCost) == StarsDisplay.Status.SUCCESS) {
			SpawnDefender (pos, defender);
		} else {
			Debug.Log ("insufficient Stars");
		}

	}

	void SpawnDefender (Vector2 pos, GameObject defender)
	{
		GameObject newDefender = Instantiate (defender, pos, Quaternion.identity);
		newDefender.transform.parent = parent.transform;
	}

	Vector2 CalculateWorldPointOfMouseClick(){
		float mouseX = Input.mousePosition.x;
		float mouseY = Input.mousePosition.y;
		float distanceFromCamera = 10f;

		Vector3 weirdTriplet = new Vector3 (mouseX,mouseY,distanceFromCamera);//this is called weird triplet because its not really x,y,z but x,y,distancefrom camera
		Vector2 worldPos = myCamera.ScreenToWorldPoint(weirdTriplet);

		return worldPos;
	}

	Vector2 SnapToGrid(Vector2 rawWorldPosition){
		
		float newX = Mathf.RoundToInt(rawWorldPosition.x);
		float newY = Mathf.RoundToInt(rawWorldPosition.y);
		return new Vector2 (newX, newY);
	}
}
