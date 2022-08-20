using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CamControl : MonoBehaviour
{

    float camZoom;
    float newZoom;
    float defaultZoom;
    Vector3 offset = new Vector3(0, 0, 10);
    Vector3 mousePos;
    // Start is called before the first frame update
    void Start()
    {
        defaultZoom = Camera.main.orthographicSize;
        camZoom = defaultZoom;
    }

    bool mouseDown;
    Vector3 currentMousePos;
    Vector3 screenPoint;
    // Update is called once per frame
    void Update()
    {

        ScreenPanKeys();
        ScreenPanMouse();
        Zoom();
        LevelReset();
    }

    void ScreenPanKeys()
    {
        transform.Translate(Input.GetAxis("Horizontal") / 10, Input.GetAxis("Vertical") / 10, 0);
    }


    void ScreenPanMouse()
    {
        screenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        screenPoint.z = 10.0f; //distance of the plane from the camera

        if (Input.GetMouseButtonDown(2))
        {
            currentMousePos = Camera.main.ScreenToWorldPoint(new Vector3(screenPoint.x, screenPoint.y, +10));
            mouseDown = true;
        }

        if (Input.GetMouseButtonUp(2))
        {
            mouseDown = false;
        }
        if (mouseDown)
        {
            Camera.main.transform.position = currentMousePos + Camera.main.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(screenPoint.x, screenPoint.y, +10));
        }
    }

    void Zoom()
    {
        newZoom -= Input.mouseScrollDelta.y / (5);
        newZoom = Mathf.Clamp(newZoom, -1, 20);
        camZoom -= (camZoom - (defaultZoom + newZoom)) / 0.1f * Time.deltaTime;
        Camera.main.orthographicSize = camZoom;
    }
    private void LevelReset()
    {
        if (Input.GetKeyDown(KeyCode.R)) SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
