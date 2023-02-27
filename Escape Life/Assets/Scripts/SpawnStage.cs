using System.Collections;
using System.Collections.Generic;
using System.Drawing.Text;
using UnityEngine;
using Vuforia;

public class SpawnStage : MonoBehaviour
{
    [SerializeField]
    private GameObject stagePrefab;

    public void PlaceStage()
    {
        private Vector3 position;
        private Vector3 rotation;

        Instantiate(stagePrefab, transform.position, transform.rotation);
    }
}
