using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmClock : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began &&
                GetComponent<Collider2D>() == Physics2D.OverlapPoint(touch.position))
            {
                if (audioSource.isPlaying)
                {
                    audioSource.Stop();
                }               
            }
        }
    }
}

