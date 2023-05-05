using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;

    float x;
    float z;

    public float Speed;
    Vector3 moveDirection;
    public Transform orientation;

    public bool canJump = false;
    public float jumpPower;


    // Start is called before the first frame update
    void Start()
    {
        jumpPower = 2000f;
        rb = GetComponent <Rigidbody>();
    }
    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            canJump = true;
        }
        else
        {
        canJump = false;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            canJump = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        MyInput();
        //rb.AddForce(x * Speed, 0, z * Speed, ForceMode.Force);
        if (canJump && Input.GetKeyDown(KeyCode.Space))
        {
            canJump = false;
            rb.AddForce(Vector3.up * jumpPower);
            rb.drag = 1.15f;
            Speed = 90f;
        }

        if(canJump == true)
        {
            rb.drag = 1.7f;
            Speed = 200f;
        }
        
        if(canJump == false)
        {
            rb.drag = 1.15f;
            Speed = 120f;
        }
    }

    void FixedUpdate()
    {
        MovePlayer();
    }

    void MyInput()
    {
        x = Input.GetAxisRaw("Horizontal");
        z = Input.GetAxisRaw("Vertical");
    }

    void MovePlayer()
    {
        moveDirection = orientation.forward * z + orientation.right * x;
        rb.AddForce(moveDirection.normalized * Speed, ForceMode.Force);
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
