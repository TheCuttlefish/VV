using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelActions : MonoBehaviour
{
    public List<GameObject> plants = new List<GameObject> ();

    public void ShowLevel()
    {
        foreach (var p in plants)
        {
            p.SetActive(true);
        }
    }

    // Start is called before the first frame update
    void Awake()
    {
        foreach( var p in plants)
        {
            p.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
