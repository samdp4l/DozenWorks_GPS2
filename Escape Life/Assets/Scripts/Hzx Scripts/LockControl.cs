using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockControl : MonoBehaviour
{
    public GameObject[] wheelObjects;
    [SerializeField]
    private int[] correctCombination;
    private int[] result;

    public Button confirmButton;
    //public Button button;
    private bool isOpened = false;

    public int inputCount;
    public float rotationOffset;

    public void Start()
    {
        result = new int[inputCount];

        isOpened = false;
        //Rotate.Rotated += CheckResults;
    }

    private void Update()
    {
        Debug.Log(isOpened);
    }

    public void CheckResults(/*string wheelName, int number*/)
    {
        for (int i = 0; i < inputCount; i++)
        {
            result[i] = wheelObjects[i].GetComponent<Rotate>().numberShown;
        }

        //switch(wheelName)
        //{
        //    case "Cylinder001":
        //        result[0] = number;
        //        break;

        //    case "Cylinder002":
        //        result[1] = number;
        //        break;

        //    case "Cylinder003":
        //        result[0] = number;
        //        break;

        //    case "Cylinder004":
        //        result[1] = number;
        //        break;

        //    case "Cylinder005":
        //        result[2] = number;
        //        break;
        //}
    }

    //public void OnDestroy()
    //{
    //    Rotate.Rotated -= CheckResults;
    //}

    void ConfirmResults()
    {
        bool wrongCombo = false;

        CheckResults();

        if (!isOpened)
        {
            for (int i = 0; i < inputCount; i++)
            {
                if (result[i] != correctCombination[i])
                {
                    wrongCombo = true;
                }
            }

            if (!wrongCombo)
            {
                isOpened = true;
                Debug.Log("Password is Right!!");
            }
            else
            {
                Debug.Log("Password is Wrong!!!!");
            }
        }

        //if (isOpened == true)
        //{
        //    transform.position = new Vector3(transform.position.x, transform.position.y + 0.005f, transform.position.z);
        //    Debug.Log("PassWord is Right");
        //}
        //else
        //{
        //    Debug.Log("PassWord is Wrong");
        //}
    }

    public void AttachButton()
    {
        confirmButton.onClick.AddListener(ConfirmResults);
    }

    public void DetachButton()
    {
        confirmButton.onClick.RemoveListener(ConfirmResults);
    }
}
