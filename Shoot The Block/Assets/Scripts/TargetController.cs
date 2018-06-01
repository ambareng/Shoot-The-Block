
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour {

	public AudioSource hitTarget;
	public int scoredPoints;

	void OnTriggerEnter2D (Collider2D col) {
		if (col.tag == "Bullet") {
			scoredPoints++;
			hitTarget.Play ();
		}
	}

}
