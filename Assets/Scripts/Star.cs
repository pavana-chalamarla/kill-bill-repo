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
    public GameObject combiner;

    public bool starcombinelevel = false;

    public Transform target;  // Reference to the target object.
    public float speed = 5.0f;  // Speed at which the object will move.
    public float duration = 2.0f;  // Duration of the movement.

    public FlyToTarget flyobj;

    private float startTime;
    private Vector3 initialPosition;

    private void Start(){
        if (combiner != null)
        {
            deactivateObject(combiner);
        }
        else
        {
            Debug.Log("combiner1 not found in the scene.");
        }
    }
    public void activateblue(){
        activateObject(smallblue);
        GameObject myGameObject = gameObject;
        deactivateObject(myGameObject);
        //flytotarget(myGameObject);
        //flyobj.ismoving = true;
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
        //flytotarget(myGameObject);
        //flyobj.ismoving = true;
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
        //flytotarget(objectToDeactivate);
        //flyobj.ismoving = true;
        if(finish1!=null){
            BoxCollider2D bx1 = finish1.GetComponent<BoxCollider2D>();
            if(bx1!=null){
            bx1.enabled = true;
            Debug.Log("finish1 activated");
        }
        }

        GameObject jump3 = GameObject.Find("jump3");
        deactivateObject(jump3);
    }
    public void activatefinish2(){
        activateObject(bigred);
        GameObject objectToDeactivate = GameObject.Find("star4");
        deactivateObject(objectToDeactivate);
        //flytotarget(objectToDeactivate);
        //flyobj.ismoving = true;
        if(finish2){
            BoxCollider2D bx2 = finish2.GetComponent<BoxCollider2D>();
            if(bx2!=null){
            bx2.enabled = true;
            Debug.Log("finish2 activated");
            }
        }
        GameObject jump4 = GameObject.Find("jump4");
        deactivateObject(jump4);

    }

    private void flytotarget(GameObject obj){
        if (target != null)
        {
            // Calculate the progress of the movement.
            float journeyLength = Vector3.Distance(initialPosition, target.position);
            float distanceCovered = (Time.time - startTime) * speed;
            float fractionOfJourney = distanceCovered / journeyLength;

            // Lerp the position between the initial and target positions.
            transform.position = Vector3.Lerp(initialPosition, target.position, fractionOfJourney);

            // If the object has reached the target, you can stop or destroy it.
            if (fractionOfJourney >= 1.0f)
            {
                // Object has reached the target; you can disable, destroy, or perform other actions.
                deactivateObject(obj);
            }
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
