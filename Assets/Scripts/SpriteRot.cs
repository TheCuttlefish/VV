using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteRot : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        transform.Rotate(50f * Time.deltaTime, 80f * Time.deltaTime, 100 * Time.deltaTime);
    }
}
