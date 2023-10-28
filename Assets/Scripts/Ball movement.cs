using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballmovement : MonoBehaviour
{
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
    // Start is called before the first frame update

    public void Start()
    {

    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Mirror"))
        {
            mirrorBallScript.ToggleDirection();
        }
        if (collider.gameObject.name == "Finish2")
        {
            fcolor2.ChangeFlagColor(Color.green);
            fcolor2.Ball2Entered = true;
            fcolor2.CheckCollisions();
//2
        }
        if (collider.gameObject.name == "Finish1")
        {
            fcolor1.ChangeFlagColor(Color.green);
            fcolor1.ball1Entered = true;
            fcolor1.CheckCollisions();

        }
<<<<<<< Updated upstream
       
=======

        if (collider.gameObject.name=="magnet")
        {
            mg.isAttracting = true;
        }
        if (collider.gameObject.name =="chain")
        {
            mirrorBallScript.s();
        }
      

>>>>>>> Stashed changes
    }
    private void OnTriggerExit2D(Collider2D collider)
    {

        if (collider.gameObject.name == "Finish1")
        {
            fcolor1.ChangeFlagColor(Color.white);
            fcolor1.ball1Entered = false;


        }
        if (collider.gameObject.name == "Finish2")
        {
            fcolor2.ChangeFlagColor(Color.white);
            fcolor2.Ball2Entered = false;


        }
    }
    public void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jump);
        }
        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f * Time.deltaTime);
        }
    }
    public void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed * Time.deltaTime, rb.velocity.y);
    }

    public bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundlayer);
    }
}
