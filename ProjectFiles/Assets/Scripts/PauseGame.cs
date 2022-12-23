using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject pauseMenu;

    // player keyboard input check
    void Update () 
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            if (isPaused) 
            {
                resumeGame();
            } else {
                pauseGame();
            }
        }
    }

    // player can click button to unpause and resume
    public void resumeGame() 
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
    
    // player can click "Esc" to bring up pause menu
    public void pauseGame() 
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    // player can exit to desktop
    public void exit() 
    {   
        //Application.Quit();
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
        Debug.Log("Quit");
    }

}
