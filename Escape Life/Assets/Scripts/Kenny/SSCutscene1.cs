using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class SSCutscene1 : MonoBehaviour
{
    public float waitEnd = 5f;

    // Start is called before the first frame update
    void Start()
    {   
        StartCoroutine(WaitforVideoEnd());
    }

     IEnumerator WaitforVideoEnd()
    {
        yield return new WaitForSeconds(waitEnd);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
