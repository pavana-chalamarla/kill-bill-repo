using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class downteleport : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject topball;
    public GameObject bottomball;
    public bool isTop = false;
    public Transform topPosition; // Assign the top position in the Inspector
    public Transform bottomPosition; // Assign the bottom position in the Inspector


    public Analytics aobj => Analytics.Instance;
    void Start()
    {
        if(topball!=null){
            topball.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Block"))
        {
            aobj.RecordPowerup();

            if(aobj.GetPowerup()== 1){
                aobj.RecordFirstpoweruptime();
            }

            // Move the ball to the opposite position
            if (isTop)
            {
                bottomball.transform.position = bottomPosition.position;
                bottomball.transform.localScale = topball.transform.localScale;
                topball.SetActive(false);
                bottomball.SetActive(true);
            }
            else
            {
                topball.transform.position = topPosition.position;
                bottomball.SetActive(false);
                topball.SetActive(true);
            }

            
        }
    }
}
