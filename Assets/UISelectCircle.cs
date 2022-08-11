using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISelectCircle : MonoBehaviour
{
    float scale = 0;
    float newScale = 1;
    float scaleSpeed = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scale -= (  scale - newScale) / scaleSpeed * Time.deltaTime;
        transform.localScale = new Vector3(1, 1, 1) * scale;
    }

    public void Show()
    {
       
        newScale = 1;
    }
    public void Hide()
    {
        newScale = 0;
        //transform.localScale = new Vector3(1, 1, 1) * 0.2f ;
    }

}
