using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollision : MonoBehaviour
{
    // Start is called before the first frame update
    public float newGravityScale = -4.0f;
    private Rigidbody2D rb;
    [SerializeField] public Transform groundCheck;
    [SerializeField] public LayerMask groundlayer;
    public float jump = 16f;
    private bool hasMoved = false;
    public Analytics aobj => Analytics.Instance;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(hasMoved){
            if (Input.GetButtonDown("Jump") && IsGrounded())
                {
                    rb.velocity = new Vector2(rb.velocity.x, -jump);
                }
                if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
                {
                    rb.velocity = new Vector2(rb.velocity.x, -rb.velocity.y * 0.5f * Time.deltaTime);
                }
        }
        
    }
    public bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundlayer);
    }

    public Transform newPosition; // Assign the new position in the Inspector

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

            if (newPosition != null)
            {
                transform.position = newPosition.position;
                // You may also want to reset the ball's velocity
                GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                // Change the gravity scale of the ball.
                 rb.gravityScale = newGravityScale;
                // Mirror the jump movement (opposite jump)
                hasMoved = true;
            }
        }
    }
}
