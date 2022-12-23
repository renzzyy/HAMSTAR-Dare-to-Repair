using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SparksOn : MonoBehaviour {

    [SerializeField] private TilemapRenderer tilemap;
    
    void Start() 
    {
       tilemap = GetComponent<TilemapRenderer>();
       StartCoroutine(SparkTime());
    }
    
    // while true, the spark visual between the wires will
    // momentarily turn off every 1 second to allow the player to
    // jump through
    IEnumerator SparkTime() 
    {
       while (true) {
          tilemap.enabled = true;
          yield return new WaitForSeconds(1);
          tilemap.enabled = false;
          yield return new WaitForSeconds(1);
       } 
    }
}
