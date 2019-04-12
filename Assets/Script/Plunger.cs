using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Plunger : MonoBehaviour
{
    public float power;
    public float maxPower = 100f;
    public Slider powerSlider;
    public List<Rigidbody> ballList;

    bool ballready;
    Touch touch;
    void Start()
    {
        powerSlider.minValue = 0f;
        powerSlider.maxValue = maxPower;
        ballList = new List<Rigidbody>();

    }
    private void Update()
    {
        //if (ballready)
        //{
        //    powerSlider.gameObject.SetActive(true);
        //}
        //else
        //{
        //    powerSlider.gameObject.SetActive(false);

        //}
        //powerSlider.value = power;
        //if(ballList.Count > 0)
        //{
        //    ballready = true;
        //    if (touch.phase == TouchPhase.Stationary)
        //    {
        //        if (power <= maxPower)
        //        power += 50 * Time.deltaTime;
        //    }
        //    if (touch.phase == TouchPhase.Stationary)
        //    {
        //        foreach(Rigidbody r in ballList)
        //        {
        //            r.AddForce(power * Vector3.forward * 10);
        //        }
        //    }
        //}
        //else
        //{
        //    ballready = false;
        //    power = 0f;
        //}
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            ballList.Add(other.gameObject.GetComponent<Rigidbody>());
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            ballList.Remove(other.gameObject.GetComponent<Rigidbody>());
            power = 0f;
        }
    }
    public void OnTouchUp()
    {
        if (ballList.Count > 0)
        {
            foreach (Rigidbody r in ballList)
            {
                r.AddForce(power * Vector3.forward * 10);
            }
        }
        else
        {
            ballready = false;
            power = 0f;
        }
    }
    public void OnTouchDown()
    {

    }
    public void OnTouchStay()
    {
        if (ballList.Count > 0)
        {
            if (power <= maxPower)
                power += 50 * Time.deltaTime;
        }
    }
    public void OnTouchExit()
    {
        
    }
}

