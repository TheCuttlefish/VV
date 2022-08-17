using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WwiseTest : MonoBehaviour
{

    public ParticleSystem confetti;
    Vector3 mousePos;
    Vector3 offset = new Vector3(0, 0, -10);
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.Space))
        {

            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - offset;
            AkSoundEngine.PostEvent("soundTest", gameObject);//  Wwise test!
            print("sound should be played!!");
            if (confetti != null)
            {
                 var c = Instantiate( confetti, mousePos, Quaternion.identity);
                 c.Play();
            }
 
        }

       
    }
}
