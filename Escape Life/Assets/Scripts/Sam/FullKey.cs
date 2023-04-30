using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullKey : MonoBehaviour
{
    [SerializeField]
    private GameObject firstHalf, secondHalf, fullKey;

    private void Update()
    {
        if (firstHalf.activeSelf && secondHalf.activeSelf)
        {
            firstHalf.SetActive(false);
            secondHalf.SetActive(false);
            fullKey.SetActive(true);
        }
    }
}
