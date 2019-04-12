using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flipper : MonoBehaviour {
    public float restPos = 0f;
    public float pressedPos = 45f;
    public float hitStrenght = 10000f;
    public float flipperDamper = 150f;
    HingeJoint hinge;
    public string inputName;
    Touch touch;
    JointSpring spring = new JointSpring();

    // Use this for initialization
    void Start () {
        hinge = GetComponent<HingeJoint>();
        hinge.useSpring = true;
    }
	
	// Update is called once per frame
	void Update () {

        spring.spring = hitStrenght;
        spring.damper = flipperDamper;

        hinge.spring = spring;
        hinge.useLimits = true;
    }
    public void OnTouchUp()
    {
        spring.targetPosition = restPos;
    }
    public void OnTouchDown()
    {

    }
    public void OnTouchStay()
    {
        spring.targetPosition = pressedPos;
    }
    public void OnTouchExit()
    {
        spring.targetPosition = restPos;
    }
}
