
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BulletController : MonoBehaviour {

	private ShootingManager shootingManager;
	private ScoreManager scoreManager;

	public float bulletSpeed = 5f; // Speed of Bullet
	public BlockerController blockerController; // Made this a public type since I'll put in here the prefab of the block instead of those in current scenes

	void Start () {
		shootingManager = FindObjectOfType<ShootingManager> ();
		scoreManager = FindObjectOfType<ScoreManager> ();
	}

    void Update () {
        transform.Translate (0f, bulletSpeed * Time.deltaTime, 0f); // Make Bullet Go Up
    }

	void OnTriggerEnter2D (Collider2D col) {
		if (col.tag == "Blocker") { // If hit an object with "Blocker" tag
			scoreManager.currentScore = 0; // Set all spawn chances back to default and the scores to default too
			blockerController.veryFastChance = 10;
			blockerController.fastChance = 7;
			blockerController.slowChance = 7;
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex); // Rebuild scene
			Destroy (this.gameObject);
		} else if (col.tag == "Target") {
			scoreManager.currentScore++;
			Destroy (this.gameObject);
		}

		shootingManager.canShoot = true;
	}

}
