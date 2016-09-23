using UnityEngine;
using System.Collections;

public class DetectTouch : MonoBehaviour {
	
	RaycastHit2D touch;

	void Start () {
	
	}

	void Update () {
		if (Input.touchCount > 0) {
			
			if (Input.GetTouch(0).phase == TouchPhase.Began) {
				touch = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (Input.GetTouch (0).position), Vector2.zero);

				if (touch.collider != null && touch.transform.gameObject.tag == "Left Button") {
					Debug.Log ("hello");
				}
			}
		}
	}
}
