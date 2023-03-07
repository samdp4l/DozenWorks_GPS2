using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInspect : MonoBehaviour
{
    private Camera cam;
    private Transform camTransform;
    private Touch firstTouch;
    [SerializeField]
    private float interactRange;
    [SerializeField]
    private float inspectDistance;
    [SerializeField]
    private GameObject inspectButton;

    private Vector3 oriPos;
    private Quaternion oriRot;
    private RaycastHit hit;

    [HideInInspector]
    public bool inspectMode = false;

    private void Awake()
    {
        cam = Camera.main;
        camTransform = Camera.main.transform;
    }

    void Update()
    {
        if (Input.touchCount > 0 && !inspectMode)
        {
            firstTouch = Input.GetTouch(0);

            if (firstTouch.phase == TouchPhase.Began)
            {
                Ray ray = cam.ScreenPointToRay(firstTouch.position);

                if (Physics.Raycast(ray, out hit, interactRange))
                {
                    if (hit.transform.CompareTag("PickUp"))
                    {
                        inspectMode = true;
                        inspectButton.SetActive(true);

                        oriPos = hit.transform.position;
                        oriRot = hit.transform.rotation;

                        hit.transform.position = camTransform.position + camTransform.forward * inspectDistance;
                        hit.transform.rotation = new Quaternion(0.0f, camTransform.rotation.y, 0.0f, camTransform.rotation.w);
                    }
                }
            }
        }
    }

    public void CancelInspect()
    {
        if (inspectMode)
        {
            inspectMode = false;
            inspectButton.SetActive(false);

            hit.transform.position = oriPos;
            hit.transform.rotation = oriRot;
        }
    }
}
