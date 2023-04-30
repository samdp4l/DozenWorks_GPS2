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
    private bool isOpened = false;
    private GameObject player;

    public Button confirmButton;
    public int inputCount;
    public Vector3 positionOffset;
    public float rotationOffset;
    public bool threeWheels;

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
                SoundManager.instance.Play("LockUnlock");

                isOpened = true;
                //Debug.Log("Password is Right!!");

                if (lockedObject.CompareTag("Drawer"))
                {
                    lockedObject.GetComponent<DrawerBehaviour>().locked = false;
                    player.GetComponent<PlayerInteract>().CancelInspect();
                    Destroy(gameObject);
                }

                if (lockedObject.CompareTag("LockBox"))
                {
                    player.GetComponent<PlayerInteract>().CancelInspect();
                    lockedObject.GetComponent<HingeJoint>().useSpring = true;

                    Destroy(lockedObject.GetComponentInParent<Collider>());
                    Destroy(gameObject);
                }
                if (lockedObject.CompareTag("LockedBook"))
                {
                    player.GetComponent<PlayerInteract>().CancelInspect();

                    Destroy(gameObject.GetComponent<LockControl>());
                    gameObject.tag = "Inspect";

                    lockedObject.GetComponent<BookLock>().UnlockBook();
                }
            }
            else
            {
                SoundManager.instance.Play("LockRattle");

                //Debug.Log("Password is Wrong!!!!");
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
