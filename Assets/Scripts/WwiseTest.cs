using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WwiseTest : MonoBehaviour
{

    public ParticleSystem confetti;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AkSoundEngine.PostEvent("soundTest", gameObject);//  Wwise test!
            print("sound should be played!!");
  
            confetti.Play();
 
        }

       
    }
}
