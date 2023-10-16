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
            //ChangeFlagColor(Color.green);
            //Ball2Entered = true;
            CheckCollisions();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Ball2")
        {
            //ChangeFlagColor(originalColor);
            //Ball2Entered = false;
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
