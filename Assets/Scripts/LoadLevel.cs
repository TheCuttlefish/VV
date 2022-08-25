using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadLevel : MonoBehaviour
{

    public void Awake()
    {
        gameObject.SetActive(true);
    }
    public void Load(int level = 0)
    {
        SceneManager.LoadScene(level);
    }
}
