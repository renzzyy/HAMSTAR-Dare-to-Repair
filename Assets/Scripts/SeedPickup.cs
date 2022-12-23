using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedPickup : MonoBehaviour
{
    [SerializeField] private GameObject seed;

    private void OnTriggerEnter2D(Collider2D trig) 
    {
       if (trig.CompareTag("Player")) 
       {
         Inventory.seeds = Inventory.seeds + 1;
         seed.SetActive(false);

         Debug.Log(Inventory.seeds);
       }
    }
}
