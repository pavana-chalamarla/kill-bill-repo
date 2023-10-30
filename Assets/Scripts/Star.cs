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

    public bool starcombinelevel = false;

    public void activateblue(){
        activateObject(smallblue);
        GameObject myGameObject = gameObject;
        deactivateObject(myGameObject);
        GameObject jump1 = GameObject.Find("jump1");
        deactivateObject(jump1);
        GameObject star3 = GameObject.Find("star3");
        activateObject(star3);
        GameObject jump3 = GameObject.Find("jump3");
        activateObject(jump3);
    }

    public void activatered(){
        activateObject(smallred);
        GameObject myGameObject = gameObject;
        deactivateObject(myGameObject);
        GameObject jump2 = GameObject.Find("jump2");
        deactivateObject(jump2);
        GameObject star4 = GameObject.Find("star4");
        activateObject(star4);
        GameObject jump4 = GameObject.Find("jump4");
        activateObject(jump4);
    }

    public void activatefinish1(){
        activateObject(bigblue);
        GameObject objectToDeactivate = GameObject.Find("star3");
        deactivateObject(objectToDeactivate);
        if(finish1!=null){
            BoxCollider2D bx1 = finish1.GetComponent<BoxCollider2D>();
            if(bx1!=null){
            bx1.enabled = true;
        }
        }

        GameObject jump3 = GameObject.Find("jump3");
        deactivateObject(jump3);

        if(starcombinelevel){
            deactivateObject(smallblue);
            deactivateObject(bigblue);
            GameObject tr1 = GameObject.Find("triangle1");
            GameObject flagpole = GameObject.Find("flag pole 1");
            deactivateObject(tr1);
            deactivateObject(flagpole);
            GameObject combiner = GameObject.Find("combiner1");
            activateObject(combiner);
        }
    }
    public void activatefinish2(){
        activateObject(bigred);
        GameObject objectToDeactivate = GameObject.Find("star4");
        deactivateObject(objectToDeactivate);
        if(finish2){
            BoxCollider2D bx2 = finish2.GetComponent<BoxCollider2D>();
            if(bx2!=null){
            bx2.enabled = true;
            }
        }
        GameObject jump4 = GameObject.Find("jump4");
        deactivateObject(jump4);

        if(starcombinelevel){
            deactivateObject(smallred);
            deactivateObject(bigred);
            GameObject tr2 = GameObject.Find("triangle2");
            GameObject flagpole = GameObject.Find("flag pole 2");
            deactivateObject(tr2);
            deactivateObject(flagpole);
        }

    }


   
       
    void activateObject(GameObject objectToActivate){
        if (objectToActivate != null)
        {
            SpriteRenderer spriteRenderer = objectToActivate.GetComponent<SpriteRenderer>();
            BoxCollider2D boxCollider = objectToActivate.GetComponent<BoxCollider2D>();
            CircleCollider2D circleCollider = objectToActivate.GetComponent<CircleCollider2D>();

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
            if (circleCollider != null)
            {
                if (!circleCollider.enabled)
                {
                    circleCollider.enabled = true;
                }
            }
        }
    }

    void deactivateObject(GameObject objectToActivate){
        if (objectToActivate != null)
        {
            SpriteRenderer spriteRenderer = objectToActivate.GetComponent<SpriteRenderer>();
            BoxCollider2D boxCollider = objectToActivate.GetComponent<BoxCollider2D>();
            CircleCollider2D circleCollider = objectToActivate.GetComponent<CircleCollider2D>();

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
            if (circleCollider != null)
            {
                // Check if the SpriteRenderer is not active, and then activate it.
                if (circleCollider.enabled)
                {
                    circleCollider.enabled = false;
                }
            }
        }
    }
     
}
