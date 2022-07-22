using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WwiseTest : MonoBehaviour
{

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AkSoundEngine.PostEvent("soundTest", gameObject);//  Wwise test!
            print("sound should be played!!");
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            AkSoundEngine.PostEvent("soundTest2", gameObject);//  Wwise test!
            print("sound should be played!!");
        }
    }
}
