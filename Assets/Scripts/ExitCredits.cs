using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ExitCredits : MonoBehaviour {

    [SerializeField] private GameObject button;
    private float timer = 32f;
    
    // Update is called once per frame
    void Update() {
        // auto adds button so player can exit game
        timer -= Time.deltaTime;

        if (timer <= 0) {
            button.SetActive(true);
        }
    }
}