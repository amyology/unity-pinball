using UnityEngine;
using System.Collections;

public class Spring : MonoBehaviour {

	Rigidbody2D plunger;

	void Start () {
		plunger = GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate () {
		
	}

	void OnMouseDown() {
		plunger.AddForce(new Vector2(0,-200), ForceMode2D.Impulse);
	}

	void OnCollisionEnter2D() {
		
	}
}
