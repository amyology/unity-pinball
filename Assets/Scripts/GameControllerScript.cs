using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameControllerScript : MonoBehaviour {

	GameObject ball;
	Rigidbody2D ballRB;
	float maxSpeed = 600f;
	Vector3 defaultPosition;
	int livesCount;
	int maxLives = 3;
	float theBottom = -9;
	public int score;
	public GUIText startGameText;

	void Start () {
		ball = GameObject.FindWithTag ("Ball");
		ballRB = ball.GetComponent<Rigidbody2D> ();
		defaultPosition = ballRB.transform.position;
		score = 0;
		livesCount = 1;
		startGameText = GameObject.FindWithTag ("StartText").GetComponent<GUIText> ();
		startGameText.text = "Press Spacebar to Start";

	}

	void FixedUpdate () {

		//Limit velocity of ball so it doesn't break out of walls
		if (ballRB.velocity.magnitude > maxSpeed) {
			ballRB.velocity = ballRB.velocity.normalized * maxSpeed;
		}

		//Return ball to default position when it falls
		if (ballRB.transform.position.y < theBottom && livesCount < maxLives) {
			StartOver ();
			AddLife ();
		}

		//If ball gets stuck
		if (ballRB.transform.position.x < 7.79 && ballRB.velocity.magnitude <= 0.05 && livesCount < maxLives) {
			StartOver ();
			AddLife ();
		}

		//Launches ball
		if (Input.GetKeyDown(KeyCode.Space)) {
			BallLaunch ();
			startGameText.text = "";
		}

		//End game
		if (livesCount == maxLives && ballRB.transform.position.y < theBottom) {
			GameOver ();
		}

	}

	//Add force to ball
	void BallLaunch () {
		if (livesCount <= maxLives && ballRB.velocity.magnitude == 0) {
			ballRB.AddForce (new Vector2 (0, 20), ForceMode2D.Impulse);
		}
	}

	//Returns ball to default position
	void StartOver () {
		ballRB.transform.position = defaultPosition;
		startGameText.text = "Lives left: " + (maxLives - livesCount);
	}

	//Add a life
	void AddLife () {
		livesCount += 1;
	}

	//Keep track of score
	public void TrackScore () {
		score += 10;
		startGameText.text = "Score: " + score;
	}

	//When no more lives
	void GameOver () {
		startGameText.text = "Game Over";
	}

}
