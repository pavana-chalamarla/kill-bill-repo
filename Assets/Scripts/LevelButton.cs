using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelButton : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 0 corresponds to the left mouse button
        {
            ReturnToMenu();
        }
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("Levels");
    }
}

