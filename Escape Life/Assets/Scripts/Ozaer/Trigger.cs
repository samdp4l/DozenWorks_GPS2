using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    BallAccelerometer ballAccelerometer;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("You Got it!");
            ballAccelerometer.isFlat = false;

        }
    }
}
