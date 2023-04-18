using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Animations;
public class Swith : MonoBehaviour
{
    public Transform first;
    MeshRenderer mr;
    GameObject Image;
    public GameObject box;
   // Animator animator;

   
    
    
 private string corrcetImageName = null;
        public Image[] image = null;
    void Start()
    {
        mr = GetComponent<MeshRenderer>();
        List<Image> tempImage = new List<Image>();
        //animator = box.GetComponent<Animator>();
        for (int i = 0; i < this.image.Length; i++)
        {
            tempImage.Add(this.image[i]);
            this.corrcetImageName += this.image[i].name;
        }
     //   print("正确的图片名字构成顺序：" + this.corrcetImageName.ToString());


    }
  
               



    
    
       
    


    private void Awake()
    {
        first = null;
    }
    
   public  void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
         
            // mr.material.EnableKeyword("_EMISSION");
         //first.GetComponent<Animator>().enabled = true;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Physics.Raycast(ray, out hit);
            if(first ==null)
            {
                first = hit.transform;
            }
            else if(first != hit.transform)
            {
                Vector3 temp = first.position;
                first.position = hit.transform.position;
                hit.transform.position = temp;
                first = null;
              //  .GetComponent<Animator>().enabled = false;
            // first.GetComponent<MeshRenderer>().material.color = Color.white;
            }
        }
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray1 = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit1;
            Physics.Raycast(ray1, out hit1);
            if(box == null)
            {
                box = hit1.collider.gameObject;
              box.GetComponent<Animator>().enabled = true;
            }
            if(hit1.collider.gameObject != box)
            {
                box.GetComponent<Animator>().Play("Defult", 0, 0);
                box.GetComponent<Animator>().Update(0);
                box.GetComponent<Animator>().enabled = false;
                
                //  box.GetComponent<MeshRenderer>().material.color = Color.white;
                box = null;

               
               
            }
        }
    }
  
}


