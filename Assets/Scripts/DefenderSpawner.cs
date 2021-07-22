using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    Defender defender;
    Currency currency;
    GameObject defenderParent;
    const string DEFENDER_PARENT_NAME = "Defenders"; /* We create this constant variable so that we spell the name of the gameObject we are trying to access once, here in this line, and then 
                                                  we dont have to write the string name anywhere else, instead we use the name of the variable (DEFENDER_PARENT) to access the string.
                                                  This prevents us from making spelling errors when writing down strings multiple times, in different places.*/


    private void Start()
    {
        CreateDefenderParent();
    }

    // This method is to keep our heirarchy clean and keep the instantiated defenders under the "defenderParent" as children.
    private void CreateDefenderParent()
    {
        defenderParent = GameObject.Find(DEFENDER_PARENT_NAME);
        if (!defenderParent) // Just in case the "defenderParent" gameObject is not in the scene (which it is not because we havent created one)
        {
            defenderParent = new GameObject(DEFENDER_PARENT_NAME); // This creates a new GameObject with the string name of "Defender", if there is no "Defender" gameObject available in the scene.
        }
    }

    private void OnMouseDown()
    {
        AttemptToPlaceDefenderAt(GetSquareClicked());

    }

    private void AttemptToPlaceDefenderAt(Vector2 gridPos) // REVIEW THIS AGAIN ***
    {
        currency = FindObjectOfType<Currency>();
        // defender = FindObjectOfType<Defender>(); // I dont need to "FindObjectOfType<Defender>()" because I already did this in the SetSelectedDefender(Defender selectedDefender). DONT GET IT, I'D JUST FIND IT AGAIN.
        var defenderCost = defender.GetCost();
        // if we have enough stars
            // spawn the defender
            // spend the stars
        if (currency.DoWeHaveEnoughStarsToSpend(defenderCost)) // if "DoWeHaveEnoughStarsToSpend(defenderCost)" is true. If we have more than or equal to the cost of the defenders then return true.
        {
            SpawnDefender(gridPos); // This way sucks and confusing. Easier if we wrap the "SpawnDefender(SnapToGrid(GetSquareClicked()));" with this if statement and the "SpendCurrency" there.
            currency.SpendCurrency(defenderCost);
        }
    }


    private Vector2 GetSquareClicked() // Gets the mouse position in world coordinates
    {
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos); 
        Vector2 gridPos = SnapToGrid(worldPos);
        return gridPos;
        /*Vector2 gridPos = SnapToGrid(worldPos);
        return gridPos; */    // ******  Rick's Way ***** Instead of my way which calls three methods in one line of code (line 14)
    }

    private Vector2 SnapToGrid(Vector2 rawWorldPos) // Round the mouse position FROM "GetSquareClicked()" value
    {
        //Debug.Log(rawWorldPos);
        int newPosX = Mathf.RoundToInt(rawWorldPos.x);
        int newPosY = Mathf.RoundToInt(rawWorldPos.y);
        return new Vector2(newPosX, newPosY);
        
    }

    private void SpawnDefender(Vector2 roundedWorldPos) // The "(Vector2 worldPos)" passed into the SpawnDefender method is called an Argumemt or Paramater.
    {
        Defender newDefender = Instantiate(defender, roundedWorldPos, Quaternion.identity) as Defender;
        newDefender.transform.parent = defenderParent.transform; // This means that the instantiatiated "newDefender" will be instantiated as a child to the "defenderParent"
        //Debug.Log(roundedWorldPos);
    }

    public void SetSelectedDefender(Defender selectedDefender) // This method is to get the selected defender form the "DefenderButtinScript" which has the defenders gameObject attached to the serializefields.
    {
        defender = selectedDefender; // Sets the defender variable in this script equal to the defender argument/parameter passed in the method, which we use in the DefenderButtonScript.
    }
}
