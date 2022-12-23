using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour {
    
    [SerializeField] private Collider2D col;
    
    public void GoToNextLevel() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void OnTriggerEnter2D(Collider2D col) 
    {
       if (col.CompareTag("Player")) {
           this.GoToNextLevel();
       }
    }
}
