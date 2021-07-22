using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [Tooltip("Our level timer in SECONDS")] // When you hover over the serializefield in the inspector, a descirption/tooltip shows up.
    [SerializeField] float levelTimer = 60f;

    // This bool variable is to make sure that after we call the "FindObjectOfType<LevelController>().LevelTimerFinished();" we dont continue loop through any sort of functioanlity. Rick's exact words.
    // In other words, to stop the "FindObjectOfType<LevelController>().LevelTimerFinished();" from doing what is doing, after it does it once.
    // Because there will be a little bit of time between the timer being done, and loading to the next scene.
    bool triggeredLevelFinished = false;


    // Update is called once per frame
    void Update()
    {
        if (triggeredLevelFinished) { return; } // Means: If "triggeredLevelFinished" is equal to true, then return or dont do anything. Dont do the rest of the code below it.
        // Moves the slider to the left as time goes by. New syntax: "Time.realtimeSinceStartup".
        GetComponent<Slider>().value = Time.timeSinceLevelLoad / levelTimer; // Real life time / levelTimer

        // Specifies when timer has finished.
        bool timerFinish = (Time.timeSinceLevelLoad >= levelTimer);
        if (timerFinish)
        {
            FindObjectOfType<LevelController>().LevelTimerFinished();
            //Debug.Log("Level timer Expired");
            triggeredLevelFinished = true;

        }

    }
}
