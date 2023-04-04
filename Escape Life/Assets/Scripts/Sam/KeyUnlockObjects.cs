using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyUnlockObjects : MonoBehaviour
{
    [SerializeField]
    private GameObject key;
    [SerializeField]
    private GameObject lockedObject;

    private bool locked = true;

    public void CheckKey()
    {
        if (key.activeSelf)
        {
            locked = false;

            if (lockedObject.CompareTag("Drawer"))
            {
                lockedObject.GetComponent<DrawerBehaviour>().locked = false;
            }

            if (lockedObject.CompareTag("Door"))
            {
                Destroy(lockedObject);
            }

            Destroy(gameObject);
        }
    }
}
