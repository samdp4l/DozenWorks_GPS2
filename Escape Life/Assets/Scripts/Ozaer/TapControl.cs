using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapControl : MonoBehaviour
{
    public GameObject CloseContainer;
    public GameObject OpenedContainer;
    public GameObject NoteBookPanel;

    void Update()
    {
        
        // Touch touch = Input.GetTouch(0);
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Touch touch = Input.GetTouch(0);
            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "ClosedContainer")
                {
                    CloseContainer.SetActive(false);
                    OpenedContainer.SetActive(true);
                }
                else if (hit.collider.tag == "NoteBook")
                {
                    NoteBookPanel.SetActive(true);
                }
            }

        }
    }
}
