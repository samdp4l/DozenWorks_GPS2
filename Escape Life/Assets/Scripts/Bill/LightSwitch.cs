using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;

public class LightSwitch : MonoBehaviour
{
    public GameObject lightorobj;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.CompareTag("LightSwitch"))
                {
                    SoundManager.instance.Play("SwitchOn");

                    lightorobj.SetActive(!lightorobj.activeSelf);
                }
            }
        }
    }
}
