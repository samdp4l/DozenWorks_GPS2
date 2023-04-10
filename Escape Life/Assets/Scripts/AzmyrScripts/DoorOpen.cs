using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public string pickupTag = "PickUp";
    public GameObject door;
    public GameObject keyImage;
    private bool isObjectPickedUp = false;
    public PickUpObject pickUpObject;

    private void Update()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit) && hit.transform == transform)
            {
                if (isObjectPickedUp)
                {         
                    //play animation/sound here
                    door.SetActive(false);
                }

                else if (pickUpObject.isPickedUp)
                {
                    // Set the isObjectPickedUp variable to true and opens the door
                    isObjectPickedUp = true;
                    pickUpObject.ObjectPickedUp();
                    door.SetActive(false); 
                    keyImage.SetActive(false);

                }

                else
                {
                    Debug.Log("no key collected");
                }
            }
        }
    }
}
