using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Level-1");
    }
    public void Controls()
    {
        SceneManager.LoadScene("Controls");
    }


    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
       
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Levels()
    {
        SceneManager.LoadScene("Levels");
        Debug.Log("Levels");
    }

}



