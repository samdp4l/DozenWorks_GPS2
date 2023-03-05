using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClickMovement : MonoBehaviour
{
    private Camera cam;
    private Touch firstTouch;
    [SerializeField]
    private float interactRange;
    [SerializeField]
    private Transform camTransform;

    private void Start()
    {
        cam = Camera.main;
        camTransform = Camera.main.transform;
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            firstTouch = Input.GetTouch(0);

            if (firstTouch.phase == TouchPhase.Began)
            {
                RaycastHit hit;
                Ray ray = cam.ScreenPointToRay(firstTouch.position);

                if (Physics.Raycast(ray, out hit, interactRange))
                {
                    if (hit.transform.CompareTag("Floor"))
                    {
                        camTransform.position = new Vector3(hit.point.x, camTransform.position.y, hit.point.z);
                    }
                }
            }
        }
    }
}
