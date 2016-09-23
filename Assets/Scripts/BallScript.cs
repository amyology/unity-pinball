using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BallScript : MonoBehaviour {

	public GameControllerScript gameController;

	Rigidbody2D ball;
	GameObject bumper;

	void Start () {
		ball = GetComponent<Rigidbody2D> ();
		bumper = GameObject.FindWithTag ("Bumper");
	}

	//Add points when ball hits a bumper
	void OnCollisionEnter2D (Collision2D collision) {
		if (collision.gameObject.tag == "Bumper") {
			gameController.TrackScore();
		}
	}
}
