using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPlant : MonoBehaviour
{

    Vector3 scale;
    public AnimationCurve curve;
    float timer;
    // Start is called before the first frame update
    void Awake()
    {
        scale = transform.localScale;
        transform.localScale = Vector3.zero;
    }

    

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime*0.75f;
        if(timer < 1)
        transform.localScale = scale * curve.Evaluate(timer);

    }
}
