using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public static bool isGameOver;
    public GameObject gameOverScreen;

    public Analytics aobj => Analytics.Instance;

    private void Awake()
    {
        isGameOver = false;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver)
        {
            gameOverScreen.SetActive(true);
        }
    }

    public void restart()
    {
        Debug.Log("Restart button clicked."); // Add this line
          SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        aobj.RecordLevelRestart();
      
    }

    public void mainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        aobj.Save();
        Debug.Log("Mainmenu");
    }
     public void levels()
    {
        
        SceneManager.LoadScene("Levels");
        aobj.Save();
       
    }
}
