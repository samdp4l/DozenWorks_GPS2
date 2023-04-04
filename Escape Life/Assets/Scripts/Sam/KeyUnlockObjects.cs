using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyUnlockObjects : MonoBehaviour
{
    [SerializeField]
    private GameObject key;
    [SerializeField]
    private GameObject lockedObject;

    public void CheckKey()
    {
        if (key.activeSelf)
        {
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
