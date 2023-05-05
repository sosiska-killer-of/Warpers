using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrientationC : MonoBehaviour
{
    public GameObject Plyr;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Plyr = GameObject.FindWithTag("player");
        transform.position = Plyr.transform.position;
    }
}
