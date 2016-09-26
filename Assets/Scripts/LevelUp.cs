using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelUp : MonoBehaviour {

	public GameControllerScript gameController;
	public GUIText gameText;

	void Start (){
		gameText = GameObject.FindWithTag ("StartText").GetComponent<GUIText> ();
	}

	void FixedUpdate () {
		if (gameController.score == 50) {
			StartCoroutine (NextLevel ());
			gameText.text = "Level 2";
		}

	}

	IEnumerator NextLevel(){
		yield return new WaitForSeconds (2);
		SceneManager.LoadScene ("Scene2");
	}
		
}
