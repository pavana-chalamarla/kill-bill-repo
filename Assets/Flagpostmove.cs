using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flagpostmove : MonoBehaviour

{
    [SerializeField] Ballmovement bm;
     public float horizontal;
    public float speed = 100f;
    public float jump = 16f;
    public bool isFacingRight = true;
    [SerializeField] public Rigidbody2D rb;
    [SerializeField] public Transform groundCheck;
    [SerializeField] public LayerMask groundlayer;
    public mirror mirrorBallScript;
    public Ball1TriggerZone fcolor1;
    public Ball2TriggerZone fcolor2;
public float moveSpeed = 5.0f; 
    public Ballmovement fp;
    private float timerDuration = 40.0f; 
    private bool canMove = true;
    // Ballmovement fp = FindObjectOfType<Ballmovement>();
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Update()
    {
        // fp = FindObjectOfType<Ballmovement>();

        // if(fp.flag)
        // {
        // float horizontalInput = Input.GetAxis("Horizontal");

        // // Calculate the new position based on the input and speed
        // Vector3 newPosition = transform.position + Vector3.right * horizontalInput * moveSpeed * Time.deltaTime;

        // // Move the square to the new position
        // transform.position = newPosition;
        // }
        
        
    }
    public void postmove()
    { // Adjust this to
      // Get input from arrow keys
      Debug.Log("Flag post is moving");
    //   for(int i=0;i<100000;i++)
    //   {
      horizontal = Input.GetAxisRaw("Horizontal");
        // if (Input.GetButtonDown("Jump") && IsGrounded())
        // {
        //     rb.velocity = new Vector2(rb.velocity.x, jump);
        // }
        // if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        // {
        //     rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f * Time.deltaTime);
        // }
    //   }
        
        }
         public void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed * Time.deltaTime, rb.velocity.y);
    }

    public bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundlayer);
    }
    IEnumerator RunForDuration(float duration)
    {
        float timer = 0f;
        while (timer < duration)
        {
            if (canMove)
            {
                postmove();
            }
            timer += Time.deltaTime;
            yield return null;
        }
    }
    public void Caller()
    {
        StartCoroutine(RunForDuration(5.0f)); // Run for 10 seconds
    }
       
}
