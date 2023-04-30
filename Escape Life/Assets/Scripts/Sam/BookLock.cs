using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookLock : MonoBehaviour
{
    [SerializeField]
    private Transform bookBone, strapBone;
    [SerializeField]
    private GameObject[] wheels;
    [SerializeField]
    private Collider oldCollider;
    [SerializeField]
    private Vector3 newPos;

    public void UnlockBook()
    {
        bookBone.localEulerAngles = new Vector3(359.950256f, 0.853983879f, 6.66938686f);
        strapBone.localEulerAngles = new Vector3(3.99334407f, 330.040955f, 0.498373181f);

        Destroy(oldCollider);

        foreach (GameObject o in wheels)
        {
            Destroy(o);
        }


    }
}
