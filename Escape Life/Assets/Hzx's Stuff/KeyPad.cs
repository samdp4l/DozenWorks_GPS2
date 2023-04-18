using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyPad : MonoBehaviour
{
    [SerializeField]
    Text codeText;
    string codeTextValue = "";
    string PassportValue = "5657";
    public GameObject canvas;
   public  GameObject canvas1;
    public bool isdown = false;
    public bool playMusic = false;
    public   AudioSource _audioSource ;
    void Awake()
    {
        _audioSource = gameObject.AddComponent<AudioSource>();
    }

    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        codeText.text = codeTextValue;
      
        if (codeTextValue.Length > 4)
            codeTextValue = "";
      
    }
    public void AddDight(string digit)
    {
        codeTextValue += digit;
        
    }
    public void Confirm()
    {
       
        if(codeTextValue =="5657")
        {
            Debug.Log("Correct!");
            canvas.SetActive(false);
            canvas1.SetActive(true);
        }
        if (codeTextValue != "5657")
        {
            playMusic = true;
            if(playMusic == true)
            { //Find the audio playback at the specified location
                AudioClip audioClip = Resources.Load<AudioClip>("sound1");
                AudioSource.PlayClipAtPoint(audioClip, Camera.main.transform.position);
               _audioSource.clip = audioClip;
                _audioSource.Play();
            }
        }
    }
    public void Cancel()
    {
        
        codeTextValue = "";
        playMusic = false;
        }
        


    
    
}
