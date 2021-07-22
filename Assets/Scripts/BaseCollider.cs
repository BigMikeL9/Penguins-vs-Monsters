using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCollider : MonoBehaviour
{
    BaseHealth baseHealth;
    [SerializeField] int damageAmountToBase = 10;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Attacker attacker = other.gameObject.GetComponent<Attacker>();
        baseHealth = FindObjectOfType<BaseHealth>(); // ********REMEMBER TO ALWAYS INITIALIZE/REFERENCE OTHER SCRIPTS/GAMEOBJECTS. I ALWAYS FORGET THIS***

        if (attacker)
        {
            baseHealth.DealDamageToBase(damageAmountToBase);
            Debug.Log("Enemy reached Base");
        }

        Destroy(other.gameObject);

    }
}
