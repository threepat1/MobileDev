using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Behaviour : MonoBehaviour {

    void OnTouchDown()
    {
        this.GetComponent<MeshRenderer>().material.color = Color.blue;
    }
    void OnTouchUp()
    {
        this.GetComponent<MeshRenderer>().material.color = Color.white;
    }
    void OnTouchStay()
    {
        this.GetComponent<MeshRenderer>().material.color = Color.green;
    }
    void OnTouchExit()
    {
        this.GetComponent<MeshRenderer>().material.color = Color.yellow;
    }
}
