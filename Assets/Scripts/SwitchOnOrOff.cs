using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SwitchOnOrOff : MonoBehaviour {

    [SerializeField] private TilemapRenderer tilemap;
    [SerializeField] private GameObject boxBlocker;

    private void OnTriggerEnter2D(Collider2D trig) {
       if (trig.CompareTag("Player")) {
           if (tilemap.enabled == true) {
               tilemap.enabled = false;
           } else {
                tilemap.enabled = true;
           }
           if (boxBlocker.activeSelf == true) {
               boxBlocker.SetActive(false);
           } else {
                boxBlocker.SetActive(true);
           }
           
          
       }
    }
}
