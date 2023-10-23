using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingSpike : MonoBehaviour
{
    public float fallSpeed = 5.0f;
    public float groundLevel = 0.0f;

    private bool hasHitGround = false;

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
    }
}
