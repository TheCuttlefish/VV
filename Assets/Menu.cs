using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Menu : MonoBehaviour
{
    int hour;
    public Gradient timeGradient;
    public GameObject clock;
    // Start is called before the first frame update
    void Start()
    {
        hour = System.DateTime.Now.ToLocalTime().Hour;
        print(hour);
    }
    float timer;
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        hour = System.DateTime.Now.ToLocalTime().Hour;
        clock.transform.localEulerAngles = new Vector3(0, 0, -hour * 15);
        //clock.transform.localEulerAngles = new Vector3(0, 0, -timer * 15);




        if (Input.GetKey(KeyCode.A))
        {
            clock.GetComponent<SpriteRenderer>().color = Color.red;
        }else
        {
            clock.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }
}
