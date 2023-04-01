using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    [SerializeField] Transform hourHand;
    [SerializeField] Transform minuteHand;
    [SerializeField] Transform secondHand;

    const float hoursToDegrees = 30f;
    const float minutesToDegrees = 6f;
    const float secondsToDegrees = 6f;

    [SerializeField] Canvas gameOverCanvas; 
    [SerializeField] float timer = 1f;
    bool canvasDisplayed = false;

    float elapsedSeconds = 0f;

    void Start()
    {
        hourHand.localRotation = Quaternion.Euler(-90f, 0f, -90f);
        minuteHand.localRotation = Quaternion.Euler(-90f, 0f, 0f);
        secondHand.localRotation = Quaternion.Euler(-90f, 0f, -90f); //the second hand keeps starting at 15 seconds instead of 0
    }

    void UpdateClock()
    {
        float currentSeconds = Time.time;
       
        elapsedSeconds += Time.deltaTime;

        float minutesRotation = minutesToDegrees * (currentSeconds / 60f); 
        float secondsRotation = secondsToDegrees * (currentSeconds % 60f);

        minuteHand.localRotation = Quaternion.Euler(-90f, 0f, minutesRotation); 
        secondHand.localRotation = Quaternion.Euler(-90f, 0f, secondsRotation);

        if (!canvasDisplayed && elapsedSeconds >= timer)
        {
            Time.timeScale = 0f;
            gameOverCanvas.gameObject.SetActive(true); 
            canvasDisplayed = true; 
            elapsedSeconds = 0f; 
        }
    }

    void Update()
    {
        UpdateClock();      
    }
}
