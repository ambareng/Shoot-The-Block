
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterController : MonoBehaviour {

	public GameObject bullet; // Bullet Game Object
	Vector3 spawnPos; // Spawn Position of Bullet
	public ShootingManager shootingManager;
	GameManager gameManager;

	void Start () {
		spawnPos = transform.position; // Set To Same Position as THIS Object
		shootingManager = FindObjectOfType<ShootingManager> ();
		gameManager = FindObjectOfType<GameManager> ();
	}

	void Update () {
		if (Input.GetMouseButtonDown (0) && shootingManager.canShoot && gameManager.gameStart) { // If Left Clicking then...
			GameObject bulletObj = Instantiate (bullet, spawnPos, Quaternion.identity); // Put Object into Game Scene
			bulletObj.transform.position = spawnPos; // Set Object Position

			shootingManager.canShoot = false;
		}
	}

}
