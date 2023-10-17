using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // Add this directive if you're working with UI components

public class EndGameScript : MonoBehaviour
{
    public void mainMenu()
    {
        // Load the "MainMenu" scene or the scene you want to return to
        SceneManager.LoadScene("MainMenu");
	Debug.Log("working");
    }
}
