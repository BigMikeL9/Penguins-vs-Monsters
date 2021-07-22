using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Currency : MonoBehaviour   // CAN REUSE THIS SCRIPT FOR OTHER GAMES ASWELL (CURRENCY/SCORE)
{
    [SerializeField] int currentCurrency = 100;
    Text currencyText;
    

    void Start()
    {
        currencyText = GetComponent<Text>();
        UpdateCurrency();

    }

    public int GetCurrentCurrency()
    {
        return currentCurrency;
    }

    private void UpdateCurrency()
    {
        currencyText.text = currentCurrency.ToString();

    }

    public bool DoWeHaveEnoughStarsToSpend(int amount) // REVISE THIS AGAIN***
    {
        return currentCurrency >= amount; // This means that if "currentCurrency" is greater than or equal to (the argument/paramter) "amount", then return true.
    }


    public void AddCurrency(int amount)
    {
        currentCurrency += amount;
        UpdateCurrency();

    }

    public void SpendCurrency(int amount)
    {
        if (currentCurrency >= amount)
        {
            currentCurrency -= amount;
            UpdateCurrency();
        }

    }
}
