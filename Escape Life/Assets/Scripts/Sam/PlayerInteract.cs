using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private Camera cam;
    private Transform camTransform;
    private Touch firstTouch;

    private Vector3 oriPos;
    private Quaternion oriRot;
    private RaycastHit hit;

    [SerializeField]
    private float interactRange, inspectDistance;
    [SerializeField]
    private GameObject inspectButton;
    [HideInInspector]
    public bool inspectMode = false;

    [SerializeField]
    private GameObject lightSource;
    private GameObject hitObject;
    [SerializeField]
    private LockCanvasBehaviour lockCanvas;
    [SerializeField]
    private GameObject inventoryBar;

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

                    if (hit.transform.CompareTag("Inspect"))
                    {
                        InspectObject(hit.transform.gameObject);
                    }

                    if (hit.transform.CompareTag("PickUp"))
                    {
                        hitObject = hit.transform.gameObject;
                        PickUp();
                    }

                    if (hit.transform.CompareTag("Lock"))
                    {
                        InspectLock();
                    }

                    if (hit.transform.CompareTag("KeyLock") || hit.transform.CompareTag("Door"))
                    {
                        hit.transform.gameObject.GetComponent<KeyUnlockObjects>().CheckKey();
                    }

                    if (hit.transform.CompareTag("Drawer"))
                    {
                        hit.transform.gameObject.GetComponent<DrawerBehaviour>().ToggleDrawer();
                    }

                    if (hit.transform.CompareTag("LightSwitch"))
                    {
                        lightSource.SetActive(!lightSource.activeSelf);
                    }
                }
            }
        }
    }

    public void InspectObject(GameObject obj)
    {
        obj.AddComponent<Inspectable>();

        inspectMode = true;
        inspectButton.SetActive(true);
        inventoryBar.SetActive(false);

        oriPos = obj.transform.position;
        oriRot = obj.transform.rotation;

        obj.transform.position = camTransform.position + camTransform.forward * inspectDistance;
        obj.transform.rotation.SetLookRotation(camTransform.position);

        hitObject = obj;
    }

    private void InspectLock()
    {
        hitObject = hit.transform.gameObject;

        inspectMode = true;
        inspectButton.SetActive(true);
        inventoryBar.SetActive(false);

        lockCanvas.GetComponent<LockCanvasBehaviour>().toggleCanvas();
        hitObject.GetComponent<LockControl>().AttachButton();

        for (int i = 0; i < hitObject.GetComponent<LockControl>().inputCount; i++)
        {
            lockCanvas.upButtons[i].onClick.AddListener(hitObject.GetComponent<LockControl>().wheelObjects[i].GetComponent<Rotate>().Rotateleft);
            lockCanvas.downButtons[i].onClick.AddListener(hitObject.GetComponent<LockControl>().wheelObjects[i].GetComponent<Rotate>().Rotateright);
        }

        oriPos = hitObject.transform.position;
        oriRot = hitObject.transform.rotation;

        hitObject.transform.position = camTransform.position + camTransform.forward * 0.1f;
        hitObject.transform.rotation = camTransform.rotation * Quaternion.Euler(0f, hitObject.GetComponent<LockControl>().rotationOffset, 0f);
    }

    public void CancelInspect()
    {
        inspectMode = false;
        inspectButton.SetActive(false);
        inventoryBar.SetActive(true);

        hitObject.transform.position = oriPos;
        hitObject.transform.rotation = oriRot;
        hitObject.transform.localScale = Vector3.one;

        if (hitObject.CompareTag("Inspect"))
        {
            Destroy(hit.transform.gameObject.GetComponent<Inspectable>());
        }

        if (hitObject.CompareTag("Lock"))
        {
            hitObject.GetComponent<LockControl>().DetachButton();

            for (int i = 0; i < hitObject.GetComponent<LockControl>().inputCount; i++)
            {
                lockCanvas.upButtons[i].onClick.RemoveListener(hitObject.GetComponent<LockControl>().wheelObjects[i].GetComponent<Rotate>().Rotateleft);
                lockCanvas.downButtons[i].onClick.RemoveListener(hitObject.GetComponent<LockControl>().wheelObjects[i].GetComponent<Rotate>().Rotateright);
            }

            lockCanvas.GetComponent<LockCanvasBehaviour>().toggleCanvas();
        }

        if (hitObject.CompareTag("PickUp"))
        {
            hitObject.SetActive(false);
        }
    }

    private void PickUp()
    {
        PickUpObject pickupObject = hitObject.GetComponent<PickUpObject>();

        if (pickupObject != null && !pickupObject.isPickedUp)
        {
            pickupObject.ObjectPickedUp();
        }
    }
}
