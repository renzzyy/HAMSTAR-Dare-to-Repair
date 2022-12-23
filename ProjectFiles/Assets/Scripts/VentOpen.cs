using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VentOpen : MonoBehaviour
{
    [SerializeField] private GameObject vent;
    [SerializeField] private GameObject textPopup;

    private bool collided = false;

    // player keyboard input check
    void Update()
    {
        if (Input.GetKeyDown("e")) 
        {
            OpenVent();
        }
    }

    // checks for collision
    private void OnTriggerEnter2D(Collider2D trig) 
    {
       if (trig.CompareTag("Player")) 
       {
          collided = true;
          Debug.Log("Collided");
          //textPopup.SetActive(true);
          //Invoke("ClosePopup", 5);
       } 
       else
       {
        collided = false;
       }
    }

    // level complete, loads next level
    void OpenVent() 
    {
        if (collided == true) 
        {
            if (Inventory.seeds > 0) 
            {
                Inventory.seeds = 0;
                Debug.Log(Inventory.seeds);
                Invoke("NextLevel", 1);
            }
        }
    }

    // level complete, loads next level
    void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //void ClosePopup()
    //{
      //textPopup.SetActive(false);
    //}
}
