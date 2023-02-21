using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class SetStage : MonoBehaviour
{
    private Transform plane;
    [SerializeField]
    private Transform player;

    private void Start()
    {
        plane = GetComponent<PlaneFinderBehaviour>().PlaneIndicator.transform;
    }
    
    void Update()
    {
        Vector3 direction = player.position - transform.position;

        Quaternion rotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        plane.rotation = rotation;
    }
}
