using UnityEngine;

public class WallController : MonoBehaviour
{
        public string balltag = "";
 
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(balltag))
        {
            Debug.Log("hey there");
            Destroy(gameObject);
        }
    }
}

