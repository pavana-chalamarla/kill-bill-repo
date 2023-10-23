using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingSpike : MonoBehaviour
{
    public float fallSpeed = 5.0f;
    public float resetDelay = 2.0f; // Time delay before resetting
    public Vector3 initialPosition; // Initial position of the spike
    public float groundLevel = 0.0f;

    private bool hasHitGround = false;
    private float timeSinceHitGround = 0f;

    private void Start()
    {
        // Store the initial position of the spike
        initialPosition = transform.position;
    }

    private void Update()
    {
        if (!hasHitGround)
        {
            // Move the spike downwards
            transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);

            // Check if the spike has hit the ground
            if (transform.position.y <= groundLevel)
            {
                // Stop the spike from falling further
                hasHitGround = true;

                // Optionally, you can play a sound or trigger an event when the spike hits the ground.
            }
        }
        else
        {
            // Spike has hit the ground, start a timer
            timeSinceHitGround += Time.deltaTime;

            // Check if the reset delay time has passed
            if (timeSinceHitGround >= resetDelay)
            {
                // Reset the spike's position
                ResetSpikePosition();
            }
        }
    }

    void ResetSpikePosition()
    {
        // Reset the position of the spike to its initial position
        transform.position = initialPosition;

        // Reset state variables
        hasHitGround = false;
        timeSinceHitGround = 0f;
    }
}
