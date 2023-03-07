using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PlayerClickMovement : MonoBehaviour
{
    private Camera cam;
    private Touch firstTouch;
    [SerializeField]
    private float moveRange;
    [SerializeField]
    private Transform camTransform;
    [SerializeField]
    private float smoothTime;

    private float hitPointX;
    private float hitPointZ;

    private float refVeloX = 0f;
    private float refVeloZ = 0f;

    private void Start()
    {
        cam = Camera.main;
        camTransform = Camera.main.transform;

        hitPointX = camTransform.position.x;
        hitPointZ = camTransform.position.z;
    }

    private void Update()
    {
        if (Input.touchCount > 0 && !gameObject.GetComponent<PlayerInspect>().inspectMode)
        {
            firstTouch = Input.GetTouch(0);

            if (firstTouch.phase == TouchPhase.Began)
            {
                RaycastHit hit;
                Ray ray = cam.ScreenPointToRay(firstTouch.position);

                if (Physics.Raycast(ray, out hit, moveRange))
                {
                    if (hit.transform.CompareTag("Floor"))
                    {
                        hitPointX = hit.point.x;
                        hitPointZ = hit.point.z;
                    }
                }
            }
        }

        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, moveRange))
            {
                if (hit.transform.CompareTag("Floor"))
                {
                    hitPointX = hit.point.x;
                    hitPointZ = hit.point.z;
                }
            }
        }

        PlayerMove(hitPointX, hitPointZ);
    }

    private void PlayerMove(float hitX, float hitZ)
    {
        float newPosX = Mathf.SmoothDamp(camTransform.position.x, hitX, ref refVeloX, smoothTime);
        float newPosZ = Mathf.SmoothDamp(camTransform.position.z, hitZ, ref refVeloZ, smoothTime);

        camTransform.position = new Vector3(newPosX, camTransform.position.y, newPosZ);
    }
}
