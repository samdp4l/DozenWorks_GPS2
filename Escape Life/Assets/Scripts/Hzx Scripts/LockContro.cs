using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockContro : MonoBehaviour
{
    public Button button;
    // Start is called before the first frame update
    public int[] result, correctCombination;
    public bool isOpened;
    public Button Confirm;
    public void Start()
    {
        result = new int[] { 0, 0, 0 };
        correctCombination = new int[] { 1, 1, 1 };
        isOpened = false;
        Roate.Rotated += CheckResults;
        Button btn = Confirm.GetComponent<Button>();
        btn.onClick.AddListener(ConfirmClick);
    }
     public void CheckResults(string wheelName,int number)
    {
        switch(wheelName)
        {
            case "Cylinder002":
                result[0] = number;
                break;
            case "Cylinder005":
                result[1] = number;
                break;

            case "Cylinder001":
                result[0] = number;
                break;

            case "Cylinder004":
                result[1] = number;
                break;

                     case "Cylinder003":

                result[2] = number;
                break;
               
        }
        if(result[0] == correctCombination[0]
            && result[1]== correctCombination[1] && result[2] == correctCombination[2] && !isOpened 
            )
        {

            
 //transform.position = new Vector3(transform.position.x, transform.position.y + 0.3f, transform.position.z);
           
        isOpened = true;
          // Debug.Log("Password is Right!!");
        }
       // else
      //  {
       //     Debug.Log("Password is Wrong!!!!");
//}
       
    }
    public void OnDestroy()
    {
        Roate.Rotated -= CheckResults;
    }
     void ConfirmClick()
    {
        
        if(isOpened == true)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.005f, transform.position.z);
            Debug.Log("PassWord is Right");
        }
        else
        {
            Debug.Log("PassWord is Wrong");
        }
        
    }



}
