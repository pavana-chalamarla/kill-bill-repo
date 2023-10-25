using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball2TriggerZone : MonoBehaviour
{
    public bool Ball2Entered { get; set; } = false;
    private GameObject flagObject;
    public Color originalColor; // Store the original color
    public Ball1TriggerZone ball1Zone;
<<<<<<< Updated upstream
=======
    public Analytics aobj => Analytics.Instance;

>>>>>>> Stashed changes
    private void Start()
    {
        // Find the object with the tag "flag1" at the start
        flagObject = GameObject.FindGameObjectWithTag("BottomFlag");
        if (flagObject == null)
        {
            Debug.LogError("No object with tag 'BottomFlag' found.");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Ball2")
        {
           // CheckCollisions();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Ball2")
        {
            
        }
    }

    public void CheckCollisions()
    {
<<<<<<< Updated upstream
        // Find the Ball1TriggerZone GameObject
        ball1Zone = FindObjectOfType<Ball1TriggerZone>();
=======
        // Find and set the Ball2TriggerZone reference
        //Ball1TriggerZone ball1Zone = GetComponent<Ball1TriggerZone>();
        Debug.Log(ball1Zone);
        Debug.Log("-------------------");
        Debug.Log("Ball 2 script ball2"+Ball2Entered);
        Debug.Log("Ball 2 script ball1"+ball1Zone.ballentered());
>>>>>>> Stashed changes

       bool b2 = Ball2Entered;
       bool b1 = ball1Zone.ballentered();

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
        return this.Ball2Entered;
    }

}
