using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.GraphicsBuffer;

public class PlayerClickMovement : MonoBehaviour
{
    private Touch firstTouch;
    private bool tappedOnce = false;
    [SerializeField]
    private float doubleTapThreshold;
    private float firstTapTime = 0f;

    private Camera cam;
    [SerializeField]
    private Transform camTransform;

    [SerializeField]
    private float moveRange, walkMoveSpeed;
    private float moveSmoothTime, targetX, targetZ, refVeloX = 0f, refVeloZ = 0f;

    [SerializeField]
    private float crouchMoveSpeed, standHeight, crouchHeight, crouchSmoothTime;
    private float crouchRefVelo = 0f;
    private bool collided = false, crouching = false, crouched = false;

    private void Awake()
    {
        cam = Camera.main;
    }

    private void Start()
    {
        moveSmoothTime = walkMoveSpeed;
        targetX = transform.position.x;
        targetZ = transform.position.z;
    }

    private void Update()
    {
        if (Input.touchCount > 0 && !gameObject.GetComponent<PlayerInteract>().inspectMode)
        {
            firstTouch = Input.GetTouch(0);

            if (firstTouch.phase == TouchPhase.Began && !tappedOnce)
            {
                tappedOnce = true;
                firstTapTime = Time.time;
            }
            else if (firstTouch.phase == TouchPhase.Began && tappedOnce && (Time.time - firstTapTime) <= doubleTapThreshold && !crouching)
            {
                crouching = true;

                tappedOnce = false;
                firstTapTime = 0f;

                if (crouched)
                {
                    moveSmoothTime = walkMoveSpeed;
                }
                else
                {
                    moveSmoothTime = crouchMoveSpeed;
                }

                Invoke("StopCrouch", crouchSmoothTime + 2f);
            }
        }
        else if (tappedOnce && (Time.time - firstTapTime) > doubleTapThreshold && !gameObject.GetComponent<PlayerInteract>().inspectMode)
        {
            tappedOnce = false;
            firstTapTime = 0f;

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

        if (gameObject.GetComponent<PlayerInteract>().inspectMode)
        {
            targetX = transform.position.x;
            targetZ = transform.position.z;
        }

        if (crouching)
        {
            PlayerCrouch();
        }

        if (!collided)
        {
            PlayerMove(targetX, targetZ);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        collided = true;
    }

    private void PlayerMove(float hitX, float hitZ)
    {
        float newPosX = Mathf.SmoothDamp(transform.position.x, hitX, ref refVeloX, moveSmoothTime);
        float newPosZ = Mathf.SmoothDamp(transform.position.z, hitZ, ref refVeloZ, moveSmoothTime);

        transform.position = new Vector3(newPosX, transform.position.y, newPosZ);
    }

    private void PlayerCrouch()
    {
        if (!crouched)
        {
            float newPos = Mathf.SmoothDamp(camTransform.localPosition.y, crouchHeight, ref crouchRefVelo, crouchSmoothTime);
            camTransform.localPosition = new Vector3(camTransform.localPosition.x, newPos, camTransform.localPosition.z);
        }
        else
        {
            float newPos = Mathf.SmoothDamp(camTransform.localPosition.y, standHeight, ref crouchRefVelo, crouchSmoothTime);
            camTransform.localPosition = new Vector3(camTransform.localPosition.x, newPos, camTransform.localPosition.z);
        }
    }

    private void StopCrouch()
    {
        crouched = !crouched;
        crouching = false;
    }
}
