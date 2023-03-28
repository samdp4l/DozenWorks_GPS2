using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class DrawerBehaviour : MonoBehaviour
{
    private bool isOpen = false;
    private bool moving = false;
    private float refVelo = 0f;
    private float oriPos;

    [SerializeField]
    private bool xMove;
    [SerializeField]
    private float targetPos;
    [SerializeField]
    private float drawerSpeed;

    private void Start()
    {
        if (xMove)
        {
            oriPos = transform.localPosition.x;
        }
        else
        {
            oriPos = transform.localPosition.z;
        }
    }

    private void Update()
    {
        if (moving)
        {
            if (!isOpen)
            {
                if (xMove)
                {
                    float newPos = Mathf.SmoothDamp(transform.localPosition.x, targetPos, ref refVelo, drawerSpeed);
                    transform.localPosition = new Vector3(newPos, transform.localPosition.y, transform.localPosition.z);
                    Debug.Log("1");
                }
                else
                {
                    float newPos = Mathf.SmoothDamp(transform.localPosition.z, targetPos, ref refVelo, drawerSpeed);
                    transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, newPos);
                    Debug.Log("2");
                }
            }
            else
            {
                if (xMove)
                {
                    float newPos = Mathf.SmoothDamp(transform.localPosition.x, oriPos, ref refVelo, drawerSpeed);
                    transform.localPosition = new Vector3(newPos, transform.localPosition.y, transform.localPosition.z);
                    Debug.Log("3");
                }
                else
                {
                    float newPos = Mathf.SmoothDamp(transform.localPosition.z, oriPos, ref refVelo, drawerSpeed);
                    transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, newPos);
                    Debug.Log("4");
                }
            }
        }
    }

    public void ToggleDrawer()
    {
        moving = true;

        Invoke("StopMoving", drawerSpeed);
    }

    private void StopMoving()
    {
        isOpen = !isOpen;
        moving = false;
    }
}
