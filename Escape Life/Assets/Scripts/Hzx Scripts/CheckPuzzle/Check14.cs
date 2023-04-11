using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check14 : MonoBehaviour
{
    // Start is called before the first frame update
    public bool applecheck = false;
      

    public GameObject Apple;
    public int CheckNum;
  static  public bool CheckRight14;


   public  void Start()
    {
        CheckRight14 = false;
    }
    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(transform.position, -transform.up);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
         // Debug.Log("14" + hit.collider.name);
            if(hit.collider.gameObject == Apple)
            {

                CheckRight14 = true;
               
               //applecheck =true;
            }
            
            
     
        }
      
    }
 
}
