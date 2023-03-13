using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomInOut : MonoBehaviour
{
    public float zoomSpeed = 0.1f;
    public float minZoomDistance = 1.0f;
    public float maxZoomDistance = 10.0f;

    private float _lastTouchDistance;

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
    }
}
