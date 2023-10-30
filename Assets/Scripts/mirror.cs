using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mirror : MonoBehaviour
{
    //private float horizontal;
    //private float speed = 100f;
    //private float jump = 16f;
    //private bool isFacingRight = true;
    //[SerializeField] private Rigidbody2D rb;
    //[SerializeField] private Transform groundCheck;
    //[SerializeField] private LayerMask groundlayer;
    // Start is called before the first frame update

    [SerializeField] private Transform originalBall; // Reference to the original ball's Transform
    private Transform mirrorTransform;
    public Ballmovement mirrorBallMovement;
    private bool shouldReverse = true;
    private Rigidbody rb;
    int stop=1;
  


    void Awake()
    {
        mirrorTransform = transform; // Get the Transform of the mirror object
        mirrorBallMovement = mirrorTransform.GetComponent<Ballmovement>();
        if (originalBall == null)
        {
            Debug.LogError("originalBall is not assigned in the Inspector!");
        }
    }


    void LateUpdate()
    {
        float directionMultiplier = shouldReverse ? -1 : 1;
        
        float horizontal = stop*directionMultiplier * originalBall.GetComponent<Ballmovement>().horizontal;
        mirrorBallMovement.horizontal = horizontal;

        // Mirror the jump movement (opposite jump)
        if (Input.GetButtonDown("Jump") && originalBall.GetComponent<Ballmovement>().IsGrounded())
        {
            mirrorBallMovement.rb.velocity = new Vector2(mirrorBallMovement.rb.velocity.x, -mirrorBallMovement.jump);
        }
        if (Input.GetButtonUp("Jump") && originalBall.GetComponent<Ballmovement>().rb.velocity.y > 0f)
        {
            mirrorBallMovement.rb.velocity = new Vector2(mirrorBallMovement.rb.velocity.x, -mirrorBallMovement.rb.velocity.y * 0.5f * Time.deltaTime);
        }
    }

    public void ToggleDirection()
    {
        //Debug.Log("working");
        shouldReverse = !shouldReverse; // Toggle the direction
        LateUpdate();

    }
    public void s()
    {
        stop =0;
        // rb.isKinematic = true;
    }
    
}