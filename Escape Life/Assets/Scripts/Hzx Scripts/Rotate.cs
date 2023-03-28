using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Rotate : MonoBehaviour
{
    //public static event Action<string, int> Rotated = delegate { };
    private bool coroutineAllowed;
    [HideInInspector]
    public int numberShown;
 
    private void Start()
    {
        coroutineAllowed = true;
        numberShown = 0;
    }

    private void Update()
    {
        //Debug.Log($"{gameObject.name}: {numberShown}");
    }

    public void Rotateleft()
    {
        if(coroutineAllowed)
        {
            StartCoroutine("RotateLeft");
        }
    }

    public void Rotateright()
    {
        if (coroutineAllowed)
        {
            StartCoroutine("RotateRight");
        }
    }

    public IEnumerator RotateLeft()
    {
        coroutineAllowed = false;

        for(int i = 0; i<=11;i++)
        {
            transform.Rotate(0f, 0f, 3f);
            yield return new WaitForSeconds(0.01f);
        }

        coroutineAllowed = true;
        numberShown += 1;

        if(numberShown > 9)
        {
            numberShown = 0;
        }

        //Rotated(name, numberShown);
    }

    public IEnumerator RotateRight()
    {
        coroutineAllowed = false;

        for (int i = 0; i <= 11; i++)
        {
            transform.Rotate(0f, 0f, -3f);
            yield return new WaitForSeconds(0.01f);
        }

        coroutineAllowed = true;
        numberShown -= 1;

        if (numberShown < 0)
        {
            numberShown = 9;
        }

        //Rotated(name, numberShown);
    }

    public int GetCurrentNumber()
    {
        return numberShown;
    }
}
