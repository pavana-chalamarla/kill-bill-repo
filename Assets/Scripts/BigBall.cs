using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BigBall : MonoBehaviour
{
    // Start is called before the first frame update
    public Analytics aobj => Analytics.Instance;
    public float horizontal;
    public float speed = 100f;
    public float jump = 16f;
    public bool isFacingRight = true;
    private GameObject flagObject;
    [SerializeField] public Rigidbody2D rb;
    [SerializeField] public Transform groundCheck;
    [SerializeField] public LayerMask groundlayer;
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.name=="Finish"){
            flagObject = GameObject.Find("Triangle");
            ChangeFlagColor("#00FF00");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            aobj.Save();
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.gameObject.name=="Finish"){
            ChangeFlagColor("#F8E600");
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

    public void ChangeFlagColor(string hexColor)
{
    if (flagObject != null)
    {
        Color color;
        if (ColorUtility.TryParseHtmlString(hexColor, out color))
        {
            flagObject.GetComponent<SpriteRenderer>().color = color;
        }
        else
        {
            Debug.LogError("Invalid hexadecimal color string: " + hexColor);
        }
    }
}

}
