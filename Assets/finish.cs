using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class finish : MonoBehaviour
{
    
    public int flag1 = 0;
    int flag2 = 0;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Ball1"&& other.gameObject.name == "Ball")
        {
            Debug.Log(other.gameObject.name);
        }


        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        //You can access information about the collision, such as contact points or the other GameObject, here.
    }

    

    //private void OnTriggerStay2D(Collider2D other)
    //{

    //    Debug.Log(other.gameObject.name);
    //    if (other.gameObject.name == "Circle (1)")
    //    {
    //        Debug.Log(other.gameObject.name);
    //    }
    //    if (other.gameObject.name == "Circle")
    //    {
    //        Debug.Log(other.gameObject.name);
    //    }



    //}


}
