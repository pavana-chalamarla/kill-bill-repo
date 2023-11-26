using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball2TriggerZone : MonoBehaviour
{
    public bool Ball2Entered { get; set; } = false;
    public GameObject flagObject;
    public bool starcombinelevel = false;
    public Ball1TriggerZone ball1Zone;
    public Analytics aobj => Analytics.Instance;
    private ParticleSystem confettiParticles;

    private void Start()
    {
        
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
            if(starcombinelevel){
                GameObject tr1 = GameObject.Find("triangle1");
                GameObject flagpole1 = GameObject.Find("flag pole 1");
                GameObject combiner = GameObject.FindWithTag("Combiner");
                GameObject smallblue = GameObject.Find("small triangle blue");
                GameObject bigblue  = GameObject.Find("blue big");
                GameObject tr2 = GameObject.Find("triangle2");
                GameObject flagpole2 = GameObject.Find("flag pole 2");
                GameObject smallred = GameObject.Find("small triangle red");
                GameObject bigred  = GameObject.Find("red big");
                smallred.SetActive(false);
                bigred.SetActive(false);
                tr2.SetActive(false);
                flagpole1.SetActive(false);
                smallblue.SetActive(false);
                bigblue.SetActive(false);
                tr1.SetActive(false);
                flagpole2.SetActive(false);
            }
            else{
                Debug.Log("Congrats, Level done!");
                // Find the Particle System by name
                ParticleSystem confettiParticles = GameObject.Find("Particle System").GetComponent<ParticleSystem>();

                if (confettiParticles != null)
                {
                    GameObject ball1 = GameObject.Find("Ball1");
                    GameObject ball2 = GameObject.Find("Ball2");
                    GameObject ball3 = GameObject.Find("Top ball 2");
                    if(ball1 !=null){
                        ball1.SetActive(false);
                    }
                    if(ball2 !=null){
                        ball2.SetActive(false);
                    }
                    if(ball3 !=null){
                        ball3.SetActive(false);
                    }
                    confettiParticles.Play();
                    float confettiDuration = confettiParticles.main.duration;
                    Invoke("LoadNextScene", confettiDuration);
                }
                else
                {
                    Debug.LogError("Particle System not found!");
                }
                
                
            }
            
        }
        else if(b1!=null && b2!=null && !b1 && b2){
            aobj.RecordSingleFlags();
        }

    }

   public void ChangeFlagColor(string hexColor)
{
    if (flagObject == null)
    {
        flagObject = GameObject.FindWithTag("BottomFlag");
        if(flagObject == null){
            Debug.Log("No object with tag 'BottomFlag' found.");
        }
    }
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

    void LoadNextScene(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        aobj.Save();
    }


}
