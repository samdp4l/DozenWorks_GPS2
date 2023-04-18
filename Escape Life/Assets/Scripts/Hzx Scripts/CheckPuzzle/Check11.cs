using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check11 : MonoBehaviour
{
    // Start is called before the first frame update
    public bool applecheck = false;
      

    public GameObject Apple;
    public int CheckNum;
  static  public bool CheckRight11;


   public  void Start()
    {
        CheckRight11 = false;
    }
    // Update is called once per frame
    public void Update()
    {
        Ray ray11 = new Ray(transform.position, -transform.up);
        RaycastHit hit;
        if (Physics.Raycast(ray11, out hit, Mathf.Infinity))
        {
          //  Debug.Log("11" + hit.collider.name);
            if (hit.collider.gameObject == Apple)
            {

                CheckRight11 = true;
               //applecheck =true;
            }
            
            
     
        }
      
    }
 
}
