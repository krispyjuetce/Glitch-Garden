using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

	public GameObject projectile, gun; 

	private GameObject projectileParent;
	private Animator animator;
	private Spawner myLaneSpawner;

	private void Fire(){
		GameObject newProjectile = Instantiate (projectile);
		newProjectile.transform.parent = projectileParent.transform;
		newProjectile.transform.position = gun.transform.position;
	}
	// Use this for initialization
	void Start () {

		animator = GetComponent<Animator> ();
		projectileParent = GameObject.Find ("Projectiles");
		//creates a parent if necessary
		if (!projectileParent) {
			projectileParent = new GameObject("Projectiles");
		}
		//
		SetMyLaneSpawner ();

	}
	
	// Update is called once per frame
	void Update () {
		if (IsAttackerAheadInLane ()) {
			animator.SetBool ("isAttacking", true);
		} else {
			animator.SetBool ("isAttacking", false);
		}
	}

	//look through all spawners and set myLaneSpawner if found
	void SetMyLaneSpawner(){

		Spawner[] spawnerArray = GameObject.FindObjectsOfType<Spawner> ();
		foreach (Spawner spawner in spawnerArray) {

			if (spawner.transform.position.y == transform.position.y) {
				myLaneSpawner = spawner;
				return;
			}
		}

		Debug.LogError (name+ " No Spawners Found in Lane");
	}

	bool IsAttackerAheadInLane(){
		//Exit is no attackers in lane
		if(myLaneSpawner.transform.childCount<=0){
			return false;
		}

		foreach (Transform attacker in myLaneSpawner.transform) {
			if (attacker.transform.position.x > transform.position.x) {
				return true;
			}
		}

		//When attackers in lane but behind us
		return false;
	}
}
