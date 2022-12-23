using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerDeath : MonoBehaviour {

   [SerializeField] private TMP_Text deathsText;
   public static int count;

   // respawns the player to the beginning of the level when they hit the "death zone"
    private void OnTriggerEnter2D(Collider2D trig) 
    {
       if (trig.CompareTag("Player")) 
       {
         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
         count = count + 1; // adds to the player death counter
         Inventory.seeds = 0; // if player was holding a seed, they "drop it" upon death
       }
    }

   // saves death count so that when the scene resets, the death count stays the same
    void Update() 
    {
      PlayerPrefs.SetInt("deathcount", count);
      int deathCount = PlayerPrefs.GetInt("deathcount");
      deathsText.text = deathCount.ToString();
    }
}
