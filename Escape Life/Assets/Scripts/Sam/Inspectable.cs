using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inspectable : MonoBehaviour
{
    public float zoomSpeed = 0.1f, minZoomDistance = 0.5f, maxZoomDistance = 2.0f, rotationSpeed = 30.0f;

    private float _lastTouchDistance;
    private Vector2 lastTouchPosition;

    void Update()
    {
        if (Input.touchCount == 2)
        {
            Touch touch1 = Input.GetTouch(0);
            Touch touch2 = Input.GetTouch(1);

            if (touch1.phase == TouchPhase.Began || touch2.phase == TouchPhase.Began)
            {
                _lastTouchDistance = Vector2.Distance(touch1.position, touch2.position);
            }
            else if (touch1.phase == TouchPhase.Moved || touch2.phase == TouchPhase.Moved)
            {
                float currentTouchDistance = Vector2.Distance(touch1.position, touch2.position);

                float deltaDistance = currentTouchDistance - _lastTouchDistance;

                float zoomAmount = deltaDistance * zoomSpeed * Time.deltaTime;

                Vector3 newScale = transform.localScale + new Vector3(zoomAmount, zoomAmount, zoomAmount);

                newScale.x = Mathf.Clamp(newScale.x, minZoomDistance, maxZoomDistance);
                newScale.y = Mathf.Clamp(newScale.y, minZoomDistance, maxZoomDistance);
                newScale.z = Mathf.Clamp(newScale.z, minZoomDistance, maxZoomDistance);

                transform.localScale = newScale;

                _lastTouchDistance = currentTouchDistance;
            }
        }

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
