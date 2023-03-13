using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxPick : MonoBehaviour
{
    private bool inbox = false;             //Check if player is inside the pick up trigger area 
    private bool pickupbox = false;         //Flag to executl pick up function
    private bool boxPickedup = false;       //Check if box has been picked up 
    private Rigidbody2D Rigidbody2D;


    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Box")
        {
            inbox = true;
            //Debug.Log("Collide");
            //collision.transform.SetParent(gameObject.transform, true);
            if (pickupbox == true)
            {
                //collision.transform.SetParent(gameObject.transform, true);
                collision.transform.parent = gameObject.transform;
                Rigidbody2D = GetComponent<Rigidbody2D>();
                gameObject.AddComponent<FixedJoint2D>();
                gameObject.GetComponent<FixedJoint2D>().connectedBody = collision.GetComponent<Rigidbody2D>();
                Debug.Log("Pressed");
                boxPickedup= true;  
                pickupbox = false;
            }

            //Debug.Log("Collision obj"+collision.gameObject.tag);

        }

    }



    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Box")
        {
            inbox = false;
            Debug.Log("Collide left ");


        }

    }

    Transform tagSearchChildTransform(string tag)                   //Get transform of child for given parent
    {
        foreach (Transform child in gameObject.transform)
            if (child.CompareTag(tag))
            {
                //Debug.Log("True");
                return child;
            }

        // Debug.Log("Foreach loop: " + child);
        //if (child.tr)
        Debug.Log("False");
        return null;
    }

    bool tagSearchChild(string tag)                                   //Return true if child exist with tag
    {
        foreach (Transform child in gameObject.transform)
            if(child.CompareTag(tag))
            {
                //Debug.Log("True");
                return true;
            }

        // Debug.Log("Foreach loop: " + child);
        //if (child.tr)
        Debug.Log("False");
        return false;
    }

    void Update()
    {
        //WithForeachLoop("Box");

        if (Input.GetKeyDown(KeyCode.E) && inbox == true)
        {
            if (!tagSearchChild("Box"))
            {
                Debug.Log("Picked box");
                pickupbox = true;
            }
            //else if (tagSearchChild("Box")==true)
            //{
            //    Debug.Log("dropped  box");
            //    tagSearchChildTransform("Box").parent=null;
            //}
        }
        if(Input.GetKeyDown(KeyCode.E) && boxPickedup == true)
        {
            Debug.Log("dropped  box");
            Destroy(gameObject.GetComponent<FixedJoint2D>());
            tagSearchChildTransform("Box").parent = null;
        }
    }

    }
