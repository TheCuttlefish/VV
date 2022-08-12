using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliceHighlight : MonoBehaviour
{

    bool slicingInput;

    // Update is called once per frame
    void Update()
    {
        slicingInput = Input.GetMouseButton(1);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Vine" && slicingInput)
        {
            collision.GetComponent<Vine>().ReadyToSlice(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Vine" && slicingInput)
        {
            collision.GetComponent<Vine>().ReadyToSlice(false);
        }
    }
}
