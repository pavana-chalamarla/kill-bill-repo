using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Ball1TriggerZone : MonoBehaviour
{
    public bool ball1Entered { get; private set; } = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Ball1")
        {
            ball1Entered = true;
            CheckCollisions();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Ball1")
        {
            ball1Entered = false;
        }
    }
    private void CheckCollisions()
    {
        // Find the Ball2TriggerZone GameObject
        Ball2TriggerZone ball2Zone = FindObjectOfType<Ball2TriggerZone>();

        if (ball2Zone != null && ball1Entered && ball2Zone.Ball2Entered)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

}
