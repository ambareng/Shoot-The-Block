
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockerController : MonoBehaviour {

	private float blockSpeed; // Movement Speed of Blocker
	private GameManager gameManager; // Game Object Holding the Game Manager Script

	public int veryFastChance; // Chances of Spawning a Very Fast Block
	public int fastChance;
	public int slowChance;
	public AudioSource hitBlock; // Sound Effect of the Block being hit
	public int spawnSpeedChance; // Chance of a block having x amount of speed to be spawned

	void Start () {
		gameManager = FindObjectOfType<GameManager> (); // Will find an object having a type of Game Manger

		spawnSpeedChance = Random.Range (1, 11); // Randomized Chance
		if (spawnSpeedChance >= veryFastChance) { // Determines Chance
			blockSpeed = 5f; // Spawns a Very Fast Block
		} else if (spawnSpeedChance > fastChance) {
			blockSpeed = 3f; // Spawns a Fast Block
		} else if (spawnSpeedChance <= slowChance) {
			blockSpeed = 1f; // Spawns a Slow Block
		}

		if (transform.position.x > 0) { // Will make the block move in the right DIRECTION
			blockSpeed = -blockSpeed;
		}
	}
	
	void Update () {
		if (gameManager.gameStart) { // Ensures the blocks will not move when game is paused or something else (may be redundant)
			transform.Translate (blockSpeed * Time.deltaTime, 0f, 0f); // Make Block Move
		}
	}

	void OnTriggerEnter2D (Collider2D col) { // If something triggers this block
		if (col.tag == "Bullet") { // If that something has a  Bullet tag
			hitBlock.Play (); // It will play the sound effect of being hit
		}
	}
		
}
