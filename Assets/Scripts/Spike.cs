using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    bool hasFallen = false;
    float dt = 0;
    float oScale;
    float destoyTime = 3f;
    private void Awake()
    {
        oScale = transform.localScale.x;
    }
    // Update is called once per frame
    void Update()
    {
        if (hasFallen)
        {
            dt += Time.deltaTime/ destoyTime;
            transform.localScale = (oScale - dt) * new Vector3(1,1,1);
        }
    }
    public void Fall()
    {
        if (!hasFallen)
        {
            if (transform.parent != null) //if there is a parent, then make the parent fall too!
            {
                transform.parent.GetComponent<Spike>().Fall();
                transform.SetParent(null);

            }

            //play breaking noise here!
            GetComponent<Rigidbody2D>().isKinematic = false;
            GetComponent<Rigidbody2D>().AddTorque(100f * Random.Range(-1f,1f));
            Destroy(gameObject, destoyTime);
           
            
        }

        hasFallen = true;

    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.transform.tag == "Vine")
        {
           
            collision.transform.GetComponent<Vine>().Slice();
            Fall();
        }
        if (collision.transform.tag == "Spike") Fall();

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Vine")
        {

            collision.transform.GetComponent<Vine>().Slice();
            Fall();
        }
        if (collision.transform.tag == "Spike") Fall();
    }
}
