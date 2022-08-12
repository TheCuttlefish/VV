using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideOnTimer : MonoBehaviour
{

    public float seconds = 1f;

    float timer = 0;
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > seconds)
        {
            timer = 0;
            gameObject.SetActive(false);
        }
    }
}
