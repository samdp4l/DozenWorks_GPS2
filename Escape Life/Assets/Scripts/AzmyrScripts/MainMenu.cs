using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Animator animator;
    
    public float transTime = 1f;
    private void Start()
    {
        SoundManager.instance.Play("BGM");
    }

    public void Room1()
    {
        SoundManager.instance.Stop("BGM");
        animator.SetTrigger("Start");
        StartCoroutine(LoadLevel(levelIndex: 2));
    }

    public void Room2()
    {
        SoundManager.instance.Stop("BGM");
        animator.SetTrigger("Start");
        StartCoroutine(LoadLevel(levelIndex: 4));
    }

    public void Room3()
    {
        SoundManager.instance.Stop("BGM");
        SceneManager.LoadScene(9);
    }

    IEnumerator LoadLevel (int levelIndex)
    {
        animator.SetTrigger("Start");
        yield return new WaitForSeconds(transTime);
        SceneManager.LoadScene(levelIndex);
    }
}
