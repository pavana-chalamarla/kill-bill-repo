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
    public bool grounded;

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
        if (Input.GetButtonDown("Jump") && originalBall.GetComponent<Ballmovement>().IsGrounded() &&grounded)
        {
            mirrorBallMovement.rb.velocity = new Vector2(mirrorBallMovement.rb.velocity.x, -mirrorBallMovement.jump);
                        grounded = false;

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
      public void OnCollisionEnter2D(Collision2D other){
        Debug.Log("ground collision");
        if(other.gameObject.layer==LayerMask.NameToLayer("Ground")){
                        grounded = true;

        }
    }
    
}