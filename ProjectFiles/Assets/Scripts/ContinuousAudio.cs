using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinuousAudio : MonoBehaviour {

    [SerializeField] private AudioSource music;
    
    // plays music throughout different levels
    // without any interruptions
    void Awake() 
    {
        DontDestroyOnLoad(music);
        SceneManager.sceneLoaded += OnSceneLoad;
    }

    void OnSceneLoad(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex == 0)
        {
            Destroy(music);
        } else {
            return;
        }
    }

}
