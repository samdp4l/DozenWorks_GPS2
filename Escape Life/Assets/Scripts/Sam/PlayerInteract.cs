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
    private Vector3 oriScale;
    private RaycastHit hit;

    [SerializeField]
    private float interactRange, inspectDistance;
    [SerializeField]
    private GameObject inspectButton;
    [SerializeField]
    private GameObject resetButton;
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
                        SoundManager.instance.Play("PickupOthers");

                        hitObject = hit.transform.gameObject;
                        InspectObject();
                    }

                    if (hit.transform.CompareTag("PickUp"))
                    {
                        SoundManager.instance.Play("PickupKey");

                        hitObject = hit.transform.gameObject;
                        PickUp();
                    }

                    if (hit.transform.CompareTag("Lock"))
                    {
                        SoundManager.instance.Play("LockRattle");

                        hitObject = hit.transform.gameObject;
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
                        SoundManager.instance.Play("SwitchOn");
                        lightSource.SetActive(!lightSource.activeSelf);
                    }

                    if (hit.transform.CompareTag("Map"))
                    {
                        hit.transform.GetComponent<Rigidbody>().useGravity = true;
                        Invoke("StopGravity", 0.35f);
                    }

                    if (hit.transform.CompareTag("Puzzle"))
                    {
                        hitObject = hit.transform.gameObject;
                        InspectPuzzle();
                    }

                    if (hit.transform.CompareTag("Maze"))
                    {
                        hitObject = hit.transform.gameObject;
                        InspectMaze();
                    }
                }
            }
        }
    }

    public void InspectObject()
    {
        hitObject.AddComponent<Inspectable>();

        inspectMode = true;
        inspectButton.SetActive(true);
        resetButton.SetActive(true);
        inventoryBar.SetActive(false);

        oriPos = hitObject.transform.position;
        oriRot = hitObject.transform.rotation;
        oriScale = hitObject.transform.localScale;

        hitObject.transform.position = camTransform.position + camTransform.forward * inspectDistance;
        hitObject.transform.LookAt(camTransform.position);
    }

    public void ResetRotation()
    {
        hitObject.transform.position = camTransform.position + camTransform.forward * inspectDistance;
        hitObject.transform.LookAt(camTransform.position);
        hitObject.transform.localScale = oriScale;
    }

    private void InspectLock()
    {
        inspectMode = true;
        inspectButton.SetActive(true);
        inventoryBar.SetActive(false);

        lockCanvas.GetComponent<LockCanvasBehaviour>().threeButtons = hitObject.GetComponent<LockControl>().threeWheels;
        lockCanvas.GetComponent<LockCanvasBehaviour>().toggleCanvas();
        hitObject.GetComponent<LockControl>().AttachButton();

        for (int i = 0; i < hitObject.GetComponent<LockControl>().inputCount; i++)
        {
            lockCanvas.upButtons[i].onClick.AddListener(hitObject.GetComponent<LockControl>().wheelObjects[i].GetComponent<Rotate>().Rotateleft);
            lockCanvas.downButtons[i].onClick.AddListener(hitObject.GetComponent<LockControl>().wheelObjects[i].GetComponent<Rotate>().Rotateright);
        }

        oriPos = hitObject.transform.position;
        oriRot = hitObject.transform.rotation;

        hitObject.transform.position = camTransform.position + camTransform.forward * 0.1f + hitObject.GetComponent<LockControl>().positionOffset;
        hitObject.transform.rotation = camTransform.rotation * Quaternion.Euler(0f, hitObject.GetComponent<LockControl>().rotationOffset, 0f);
    }

    public void InspectInventory(GameObject invObj)
    {
        hitObject = invObj;
        InspectObject();
    }

    public void InspectPuzzle()
    {
        inspectMode = true;
        inspectButton.SetActive(true);

        oriPos = hitObject.transform.position;
        oriRot = hitObject.transform.rotation;
        oriScale = hitObject.transform.localScale;

        hitObject.transform.position = camTransform.position + camTransform.forward * inspectDistance;
        hitObject.transform.LookAt(camTransform.position);
    }

    public void InspectMaze()
    {
        inspectMode = true;
        inspectButton.SetActive(true);

        hitObject.transform.GetComponent<BoardTilt>().flat = true;

        oriPos = hitObject.transform.position;
        oriRot = hitObject.transform.rotation;
        oriScale = hitObject.transform.localScale;

        hitObject.transform.position = camTransform.position + camTransform.forward * inspectDistance;
        hitObject.transform.LookAt(camTransform.position);
    }

    public void CancelInspect()
    {
        inspectMode = false;
        inspectButton.SetActive(false);
        resetButton.SetActive(false);
        inventoryBar.SetActive(true);

        hitObject.transform.position = oriPos;
        hitObject.transform.rotation = oriRot;

        if (hitObject.CompareTag("Inspect"))
        {
            Destroy(hit.transform.gameObject.GetComponent<Inspectable>());
            hitObject.transform.localScale = oriScale;
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

        if (hitObject.CompareTag("Maze"))
        {
            hitObject.GetComponent<BoardTilt>().flat = false;
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

    private void StopGravity()
    {
        hit.transform.GetComponent<Rigidbody>().useGravity = false;
        hit.transform.GetComponent<Rigidbody>().velocity = Vector3.zero;
        Destroy(hit.transform.GetComponent<BoxCollider>());
    }
}
