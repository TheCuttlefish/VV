using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class SeedIcon : MonoBehaviour
{
    
    void Update()
    {
       
        transform.localEulerAngles = new Vector3 (0, Mathf.Cos(Time.time ) * 15, 0);
        transform.localPosition = new Vector3(0, Mathf.Cos(Time.time * 2) / 2 , 0);
    }
}
