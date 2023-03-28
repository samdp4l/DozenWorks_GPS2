using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    [SerializeField] Transform hourHand;
    [SerializeField] Transform minuteHand;
    [SerializeField] Transform secondHand;
    const float hoursToDegrees = 0f;
    const float minutesToDegrees = 6f;
   
    void Update()
    {
        TimeSpan time = DateTime.Now.TimeOfDay;
        hourHand.localRotation = Quaternion.Euler(-90f, 0f, hoursToDegrees * (float)time.TotalHours);
        minuteHand.localRotation = Quaternion.Euler(-90f, 0f, minutesToDegrees * (float)time.TotalMinutes);       
    }
}
