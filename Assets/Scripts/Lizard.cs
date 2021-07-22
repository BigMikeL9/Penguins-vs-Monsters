using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lizard : MonoBehaviour
{
  
    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject otherObject = other.gameObject; // Unnecessary

        if (otherObject.GetComponent<Defender>()) // Are you a defender component
        {
            GetComponent<Attacker>().Attack(otherObject);

        }
    }
}
