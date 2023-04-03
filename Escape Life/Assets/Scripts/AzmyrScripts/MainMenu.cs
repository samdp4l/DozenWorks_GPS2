using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Room1()
    { 
        SceneManager.LoadScene(1);
    }

    public void Room2()
    {
        SceneManager.LoadScene(2);
    }

    public void Room3()
    {
        SceneManager.LoadScene(3);
    }
}
