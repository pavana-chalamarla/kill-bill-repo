using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintText : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject textObject; // Assign your TextMesh or TextMeshPro GameObject here in the inspector
    void Start()
    {
        // Make the text initially invisible
        textObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name== "Ball1") // Replace "Player" with your player tag
        {
            // Toggle the visibility of the text
                        textObject.SetActive(true);
           Invoke("HideText", 2f); // Hide the text after 2 seconds
        }
    }

    private void HideText()
    {
        // This function will be called after 2 seconds to hide the text
        textObject.SetActive(false);
    }
}
