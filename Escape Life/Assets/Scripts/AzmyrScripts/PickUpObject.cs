using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    public GameObject cube;
    public GameObject keyGone;
    public GameObject KeyImage;
   
    void Update()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == "PickUp")
                {
                    Debug.Log("Touched");
                    //Color newColor = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
                    //hit.collider.GetComponent<MeshRenderer>().material.color = newColor;
                    keyGone.SetActive(false);
                    KeyImage.SetActive(true);
                }
            }
        }   
    }
}
