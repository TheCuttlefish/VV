using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISelectCircle : MonoBehaviour
{
    float scale = 0;
    float newScale = 1;
    float scaleSpeed = 0.2f;
  
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
    }
    public void ShowLimit()
    {
        newScale = 2;
    }

}
