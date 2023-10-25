using UnityEngine;

<<<<<<< Updated upstream
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

=======
public class Wall : MonoBehaviour
{
    public GameObject wall1;
    public GameObject wall2;
    public GameObject wall3;

    private BoxCollider wall1Collider;
    private BoxCollider wall2Collider;
    private BoxCollider wall3Collider;

    private void Start()
    {
        // Get the BoxCollider components for each wall
        wall1Collider = wall1.GetComponent<BoxCollider>();
        wall2Collider = wall2.GetComponent<BoxCollider>();
        wall3Collider = wall3.GetComponent<BoxCollider>();
    }

    public void RemoveWalls()
    {
            Debug.Log("yooo");
            if (wall1.activeSelf)
            {
                // Disable Wall1 and its collider
                wall1.SetActive(false);
                wall1Collider.enabled = false;

                // Enable Wall2 and its collider
                wall2.SetActive(true);
                wall2Collider.enabled = true;
            }
            else if (wall2.activeSelf)
            {
                // Disable Wall2 and its collider
                wall2.SetActive(false);
                wall2Collider.enabled = false;

                // Enable Wall3 and its collider
                wall3.SetActive(true);
                wall3Collider.enabled = true;
            }
            else if (wall3.activeSelf)
            {
                // Destroy Wall3 or perform any other action you want
                Destroy(wall3);
            }
    }
}


>>>>>>> Stashed changes
