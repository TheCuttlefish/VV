using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlicerObject : MonoBehaviour
{
    // Start is called before the first frame update
    public Gradient gradient;
    float sliceTimer;
    bool showSlice = false;

    private void Awake()
    {
       // transform.localScale = new Vector3(1, 0, 1);
    }
    public void StartSlicing()
    {
        showSlice = false;
        sliceTimer = 0;
        GetComponent<SpriteRenderer>().color = new Color(1, 0, 0, 0.3f);
    }

    public void ShowSlice()
    {
        showSlice = true;
        sliceTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (showSlice)
        {
            if (sliceTimer < 1)
            {
                sliceTimer += Time.deltaTime*3;
                GetComponent<SpriteRenderer>().color = gradient.Evaluate(sliceTimer);

            }else
            {
                showSlice = false;
                sliceTimer = 0;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Vine")
        {
            collision.GetComponent<Vine>().Slice();
            
        }
    }
}
