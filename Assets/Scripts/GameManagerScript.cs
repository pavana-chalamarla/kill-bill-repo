using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour

{
    public GameObject gameOverUI; // Start is called before the first frame update Unity Message 
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void gameOver()
    {

        gameOverUI.SetActive(true);
    }
   
    public void restart()
    {
            Debug.Log("Restart button clicked."); // Add this line
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

   public void mainMenu()
   {
      SceneManager.LoadScene("MainMenu");
       Debug.Log("Mainmenu");
   }
}


