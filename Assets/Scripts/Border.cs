using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Border : MonoBehaviour
{
    // Start is called before the first frame update
    float heightUpper, heightLower, widthUpper, widthLower;

    void Awake()
    {
        widthUpper = transform.position.x +  GetComponent<SpriteRenderer>().size.x / 2;
        heightUpper = transform.position.y + GetComponent<SpriteRenderer>().size.y / 2;
        heightLower = transform.position.y - GetComponent<SpriteRenderer>().size.y / 2;
        GameObject.Find("Main Camera").GetComponent<CamControl>().SetBorder(widthUpper, widthLower, heightUpper, heightLower);
        gameObject.SetActive(false);
    }

}
