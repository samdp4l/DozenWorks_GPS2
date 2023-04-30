using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class KeyUnlockObjects : MonoBehaviour
{
    [SerializeField]
    private GameObject key;
    [SerializeField]
    private GameObject lockedObject;

    public Animator animator;
    public float transTime = 1f;

    public int sceneNum;

    public void CheckKey()
    {
        if (key.activeSelf)
        {
            if (lockedObject.CompareTag("Drawer"))
            {
                SoundManager.instance.Play("LockUnlock");

                lockedObject.GetComponent<DrawerBehaviour>().locked = false;

                Destroy(gameObject);
            }

            if (lockedObject.CompareTag("Door"))
            {
                SoundManager.instance.Play("DoorOpen");
                animator.SetTrigger("Start");
                StartCoroutine(LoadLevel(levelIndex: sceneNum));
            }

        }
    }

    IEnumerator LoadLevel (int levelIndex)
    {
        animator.SetTrigger("Start");
        yield return new WaitForSeconds(transTime);
        SceneManager.LoadScene(levelIndex);
    }
}
