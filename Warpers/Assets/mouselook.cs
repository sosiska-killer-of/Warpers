using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouselook : MonoBehaviour
{

public float mouseSensitivity = 100f;

public Transform playerBody;   
public Transform head; 

float xRotation = 0f;
float x1Rotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        x1Rotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        x1Rotation = Mathf.Clamp(xRotation, -50f, 50f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
        head.localRotation = Quaternion.Euler(x1Rotation, 0f, 0f);
    }
}
