using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lightning : MonoBehaviour
{
    public AnimationCurve curve;
    float timer = 1;
    // Start is called before the first frame update

    private void Awake()
    {
        GetComponent<CanvasGroup>().alpha = 0;
    }
    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.L))
        {
            //lightning activates here when you press L
            timer = 0;
        }
        timer += Time.deltaTime;

        if (timer < 1) { 
            GetComponent<CanvasGroup>().alpha =  Mathf.Abs( curve.Evaluate(timer) );
        }
    }
}
