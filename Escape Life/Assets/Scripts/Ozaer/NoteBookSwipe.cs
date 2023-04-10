using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteBookSwipe : MonoBehaviour
{
    public Swipe swipeControls;
    public GameObject text1;
    public GameObject text2;
    //public GameObject text3;
    //public int pageIndex = 0;
    //public int pageCount = 2;
    //void Start()
   // {
    //    pageIndex= 0;
   // }
    void Update()
    {
        if (swipeControls.SwipeLeft)// && pageIndex != pageCount)
        {
            //pageIndex++;
            text1.SetActive(false);
            text2.SetActive(true);
        }
        if (swipeControls.SwipeRight)// && pageIndex != 0)
        {
            text1.SetActive(true);
            text2.SetActive(false);
            //pageIndex--;
        }

       // if (pageIndex = 0)
       // {
       //     Showtext1();
       //
       // } else if (pageIndex = 1)
       // {
       //     Showtext2();
      //  }
       // else if (pageIndex = 2)
       // {
       //     Showtext3();
       // }
        
    }
   // private void Showtext1()
   // {
     //   text1.SetActive(true);
   //     text2.SetActive(false);
   //     text3.SetActive(false);
   // }
  //  private void Showtext2()
   // {
  //      text1.SetActive(false);
   //     text2.SetActive(true);
   //     text3.SetActive(false);
   // }
   // private void Showtext3()
   // {
   //     text1.SetActive(false);
    //    text2.SetActive(false);
    //    text3.SetActive(true);
   // }
}
