using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class MenuCam : MonoBehaviour
{

    float timer;
    public Transform cam1;
    public Transform copter;
    public Transform level1;
    public UnityEvent showLevel1;
    bool levelIsShown = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(4);
        }



        timer += Time.deltaTime;
        //camera pans //zoom at intro
        if (timer < 12)
        {
            transform.position -= (transform.position - cam1.position) / 4 * Time.deltaTime;
            transform.forward -= ( transform.position - copter.position) / 5 * Time.deltaTime;

            if(timer > 7 && timer < 10)
            {
                GetComponent<Camera>().fieldOfView -= (GetComponent<Camera>().fieldOfView - 10) / 3f * Time.deltaTime;
            }
        }else
        {
            if (timer > 12 && timer < 20)
            {
                GetComponent<Camera>().fieldOfView -= (GetComponent<Camera>().fieldOfView - 60) / 2f * Time.deltaTime;
            }
            transform.position -= (transform.position - cam1.position) / 5 * Time.deltaTime;
            transform.forward -= (transform.position - level1.position )/ 10 * Time.deltaTime;
        }

        if(timer > 15.5f)
        {
            if (!levelIsShown)
            {
                showLevel1.Invoke();
                levelIsShown = true;
            }
        }


    }
}
