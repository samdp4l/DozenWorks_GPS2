using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LockCanvasBehaviour : MonoBehaviour
{
    public Button[] upButtons;
    public Button[] downButtons;

    [HideInInspector]
    public bool threeButtons;

    public void toggleCanvas()
    {
        if (gameObject.activeSelf)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);

            if (threeButtons)
            {
                upButtons[3].gameObject.SetActive(false);
                downButtons[3].gameObject.SetActive(false);
            }
            else
            {
                upButtons[3].gameObject.SetActive(true);
                downButtons[3].gameObject.SetActive(true);
            }
        }
    }
}
