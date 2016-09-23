using UnityEngine;
using System.Collections;

public class BumperScript : MonoBehaviour {

	public GameObject bumper;
	public GameObject ball;
	public float points;

	void Start () {
		ball = GameObject.FindWithTag ("Ball");
		bumper = GetComponent<GameObject> ();
		points = 0;
	}

	void Update () {

	}

	void OnCollisionEnter2D (Collision2D collision) {
		if (collision.gameObject.tag == "Ball") {
			points += 10;
			Debug.Log (points);
		}
	}

}
