using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    public GameObject keyGone;
    public GameObject keyImage;
    public string pickupTag = "PickUp";
    public bool isPickedUp { get; private set; }

    public void ObjectPickedUp()
    {
        isPickedUp = true;
        keyGone.SetActive(false);
        keyImage.SetActive(true);
    }

    void Update()
    {
        for (int i = 0; i < Input.touchCount; i++)
        {
            if (Input.touches[i].phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.touches[i].position);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit) && hit.transform.CompareTag(pickupTag))
                {
                    PickUpObject pickupObject = hit.transform.GetComponent<PickUpObject>();
                    if (pickupObject != null && !pickupObject.isPickedUp)
                    {
                        pickupObject.isPickedUp = true;
                        pickupObject.keyGone.SetActive(false);
                        pickupObject.keyImage.SetActive(true);
                        pickupObject.ObjectPickedUp();
                    }
                }
            }
        }


    }
}

