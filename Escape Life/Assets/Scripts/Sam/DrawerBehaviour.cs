using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class DrawerBehaviour : MonoBehaviour
{
    private bool isOpen = false, moving = false;
    private float refVelo = 0f, oriPos;

    public bool locked = false;
    [SerializeField]
    private bool xMove;
    [SerializeField]
    private float targetPos, drawerSpeed;

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
                }
                else
                {
                    float newPos = Mathf.SmoothDamp(transform.localPosition.z, targetPos, ref refVelo, drawerSpeed);
                    transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, newPos);
                }
            }
            else
            {
                if (xMove)
                {
                    float newPos = Mathf.SmoothDamp(transform.localPosition.x, oriPos, ref refVelo, drawerSpeed);
                    transform.localPosition = new Vector3(newPos, transform.localPosition.y, transform.localPosition.z);
                }
                else
                {
                    float newPos = Mathf.SmoothDamp(transform.localPosition.z, oriPos, ref refVelo, drawerSpeed);
                    transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, newPos);
                }
            }
        }
    }

    public void ToggleDrawer()
    {
        if (!locked && !moving)
        {
            SoundManager.instance.Play("DrawerSlide");

            moving = true;

            Invoke("StopMoving", 2f);
        }
    }

    private void StopMoving()
    {
        isOpen = !isOpen;
        moving = false;
    }
}
