using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private bool isPowerupActive = false;
    private Vector3 originalSize;
    private Vector3 threeQuarterSize;

    private void Start()
    {
        // Store the original size of the object
        originalSize = transform.localScale;
        threeQuarterSize = originalSize * 0.75f; // Set it to 3/4 of the original size
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            PlayerManager.isGameOver = true;
        }
        if (collision.transform.tag == "PowerUp")
        {
            if (isPowerupActive)
            {
                // PowerUp was already active, so deactivate it
                isPowerupActive = false;
                RestoreOriginalSize();
            }
            else
            {
                // PowerUp is touched for the first time, activate it
                isPowerupActive = true;
                ReduceSize();
            }
        }
    }

    private void ReduceSize()
    {
        transform.localScale = threeQuarterSize; // Set the size to 3/4 of the original size
    }

    private void RestoreOriginalSize()
    {
        transform.localScale = originalSize;
    }
}
