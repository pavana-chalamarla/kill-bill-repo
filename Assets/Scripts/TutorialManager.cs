using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTutorial : MonoBehaviour
{
    public Transform[] focusPoints; // Points of interest for the tutorial
    public Transform originalPosition; // Original camera position and rotation
    public float focusTime = 5f; // Time in seconds to focus on each point
    public float transitionSpeed = 1f; // Speed of the transition

    private Camera mainCamera; // Main camera reference
    private Vector3 startPosition; // Start position of the camera before tutorial
    private Quaternion startRotation; // Start rotation of the camera before tutorial
    public const float FixedZPosition = -1.78f;
    void Start()
    {
        // Get the main camera
        mainCamera = Camera.main;

        // Store the original position and rotation
        startPosition = originalPosition.position;
        startRotation = originalPosition.rotation;

        // Start the tutorial sequence
        StartCoroutine(TutorialSequence());
    }

    IEnumerator TutorialSequence()
    {
        // Loop through all focus points
        foreach (var focusPoint in focusPoints)
        {
            // Lerp position and rotation to the focus point
            float elapsedTime = 0f;
            Vector3 nextPosition;

            while (elapsedTime < transitionSpeed)
            {
                nextPosition = new Vector3(
                focusPoint.position.x,
                focusPoint.position.y,
                FixedZPosition // Preserve the original Z position
            );
                mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, nextPosition, (elapsedTime / transitionSpeed));
                mainCamera.transform.rotation = Quaternion.Lerp(mainCamera.transform.rotation, focusPoint.rotation, (elapsedTime / transitionSpeed));

                elapsedTime += Time.deltaTime;
                yield return null;
            }

            // Wait at the focus point
            yield return new WaitForSeconds(focusTime);
        }

        // Return to the original position
        float returnTime = 0f;
        while (returnTime < transitionSpeed)
        {
            mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, startPosition, (returnTime / transitionSpeed));
            mainCamera.transform.rotation = Quaternion.Lerp(mainCamera.transform.rotation, startRotation, (returnTime / transitionSpeed));

            returnTime += Time.deltaTime;
            yield return null;
        }
    }
}
