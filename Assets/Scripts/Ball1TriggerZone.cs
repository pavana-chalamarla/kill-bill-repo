using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Ball1TriggerZone : MonoBehaviour
{
    public bool ball1Entered { get; set; } = false;
    public Color originalColor; // Store the original color
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
        bool b2 = ball1Entered;
        bool b1 = ball2Zone.ballentered();

        if(b1!=null && b2!=null && b1 && b2){
            Debug.Log("heyyy");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            aobj.Save();
        }
    }

    public void ChangeFlagColor(Color color)
    {
        if (flagObject != null)
        {
            flagObject.GetComponent<SpriteRenderer>().color = color;
        }
    }

    public bool ballentered(){
        return this.ball1Entered;
    }

}
