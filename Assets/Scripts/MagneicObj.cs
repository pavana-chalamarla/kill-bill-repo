using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagneicObj : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform ball;
    public float speed = 1f;
    private float minDistance = 0.0f; // you can adjust this value as needed

    public bool isAttracting = false;
    public Transform target;
    private bool hasReachedTarget = false;

    private Vector3 directionToTarget;
    // Update is called once per frame
    void Update()
    {
        if (isAttracting)
        {
            Debug.Log("Target assigned.");

            //  Vector3 newPosition = transform.position;
            // newPosition.x = Mathf.MoveTowards(transform.position.x, ball.position.x, attractionSpeed * Time.deltaTime);
            // transform.position = newPosition;
            // Determine the direction to the target by subtracting the current position from the target's position.
            directionToTarget = target.position - transform.position;

            // We zero-out the y-component of the vector to keep the movement strictly horizontal.
            // This is assuming a 3D space where 'y' is the up-vector. For a 2D space (using Vector2), you would adjust accordingly.
            directionToTarget.y = 0;

            // Normalize the direction to ensure consistent speed.
            directionToTarget.Normalize();

            // Calculate the step size for this frame.
            float step = speed * Time.deltaTime;

            // Move the object towards the target.
            transform.position += directionToTarget * step;

            // For debugging purposes: log the current direction.
            Debug.Log("Moving in direction: " + directionToTarget);
        }

        if (target == null)
        {
            Debug.LogWarning("Target is not assigned.");
            return;
        }

        if (hasReachedTarget)
            return;

        // Calculate the distance to the target
        float distanceToTarget = Vector3.Distance(transform.position, target.position);

        if (!isAttracting && distanceToTarget < minDistance)
        {
            // Close enough to consider that the target has been reached
            Debug.Log("Target reached.");
            hasReachedTarget = true;
        }
        else if (isAttracting)
        {
            // If the object has not reached the target, continue moving towards it
            MoveTowardsTarget();
        }
        else
        {
            //Debug.Log("Donothing");
        }
    }

    void MoveTowardsTarget()
    {
        // Calculate the step size for this frame.
        float step = speed * Time.deltaTime;

        // Calculate the new position
        Vector3 newPosition = Vector3.MoveTowards(transform.position, target.position, step);

        // Ensure that the movement is only along the X-axis (assuming it's a 2D game on the XY plane).
        newPosition.y = transform.position.y;

        // Move our position a step closer to the target.
        transform.position = newPosition;
    }





}



