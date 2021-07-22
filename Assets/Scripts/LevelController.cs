using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelController : MonoBehaviour
{
    int numOfAttackers = 0;
    bool levelTimerFinished = false;

    [SerializeField] GameObject levelCompleteText;
    [SerializeField] GameObject youLoseText;

    [SerializeField] AudioClip winSFX;
    [SerializeField] AudioClip loseSFX;
    [SerializeField] float waitToLoad = 5f;
    private AudioSource audioSource;



    private void Start()
    {
        levelCompleteText.SetActive(false);
        youLoseText.SetActive(false);

    }

    public void AttackersSpawned()
    {
        numOfAttackers++;
    }

    public void AttackersKilled()
    {
        numOfAttackers--;
        if (numOfAttackers <= 0 && levelTimerFinished) // when we dont specify the bool, it means "True". So "levelTimerFinished" here is equal to TRUE.
        {
            Debug.Log("End Level Now!");
            StartCoroutine(HandleWinCondition());

        }
    }

    private IEnumerator HandleWinCondition()
    {
        levelCompleteText.SetActive(true);
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(winSFX, 0.08f);
        yield return new WaitForSeconds(waitToLoad);
        SceneLoader sceneLoader = FindObjectOfType<SceneLoader>();
        sceneLoader.LoadNextScene();
        // Can also write this as "FindObjectOfType<SceneLoader>().LoadNextScene();
    }

    public void HandleLoseCondition()
    {
        youLoseText.SetActive(true);
        GetComponent<AudioSource>().PlayOneShot(loseSFX, 0.08f);
        Time.timeScale = 0; // Stops the game entirely
        //FindObjectOfType<SceneLoader>().LoadYouLoseScreen();
    }

    public void LevelTimerFinished()
    {
        levelTimerFinished = true;
        StopSpawners(); //Stops spawning enemies from each spawner using this method.
    }

    private void StopSpawners() // This method is to get all of the "spawner" gameObjects, and then call the "StopSpawning()" in them each one of them, to make each one of them stop spawning enemies.
    {
        Spawner[] spawners = FindObjectsOfType<Spawner>();
        foreach (Spawner spawner in spawners)
        {
            spawner.StopSpawning();
        }
    }




    //This is my way. EVERYTHING IS IN ONE SCRIPT. Rick's way is different, his way is simpler but uses different scripts.

    //Attacker[] attacker;
    // GameTimer gameTimer;


    /* void Update()
     {
         aliveEnemyTracker();
         timerListener();
         EndLevel();
     }

     private int aliveEnemyTracker()
     {
         attacker = FindObjectsOfType<Attacker>();
         int numOfAliveAttackers = attacker.Length;
         //Debug.Log("Attackers Alive= " + numOfAliveAttackers);
         return numOfAliveAttackers;   
     }

     private float timerListener()
     {
         gameTimer = FindObjectOfType<GameTimer>();
         float timeListener = gameTimer.GetComponent<Slider>().value;
         //Debug.Log("Time since start = " + timeListener);
         return timeListener;

     }

     private void EndLevel()
     {
         if (aliveEnemyTracker() == 0 && timerListener() == 1)
         {
             Debug.Log("End Level Now");

         }
     } */
}
