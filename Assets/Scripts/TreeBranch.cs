using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeBranch : MonoBehaviour
{
    float timer;
    float originalScale;
    public AnimationCurve curve;
    float waitTimer;

    void Awake()
    {
        waitTimer = Random.Range(0, 1f);
        originalScale = transform.localScale.x;
        transform.localScale = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        waitTimer -= Time.deltaTime;
        if (waitTimer < 0)
        {
            if (timer < 1)
            {
                timer += Time.deltaTime * 3;
                transform.localScale = new Vector3(1, 1, 1) * curve.Evaluate(timer)* originalScale;
            }
        }
    }

}
