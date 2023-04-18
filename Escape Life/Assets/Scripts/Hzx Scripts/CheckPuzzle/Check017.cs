using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check017 : MonoBehaviour
{
    // Start is called before the first frame update
    public bool applecheck = false;
      

    public GameObject Apple;
    public int CheckNum;
  static  public bool CheckRight017;


   public  void Start()
    {
        CheckRight017= false;
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

                CheckRight017 = true;
               
               //applecheck =true;
            }
            
            
     
        }
      
    }
 
}
