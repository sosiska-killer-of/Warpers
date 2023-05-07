using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSChangePlayer : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] public float HitObjectX;
    [SerializeField] public float HitObjectZ;
    [SerializeField] public float HitObjectY;
    public float distance;
    public bool Cooldown = false;
    public CooldownC cooldownC;

    // Start is called before the first frame update
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
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10f;
        mousePos = cam.ScreenToWorldPoint(mousePos);
        Debug.DrawRay(transform.position, mousePos - transform.position, Color.green);
        if (Input.GetMouseButtonDown(0))
        {
            if (Cooldown == false) 
            {
                Debug.Log("Raycast casted");
                Vector3 raycastDirection = cam.transform.forward;
                Ray ray = new Ray(transform.position, raycastDirection);

                RaycastHit hit;
                Debug.DrawRay(ray.origin, ray.direction * 100, Color.red);

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
                            FPSmovement AddPlayerMovement = hit.collider.gameObject.GetComponent<FPSmovement>();
                            if (AddPlayerMovement != null) 
                            {
                                AddPlayerMovement.enabled = true;
                            }


                            if(Player != null) 
                            {
                                Debug.Log("player not null (check 1)");
                                FPSmovement fPSmovement = Player.GetComponent<FPSmovement>();
                                //CamScript camScript = Cam.GetComponent<CamScript>();

                                if(fPSmovement != null) 
                                {
                                    Debug.Log("fps not null (check 2)");
                                    fPSmovement.DisableMovement();
                                    
                                    //transform.SetParent(Player.transform);
                                    //transform.SetParent(Player.transform);
                                    //transform.position = Player.transform.position;
                                    //camScript.ChangeTag();

                                    GameObject Camera = GameObject.FindWithTag("MainCamera");
                                    CameraScript cameraScript = Camera.GetComponent<CameraScript>();

                                    if(cameraScript != null)
                                    {
                                        Debug.Log("camera not null (check 3)");
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
