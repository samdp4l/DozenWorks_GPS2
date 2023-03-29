using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardTilt : MonoBehaviour
{
    public bool flat = true;
    private Quaternion Rotation;
    public float speed = 1.0f;

    void Start()
    {
        Rotation = transform.rotation;
    }

    void Update()
    {
        Vector3 tilt = Input.acceleration;
        if (flat)
        {
            tilt = Quaternion.Euler(90, 0, 0) * tilt;
        }
        Rotation.y += tilt.x;
        Rotation.x += tilt.y;
        transform.rotation = Rotation;
    }


}
