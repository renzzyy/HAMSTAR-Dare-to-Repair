using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinuousAudio : MonoBehaviour {
    
    // plays music throughout different levels
    // without any interruptions
    void Awake() {
        DontDestroyOnLoad(this.gameObject);
    }
}
