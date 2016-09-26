using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BallScript : MonoBehaviour {

	public GameControllerScript gameController;

	void Start () {

	}

	//Add points when ball hits a bumper
	void OnCollisionEnter2D (Collision2D collision) {
		if (collision.gameObject.tag == "Bumper") {
			gameController.TrackScore();
		}
	}
}
