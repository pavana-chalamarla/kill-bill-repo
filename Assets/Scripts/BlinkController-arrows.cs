using UnityEngine;

public class BlinkController : MonoBehaviour
{
    public float blinkDuration = 3f; // Duration of blinking in seconds
    public float blinkInterval = 0.5f; // Interval between blinks in seconds

    private SpriteRenderer spriteRenderer;
    private bool isVisible = true;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        InvokeRepeating("ToggleVisibility", 0f, blinkInterval);
        Invoke("HideObject", blinkDuration);
    }

    void ToggleVisibility()
    {
        isVisible = !isVisible;
        spriteRenderer.enabled = isVisible;
    }

    void HideObject()
    {
        CancelInvoke("ToggleVisibility");
        spriteRenderer.enabled = false;
    }
}
