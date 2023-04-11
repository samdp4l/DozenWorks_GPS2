using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//WORKS
public class BallAccelerometer : MonoBehaviour
{
    //boolean to control accelerometer activation, requires deactivation after game and activation when opening the mini game. by default i put true
    public bool isFlat = true;

    private Rigidbody rigid;
    public float forceMultiplier = 1.0f;

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }


    void Update()
    {
        Vector3 tilt = Input.acceleration;
        if (isFlat)
        {
            tilt = Quaternion.Euler(90, 0, 0) * tilt;
        }
        rigid.AddForce(tilt* forceMultiplier);
    }
}
