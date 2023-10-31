using UnityEngine;

public class SpaceTrigger : MonoBehaviour
{
    public float delayBeforeStart = 5f; // Delay before the blinking starts in seconds
    public float blinkDuration = 3f; // Duration of blinking in seconds
    public float blinkInterval = 0.5f; // Interval between blinks in seconds

    private SpriteRenderer spriteRenderer;
    private bool isVisible = false;
    private bool blinkingStarted = false;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false; // Set the sprite renderer to be initially invisible
        Invoke("StartBlinking", delayBeforeStart);
    }

    void StartBlinking()
    {
        blinkingStarted = true;
        spriteRenderer.enabled = true; // Make the sprite renderer visible before blinking starts
        InvokeRepeating("ToggleVisibility", 0f, blinkInterval);
        Invoke("HideObject", blinkDuration);
    }

    void ToggleVisibility()
    {
        if (blinkingStarted)
        {
            isVisible = !isVisible;
            spriteRenderer.enabled = isVisible;
        }
    }

    void HideObject()
    {
        CancelInvoke("ToggleVisibility");
        spriteRenderer.enabled = false;
    }
}
