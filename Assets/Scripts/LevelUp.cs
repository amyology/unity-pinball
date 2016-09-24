using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelUp : MonoBehaviour {

	public GameControllerScript gameController;

	void FixedUpdate () {
		if (gameController.score == 50) {
			SceneManager.LoadScene ("Scene2");
		}
	}
}
