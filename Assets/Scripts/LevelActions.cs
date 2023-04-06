using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelActions : MonoBehaviour
{
    public int level = 1;
    int currentLevel = 0;
    public List<GameObject> plants = new List<GameObject> ();
    public GameObject copter;



   public void InitLevel(int _currentLevel)
   {
       
        currentLevel = _currentLevel;

        foreach (var i in plants) i.SetActive(false);
        if (currentLevel == 0 && level == 1 )//if current level ==0 and this is the first level
        {
            copter.SetActive(true);
        }
        else
        {

            if ((currentLevel + 1) > level)
            {
                foreach (var i in plants) {
                    if(!i.GetComponent<LevelItem>().introEffect)
                        i.SetActive(true);
                }
            
            }
            else
            {
                foreach (var p in plants) p.SetActive(false);
            }

        }
    }

   

    public void AnimateLevelIntro()
    {

        foreach (var i in plants) i.GetComponent<LevelItem>().Animate();
        foreach (var i in plants) i.SetActive(true);

    }

}
