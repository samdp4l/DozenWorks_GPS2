using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    private bool canInteract;
    [SerializeField]
    private Material oriMat;
    [SerializeField]
    private Material newMat;

    private void Start()
    {
        canInteract = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DetectRange"))
        { 
            canInteract= true;
            GetComponent<MeshRenderer>().material = newMat;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("DetectRange"))
        {
            canInteract= false;
            GetComponent<MeshRenderer>().material = oriMat;
        }
    }
}
