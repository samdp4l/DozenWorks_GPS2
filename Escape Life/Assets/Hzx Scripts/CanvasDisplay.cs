using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasDisplay : MonoBehaviour
{
    public GameObject canvas;
    public  void showCanvas()
    {
        canvas.SetActive(true);
    }
   // public void HideCanvas()
   // {
    //    canvas.SetActive(false);
   // }
    // Start is called before the first frame update
    void Start()
    {
        canvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
