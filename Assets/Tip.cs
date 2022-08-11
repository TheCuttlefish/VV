using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tip : MonoBehaviour
{

    float scale = 0;
    float newScale = 1.1f;
    float scaleSpeed = 0.2f;

    void Awake()
    {
        transform.localScale = Vector3.zero;
    }

    void Update()
    {
        scale -= (scale - newScale) / scaleSpeed * Time.deltaTime;
        transform.localScale = new Vector3(1, 1, 1) * scale;
        if (scale > 1) Destroy(GetComponent<Tip>());
        
    }
}
