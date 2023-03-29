using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwipe : MonoBehaviour
{
    private Touch initialTouch = new Touch();
    public Camera mobileCam;
    private float xRot = 0.0f;
    private float yRot = 0.0f;
    public Vector3 initialRot;
    public float rotSpeed = 1.0f;

    void Start()
    {
        initialRot = mobileCam.transform.eulerAngles;
        xRot = initialRot.x;
        yRot = initialRot.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                initialTouch = touch;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                float diffX = initialTouch.position.x - touch.position.x;
                float diffY = initialTouch.position.y - touch.position.y;
                xRot += diffY * Time.deltaTime * rotSpeed;
                yRot -= diffX * Time.deltaTime * rotSpeed;

            }
            else if (touch.phase == TouchPhase.Ended)
            {
                initialTouch = touch;
            }
        }
    }
}