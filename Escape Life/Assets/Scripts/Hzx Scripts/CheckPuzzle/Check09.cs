using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check09 : MonoBehaviour
{
    // Start is called before the first frame update
    public bool applecheck = false;
      

    public GameObject Apple;
    public int CheckNum;
  static  public bool CheckRight09;


   public  void Start()
    {
        CheckRight09 = false;
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

                CheckRight09 = true;
               
               //applecheck =true;
            }
            
            
     
        }
      
    }
 
}
