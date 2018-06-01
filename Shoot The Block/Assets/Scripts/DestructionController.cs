
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructionController : MonoBehaviour {

	SpawnController spawnController;
	SpawnController1 spawnController1;
	SpawnController2 spawnController2;
	SpawnController3 spawnController3;

	void Start () {
		spawnController = FindObjectOfType<SpawnController> ();
		spawnController1 = FindObjectOfType<SpawnController1> ();
		spawnController2 = FindObjectOfType<SpawnController2> ();
		spawnController3 = FindObjectOfType<SpawnController3> ();
	}

	void OnTriggerEnter2D (Collider2D col) {
		if (col.tag == "Blocker") {
			if (col.transform.parent.name == "Spawn Point 001") {
				spawnController.canSpawn = true;
			} else if (col.transform.parent.name == "Spawn Point 002") {
				spawnController1.canSpawn = true;
			} else if (col.transform.parent.name == "Spawn Point 003") {
				spawnController2.canSpawn = true;
			} else if (col.transform.parent.name == "Spawn Point 004") {
				spawnController3.canSpawn = true;
			}

			Destroy (col.gameObject);
		}
			

	}

}
