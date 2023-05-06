using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSmovement : MonoBehaviour
{
    [SerializeField] private Transform mainCamera;
    [SerializeField] private float sensitivity;
    [SerializeField] private Rigidbody rigidbody;
    [SerializeField] private float moveForce;
    [SerializeField] private float maxMoveSpeed;

    [SerializeField] private GameObject CheckSphere;
    [SerializeField] private float CheckSphereRadius;
    [SerializeField] private LayerMask groundLayerMask;
    [SerializeField] private float jumpforce;

    [SerializeField] private float gravityScale;

    private bool grounded;
    private float pitch;
    private float yaw;

    private void Start() {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update() {
        yaw += Input.GetAxisRaw("Mouse X") * sensitivity;
        pitch -= Input.GetAxisRaw("Mouse Y") * sensitivity;
        pitch = Mathf.Clamp(pitch, -90f, 90f);

        transform.localRotation = Quaternion.Euler(0, yaw, 0);
        mainCamera.localRotation = Quaternion.Euler(pitch, 0, 0);

        grounded = Physics.CheckSphere(CheckSphere.transform.position, CheckSphereRadius, groundLayerMask);
        if(Input.GetKeyDown(KeyCode.Space) && grounded) {
            rigidbody.AddForce(new Vector3(0, jumpforce, 0));
        }
    }

    private void FixedUpdate() {
        rigidbody.AddRelativeForce(new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")) * moveForce);

        Vector3 vel = new Vector3(rigidbody.velocity.x, 0, rigidbody.velocity.z);
        rigidbody.AddForce(-vel * (moveForce / maxMoveSpeed), ForceMode.Acceleration);

        rigidbody.AddForce(Physics.gravity.y * Vector3.up * gravityScale, ForceMode.Acceleration);
    }

    public void DisableMovement()
    {
        if (gameObject.CompareTag("player"))
        {
            GameObject myGameObject = gameObject;
            enabled = false;
            myGameObject.tag = "Teammate";
        }

    }
}
