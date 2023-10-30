using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combiner : MonoBehaviour
{

   public void activateball(){
    GameObject yellowball = GameObject.Find("Ball");
    GameObject myGameObject = gameObject;
    deactivateObject(myGameObject);
    GameObject ball1 = GameObject.Find("Ball1");
    GameObject ball2 = GameObject.Find("Ball2");
    deactivateObject(ball1);
    deactivateObject(ball2);
    activateObject(yellowball);
   }
   void activateObject(GameObject objectToActivate){
        if (objectToActivate != null)
        {
            SpriteRenderer spriteRenderer = objectToActivate.GetComponent<SpriteRenderer>();
            CircleCollider2D circleCollider = objectToActivate.GetComponent<CircleCollider2D>();
            Rigidbody2D myRigidbody = objectToActivate.GetComponent<Rigidbody2D>();



            if (spriteRenderer != null)
            {
                if (!spriteRenderer.enabled)
                {
                    spriteRenderer.enabled = true;
                }
            }
            if (circleCollider != null)
            {
                if (!circleCollider.enabled)
                {
                    circleCollider.enabled = true;
                }
            }
            if (myRigidbody != null)
            {
                myRigidbody.simulated = true;
            }
        }
    }

    void deactivateObject(GameObject objectToActivate){
        if (objectToActivate != null)
        {
            SpriteRenderer spriteRenderer = objectToActivate.GetComponent<SpriteRenderer>();
            CircleCollider2D circleCollider = objectToActivate.GetComponent<CircleCollider2D>();

            if (spriteRenderer != null)
            {
                // Check if the SpriteRenderer is not active, and then activate it.
                if (spriteRenderer.enabled)
                {
                    spriteRenderer.enabled = false;
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
