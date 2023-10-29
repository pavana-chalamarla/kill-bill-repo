using UnityEngine;

public class BallSizeChanger : MonoBehaviour
{
    private Vector3 originalSize;
    private bool isPowerupActive = false;

    private void Start()
    {
        // Store the original size of the object
        originalSize = transform.localScale;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with the power-up object
        if (collision.gameObject.CompareTag("PowerUp"))
        {
            Debug.Log("Collision with Power-Up detected");
            // Toggle the power-up effect
            isPowerupActive = !isPowerupActive;

            // Adjust the size based on the power-up state
            if (isPowerupActive)
            {
                Debug.Log("Power-Up Active - Reducing Size");
                // Reduce the size to half
                transform.localScale = originalSize / 2;
            }
            else
            {
                Debug.Log("Power-Up Deactivated - Returning to Original Size");
                // Return to the original size
                transform.localScale = originalSize;
            }
        }
    }
}
