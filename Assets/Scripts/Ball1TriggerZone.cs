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
<<<<<<< Updated upstream
=======
    public Analytics aobj => Analytics.Instance;


>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
            Debug.Log("collision detected");
            CheckCollisions();
=======
            Debug.Log("collision dtected");

            //ChangeFlagColor(Color.green);
           // ball1Entered = true;
          //  CheckCollisions();
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
        // Find the Ball2TriggerZone GameObject
        ball2Zone = FindObjectOfType<Ball2TriggerZone>();

        if (ball2Zone != null && ball1Entered && ball2Zone.Ball2Entered)
        {
<<<<<<< HEAD
=======
            Debug.Log("call next scene");
            Analytics.Instance.Save();
>>>>>>> 23831bb74a7faf8c58badd8c84e37dc3a86f014b
=======

        // Find and set the Ball2TriggerZone reference
        //Ball2TriggerZone ball2Zone = GetComponent<Ball2TriggerZone>();
        //Debug.Log(ball2Zone);
        //Debug.Log("-------------------");
        Debug.Log("Ball 1 script ball1"+ball1Entered);
        Debug.Log("Ball 1 script ball2"+ball2Zone.ballentered());
        bool b2 = ball1Entered;
        bool b1 = ball2Zone.ballentered();

        if(b1!=null && b2!=null && b1 && b2){
            Debug.Log("heyyy");
>>>>>>> Stashed changes
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
