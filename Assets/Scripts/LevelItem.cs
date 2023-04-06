using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelItem : MonoBehaviour
{
    Vector3 scale;
    public AnimationCurve curve;
    float timer = 0;
    [Range(0f, 3f)]
    public float delay = 0.5f;
    bool animate = false;
    public bool introEffect = false;

    //when completed!!! bool (flower) 

    public void Animate()
    {
        timer = -delay;
        scale = transform.localScale;
        transform.localScale = Vector3.zero;
        animate = true;
    }
   



    void Update()
    {
        if (animate)
        {
            timer += Time.deltaTime * 0.75f;
            if (timer < 1)
                transform.localScale = scale * curve.Evaluate(timer);
        }
        
    }
}
