using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    private float _rotationSpeed = 50.0f;
    private Vector2 _lastTouchPosition;

    void Update()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                _lastTouchPosition = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                Vector2 delta = touch.position - _lastTouchPosition;

                float rotationX = delta.y * _rotationSpeed * Time.deltaTime;
                float rotationY = -delta.x * _rotationSpeed * Time.deltaTime;

                transform.Rotate(new Vector3(rotationX, rotationY, 0));

                _lastTouchPosition = touch.position;
            }
        }
    }
}
