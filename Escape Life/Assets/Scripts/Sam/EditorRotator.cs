using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditorRotator : MonoBehaviour
{
    [SerializeField]
    private float mouseSens = 100f;
    [SerializeField]
    private Transform playerRot;

    private float xRot = 0f;
    private float yRot = 0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;

        xRot -= mouseY;
        xRot = Mathf.Clamp(xRot, -90f, 90f);

        yRot += mouseX;

        transform.localRotation = Quaternion.Euler(xRot, yRot, 0f);
        //transform.Rotate(Vector3.up * mouseX);
    }
}
