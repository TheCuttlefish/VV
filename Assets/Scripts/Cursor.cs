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

    private void Awake()
    {
        spriteCursor.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) - offset;
        originalSrpiteCursorScale = new Vector3(1, 1, 1);
        spriteCursor.transform.localScale = Vector3.zero;
    }
    void Update()
    {
        ClickAndSelect();
        SpriteCursorControl();
    }

   
    void SpriteCursorControl()
    {
        if (selectedTip == null)
        {
            spriteCursor.transform.position -= (spriteCursor.transform.position - transform.position) / 10;
            spriteCursor.transform.localScale -= (spriteCursor.transform.localScale - Vector3.zero) / 20;

            
        }
        else
        {
            spriteCursor.transform.position -= (spriteCursor.transform.position - selectedTip.transform.position) / 20;
            spriteCursor.transform.localScale -= (spriteCursor.transform.localScale - originalSrpiteCursorScale) / 10;
        }
    }
    void ClickAndSelect()
    {
        //mouse position
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) - offset;
      
        //ray cast
        hit = Physics2D.Raycast(transform.position, Vector3.zero, Mathf.Infinity, tip);
        lineToVine.transform.localScale = new Vector3(0.075f, 0, 1);

        if (hit.collider != null && hit.collider.name == "tip")
        {
            //check by disntace
            if(selectedTip == null) {

                selectedTip = hit.collider.gameObject;

                
            }

            if(  Vector2.Distance( hit.collider.transform.position,transform.position) < Vector2.Distance(selectedTip.transform.position, transform.position))
            {
                selectedTip = hit.collider.gameObject;
                
            }
            

            if (Input.GetMouseButtonDown(0)) selectedTip.transform.parent.GetComponent<Vine>().Grow();
            //DEBUG!!
            if(Input.GetKeyDown(KeyCode.Alpha1)) selectedTip.transform.parent.GetComponent<Vine>().Grow();
            if (Input.GetKeyDown(KeyCode.Alpha2)) selectedTip.transform.parent.GetComponent<Vine>().Grow(true);
        }
        if (hit.collider == null) {

            selectedTip = null; }


        
       //find angle
        if (selectedTip == null) return;
        Debug.DrawLine(transform.position, selectedTip.transform.position);//draw line
        dist = Vector2.Distance(transform.position, selectedTip.transform.position);//find dist (not used)
        lineToVine.transform.position = transform.position;
        lineToVine.transform.up = transform.position - selectedTip.transform.position;
        lineToVine.transform.localScale = new Vector3(0.075f, dist, 1);
        GAME.VINE_LINE_Z = lineToVine.transform.localEulerAngles.z;
    }

}
