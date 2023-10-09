using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball2TriggerZone : MonoBehaviour
{
    public bool Ball2Entered { get; private set; } = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Ball2")
        {
            Ball2Entered = true;
            CheckCollisions();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Ball2")
        {
            Ball2Entered = false;
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
    

}
