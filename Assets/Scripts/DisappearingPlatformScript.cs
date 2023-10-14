using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearingPlatformScript : MonoBehaviour
{
    public float timeToTogglePlatform = 2f; // Time interval for toggling the platform
    private float currentTime = 0f;         // Tracks time
    private bool isEnabled = true;           // Indicates if the platform is currently enabled

    // Start is called before the first frame update
    void Start()
    {
        isEnabled = true; // Initialize the platform as enabled
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;

        // Check if it's time to toggle the platform
        if (currentTime >= timeToTogglePlatform)
        {
            TogglePlatform(); // Toggle the platform's visibility
            currentTime = 0f; // Reset the timer
        }
    }

    void TogglePlatform()
    {
        isEnabled = !isEnabled; // Toggle the isEnabled flag

        // Loop through the child objects of the platform
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(isEnabled); // Enable or disable each child object
        }
    }
}
