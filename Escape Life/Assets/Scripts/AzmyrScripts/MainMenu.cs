using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void Start()
    {
        SoundManager.instance.Play("BGM");
    }

    public void Room1()
    {
        SoundManager.instance.Stop("BGM");
        SceneManager.LoadScene(2);
    }

    public void Room2()
    {
        SoundManager.instance.Stop("BGM");
        SceneManager.LoadScene(4);
    }

    public void Room3()
    {
        SoundManager.instance.Stop("BGM");
        SceneManager.LoadScene(5);
    }
}
