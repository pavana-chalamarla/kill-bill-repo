using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball2TriggerZone : MonoBehaviour
{
    public bool Ball2Entered { get; set; } = false;
    private GameObject flagObject;
    public Color originalColor; // Store the original color

    private void Start()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Ball2")
        {
<<<<<<< Updated upstream
            //ChangeFlagColor(Color.green);
            //Ball2Entered = true;
=======
            Ball2Entered = true;
>>>>>>> Stashed changes
            CheckCollisions();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Ball2")
        {
<<<<<<< Updated upstream
            //ChangeFlagColor(originalColor);
            //Ball2Entered = false;
=======
            Ball2Entered = false;
>>>>>>> Stashed changes
        }
    }

    private void CheckCollisions()
    {
        // Find the Ball1TriggerZone GameObject
        Ball1TriggerZone ball1Zone = FindObjectOfType<Ball1TriggerZone>();

        if (ball1Zone != null && Ball2Entered && ball1Zone.ball1Entered)
        {
            // Do nothing here, as the scene loading is handled in Ball1TriggerZone
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
