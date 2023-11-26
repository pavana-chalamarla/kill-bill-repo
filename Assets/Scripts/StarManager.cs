using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject star1;
    public GameObject star2;
    public GameObject star3;
    public GameObject star4;
    public GameObject smallblue;
    public GameObject smallred;
    public GameObject bigblue;
    public GameObject bigred;
    public GameObject finish1;
    public GameObject finish2;
    public Analytics aobj => Analytics.Instance;

    void Start()
    {
        star3.SetActive(false);
        star4.SetActive(false);
        smallblue.SetActive(false);
        smallred.SetActive(false);
        bigblue.SetActive(false);
        bigred.SetActive(false);
        finish1.SetActive(false);
        finish2.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "star1")
        {
            aobj.RecordPowerup();

            if(aobj.GetPowerup()== 1){
                aobj.RecordFirstpoweruptime();
            }
            star1.SetActive(false);
            bothactive();
            
            smallblue.SetActive(true);
        }
        if(collision.gameObject.name == "star2")
        {
            aobj.RecordPowerup();

            if(aobj.GetPowerup()== 1){
                aobj.RecordFirstpoweruptime();
            }
            star2.SetActive(false);
            bothactive();
            
            smallred.SetActive(true);
        }
        if(collision.gameObject.name == "star3" && gameObject.name == "Ball1")
        {
            aobj.RecordPowerup();

            if(aobj.GetPowerup()== 1){
                aobj.RecordFirstpoweruptime();
            }

            star3.SetActive(false);
            finish1.SetActive(true);
            bigblue.SetActive(true);

        }
        if(collision.gameObject.name == "star4" && (gameObject.name == "Ball2" || gameObject.name == "New Ball 2") )
        {
            aobj.RecordPowerup();

            if(aobj.GetPowerup()== 1){
                aobj.RecordFirstpoweruptime();
            }

            star4.SetActive(false);
            finish2.SetActive(true);
            bigred.SetActive(true);
        }
    }

    public void bothactive(){
        if(!star1.activeSelf && !star2.activeSelf){
            star3.SetActive(true);
            star4.SetActive(true);
        }
    }
}
