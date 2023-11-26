using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColorRumble : MonoBehaviour
{
    public GameObject[] flgs;
    public GameObject[] nflgs;
    public int alignments = 3;
    // Start is called before the first frame update
    public bool rumblecombiner = false;
    public GameObject combiner;
    public Analytics aobj => Analytics.Instance;
    void Start()
    {
        if(combiner!=null){
            combiner.SetActive(false);
        }
        else{
            Debug.Log("couldn't found combiner");
        }
    }

    public void setTrue(GameObject obj){
        isCollided flagScript = obj.GetComponent<isCollided>();
        if (flagScript != null)  // Always good to check.
        {
            flagScript.SetCollisionState(true);
        }
        else
        {
            Debug.Log("No 'isCollided' script found on " + obj.name);
        }
        CheckAlignments();
    }

    public void setFalse(GameObject obj){

         isCollided flagScript = obj.GetComponent<isCollided>();
        if (flagScript != null)  // Always good to check.
        {
                                Debug.Log("Set to false " );

            flagScript.SetCollisionState(false);
        }
        else
        {
            Debug.Log("No 'isCollided' script found on " + obj.name);
        }

    }

    void setFlag(){

    }
    void CheckAlignments(){
        if (flgs != null && nflgs!= null && flgs.Length > 0 && nflgs.Length>0 && alignments >0)
        {
            for (int i = 0; i < flgs.Length; i++)
            {
                    isCollided flagScript1 = flgs[i].GetComponent<isCollided>();
                    isCollided flagScript2 = nflgs[i].GetComponent<isCollided>();

                if (flagScript1 != null && flagScript2 !=null && flagScript1.flgbool && flagScript2.flgbool) // Also check if the element itself is not null.
                {
                    //bool isFlagCollided = flgs[i].flgbool;
                    Debug.Log("Flag " + i + " collided status: --------" );
                    flgs[i].SetActive(false);
                    nflgs[i].SetActive(false);
                    alignments = alignments-1;
                }
                else if(flagScript1 != null && flagScript2 !=null && flagScript1.flgbool && !flagScript2.flgbool){
                    aobj.RecordSingleFlags();
                }
                else if(flagScript1 != null && flagScript2 !=null && !flagScript1.flgbool && flagScript2.flgbool){
                    aobj.RecordSingleFlags();
                }
                else
                {
                    Debug.Log("Flag at index " + i + " is null.");
                }
            }
            if (alignments==0){
                Debug.Log("Level Completed");
                if(rumblecombiner){
                    combiner.SetActive(true);
                }
                else{
                    ParticleSystem confettiParticles = GameObject.Find("Particle System").GetComponent<ParticleSystem>();

                    if (confettiParticles != null)
                    {
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
        }
        else
        {
            Debug.LogError("The 'flgs' array is null or empty.");
        } 
    }
    void LoadNextScene(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        aobj.Save();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
