using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallAccelerometer : MonoBehaviour
{
    public bool flat = true;
    private Rigidbody rigid;

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
        rigid.AddForce(tilt);
    }
}
