using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GAME
{
    public static float VINE_LINE_Z;
}





public class Cursor : MonoBehaviour
{
    Vector3 mousePos;
    Vector3 offset  = new Vector3(0, 0, -10);
    GameObject selectedTip;
    float dist;
    public GameObject lineToVine;
    Rigidbody2D rb2D;
    public LayerMask tip;
    public GameObject spriteCursor;
    Vector3 originalSrpiteCursorScale;
    RaycastHit2D hit;
    public GameObject bubbleUI;
    GameObject lastActiveVine;
    bool creatineVine = false;
    private void Awake()
    {
        spriteCursor.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) - offset;
        originalSrpiteCursorScale = new Vector3(1, 1, 1);
        spriteCursor.transform.localScale = Vector3.zero;
       
    }
    void Update()
    {
        if (Input.GetMouseButton(1))//slicing mouse buttton
        {
            spriteCursor.transform.localScale = Vector3.zero;
            bubbleUI.GetComponent<UISelectCircle>().Hide();
        }
        else
        {
            ClickAndSelect();//show direction
            MagicCursor();
            BubbleUI();
        }
    }


    void BubbleUI()
    {
        if (selectedTip == null) //disappear
        {
          
            bubbleUI.GetComponent<UISelectCircle>().Hide();
            if (lastActiveVine != null) bubbleUI.transform.position = lastActiveVine.transform.position;
            bubbleUI.GetComponent<SpriteRenderer>().color -= (bubbleUI.GetComponent<SpriteRenderer>().color - new Color(0, 1, 1, 0)) / 0.06f * Time.deltaTime;

        }
        else//appear
        {
     
            bubbleUI.GetComponent<UISelectCircle>().Show();
            bubbleUI.transform.position = selectedTip.transform.position;
            bubbleUI.GetComponent<SpriteRenderer>().color -= (bubbleUI.GetComponent<SpriteRenderer>().color - new Color(0, 1, 1, 1)) / 0.8f * Time.deltaTime;
        }
    }
    void MagicCursor()
    {
        
            if (selectedTip == null)
            {
                spriteCursor.transform.position -= (spriteCursor.transform.position - transform.position) / 0.2f * Time.deltaTime;//speed away
                spriteCursor.transform.localScale -= (spriteCursor.transform.localScale - Vector3.zero) / 0.05f * Time.deltaTime;//scale away
           
            }
            else
            {
                spriteCursor.transform.position -= (spriteCursor.transform.position - selectedTip.transform.position) / 0.2f * Time.deltaTime;//
                spriteCursor.transform.localScale -= (spriteCursor.transform.localScale - originalSrpiteCursorScale) / 0.05f * Time.deltaTime;
            
        }
        
    }
    void ClickAndSelect()
    {
        //mouse position
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) - offset;
      
        //ray cast
        hit = Physics2D.Raycast(transform.position, Vector3.zero, Mathf.Infinity, tip);
        lineToVine.transform.localScale = new Vector3(0.075f, 0, 1);


        if (creatineVine == false)
        {


            if (hit.collider != null && hit.collider.name == "tip")
            {
                //get new vine tip if it's not set
                if (selectedTip == null)
                {

                    selectedTip = hit.collider.gameObject;
                }

                //get new vine tip by distance
                if (Vector2.Distance(hit.collider.transform.position, transform.position) < Vector2.Distance(selectedTip.transform.position, transform.position))
                {
                    selectedTip = hit.collider.gameObject;
                }




                //if (Input.GetMouseButtonDown(0)) selectedTip.transform.parent.GetComponent<Vine>().Grow(); -- one click grow
                //DEBUG!!
                if (Input.GetKeyDown(KeyCode.Alpha1)) selectedTip.transform.parent.GetComponent<Vine>().Grow();
                if (Input.GetKeyDown(KeyCode.Alpha2)) selectedTip.transform.parent.GetComponent<Vine>().Grow(true);
            }

            if (hit.collider == null)
            {

                if (selectedTip != null) lastActiveVine = selectedTip; // chose last active vine only if it exists, and if it's chosen don't override it to null ( because next line would set selexted tip to null and then lastActive would become null the next frame)
                selectedTip = null;//if collider is hitting nothing then disable selected tip

            }
        }

        if (Input.GetMouseButton(0))
        {
            creatineVine = true;
            //find angle
            if (selectedTip == null) return;
            Debug.DrawLine(transform.position, selectedTip.transform.position);//draw line
            dist = Vector2.Distance(transform.position, selectedTip.transform.position);//find dist (not used)
            lineToVine.transform.position = transform.position;
            lineToVine.transform.up = transform.position - selectedTip.transform.position;
            lineToVine.transform.localScale = new Vector3(0.075f, dist, 1);
            GAME.VINE_LINE_Z = lineToVine.transform.localEulerAngles.z;
        }

        if (Input.GetMouseButtonUp(0))
        {
            creatineVine = false;
            if (selectedTip == null) return;
            selectedTip.transform.parent.GetComponent<Vine>().Grow();
            
        }
        
       
    }

}
