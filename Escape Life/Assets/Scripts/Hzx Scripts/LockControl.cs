using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockControl : MonoBehaviour
{
    public GameObject[] wheelObjects;
    [SerializeField]
    private int[] correctCombination, result;
    private bool isOpened = false;
    private GameObject player;

    public Button confirmButton;
    public int inputCount;
    public float rotationOffset;

    [SerializeField]
    private GameObject lockedObject;

    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        result = new int[inputCount];

        isOpened = false;
    }

    public void CheckResults()
    {
        for (int i = 0; i < inputCount; i++)
        {
            result[i] = wheelObjects[i].GetComponent<Rotate>().numberShown;
        }
    }

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
                //Debug.Log("Password is Right!!");

                if (lockedObject.CompareTag("Drawer"))
                {
                    lockedObject.GetComponent<DrawerBehaviour>().locked = false;
                    player.GetComponent<PlayerInteract>().CancelInspect();
                    Destroy(gameObject);
                }
            }
            else
            {
                Debug.Log("Password is Wrong!!!!");
            }
        }
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
