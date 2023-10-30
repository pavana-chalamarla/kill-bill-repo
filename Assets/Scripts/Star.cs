using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    public GameObject smallblue;
    public GameObject smallred;
    public GameObject bigblue;
    public GameObject bigred;
    public GameObject star;
    public GameObject finish1;
    public GameObject finish2;

    public void activateblue(){
        activateObject(smallblue);
        GameObject myGameObject = gameObject;
        deactivateObject(myGameObject);
        GameObject star3 = GameObject.Find("star3");
        activateObject(star3);

    }

    public void activatered(){
        activateObject(smallred);
        GameObject myGameObject = gameObject;
        deactivateObject(myGameObject);
        GameObject star4 = GameObject.Find("star4");
        activateObject(star4);
    }

    public void activatefinish1(){
        activateObject(bigblue);
        GameObject objectToDeactivate = GameObject.Find("star3");
        deactivateObject(objectToDeactivate);
        BoxCollider2D bx1 = finish1.GetComponent<BoxCollider2D>();
        if(bx1!=null){
            bx1.enabled = true;
        }
    }
    public void activatefinish2(){
        activateObject(bigred);
        GameObject objectToDeactivate = GameObject.Find("star4");
        deactivateObject(objectToDeactivate);
        BoxCollider2D bx2 = finish2.GetComponent<BoxCollider2D>();
        if(bx2!=null){
            bx2.enabled = true;
        }
    }


   
       
    void activateObject(GameObject objectToActivate){
        if (objectToActivate != null)
        {
            SpriteRenderer spriteRenderer = objectToActivate.GetComponent<SpriteRenderer>();
            BoxCollider2D boxCollider = objectToActivate.GetComponent<BoxCollider2D>();

            if (spriteRenderer != null)
            {
                if (!spriteRenderer.enabled)
                {
                    spriteRenderer.enabled = true;
                }
            }
            if (boxCollider != null)
            {
                if (!boxCollider.enabled)
                {
                    boxCollider.enabled = true;
                }
            }
        }
    }

    void deactivateObject(GameObject objectToActivate){
        if (objectToActivate != null)
        {
            SpriteRenderer spriteRenderer = objectToActivate.GetComponent<SpriteRenderer>();
            BoxCollider2D boxCollider = objectToActivate.GetComponent<BoxCollider2D>();

            if (spriteRenderer != null)
            {
                // Check if the SpriteRenderer is not active, and then activate it.
                if (spriteRenderer.enabled)
                {
                    spriteRenderer.enabled = false;
                }
            }
            if (boxCollider != null)
            {
                // Check if the SpriteRenderer is not active, and then activate it.
                if (boxCollider.enabled)
                {
                    boxCollider.enabled = false;
                }
            }
        }
    }
     
}
