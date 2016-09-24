using UnityEngine;
using System.Collections;

public class flipperScript : MonoBehaviour {
	
	HingeJoint2D flipperJoint;

	void Start () {
		flipperJoint = GetComponent<HingeJoint2D> ();
	}

	void FixedUpdate () {
		if (Input.GetKey(KeyCode.RightArrow)) {
			flipperJoint.useMotor = true;
		}

		if (!Input.GetKey(KeyCode.RightArrow)) {
			flipperJoint.useMotor = false;
		}
	}

//	void OnMouseDown() {
//		flipperJoint.useMotor = true;
//		flipperMotor.motorSpeed = 500;
//	}
//
//	void OnMouseUp() {
//		flipperJoint.useMotor = false;
//	}

	public void FlipperDown () {
		flipperJoint.useMotor = true;
	}

	public void FlipperUp () {
		flipperJoint.useMotor = false;
	}

}