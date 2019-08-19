using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public GameObject[] attackerPrefabArray;
	
	// Update is called once per frame
	void Update () {

		foreach (GameObject thisAttacker in attackerPrefabArray) {
			if (IsTimeToSpawn (thisAttacker)) {
				Spawn (thisAttacker);
			}
		}
	}

	bool IsTimeToSpawn(GameObject attackerGameObject){

		Attacker attacker = attackerGameObject.GetComponent<Attacker> ();
		float meanSpawnDelay = attacker.seenEverySeconds;
		float spawnsPerSecond = 1 / meanSpawnDelay;

		if(Time.deltaTime > meanSpawnDelay){

			Debug.LogWarning ("Spawn Rate Capped By frame Rate");
		}

		float threshold = spawnsPerSecond * Time.deltaTime;

		return (Random.value < threshold);
	}

	void Spawn (GameObject myGameObject){

		GameObject myAttacker = Instantiate (myGameObject);
		myAttacker.transform.parent = transform;
		myAttacker.transform.position = transform.position;
	}

}
