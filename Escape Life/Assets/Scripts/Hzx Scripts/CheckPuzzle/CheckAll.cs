using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckAll : MonoBehaviour
{

    // Start is called before the first frame update
  public void CheckAll1()
    {
        if(Check11.CheckRight11 == true && Check14.CheckRight14 == true && Check08.CheckRight08 == true && Check09.CheckRight09 == true && Check017.CheckRight017 == true
            && Check02.CheckRight02 == true && Check03.CheckRight03 == true && Check04.CheckRight04 == true && Check05.CheckRight05 == true 
            && Check06.CheckRight06 == true && Check07.CheckRight07 == true && Check10.CheckRight10 == true && Check12.CheckRight12 == true 
            && Check13.CheckRight13 == true && Check15.CheckRight15 == true && Check16.CheckRight16 == true)
        {
            Debug.Log("Win");
        }
        else
        {
            Debug.Log("False;");
        }
    }
}
