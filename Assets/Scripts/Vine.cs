using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vine : MonoBehaviour
{


    private GameObject parentVine;
    private GameObject vineArt;
    private Color originalVineColour;
    private GameObject vineTipArt;
    int currentSize = 0;
    float velocityMag; // velocity magnitude - how fast the vine is moving / colliding
    
    public void Awake()
    {
       
        currentSize = 0;
        vineArt = transform.Find("artContainer").transform.Find("vineArt").gameObject; // be careful with finding vine art by name....
        vineTipArt = transform.Find("tip").transform.Find("tipArt").gameObject;
        originalVineColour = vineArt.GetComponent<SpriteRenderer>().color;
        vineArt.transform.localScale = new Vector3(1.16f, 0.093f, 0.093f);
    }


    public void IncreaseSize(int _newVineSize)
    {

        if (_newVineSize == currentSize )//only increase if new vine is the same size as parent
        {

            if (currentSize == 8) return;// should be size of max size - so 7 or 8 (test it !!!  )
            currentSize++;
            if (currentSize == 1) vineArt.transform.localScale = new Vector3(1.8f, 0.093f, 0.093f);
            if (currentSize == 2) vineArt.transform.localScale = new Vector3(2.0f, 0.093f, 0.093f);
            if (currentSize == 3) vineArt.transform.localScale = new Vector3(3.2f, 0.093f, 0.093f);
            if (currentSize == 4) vineArt.transform.localScale = new Vector3(4.4f, 0.093f, 0.093f);
            if (currentSize == 5) vineArt.transform.localScale = new Vector3(5.6f, 0.093f, 0.093f);
            if (currentSize == 6) vineArt.transform.localScale = new Vector3(6.8f, 0.093f, 0.093f);
            if (currentSize == 7)
            {
                vineArt.transform.localScale = new Vector3(7.0f, 0.093f, 0.093f);
                vineArt.GetComponent<SpriteRenderer>().color = Color.black;
                vineTipArt.GetComponent<SpriteRenderer>().color = Color.black;//not entirely finished code !!!
                vineTipArt.transform.parent.gameObject.SetActive(false);//not entirely finished code !!! --- needs playtesting
            }
            
            if (parentVine != null) parentVine.GetComponent<Vine>().IncreaseSize(currentSize);
            
        }

        AkSoundEngine.PostEvent("vineAdd", gameObject);

    }

    public void SetParentVine(GameObject _parentVine)
    {
        parentVine = _parentVine;
        parentVine.GetComponent<Vine>().IncreaseSize(currentSize);
    }

    private void Start()
    {
       
        transform.GetChild(1).GetComponent<VineArt>().enabled = true;
    }

    public void Grow(bool many = false)
    {
        GameObject newVine;
        if (!many)
        {
            newVine = Instantiate(gameObject, transform.GetChild(0).position, Quaternion.Euler(0,0,GAME.VINE_LINE_Z));
            newVine.GetComponent<FixedJoint2D>().connectedBody = GetComponent<Rigidbody2D>(); newVine.name = name + "|";
            newVine.GetComponent<Vine>().SetParentVine(gameObject);
        }
        else if (many)
        {
            newVine = Instantiate(gameObject, transform.GetChild(0).position, Quaternion.Euler(0, 0, transform.localEulerAngles.z - 40));
            newVine.GetComponent<FixedJoint2D>().connectedBody = GetComponent<Rigidbody2D>(); newVine.name = name + "|";
            newVine.GetComponent<Vine>().SetParentVine(gameObject);

            newVine = Instantiate(gameObject, transform.GetChild(0).position, Quaternion.Euler(0, 0, transform.localEulerAngles.z));
            newVine.GetComponent<FixedJoint2D>().connectedBody = GetComponent<Rigidbody2D>(); newVine.name = name + "|";
            newVine.GetComponent<Vine>().SetParentVine(gameObject);

            newVine = Instantiate(gameObject, transform.GetChild(0).position, Quaternion.Euler(0, 0, transform.localEulerAngles.z + 40));
            newVine.GetComponent<FixedJoint2D>().connectedBody = GetComponent<Rigidbody2D>(); newVine.name = name + "|";
            newVine.GetComponent<Vine>().SetParentVine(gameObject);
        }
    }



    private void Update()
    {
        
        velocityMag = GetComponent<Rigidbody2D>().velocity.magnitude;
        Debug.DrawLine(transform.position, transform.position + (Vector3.up * velocityMag), Color.red);
        AkSoundEngine.SetRTPCValue("vineSpeed", velocityMag);
        
        if (GetComponent<FixedJoint2D>().connectedBody == null)
        {
            Slice();
        }
    }
    bool sliced = false;
    public void Slice()
    {
        if (!sliced)
        {
            ReadyToSlice(false);
            GetComponent<FixedJoint2D>().enabled = false;
            GetComponent<BoxCollider2D>().isTrigger = true;
            Destroy(gameObject, Random.Range(0.5f,1f));
            sliced = true;
        }
    }

    public void ReadyToSlice(bool isSelected)
    {
        if (isSelected)
        {
            vineArt.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0, 0.3f);
        }else
        {
            vineArt.GetComponent<SpriteRenderer>().color = originalVineColour;
        }

    }

    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        AkSoundEngine.PostEvent("vineImpact", gameObject);            
        // add collision sound here !  (from 0 to 50+??? will need to playtest!) 
        // use collsionMag variable
        // I may need to change it so it only listens to active vine.... maybe too noisy otherwise
      
    }


}
