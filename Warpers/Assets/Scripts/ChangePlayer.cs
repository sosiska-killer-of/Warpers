using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePlayer : MonoBehaviour
{
    public float HitObjectX;
    public float HitObjectZ;
    public float HitObjectY;
    public float distance;
    public bool Cooldown = false;
    public CooldownC cooldownC;

    private IEnumerator CD()
    {
        cooldownC.CDc();
        Cooldown = true;
        yield return new WaitForSeconds(3f);
        Cooldown = false;
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Ray raycastt = Camera.main.ScreenPointToRay(Input.mousePosition);
                Debug.DrawRay(raycastt.origin, raycastt.direction * 100, Color.green);
        if (Input.GetMouseButtonDown(0))
        {
            if (Cooldown == false)
            {
                Debug.Log("Raycast casted");
                Vector3 raycastDirection = Camera.main.transform.forward;
                Ray ray = new Ray(transform.position, raycastDirection);

                RaycastHit hit;
                Debug.DrawRay(ray.origin, ray.direction * 100, Color.green);


                if (Physics.Raycast(ray, out hit)) 
                {
                    if (hit.collider.gameObject.CompareTag("Teammate"))
                    {
                        Debug.Log("Raycast hit");
                        HitObjectX = hit.collider.gameObject.transform.position.x;
                        HitObjectY = hit.collider.gameObject.transform.position.z;
                        HitObjectZ = hit.collider.gameObject.transform.position.y;
                        distance = Vector3.Distance(hit.collider.gameObject.transform.position, transform.position);

                        if(distance < 35)
                        {
                            StartCoroutine(CD());

                            GameObject Player = GameObject.FindWithTag("player");
                            GameObject Cam = GameObject.FindWithTag("MainCamera");
                            hit.collider.gameObject.tag = "player";
                            PlayerMovement AddPlayerMovement = hit.collider.gameObject.GetComponent<PlayerMovement>();
                            if (AddPlayerMovement != null) 
                            {
                                AddPlayerMovement.enabled = true;
                            }


                            if(Player != null) 
                            {
                                PlayerMovement playerMovement = Player.GetComponent<PlayerMovement>();
                                CamScript camScript = Cam.GetComponent<CamScript>();

                                if(playerMovement != null) 
                                {
                                    playerMovement.DisableMovement();
                                    camScript.ChangeTag();

                                    GameObject Camera = GameObject.FindWithTag("MainCamera");
                                    CameraScript cameraScript = Camera.GetComponent<CameraScript>();

                                    if(cameraScript != null)
                                    {
                                        cameraScript.ChangeCamera();
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
