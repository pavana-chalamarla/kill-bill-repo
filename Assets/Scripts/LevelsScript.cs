using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelsScript : MonoBehaviour
{ 
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void Level2()
    {
        SceneManager.LoadScene("Level-2");
    }
    public void Level3()
    {
        SceneManager.LoadScene("Level-3");
    }
    public void Level4()
    {
        SceneManager.LoadScene("Level-4");
    }
 public void Level5()
    {
        SceneManager.LoadScene("Level-5");
    }
public void Level6()
    {
        SceneManager.LoadScene("Ball size powerup");
    }
public void Level7()
    {
        SceneManager.LoadScene("Level-7");
    }
public void Level8()
    {
        SceneManager.LoadScene("Level-8");
    }
public void Level9()
    {
        SceneManager.LoadScene("Level-9");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
