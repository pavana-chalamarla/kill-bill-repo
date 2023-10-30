using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball2TriggerZone : MonoBehaviour
{
    public bool Ball2Entered { get; set; } = false;
    private GameObject flagObject;
    public Color originalColor; // Store the original color
    public Ball1TriggerZone ball1Zone;
    public Analytics aobj => Analytics.Instance;

    private void Start()
    {
        // Find the object with the tag "flag1" at the start
        flagObject = GameObject.FindGameObjectWithTag("BottomFlag");
        if (flagObject == null)
        {
            Debug.LogError("No object with tag 'BottomFlag' found.");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Ball2")
        {
           // CheckCollisions();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Ball2")
        {
            
        }
    }

    public void CheckCollisions()
    {

       bool b2 = Ball2Entered;
       bool b1 = ball1Zone.ballentered();

        if(b1!=null && b2!=null && b1 && b2){
            Debug.Log("heyyy");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            aobj.Save();
        }

        

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

    public bool ballentered(){
        return this.Ball2Entered;
    }

}
