using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Defender : MonoBehaviour
{
    [SerializeField] int cost = 100;

    public int GetCost()
    {
        return cost;
    }

    public void AddCurrency(int amount) // This is for the **animation event** on the defender that spawns currency (the sunflower). To call this method from the animation event.
    {                                   // If in the future we forget that we added this method to an animation event or we want to find which animation event it is placed at, we can use "Ctrl+Shift+F" after highlighting it (using "Ctrl+F" would just show where it is on all of the scripts and not on Unity interface itself when the animation and animation events are. Then There is other options you need to choose to find where exactly this methid is used (either look at rick's - Udemy 2D lecture 150, or look it up)
        FindObjectOfType<Currency>().AddCurrency(amount);
    }

}
