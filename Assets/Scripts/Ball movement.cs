using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballmovement : MonoBehaviour
{
    public float horizontal;
    public float speed = 250f;
    public float jump = 13f;
    public bool isFacingRight = true;
    [SerializeField] public Rigidbody2D rb;
    [SerializeField] public Transform groundCheck;
    [SerializeField] public LayerMask groundlayer;
    public mirror mirrorBallScript;
    public Ball1TriggerZone fcolor1;
    public MagneicObj mg;
    public Ball2TriggerZone fcolor2;
    public ColorRumble colorRumble;

    public Star star;
    public Combiner combiner;
    private int starcount = 0;
    public bool grounded;

    public Analytics aobj => Analytics.Instance;

    public void Start()
    {

    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Mirror"))
        {
            mirrorBallScript.ToggleDirection();
            aobj.RecordPowerup();
            aobj.Recordpowerupname(" Mirror");

            if(aobj.GetPowerup()== 1){
                aobj.RecordFirstpoweruptime();
            }

        }

        if (collider.gameObject.CompareTag("Enemy"))
        {
            PlayerManager.isGameOver=true;
        }

        if (collider.gameObject.name == "Finish2" && gameObject.name == "Ball2")
        {
            fcolor2.ChangeFlagColor("#00FF00");
            fcolor2.Ball2Entered = true;
            fcolor2.CheckCollisions();
//2
        }
        if (collider.gameObject.name == "Finish1"&& gameObject.name == "Ball1")
        {
            fcolor1.ChangeFlagColor("#00FF00");
            fcolor1.ball1Entered = true;
            fcolor1.CheckCollisions();
        }

        if (collider.gameObject.name =="chain")
        {
            aobj.RecordPowerup();
            aobj.Recordpowerupname(" Link");

            if(aobj.GetPowerup()== 1){
                aobj.RecordFirstpoweruptime();
            }
            mirrorBallScript.s();
            collider.gameObject.SetActive(false);
        }
        

        if (collider.gameObject.name=="magnet")
        {
            aobj.RecordPowerup();
            aobj.Recordpowerupname(" Magnet");

            if(aobj.GetPowerup()== 1){
                aobj.RecordFirstpoweruptime();
            }
            mg.isAttracting = true;
        }

        if  (collider.gameObject.tag == "ColorFlag"){
            Debug.Log("color flag collisiom");
            colorRumble.setTrue(collider.gameObject);
        }
       if(collider.gameObject.name=="star1"){
            aobj.RecordPowerup();
            aobj.Recordpowerupname(" Star");

            if(aobj.GetPowerup()== 1){
                aobj.RecordFirstpoweruptime();
            }
            star.activateblue();
       }
       if(collider.gameObject.name=="star2"){
            aobj.RecordPowerup();
            aobj.Recordpowerupname(" Star");

            if(aobj.GetPowerup()== 1){
                aobj.RecordFirstpoweruptime();
            }
            star.activatered();
       }
       if(collider.gameObject.name=="star3"){
            aobj.RecordPowerup();
            aobj.Recordpowerupname(" Star");

            if(aobj.GetPowerup()== 1){
                aobj.RecordFirstpoweruptime();
            }
            star.activatefinish1();
       }
       if(collider.gameObject.name=="star4"){
            aobj.RecordPowerup();
            aobj.Recordpowerupname(" Star");

            if(aobj.GetPowerup()== 1){
                aobj.RecordFirstpoweruptime();
            }
            star.activatefinish2();
       }

       if(collider.gameObject.CompareTag("Combiner")){
          aobj.RecordPowerup();
          aobj.Recordpowerupname(" Combiner");

            if(aobj.GetPowerup()== 1){
                aobj.RecordFirstpoweruptime();
            }
          combiner.activateball();
       }


    }
    private void OnTriggerExit2D(Collider2D collider)
    {

        if (collider.gameObject.name == "Finish1")
        {
            fcolor1.ChangeFlagColor("#00F8CD");
            fcolor1.ball1Entered = false;


        }
        if (collider.gameObject.name == "Finish2")
        {
            fcolor2.ChangeFlagColor("#F80F0F");
            fcolor2.Ball2Entered = false;


        }

        if (collider.gameObject.name == "magnet")
        {
            mg.isAttracting = false;
        }


        if  (collider.gameObject.tag == "ColorFlag"){
            colorRumble.setFalse(collider.gameObject);
        }


    }
    public void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        if (Input.GetButtonDown("Jump") && IsGrounded() && grounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jump);
                                grounded = false;

        }

        // if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        // {
        //     rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f * Time.deltaTime);
        // }
    }
    public void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed * Time.deltaTime, rb.velocity.y);
    }

    public bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundlayer);
    }

    public void OnCollisionEnter2D(Collision2D other){
        Debug.Log("ground collision");
        if(other.gameObject.layer==LayerMask.NameToLayer("Ground")){
                        grounded = true;

        }
    }
    
}
