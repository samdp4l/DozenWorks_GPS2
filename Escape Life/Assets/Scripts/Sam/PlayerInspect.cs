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
    private GameObject lockObject;
    [SerializeField]
    private LockCanvasBehaviour lockCanvas;

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
                    //Debug.Log(hit.transform.tag);

                    if (hit.transform.CompareTag("PickUp"))
                    {
                        inspectMode = true;
                        inspectButton.SetActive(true);

                        oriPos = hit.transform.position;
                        oriRot = hit.transform.rotation;

                        hit.transform.position = camTransform.position + camTransform.forward * inspectDistance;
                        hit.transform.rotation = camTransform.rotation;
                    }

                    if (hit.transform.CompareTag("Lock"))
                    {
                        lockObject = hit.transform.gameObject;

                        inspectMode = true;
                        inspectButton.SetActive(true);

                        lockCanvas.GetComponent<LockCanvasBehaviour>().toggleCanvas();
                        lockObject.GetComponent<LockControl>().AttachButton();

                        for (int i = 0; i < lockObject.GetComponent<LockControl>().inputCount; i++)
                        {
                            lockCanvas.upButtons[i].onClick.AddListener(lockObject.GetComponent<LockControl>().wheelObjects[i].GetComponent<Rotate>().Rotateleft);
                            lockCanvas.downButtons[i].onClick.AddListener(lockObject.GetComponent<LockControl>().wheelObjects[i].GetComponent<Rotate>().Rotateright);
                        }

                        oriPos = lockObject.transform.position;
                        oriRot = lockObject.transform.rotation;

                        lockObject.transform.position = camTransform.position + camTransform.forward * 0.1f;
                        lockObject.transform.rotation = camTransform.rotation * Quaternion.Euler(0f, lockObject.GetComponent<LockControl>().rotationOffset, 0f);
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

            if (hit.transform.CompareTag("PickUp"))
            {
                hit.transform.position = oriPos;
                hit.transform.rotation = oriRot;
            }

            if (hit.transform.CompareTag("Lock"))
            {
                lockObject.transform.position = oriPos;
                lockObject.transform.rotation = oriRot;

                lockObject.GetComponent<LockControl>().DetachButton();

                for (int i = 0; i < lockObject.GetComponent<LockControl>().inputCount; i++)
                {
                    lockCanvas.upButtons[i].onClick.RemoveListener(lockObject.GetComponent<LockControl>().wheelObjects[i].GetComponent<Rotate>().Rotateleft);
                    lockCanvas.downButtons[i].onClick.RemoveListener(lockObject.GetComponent<LockControl>().wheelObjects[i].GetComponent<Rotate>().Rotateright);
                }

                lockCanvas.GetComponent<LockCanvasBehaviour>().toggleCanvas();
            }
        }
    }
}
