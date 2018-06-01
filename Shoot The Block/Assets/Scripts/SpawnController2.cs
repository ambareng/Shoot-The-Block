
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController2 : MonoBehaviour {

	private float spawnCooldown = 0f;
	private Vector3 spawnPos;
	private GameManager gameManager;

	public int spawnChance;
	public GameObject block;
	public bool canSpawn = true;
	public GameObject parent;

	void Start () {
		spawnPos = transform.position;
		gameManager = FindObjectOfType<GameManager> ();
	}

	void Update () {
		if (gameManager.gameStart) {
			spawnCooldown -= Time.deltaTime;

			if (spawnCooldown <= 0 && canSpawn) {
				spawnChance = Random.Range (1, 3);
				if (spawnChance == 1) {
					StartCoroutine ("SpawnBlock");
				} else if (spawnChance == 2) {

				}

				spawnCooldown = 2f;
			}	
		}
	}

	IEnumerator SpawnBlock () {
		GameObject blockObj = Instantiate (block, spawnPos, Quaternion.identity);
		blockObj.transform.position = spawnPos;
		blockObj.transform.SetParent (parent.transform);

		if (blockObj.activeSelf) {
			canSpawn = false;
		} 

		yield return new WaitForSeconds (0.1f);
	}

}
