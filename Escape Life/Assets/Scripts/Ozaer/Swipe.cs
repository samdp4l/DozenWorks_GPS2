using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//WORKS, JUST NEED TO USE REFERENCE
public class Swipe : MonoBehaviour
{
    private bool swipeLeft, swipeRight, swipeUp, swipeDown, tap;
    private bool isDraging = false;
    private Vector2 startTouch, swipeLength;
    public Vector2 SwipeLength { get { return swipeLength; } }
    public bool Tap { get { return tap; } }
    public bool SwipeLeft { get { return swipeLeft; } }
    public bool SwipeRight { get { return swipeRight; } }
    public bool SwipeUp { get { return swipeUp; } }
    public bool SwipeDown { get { return swipeDown; } }


    private void Update()
    {
         swipeLeft = swipeRight = swipeUp = swipeDown = tap = false;
        // interaction
        if (Input.touches.Length > 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                isDraging = true;
                tap = true;
                startTouch = Input.touches[0].position;
            }
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                isDraging = false;
                Reset();
            }

        }
        // calculate distance
        swipeLength = Vector2.zero;
        if (isDraging)
        {
            if (Input.touches.Length != 0)
            {
                swipeLength = Input.touches[0].position - startTouch;
            }

        }

        //swipe far enough
        if (swipeLength.magnitude > 50)
        {
            float x = swipeLength.x;
            if (x > 0)
            {
                swipeRight = true;
            }
            else if (x < 0)
            {
                swipeLeft = true;
            }
            Reset();


        }
    }
      void Reset()
      {
        startTouch = swipeLength = Vector2.zero;
            isDraging = false;
      }
    }
