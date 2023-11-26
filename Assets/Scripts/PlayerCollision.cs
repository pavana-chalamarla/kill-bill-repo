using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private bool isPowerupActive = false;
    private Vector3 originalSize;
    private Vector3 threeQuarterSize;

    public GameObject shrink;
    public GameObject big;

    public Analytics aobj => Analytics.Instance;

    
    private void Start()
    {
        // Store the original size of the object
        originalSize = transform.localScale;
        threeQuarterSize = originalSize * 0.75f; // Set it to 3/4 of the original size
        if(big!=null && shrink.activeSelf){
            big.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Obstacle hit");
            aobj.RecordObstacle();
            PlayerManager.isGameOver = true;
        }
        if(collision.gameObject.CompareTag("PowerUp"))
        {
            aobj.RecordPowerup();

            if(aobj.GetPowerup()== 1){
                aobj.RecordFirstpoweruptime();
            }

            if(!isPowerupActive){
                // PowerUp was not there, so activate it
               isPowerupActive = true;
               ReduceSize();
               aobj.Recordpowerupname(" Shrink");
               shrink.SetActive(false);
               big.SetActive(true);
            }
              else{
                // PowerUp was already active, so deactivate it
                isPowerupActive = false;
                RestoreOriginalSize();
                aobj.Recordpowerupname(" Unshrink");
                big.SetActive(false);
                shrink.SetActive(true);
            } 
        }

        


    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "shrink")
        {
            //activateObject(big);
        }

        if (collision.gameObject.name=="big"){
            //activateObject(shrink);
        }
        
    }

    private void ReduceSize()
    {
        transform.localScale = threeQuarterSize; // Set the size to 3/4 of the original size
    }

    private void RestoreOriginalSize()
    {
        transform.localScale = originalSize;
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
