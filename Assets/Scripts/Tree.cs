using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{


    
 
    public bool win = false;
    public GameObject branchContainer;
    void Update()
    {
       
    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        if (win) return;
        if(collision.transform.tag == "Vine")
        {
            collision.transform.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            branchContainer.SetActive(true);
            GameObject.Find("Main Camera").GetComponent<CamControl>().Win(transform.position);
            win = true;
            AkSoundEngine.PostEvent("treeSprout", gameObject);
        }
    }

   
}
