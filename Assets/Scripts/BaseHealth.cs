using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseHealth : MonoBehaviour
{
    [SerializeField] float currentBaseHealth = 5;
    Text baseHealthText;

    private void Start()
    {
        baseHealthText = GetComponent<Text>();
        SetBaseHealthDependingOnDifficulty();
        UpdateBaseHealth();
    }


    private void UpdateBaseHealth()
    {
        baseHealthText.text = currentBaseHealth.ToString();
    }

    private void SetBaseHealthDependingOnDifficulty()
    {
        if (PlayerPrefsContoller.GetMasterDifficulty() == 0)
        {
            currentBaseHealth = 5;
        }
        else if (PlayerPrefsContoller.GetMasterDifficulty() == 1)
        {
            currentBaseHealth = 3;
        }
        else if (PlayerPrefsContoller.GetMasterDifficulty() == 2)
        {
            currentBaseHealth = 1;
        }
    }

    public void DealDamageToBase(int damageAmount)
    {
        if (currentBaseHealth >= 0)
        {
            currentBaseHealth -= damageAmount;
            UpdateBaseHealth();
        }

        if (currentBaseHealth <= 0)
        {
            //SceneLoader sceneloader = FindObjectOfType<SceneLoader>(); // "FindObjectOfType<SceneLoader>()" can find scripts on our scene that are not attached to a gameObject. So it can find anything GameObjects that have a particular script, or just the script on its own.
            //sceneloader.LoadYouLoseScreen();
            FindObjectOfType<LevelController>().HandleLoseCondition();

        }

    }
}
