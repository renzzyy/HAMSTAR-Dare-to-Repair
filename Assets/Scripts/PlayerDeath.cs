using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour {

    // [SerializeField] private Transform player;
    // [SerializeField] private CharacterControllerSH deathActions;
    // [SerializeField] private Transform respawn;

    // private int count = 0; // will be used to display death count to players

   // respawns the player to the beginning of the level
   // when they hit the "death zone"
    private void OnTriggerEnter2D(Collider2D trig) {
       if (trig.CompareTag("Player")) {
          SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
         // player.transform.position = respawn.transform.position;
         // deathActions.FlipRight();
         // Physics.SyncTransforms();
         // count++;
       }
    }
}
