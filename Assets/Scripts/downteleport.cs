using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class downteleport : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject topball;
    public GameObject bottomball;

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

            bottomball.SetActive(false);
            topball.SetActive(true);

        }
    }
}
