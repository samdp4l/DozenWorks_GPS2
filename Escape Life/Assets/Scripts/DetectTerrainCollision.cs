using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectTerrainCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Terrain"))
        {
            Debug.Log("You are in terrain!");
        }
    }
}
