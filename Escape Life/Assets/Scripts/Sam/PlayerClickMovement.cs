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
    private float moveRange, smoothTime;
    [SerializeField]
    private Transform camTransform;

    private float targetX, targetZ, refVeloX = 0f, refVeloZ = 0f;

    private bool collided = false;

    private void Awake()
    {
        cam = Camera.main;
    }

    private void Start()
    {
        targetX = transform.position.x;
        targetZ = transform.position.z;
    }

    private void Update()
    {
        if (Input.touchCount > 0 && !gameObject.GetComponent<PlayerInteract>().inspectMode)
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
                        collided = false;

                        targetX = hit.point.x;
                        targetZ = hit.point.z;
                    }
                }
            }
        }

        if (gameObject.GetComponent<PlayerInteract>().inspectMode)
        {
            targetX = transform.position.x;
            targetZ = transform.position.z;
        }

        PlayerMove(targetX, targetZ);
    }

    private void OnCollisionEnter(Collision other)
    {
        collided = true;
    }

    private void PlayerMove(float hitX, float hitZ)
    {
        if (!collided)
        {
            float newPosX = Mathf.SmoothDamp(transform.position.x, hitX, ref refVeloX, smoothTime);
            float newPosZ = Mathf.SmoothDamp(transform.position.z, hitZ, ref refVeloZ, smoothTime);

            transform.position = new Vector3(newPosX, transform.position.y, newPosZ);
        }
    }
}
