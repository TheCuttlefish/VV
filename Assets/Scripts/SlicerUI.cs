using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlicerUI : MonoBehaviour
{

    Vector3 offset = new Vector3(0, 0, -10);
    Vector3 sliceStartPos;
    float dist;
    bool mouseDown;
    public GameObject slicerArt;
    float sliceTimer = 0;
    bool sliceActive = false;
    public GameObject sliceEffect;
    public GameObject spriteEffect;
    
    private void Start()
    {
        transform.localScale = new Vector3(0, 1, 1);//reset scale to 0
       // slicerArt.GetComponent<BoxCollider2D>().enabled = false;
    }
    // Update is called once per frame
    void Update()
    {
       

        if (mouseDown)
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) - offset;
            transform.right = ( sliceStartPos - transform.position);

            dist = Vector2.Distance(transform.position, sliceStartPos);
            transform.localScale = new Vector3(dist, 1, 1);
        }



        if (Input.GetMouseButtonDown(1))
        {
            mouseDown = true;
            sliceStartPos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - offset;
            slicerArt.GetComponent<SlicerObject>().StartSlicing();
            spriteEffect.SetActive(false);
            AkSoundEngine.PostEvent("sliceAimLoopStart", gameObject);
        }

        if (Input.GetMouseButtonUp(1))
        {
            slicerArt.GetComponent<SlicerObject>().ShowSlice();
            slicerArt.GetComponent<BoxCollider2D>().enabled = true;
            sliceActive = true;
            mouseDown = false;
            sliceEffect.transform.position =  (transform.position + sliceStartPos)/2;
            sliceEffect.transform.localEulerAngles = transform.localEulerAngles + new Vector3(0,0,-45);
            sliceEffect.SetActive(false);
            sliceEffect.SetActive(true);
            spriteEffect.transform.position = transform.position;
            spriteEffect.SetActive(true);
            AkSoundEngine.PostEvent("sliceReleased", gameObject);
           
        }

        if (sliceActive)
        {
            sliceTimer += Time.deltaTime;
            if(sliceTimer > 0.1f)
            {
               
                slicerArt.GetComponent<BoxCollider2D>().enabled = false;
                sliceActive = false;
                sliceTimer = 0;
                transform.localScale = new Vector3(0, 1, 1);//reset scale to 0
            }



        }


    }
}
