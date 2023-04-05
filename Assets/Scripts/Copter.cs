using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Copter : MonoBehaviour
{


    public void StopParticles()
    {
        transform.GetChild(0).GetComponent<ParticleSystem>().Stop();
    }

    public void Landed()
    {
        //delete copter object
        Destroy( transform.parent.gameObject );
    }

   
}
