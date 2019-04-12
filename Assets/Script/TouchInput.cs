﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInput : MonoBehaviour {

    public LayerMask touchMask;
    private List<GameObject> touchList = new List<GameObject>();
    private GameObject[] touchOld;
    private RaycastHit hit;
    public GameObject[] targets;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
#if UNITY_EDITOR
        if(Input.GetMouseButton(0) || Input.GetMouseButtonUp(0) || Input.GetMouseButtonDown(0))
        {
            touchOld = new GameObject[touchList.Count];
            touchList.CopyTo(touchOld);
            touchList.Clear();

            Ray ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out hit, touchMask))
            {
                GameObject reciepient = hit.transform.gameObject;
                touchList.Add(reciepient);

                if (Input.GetMouseButtonDown(0))
                {
                    reciepient.SendMessage("OnTouchDown", hit.point, SendMessageOptions.DontRequireReceiver);
                    for (int i = 0; i < targets.Length; i++)
                    {
                        targets[i].SendMessage("OnTouchDown", hit.point, SendMessageOptions.DontRequireReceiver);

                    }
                }
                if (Input.GetMouseButton(0))
                {
                    reciepient.SendMessage("OnTouchStay", hit.point, SendMessageOptions.DontRequireReceiver);
                    for (int i = 0; i < targets.Length; i++)
                    {
                        targets[i].SendMessage("OnTouchStay", hit.point, SendMessageOptions.DontRequireReceiver);

                    }
                }
                if (Input.GetMouseButtonUp(0))
                {
                    reciepient.SendMessage("OnTouchUp", hit.point, SendMessageOptions.DontRequireReceiver);
                    for (int i = 0; i < targets.Length; i++)
                    {
                        targets[i].SendMessage("OnTouchUp", hit.point, SendMessageOptions.DontRequireReceiver);

                    }
                }
                
            }
            foreach (GameObject item in touchOld)
            {
                if (!touchList.Contains(item))
                {
                    item.SendMessage("OnTouchExit", hit.point, SendMessageOptions.DontRequireReceiver);
                    for (int i = 0; i < targets.Length; i++)
                    {
                        targets[i].SendMessage("OnTouchExit", hit.point, SendMessageOptions.DontRequireReceiver);

                    }
                }
            }
        }
#endif
        if(Input.touchCount > 0)
        {
            touchOld = new GameObject[touchList.Count];
            touchList.CopyTo(touchOld);
            touchList.Clear();

            foreach (Touch touch in Input.touches)
            {
                Ray ray = GetComponent<Camera>().ScreenPointToRay(touch.position);
                if(Physics.Raycast(ray, out hit, touchMask))
                {
                    GameObject recipient = hit.transform.gameObject;
                    touchList.Add(recipient);
                    if(touch.phase == TouchPhase.Began)
                    {
                        recipient.SendMessage("OnTouchDown", hit.point, SendMessageOptions.DontRequireReceiver);
                    }
                    if (touch.phase == TouchPhase.Ended)
                    {
                        recipient.SendMessage("OnTouchUp", hit.point, SendMessageOptions.DontRequireReceiver);
                    }
                    if (touch.phase == TouchPhase.Stationary)
                    {
                        recipient.SendMessage("OnTouchStay", hit.point, SendMessageOptions.DontRequireReceiver);
                    }
                    if (touch.phase == TouchPhase.Canceled)
                    {
                        recipient.SendMessage("OnTouchExit", hit.point, SendMessageOptions.DontRequireReceiver);
                    }
                }
            }
            foreach(GameObject item in touchOld)
            {

                if (!touchList.Contains(item))
                {
                    item.SendMessage("OnTouchExit", hit.point, SendMessageOptions.DontRequireReceiver);

                }
            }
        }

    }
   
}
