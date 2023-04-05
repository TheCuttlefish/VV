using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using static UnityEngine.GraphicsBuffer;

public class MenuCam : MonoBehaviour
{

    int levelProgress = 0;
    public List<Transform> camPositions = new List<Transform>();
    float timer;
    public Transform copter;
    public Transform level1;
    public UnityEvent showLevel1;
    bool levelIsShown = false;
    Camera noPostCamera;

   

    void Awake()
    {
       
        noPostCamera = transform.Find("no post Camera").GetComponent<Camera>();

        if (levelProgress == 0)
        {
            noPostCamera.fieldOfView = 10f;
            transform.position = camPositions[0].position;
            GetComponent<Camera>().fieldOfView = 60f;
        }

        if (levelProgress == 1)
        {
            noPostCamera.fieldOfView = 60f;
            GetComponent<Camera>().fieldOfView = 60f;
            transform.position = camPositions[1].position;
            LookAtNoDelay(level1.position);
        }


    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(4);
        }

        if (levelProgress == 0) //camera pans & zoom at intro
        {

            timer += Time.deltaTime;

            if (timer < 12)
            {
                noPostCamera.fieldOfView -= (noPostCamera.fieldOfView - GetComponent<Camera>().fieldOfView) / 5f * Time.deltaTime;

                transform.position -= (transform.position - camPositions[1].position) / 4 * Time.deltaTime;
                LookAtSmooth(copter.position,5f);
               
                if (timer > 7 && timer < 10)
                {
                    GetComponent<Camera>().fieldOfView -= (GetComponent<Camera>().fieldOfView - 10) / 3f * Time.deltaTime;

                }
            }
            else
            {
                if (timer > 12 && timer < 20)
                {
                    //no post cam
                    noPostCamera.fieldOfView -= (noPostCamera.fieldOfView - GetComponent<Camera>().fieldOfView) / 1f * Time.deltaTime;
                    GetComponent<Camera>().fieldOfView -= (GetComponent<Camera>().fieldOfView - 60) / 1f * Time.deltaTime;
                }
                transform.position -= (transform.position - camPositions[1].position) / 5 * Time.deltaTime;
                LookAtSmooth(level1.position);
                
            }

            if (timer > 14.00f)
            {
                if (!levelIsShown)
                {
                    showLevel1.Invoke();
                    levelIsShown = true;
                }
            }

        }

        if (levelProgress == 1)
        {
            LookAtSmooth(level1.position);
        }

    }

    void LookAtNoDelay(Vector3 _target)
    {
        transform.forward = (_target - transform.position).normalized;
    }
    void LookAtSmooth(Vector3 _target , float speed = 10)
    {
        transform.forward -= (transform.position - _target) / speed * Time.deltaTime;
    }
}
