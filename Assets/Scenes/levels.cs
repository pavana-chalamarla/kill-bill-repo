using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class levels : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        
    }
    private void OnMouseDown()
    {
        int buildIndex=5;
        Debug.Log("Hello");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
