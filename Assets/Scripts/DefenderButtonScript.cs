using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DefenderButtonScript : MonoBehaviour
{
    [SerializeField] Defender defenderPrefab;
    

    private void Start()
    {
        LabelButtonWithCost();
    }

    private void LabelButtonWithCost()
    {
        var costText = GetComponentInChildren<TextMeshProUGUI>();
        if (!costText)
        {
            Debug.LogError(name + "has no cost text, add some!");
        }

        // I dont have to use"GetComponent<Defender>()" here because the defenderPrefab (which has the Defender script/class) is serializfield in this script, AKA already connected.
        costText.text = defenderPrefab.GetCost().ToString();
    }

    public void OnMouseDown()  // ** To fix the issue where the defenders can be placed on top of each other, just add a collider to each defender and move th "core game area" box collider back on the z-axis, to avoid any bugs
    {
        var buttons = FindObjectsOfType<DefenderButtonScript>();
        foreach (DefenderButtonScript button in buttons) // keeps the defender buttons greyed back and returns them to the grey color after we click on another defender button.
        {
            button.GetComponent<SpriteRenderer>().color = new Color32(123, 123, 123, 255);
        }

        var defenderColor =  GetComponent<SpriteRenderer>();
        defenderColor.color = Color.white;
        FindObjectOfType<DefenderSpawner>().SetSelectedDefender(defenderPrefab); // This sends what defender we chose back to the "DefenderSpawner" script/class. Inorder to tell it what to spawn (depending on what we selected form this script).
    }

}
