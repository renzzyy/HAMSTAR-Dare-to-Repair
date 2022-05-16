using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZapTime : MonoBehaviour {

    [SerializeField] private Collider2D col;
    
    void Start() {
       col = GetComponent<Collider2D>();
       StartCoroutine(ElectricZapTime());
    }
    
    // while true, the electric death zone between the wires will
    // momentarily turn off every 1 seconds to allow the player to
    // jump through
    IEnumerator ElectricZapTime() {
       while (true) {
          col.enabled = true;
          //Debug.Log("Collider Enabled = " + col.enabled);
          yield return new WaitForSeconds(1);
          col.enabled = false;
          //Debug.Log("Collider Enabled = " + col.enabled);
          yield return new WaitForSeconds(1);
       } 
    }
}
