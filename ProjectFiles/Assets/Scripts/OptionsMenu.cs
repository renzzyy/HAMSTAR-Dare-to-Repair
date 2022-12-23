using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer audioMix;

    // allows player to set the volume
    public void setVolume(float vol) 
    {
        audioMix.SetFloat("vol", vol);
        // Debug.Log(vol);
    }

    // allows player to set fullscreen mode
    public void setFullscreen(bool fullscreen) 
    {
        Screen.fullScreen = fullscreen;
        // Debug.Log(fullscreen);
    }

    public void setGraphicsQual(int qual) 
    {
        QualitySettings.SetQualityLevel(qual);
        Debug.Log(qual);
    }


}
