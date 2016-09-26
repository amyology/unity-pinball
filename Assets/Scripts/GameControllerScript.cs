using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameControllerScript : MonoBehaviour {

	GameObject ball; //the ball
	Rigidbody2D ballRB; //the ball rigidbody2d
	float maxSpeed = 600f; //maximum speed
	Vector3 defaultPosition; //starting position
	int livesCount; //lives counter
	int maxLives = 3; //max number of lives
	float theBottom = -9; //bottom of the game board
	public int score; //score tracker
	int pointsValue = 10; //How many points for each bumper
	public GUIText gameText; //the text

	void Start () {
		ball = GameObject.FindWithTag ("Ball"); //Finds gameobject tagged "Ball"
		ballRB = ball.GetComponent<Rigidbody2D> (); //Gets the rigidbody2d component of ball gameobject
		defaultPosition = ballRB.transform.position; //Gets the start position of ball
		score = 0; //starting score
		livesCount = 1; //starting life count
		gameText = GameObject.FindWithTag ("StartText").GetComponent<GUIText> (); //Finds text gameobject tagged "StartText"
		gameText.text = "Press Spacebar to Start"; //change text component of StartText gameobject
	}

	void FixedUpdate () {

		//Quit app
		if (Input.GetKey ("escape")) {
			gameText.text = "Exiting...";
			Application.Quit ();
		}

		//Restart app
		if (Input.GetKey ("return")) {
			gameText.text = "Restarting...";
			StartCoroutine (ReloadGame ());
		}

		//Limit velocity of ball so it doesn't break out of walls
		if (ballRB.velocity.magnitude > maxSpeed) {
			ballRB.velocity = ballRB.velocity.normalized * maxSpeed;
		}

		//Return ball to default position and add a life when it falls below y axis
		if (ballRB.transform.position.y < theBottom && livesCount < maxLives) {
			StartOver ();
			AddLife ();
		}

		//If ball gets stuck, return ball to default position and add a life
		if (ballRB.transform.position.x < 7.79 && ballRB.velocity.magnitude <= 0.05 && livesCount < maxLives) {
			StartOver ();
			AddLife ();
		}

		//Launches ball
		if (Input.GetKeyDown(KeyCode.Space)) {
			BallLaunch ();
			gameText.text = "";
		}

		//End game when no more lives and ball falls below y axis
		if (livesCount == maxLives && ballRB.transform.position.y < theBottom) {
			GameOver ();
		}
			
	}

	//Add force to ball on launch
	void BallLaunch () {
		if (livesCount <= maxLives && ballRB.velocity.magnitude <= 0.05) {
			ballRB.AddForce (new Vector2 (0, 20), ForceMode2D.Impulse);
		}
	}

	//Returns ball to default position and display remaining lives
	void StartOver () {
		ballRB.transform.position = defaultPosition;
		gameText.text = "Lives left: " + (maxLives - livesCount);
	}

	//Add a life
	void AddLife () {
		livesCount += 1;
	}

	//Keep track of score
	public void TrackScore () {
		score += pointsValue;
		gameText.text = "Score: " + score;
	}

	//When no more lives
	void GameOver () {
		gameText.text = "Game Over";
		StartCoroutine (ReloadGame ());
	}

	//Reload when no more lives
	IEnumerator ReloadGame () {
		yield return new WaitForSeconds (2);
		Scene scene = SceneManager.GetActiveScene ();
		SceneManager.LoadScene (scene.name);
	}

}
