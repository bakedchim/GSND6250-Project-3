using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    public float senX = 1.0f;
    public float senY = 1.0f;
    float xRotation = 0.0f;
    float yRotation = 0.0f;

    public Transform gun;

    public Transform player;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * senX;
        float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * senY;

        yRotation += mouseX;
        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, -90.0f, 90.0f);

        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0.0f);
        player.localRotation = Quaternion.Euler(0.0f, yRotation, 0.0f);

        // Move gun vertically
        gun.localRotation = Quaternion.Euler(xRotation, 0.0f, 0.0f);
    }
}
