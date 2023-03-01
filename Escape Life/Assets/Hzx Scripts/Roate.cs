using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Roate : MonoBehaviour
{
    public static event Action<string, int> Rotated = delegate { };
    private bool coroutineAllowed;
    private int numberShown;
 
    // Start is called before the first frame update
   private void Start()
    {
        coroutineAllowed = true;
        numberShown = 0;
      

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
        if(numberShown>9)
        {
            numberShown = 0;
        }
        Rotated(name, numberShown);
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
        if (numberShown < 9)
        {
            numberShown = 0;
        }
        Rotated(name, numberShown);
    }
    // Update is called once per frame

}
