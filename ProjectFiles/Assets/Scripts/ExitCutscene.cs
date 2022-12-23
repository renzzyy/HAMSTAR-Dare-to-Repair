using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ExitCutscene : MonoBehaviour
{

    private float timer = 101f;
    
    void Update() 
    {
        // auto swaps scenes after 90 seconds
        timer -= Time.deltaTime;

        if (timer <= 0) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
