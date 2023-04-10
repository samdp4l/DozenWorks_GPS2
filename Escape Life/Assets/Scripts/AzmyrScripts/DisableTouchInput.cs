using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DisableTouchInput : MonoBehaviour
{
    private Collider collide;
    public Canvas[] canvases;

    private void Start()
    {
        collide = GetComponent<Collider>();
        collide.enabled = true;
        canvases = new Canvas[] 
            {
                GetInactiveCanvas("ItemInspectCanvas"), 
                GetInactiveCanvas("ItemInspectCanvas1")
         //had to declare as public and still put it here and the inspector of the game objects/cube/sphere/ for the touch not to work when inspecting
            };
    }

    private Canvas GetInactiveCanvas(string canvasName)
    {
        Canvas canvas = GameObject.Find(canvasName).GetComponent<Canvas>();
        if (canvas != null && !canvas.isActiveAndEnabled)
        {
            return canvas;
        }
        return null;
    }

    private void Update()
    {
        bool anyCanvasActive = false;
        foreach (Canvas canvas in canvases)
        {
            if (canvas != null && canvas.isActiveAndEnabled)
            {
                anyCanvasActive = true;
                break;
            }
        }

        if (anyCanvasActive)
        {
            collide.enabled = false;
        }
        else
        {
            collide.enabled = true;
        }
    }
}


