using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsContoller : MonoBehaviour
{
    // "const" is a value that is constant, it cannot change. "Variable" is a value that varies, or can be changed.
    // "const" values names are always capital.
    //These are MASTER KEYS
    private const string MASTER_VOLUME_KEY = "master volume";
    private const string MASTER_DIFFICULTY_KEY = "master difficulty";


    //tHESE ARE CONST BECASUE WE DONT WANT OUR PROGRAM OR ANYONE ELSE TO CHANGE THESE VALUES
    private const float MIN_VOLUME = 0f;
    private const float MAX_VOLUME = 1f;

    private static int MIN_DIFFICULTY = 0;
    private static int MAX_DIFFICULTY = 2;

    // "static" means it will be consistent through out the game, it will only be set once and it will be the same value in all of the places.
   public static void SetMasterVolume(float volume)
    {
        if (volume >= MIN_VOLUME && volume <= MAX_VOLUME)
        {
            Debug.Log("Volume is set to: " + volume);
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
        }
        else
        {
            Debug.LogError("Volume is out of range");
        }

    }

    public static void SetMasterDifficulty(float difficulty)
    {
        if (difficulty >= MIN_DIFFICULTY && difficulty <= MAX_DIFFICULTY)
        {
            Debug.Log("Difficulty is set to: " + difficulty);
            PlayerPrefs.SetFloat(MASTER_DIFFICULTY_KEY, difficulty);
        }
        else
        {
            Debug.LogError("Difficulty level is out of range");
        }
    }


    // This method "GETS" the volume instead of setting it
    public static float GetMasterVolume()
    {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
    }

    public static float GetMasterDifficulty()
    {
        return PlayerPrefs.GetFloat(MASTER_DIFFICULTY_KEY);
    }
}
