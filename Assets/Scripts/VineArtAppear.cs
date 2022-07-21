using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VineArtAppear : MonoBehaviour
{
    
    void Awake()
    {
        
        transform.localScale = new Vector3(0.08f, 0f, 1f);
    }

    float timer;
    void Update()
    {
        timer += Time.deltaTime*5;
        transform.localScale = new Vector3(0.08f, timer, 1f);
        if (timer > 1) GetComponent<VineArtAppear>().enabled = false;
    }
}
