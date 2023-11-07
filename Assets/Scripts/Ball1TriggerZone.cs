using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Ball1TriggerZone : MonoBehaviour
{
    public bool ball1Entered { get; set; } = false;
    public bool starcombinelevel = false;
    private GameObject flagObject;
    public Ball2TriggerZone ball2Zone;
    public Analytics aobj => Analytics.Instance;


    private void Start()
    {
        Debug.Log("collision.");
        // Find the object with the tag "flag1" at the start
        flagObject = GameObject.FindGameObjectWithTag("TopFlag");
        if (flagObject == null)
        {
            Debug.Log("No object with tag 'TopFlag' found.");
        }
    }
   
    private void OnTriggerEnter2D (Collider2D other)
    {

        if (other.gameObject.CompareTag("Mirror"))
        {
            Debug.Log("mirror coll");
        }


        if (other.gameObject.name == "Ball1")
        {
            Debug.Log("collision dtected");

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {

       
        if (other.gameObject.name == "Ball1")
        {
            
        }
    }
    public void CheckCollisions()
    {
        bool b1 = ball1Entered;
        bool b2 = ball2Zone.ballentered();

        
        
        if(b1!=null && b2!=null && b1 && b2){
            if(starcombinelevel){
                GameObject tr1 = GameObject.Find("triangle1");
                GameObject flagpole1 = GameObject.Find("flag pole 1");
                GameObject combiner = GameObject.FindWithTag("Combiner");
                GameObject smallblue = GameObject.Find("small triangle blue");
                GameObject bigblue  = GameObject.Find("blue big");
                GameObject tr2 = GameObject.Find("triangle2");
                GameObject flagpole2 = GameObject.Find("flag pole 2");
                GameObject smallred = GameObject.Find("small triangle red");
                GameObject bigred  = GameObject.Find("red big");
                smallred.SetActive(false);
                bigred.SetActive(false);
                tr2.SetActive(false);
                flagpole1.SetActive(false);
                smallblue.SetActive(false);
                bigblue.SetActive(false);
                tr1.SetActive(false);
                flagpole2.SetActive(false);
                activateObject(combiner);
            }
            else{
                Debug.Log("heyyy");
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                aobj.Save();
            }
        }
        else if(b1!=null && b2!=null && b1 && !b2){
            aobj.RecordSingleFlags();
        }
    }

   public void ChangeFlagColor(string hexColor)
{
    if (flagObject != null)
    {
        Color color;
        if (ColorUtility.TryParseHtmlString(hexColor, out color))
        {
            flagObject.GetComponent<SpriteRenderer>().color = color;
        }
        else
        {
            Debug.LogError("Invalid hexadecimal color string: " + hexColor);
        }
    }
}


    public bool ballentered(){
        return this.ball1Entered;
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

    
    
}
    


