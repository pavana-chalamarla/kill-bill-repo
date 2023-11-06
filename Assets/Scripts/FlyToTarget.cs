using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyToTarget : MonoBehaviour
{
    public Transform target;  // Reference to the target object.
    public float speed = 5.0f;  // Speed at which the object will move.
    public float duration = 2.0f;  // Duration of the movement.

    private float startTime;
    private Vector3 initialPosition;

    public bool ismoving = false;

    private void Start()
    {
        initialPosition = transform.position;
        startTime = Time.time;
    }

    private void Update()
    {
        if (target != null && ismoving)
        {
            // Calculate the progress of the movement.
            float journeyLength = Vector3.Distance(initialPosition, target.position);
            float distanceCovered = (Time.time - startTime) * speed;
            float fractionOfJourney = distanceCovered / journeyLength;

            // Lerp the position between the initial and target positions.
            transform.position = Vector3.Lerp(initialPosition, target.position, fractionOfJourney);

            // If the object has reached the target, you can stop or destroy it.
            if (fractionOfJourney >= 1.0f)
            {
                // Object has reached the target; you can disable, destroy, or perform other actions.
                ismoving = false;
                Destroy(gameObject);
            }
        }
    }
}
