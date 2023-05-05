using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamScript : MonoBehaviour
{
    [Header("References")]
    public Transform orientation;
    public Transform player;
    public Transform playerobj;
    public Rigidbody rb;
    public Transform combatLookAt;

    public float rotationSpeed;
    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent <Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 viewDirection = player.position - new Vector3(transform.position.x, player.position.y, transform.position.z);
        orientation.forward = viewDirection.normalized;

        Vector3 dirToCombatLookAt = combatLookAt.position - new Vector3(transform.position.x, combatLookAt.position.y, transform.position.z);
        orientation.forward = dirToCombatLookAt.normalized;

        playerobj.forward = dirToCombatLookAt.normalized;

        if(Input.GetKeyDown(KeyCode.P))
        {
            Cursor.lockState = CursorLockMode.None;

        }


    }

    public void ChangeTag()
    {
        player = GameObject.FindWithTag("player").GetComponent<Transform>();
        playerobj = GameObject.FindWithTag("player").GetComponent<Transform>();
    }
}
