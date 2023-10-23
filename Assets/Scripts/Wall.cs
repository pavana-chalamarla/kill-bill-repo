using UnityEngine;

public class WallController : MonoBehaviour
{
    public int maxHits = 3;
    private int hitCount = 0;
    public string balltag = "";
    public ParticleSystem crackingEffect;
    public Texture2D crackedWallTexture; // Assign the cracked wall texture in the Inspector.

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(balltag))
        {
            hitCount++;
            Debug.Log(hitCount);

            if (hitCount >= maxHits)
            {
                // Destroy the wall when hit three times.
                Destroy(gameObject);
            }
            else
            {
                // Apply a cracked texture gradually.
                Debug.Log("applying cracks");
                ApplyCracks();
            }
        }
    }

    private void ApplyCracks()
    {
        // Adjust the wall's texture to show cracks.
        GetComponent<SpriteRenderer>().material.mainTexture = crackedWallTexture;
    }
}

