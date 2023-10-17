using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Ball1TriggerZone : MonoBehaviour
{
    public bool ball1Entered { get; set; } = false;
    public Color originalColor; // Store the original color
    private GameObject flagObject;

    private void Start()
    {
<<<<<<< Updated upstream
        Debug.Log("collision.");
        // Find the object with the tag "flag1" at the start
        flagObject = GameObject.FindGameObjectWithTag("TopFlag");
        if (flagObject == null)
        {
            Debug.Log("No object with tag 'TopFlag' found.");
        }
=======

>>>>>>> Stashed changes
    }
   
    private void OnTriggerEnter2D (Collider2D other)
    {

        if (other.gameObject.CompareTag("Mirror"))
        {
            Debug.Log("miroor coll");
        }


        if (other.gameObject.name == "Ball1")
        {
<<<<<<< Updated upstream
            Debug.Log("collision dtected");

            //ChangeFlagColor(Color.green);
           // ball1Entered = true;
            CheckCollisions();
=======
                ball1Entered = true;
                CheckCollisions();
>>>>>>> Stashed changes
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {

       
        if (other.gameObject.name == "Ball1")
        {
<<<<<<< Updated upstream
            //ChangeFlagColor(originalColor);
            //ball1Entered = false;
=======
            ball1Entered = false;
>>>>>>> Stashed changes
        }
    }
    public void CheckCollisions()
    {
        // Find the Ball2TriggerZone GameObject
        Ball2TriggerZone ball2Zone = FindObjectOfType<Ball2TriggerZone>();

        if (ball2Zone != null && ball1Entered && ball2Zone.Ball2Entered)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void ChangeFlagColor(Color color)
    {
        if (flagObject != null)
        {
            flagObject.GetComponent<SpriteRenderer>().color = color;
        }
    }

}
