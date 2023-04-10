using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    public GameObject keyGone, keyImage;
    public bool isPickedUp { get; private set; }

    public void ObjectPickedUp()
    {
        isPickedUp = true;
        keyGone.SetActive(false);
        keyImage.SetActive(true);
    }
}

