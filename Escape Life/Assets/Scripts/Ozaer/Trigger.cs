using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public GameObject panel;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ball")
        {
            //Debug.Log("You Got it!");
            panel.transform.localEulerAngles += new Vector3(180f, 0f, 0f);

            Destroy(gameObject.GetComponent<Collider>());
        }
    }
}
