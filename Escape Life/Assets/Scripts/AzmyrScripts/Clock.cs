using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    //NOT FINAL DO NOT TOUCH

    [SerializeField] Transform hourHand;
    [SerializeField] Transform minuteHand;
    
    const float hoursToDegrees = 0f;
    const float minutesToDegrees = 6f;

    
    void Update()
    {  
        TimeSpan time = DateTime.Now.TimeOfDay;
        hourHand.localRotation = Quaternion.Euler(-90f, 0f, hoursToDegrees * (float)time.TotalHours);
        minuteHand.localRotation = Quaternion.Euler(-90f, 0f, minutesToDegrees * (float)time.TotalMinutes);       
    }

   
    //void Start()
    //{
    //    minuteHandInitialRotation = minuteHand.localEulerAngles;
    //}

    //void Update()
    //{
    //    TimeSpan time = DateTime.Now.TimeOfDay;
    //    float hourRotation = hoursToDegrees * (float)time.TotalHours;
    //    hourHand.localRotation = Quaternion.Euler(270f, 0f, hourRotation);

    //    float minuteRotation = minutesToDegrees * (float)time.TotalMinutes;
    //    minuteHand.localRotation = Quaternion.Euler(minuteHandInitialRotation.x, minuteHandInitialRotation.y, minuteRotation);
    //}
}
