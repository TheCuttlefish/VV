using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScreenFade : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<CanvasGroup>().alpha = 1;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<CanvasGroup>().alpha -= Time.deltaTime;
    }
}
