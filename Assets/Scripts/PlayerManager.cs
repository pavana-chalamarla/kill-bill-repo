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
            aobj.RecordGameOver();
            gameOverScreen.SetActive(true);
        }
    }

    public void restart()
    {
        Debug.Log("Restart button clicked."); // Add this line
        aobj.RecordLevelRestart();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void mainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Debug.Log("Mainmenu");
    }
     public void levels()
    {
        SceneManager.LoadScene("Levels");
       
    }
}
