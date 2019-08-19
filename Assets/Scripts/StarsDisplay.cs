using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarsDisplay : MonoBehaviour {

	public enum Status {SUCCESS,FAILURE};
	private Text starText;
	private int stars = 200;
	// Use this for initialization
	void Start () {
		starText = GetComponent<Text> ();
		UpdateDisplay ();
	}

	public void AddStars( int amount){
		stars += amount;
		UpdateDisplay ();
	}

	public Status UseStars( int amount){
		if (stars >= amount) {
			stars -= amount;
			UpdateDisplay ();
			return Status.SUCCESS;
		}
		return Status.FAILURE;

	}

	private void UpdateDisplay(){
		starText.text = stars.ToString ();
	}
}
