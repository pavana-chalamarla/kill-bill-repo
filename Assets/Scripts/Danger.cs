using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Danger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        {
           SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
           Debug.Log("Enter");

	    
        }
    }
 

}
