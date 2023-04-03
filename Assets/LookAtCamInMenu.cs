using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamInMenu : MonoBehaviour
{
    Transform cam;
    Vector3 camPos;

    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("Main Camera").transform;
    }

    // Update is called once per frame
    void Update()
    {
        camPos = cam.position;
        camPos.y = transform.position.y;
        transform.forward = (transform.position - camPos);
    }
}
