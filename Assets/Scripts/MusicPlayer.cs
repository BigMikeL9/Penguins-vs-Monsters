using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    AudioSource AudioSource;

    // To hear the music, we have to start the game from the splash screen because this is where the music player gameObject is.
    void Start() // This is when we start it (the musicplayer when the "splash screen" starts running)
    {
        DontDestroyOnLoad(this); // We want the same music to keep playing through out the game in everyscene, starting from the "Splash Screen" which is why we are adding "DontDestroyOnLoad(this);" which prevents that gameObject that this script/class is attached to, from getting destroyed when we load to another scene. "this" means THIS script/class.
        AudioSource = GetComponent<AudioSource>(); //We reference so that we know what "audioSource" is, which we are storing as a variable.
        AudioSource.volume = PlayerPrefsContoller.GetMasterVolume(); 
    }

    // This method is so that we can change the volume from other scenes or scripts/classes
    public void SetVolume(float volume)
    {
        AudioSource.volume = volume;
    }
}
