using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float rotationSpeed = 30.0f; // Adjust the speed of rotation in degrees per second

    // Update is called once per frame
    void Update()
    {
        // Rotate the object around the Z-axis (2D) in a clockwise direction
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }
}
