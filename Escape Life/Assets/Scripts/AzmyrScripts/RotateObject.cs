using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float rotationSpeed = 20.0f;
    private Vector2 lastTouchPosition;

    void Update()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                lastTouchPosition = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                Vector2 delta = touch.position - lastTouchPosition;

                float rotationX = delta.y * rotationSpeed * Time.deltaTime;
                float rotationY = -delta.x * rotationSpeed * Time.deltaTime;

                transform.Rotate(new Vector3(rotationX, rotationY, 0));

                lastTouchPosition = touch.position;
            }
        }
    }
}
