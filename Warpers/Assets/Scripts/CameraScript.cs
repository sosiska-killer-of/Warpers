using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject Plyr;
    public Vector3 cameraOffset = new Vector3 (0, 2.7f, -5);
    // Start is called before the first frame update
    void Start()
    {
        Plyr = GameObject.FindWithTag("player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Plyr.transform.position + cameraOffset;
        transform.LookAt(Plyr.transform);

    }

    public void ChangeCamera()
    {
        Plyr = GameObject.FindWithTag("player");
    }
}
