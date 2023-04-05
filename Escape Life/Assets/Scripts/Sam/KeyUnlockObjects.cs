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
                SoundManager.instance.Play("LockUnlock");

                lockedObject.GetComponent<DrawerBehaviour>().locked = false;
            }

            if (lockedObject.CompareTag("Door"))
            {
                SoundManager.instance.Play("DoorOpen");

                Destroy(lockedObject);
            }

            Destroy(gameObject);
        }
    }
}
