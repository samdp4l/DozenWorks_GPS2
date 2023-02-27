using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class PlaneIndicatorBehaviour : MonoBehaviour
{
    [SerializeField]
    private Camera cam;
    [SerializeField]
    private PlaneFinderBehaviour pfb;

    void Update()
    {
        Vector3 direction = cam.transform.position - pfb.PlaneIndicator.transform.position;

        Quaternion rotation = Quaternion.LookRotation(direction);
        pfb.PlaneIndicator.transform.rotation = rotation;
    }
}
