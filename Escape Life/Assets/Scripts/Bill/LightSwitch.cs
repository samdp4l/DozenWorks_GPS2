using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;

public class LightSwitch : MonoBehaviour
{
    public bool isOn = true;
    public GameObject lightObj;

    private void Start()
    {
        isOn = true;
        lightObj.SetActive(isOn);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            //Debug.Log("Click is working");
            if (Physics.Raycast(ray, out hit) && hit.collider.CompareTag("LightSwitch"))
            {
                SoundManager.instance.Play("SwitchOn");
                toggleLights();
                //Debug.Log("Switch check is working");
            }
        }
    }

    public void toggleLights()
    {
        isOn = !isOn;
        lightObj.SetActive(isOn);
    }
}
