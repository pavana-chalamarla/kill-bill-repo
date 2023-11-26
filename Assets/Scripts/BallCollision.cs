using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollision : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    [SerializeField] public Transform groundCheck;
    [SerializeField] public LayerMask groundlayer;
    public float jump = 16f;
    public bool isTop = false;
    public Analytics aobj => Analytics.Instance;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && IsGrounded())
    {
        if (isTop)
        {
            // Apply top jump force
            rb.velocity = new Vector2(rb.velocity.x, jump);
        }
        else
        {
            // Apply bottom jump force
            rb.velocity = new Vector2(rb.velocity.x, -jump);
        }
    }
    }
    public bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundlayer);
    }

    public Transform topPosition; // Assign the top position in the Inspector
    public Transform bottomPosition; // Assign the bottom position in the Inspector


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Block")) // You should set a tag for your block GameObject
        {
            // Move the ball to a new position
            aobj.RecordPowerup();
            aobj.Recordpowerupname("Teleport");

            if(aobj.GetPowerup()== 1){
                aobj.RecordFirstpoweruptime();
            }

            // Move the ball to the opposite position
            if (isTop)
            {
                if(bottomPosition != null){
                    transform.position = bottomPosition.position;
                }
                else{
                    Debug.Log("No bottom");
                }
            }
            else
            {
                if(topPosition != null){
                    transform.position = topPosition.position;
                }
                else{
                    Debug.Log("No top");
                }
            }

            // Reverse the gravity scale of the ball.
            rb.gravityScale = -rb.gravityScale;

            // Toggle the top/bottom flag
            isTop = !isTop;
        }

    }
}
