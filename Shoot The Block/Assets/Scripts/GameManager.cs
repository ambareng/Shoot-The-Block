
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public GameObject scoreUI;
	public GameObject gameUI;
	public bool gameStart = false;
	public BlockerController blockerController;
	public ScoreManager scoreManager;
	public TargetController targetController;

	void Start () {
		scoreManager = FindObjectOfType<ScoreManager> ();
		targetController = FindObjectOfType<TargetController> ();
	}

    void Update () {
		if (Input.GetMouseButtonDown (0)) {
			scoreUI.SetActive (true);
			gameUI.SetActive (false);
			gameStart = true;
		}


		if (scoreManager.currentScore == 0) {
			blockerController.veryFastChance = 10;
			blockerController.fastChance = 7;
			blockerController.slowChance = 7;
			targetController.scoredPoints = 0;
		} else if (scoreManager.currentScore <= 6 && targetController.scoredPoints == 2) {
			blockerController.veryFastChance -= 1;
			blockerController.fastChance -= 2;
			blockerController.slowChance -= 2;
			targetController.scoredPoints = 0;
		} else if (scoreManager.currentScore > 6 && targetController.scoredPoints == 2 && blockerController.veryFastChance > 1) {
			blockerController.veryFastChance -= 1;
			targetController.scoredPoints = 0;
		}
    }

}
