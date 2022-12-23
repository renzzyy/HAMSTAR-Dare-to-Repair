using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public void Play() 
    {
        Debug.Log("Play");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
    public void QuitGame() 
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void ReturnToMenu() 
    {
        Debug.Log("Return");
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
