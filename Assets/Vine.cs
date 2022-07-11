using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vine : MonoBehaviour
{


    private GameObject parentVine;
    int currentSize = 0;


    public void Awake()
    {
        currentSize = 0;
        transform.Find("art").transform.Find("Vineartsample2").GetComponent<SpriteRenderer>().transform.localScale = new Vector3(1.16f, 0.093f, 0.093f);
    }


    public void IncreaseSize(int _newVineSize)
    {

        if (_newVineSize == currentSize )//only increase if new vine is the same size as parent
        {

            if (currentSize == 2) return;// don't send message after 2 increases
            currentSize++;
            if (currentSize == 1)
            {
               // transform.localScale = new Vector3(1.8f, 1, 1);
                transform.Find("art").transform.Find("Vineartsample2").GetComponent<SpriteRenderer>().transform.localScale = new Vector3(1.8f, 0.093f, 0.093f);

            }
            else if (currentSize == 2)
            {
                //transform.localScale = new Vector3(3f, 1, 1);
                transform.Find("art").transform.Find("Vineartsample2").GetComponent<SpriteRenderer>().transform.localScale = new Vector3(3.0f, 0.093f, 0.093f);
            }
            if (parentVine != null) parentVine.GetComponent<Vine>().IncreaseSize(currentSize);
        }
    }

    public void SetParentVine(GameObject _parentVine)
    {
        parentVine = _parentVine;
        parentVine.GetComponent<Vine>().IncreaseSize(currentSize);
    }

    private void Start()
    {
       
        transform.GetChild(1).GetComponent<VineArtAppear>().enabled = true;
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
            GetComponent<FixedJoint2D>().enabled = false;
            GetComponent<BoxCollider2D>().isTrigger = true;
            Destroy(gameObject, Random.Range(0.5f,1f));
            sliced = true;
        }
    }
}
