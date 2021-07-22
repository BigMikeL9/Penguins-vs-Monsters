using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    [SerializeField] Slider difficultySlider;
    [SerializeField] float defaultVolume = 0.08f;
    [SerializeField] float defaultDifficulty = 0;


    // Start is called before the first frame update
    void Start()
    {
        // **IMPORTANT** Dont forget to GET the master keys in the start.
        volumeSlider.value = PlayerPrefsContoller.GetMasterVolume(); // This line is so that in the very beginning, we get what we saved in the past or what it should be.
        difficultySlider.value = PlayerPrefsContoller.GetMasterDifficulty();

    }

    // Update is called once per frame
    void Update()
    {
        var musicPlayer = FindObjectOfType<MusicPlayer>();
        if(musicPlayer) // If music player is there
        {
            musicPlayer.SetVolume(volumeSlider.value);
        }
        else
        {
            Debug.LogWarning("No music player found... did you start from splash screen?");
        }

    }

    public void SaveAndExit() // This method is for the "BACK" button. To save the volume level that we set in the options screen, and go back to the main menu.
    {
        PlayerPrefsContoller.SetMasterVolume(volumeSlider.value);
        PlayerPrefsContoller.SetMasterDifficulty(difficultySlider.value);
        FindObjectOfType<SceneLoader>().LoadMainMenu();
    }

    public void SetDefaults() // This method is for the :defaults" button.
    {
        volumeSlider.value = defaultVolume;
        difficultySlider.value = defaultDifficulty;
    }
}
