using UnityEngine;
using System.Collections;

public class LeftFlipper : MonoBehaviour {

	HingeJoint2D flipperJoint;
	JointMotor2D flipperMotor;

	void Start () {
		flipperJoint = GetComponent<HingeJoint2D> ();
		flipperMotor = GetComponent<JointMotor2D> ();
	}

	void FixedUpdate() {
		if (Input.GetKey(KeyCode.LeftArrow)) {
			flipperMotor.motorSpeed = -500;
			flipperJoint.useMotor = true;
		}

		if (!Input.GetKey(KeyCode.LeftArrow)) {
			flipperJoint.useMotor = false;
		}
	}

//	void OnMouseDown() {
//		flipperJoint.useMotor = true;
//		flipperMotor.motorSpeed = -500;
//	}
//
//	void OnMouseUp() {
//		flipperJoint.useMotor = false;
//	}
	
	public void FlipperDown () {
		flipperJoint.useMotor = true;
		flipperMotor.motorSpeed = 500;
	}

	public void FlipperUp () {
		flipperJoint.useMotor = false;
	}
}
