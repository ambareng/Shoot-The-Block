
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public int currentScore;
	public int highScore;
	public Text currentScoreText;
	public Text highScoreText;

	void Start () {
		highScore = PlayerPrefs.GetInt ("High Score", 0);
		highScoreText.text = highScore.ToString ();
	}

	void Update () {
		currentScoreText.text = currentScore.ToString (); 
		if (currentScore > highScore) {
			highScore = currentScore;
			highScoreText.text = highScore.ToString ();
			PlayerPrefs.SetInt ("High Score", currentScore);
		}
	}

}
