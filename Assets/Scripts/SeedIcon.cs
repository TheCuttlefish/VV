using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class SeedIcon : MonoBehaviour
{


    SpriteRenderer sr;
    float timer = -2f;
    public AnimationCurve curve;
    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.color = new Vector4(1, 1, 1, 0);
    }

    void Update()
    {


        if (timer < 1)
        {
            timer += Time.deltaTime;
            sr.color = new Vector4(1, 1, 1, timer/3);
            
        }

        if (timer > 0)
        {
            
           


            transform.localPosition = new Vector3(0,  ( Mathf.Cos(Time.time * 2) / 2), 0);
            transform.localEulerAngles = new Vector3(0, Mathf.Cos(Time.time) * 15 + (curve.Evaluate( ( timer ) ) * 90), 0);
           
          

        } 
       
  
        
    }


    private void OnMouseEnter()
    {
        sr.color = new Vector4(1, 0.6745f, 0, 1);
    }


    private void OnMouseExit()
    {
        sr.color = new Vector4(1, 1, 1, 0.5f);
    }


}
