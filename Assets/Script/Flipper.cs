using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flipper : MonoBehaviour {
    public float restPos = 0f;
    public float pressedPos = 45f;
    public float hitS
    // Use this for initialization
    void Start () {
        GetComponent<Rigidbody>().maxAngularVelocity = 10f;
    }
	
	// Update is called once per frame
	void OnTouchDown () {

            HingeJoint hinge = GetComponent<HingeJoint>();
            JointMotor motor = hinge.motor;
            motor.targetVelocity = -motor.targetVelocity;
            hinge.motor = motor;

    }
}
