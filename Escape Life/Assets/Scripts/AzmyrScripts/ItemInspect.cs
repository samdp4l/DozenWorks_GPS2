using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInspect : MonoBehaviour
{
    public Canvas canvas;
    public Canvas inventory;

    private void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;
          
            if (Physics.Raycast(ray, out hit) && hit.transform.gameObject == gameObject)
            {
                canvas.gameObject.SetActive(true);
                inventory.gameObject.SetActive(false); //closes the inventory bar when inspecting items in the game
            }
        }
    }
}
