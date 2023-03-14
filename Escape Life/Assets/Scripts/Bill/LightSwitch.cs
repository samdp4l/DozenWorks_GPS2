using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    public GameObject lightorobj;
    [SerializeField] public GameObject dent;
    public Vector3 newPos, oldPos;

    private void Start()
    {
        dent.transform.localPosition = oldPos;
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                lightorobj.SetActive(!lightorobj.activeSelf);
                if (lightorobj.activeSelf)
                { 
                    dent.transform.localPosition = newPos;
                }
                else
                {
                    dent.transform.localPosition = oldPos;
                }
            }
        }
       
    }

}
