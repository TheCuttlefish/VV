using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteRot : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, 300 * Time.deltaTime);
    }
}
