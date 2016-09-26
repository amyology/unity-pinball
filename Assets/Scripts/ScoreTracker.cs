using UnityEngine;
using System.Collections;

public class ScoreTracker : MonoBehaviour {

	public int score; //score tracker
	int pointsValue = 10; //How many points for each bumper
	public GUIText gameText;

	void Start () {
		score = 0;
		gameText = GameObject.FindWithTag ("StartText").GetComponent<GUIText> ();
	}

	public void TrackScore () {
		score += pointsValue;
		gameText.text = "Score: " + score;
	}
}
