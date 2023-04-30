using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check02 : MonoBehaviour
{
    // Start is called before the first frame update
    public bool applecheck = false;
      

    public GameObject Apple;
    public int CheckNum;
  static  public bool CheckRight02;


   public  void Start()
    {
        CheckRight02 = false;
    }
    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(transform.position, -transform.up);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
          
            if(hit.collider.gameObject == Apple)
            {

                CheckRight02 = true;
               
               //applecheck =true;
            }
            
            
     
        }
      
    }
 
}
