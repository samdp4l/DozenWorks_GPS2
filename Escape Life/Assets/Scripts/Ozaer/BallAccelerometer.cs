using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//WORKS
public class BallAccelerometer : MonoBehaviour
{
    public bool flat = true;
    private Rigidbody rigid;
    public float forceMultiplier = 1.0f;

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }


    void Update()
    {
        Vector3 tilt = Input.acceleration;
        if (flat)
        {
            tilt = Quaternion.Euler(90, 0, 0) * tilt;
        }
        rigid.AddForce(tilt* forceMultiplier);
    }
}
