using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SwitchOnOrOff : MonoBehaviour {

    [SerializeField] private TilemapRenderer tilemap;
    [SerializeField] private GameObject boxBlocker;

    private bool collided = false;

    // player keyboard input check
    void Update()
    {
        if (Input.GetKeyDown("e")) 
        {
            Switch();
        }
    }

    // checks for collision
    private void OnTriggerEnter2D(Collider2D trig) 
    {
       if (trig.CompareTag("Player")) 
       {
            collided = true; 
            Invoke("EndCollide", 2); 
       } else {
            collided = false;
       }
    }

    // turns tilemap on or off
    private void Switch()
    {
        if (collided == true)
        {
            if (tilemap.enabled == true) 
           {
               tilemap.enabled = false;
           } else {
                tilemap.enabled = true;
           }
           if (boxBlocker.activeSelf == true) 
           {
               boxBlocker.SetActive(false);
           } else {
                boxBlocker.SetActive(true);
           }
        }
    }

    // switches collision to false after a few seconds
    private void EndCollide()
    {
        collided = false;
    }
}
