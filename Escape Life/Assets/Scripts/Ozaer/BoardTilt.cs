using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// WORK IN PROGRESS
public class BoardTilt : MonoBehaviour
{
    public bool flat = true;
    private Quaternion Rotation;
    public float speed = 1.0f;

    [SerializeField]
    private GameObject ball;

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
            ball.GetComponent<BallAccelerometer>().isFlat = true;

            Rotation.y += Mathf.Clamp(tilt.y, -10, 10);
            Rotation.x += Mathf.Clamp(tilt.x, -10, 10);
            Rotation.z += Mathf.Clamp(tilt.z, -10, 10);

            transform.Rotate(new Vector3(Rotation.x, Rotation.y, Rotation.z));
        }
        else
        {
            ball.GetComponent<BallAccelerometer>().isFlat = false;
        }
    }
}
